use project1;
DELIMITER //
CREATE PROCEDURE  check_account(rq_username varchar(50),rq_password varchar(50))
BEGIN
	select *
    from accountant 
    where username=rq_username and password=rq_password;
END //
DELIMITER ;

-- ---------------------------------------------------------------------------------------
DELIMITER //
CREATE PROCEDURE  get_cars(rq_model_id int, rq_saloon_id int ,rq_fist_price bigint, rq_last_price bigint)
begin
	if (rq_model_id=0) and (rq_saloon_id=0) then
		select *
		from search_car
		where price>=rq_fist_price and price<=rq_last_price;
    elseif (rq_saloon_id=0) and (rq_model_id!=0) then
		select *
		from search_car
		where model_id=rq_model_id and price>=rq_fist_price and price<=rq_last_price;
	elseif (rq_saloon_id!=0) and (rq_model_id!=0) then
		select *
		from search_car
		where model_id=rq_model_id and saloon_id=rq_saloon_id and price>=rq_fist_price and price<=rq_last_price;
	else 
		select *
		from search_car
		where saloon_id=rq_saloon_id and price>=rq_fist_price and price<=rq_last_price;
	end if;
end//
DELIMITER ;
call get_cars(100001,0,0,19999999999);
DELIMITER //
CREATE PROCEDURE  delete_cars(rq_car_id int)
BEGIN
	update car
    set state=0
    where id=rq_car_id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE  create_car(rq_name varchar(50),rq_saloon_id int,rq_engine varchar(100) ,rq_colors varchar(100) ,rq_uphostery varchar(100) ,rq_cylinder int ,rq_displacement double ,rq_length double ,rq_width double ,rq_height double ,rq_weight double ,rq_max_speed int ,rq_seat_num int ,rq_door_num int ,rq_price bigint,rq_quantity int)
BEGIN
	insert into car(name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price,quantity_in_stock)
    value (rq_name,rq_saloon_id,rq_engine,rq_colors,rq_uphostery,rq_cylinder,rq_displacement,rq_length,rq_width,rq_height,rq_weight,rq_max_speed,rq_seat_num,rq_door_num,rq_price,rq_quantity);
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE  update_car(rq_car_id int,rq_engine varchar(100) ,rq_colors varchar(100) ,rq_uphostery varchar(100) ,rq_cylinder int ,rq_displacement double ,rq_length double ,rq_width double ,rq_height double ,rq_weight double ,rq_max_speed int ,rq_seat_num int ,rq_door_num int ,rq_price bigint,rq_quantity int)
BEGIN
	update car
    set engine=rq_engine,
		colors=rq_colors,
        uphostery=rq_uphostery,
        cylinder=rq_cylinder,
        displacement=rq_displacement,
        length=rq_length,
        width=rq_width,
        height=rq_height,
        weight=rq_weight,
        max_speed=rq_max_speed,
        price=rq_price,
        quantity_in_stock=rq_quantity
    where id=rq_car_id;
	
END //
DELIMITER ;
call update_car(100001,	"380kW-Electric-Automatic","Nautic Blue/Onyx Black","Leather-Black",0,0,5.216,1.954,1.512,2.62,210,5,4,5959000000);

-- ---------------------------------------------------------------------------------------
DELIMITER //
CREATE PROCEDURE  get_showroom()
BEGIN
	select *
    from showroom
    where id!=1;
END //
DELIMITER ;
-- ---------------------------------------------------------------------------------------
DELIMITER //
CREATE PROCEDURE  get_request(rq_showroom_id int)
BEGIN
	select *
    from all_order
    where showroom_id=rq_showroom_id and state=1;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE  get_processing_request(rq_sales_id int)
BEGIN
	select *
    from all_order
    where sales_id=rq_sales_id and state=2;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE  create_request( rq_customer_id int,rq_note varchar(50) ,rq_showroom_id int,rq_car_id int)
BEGIN
	insert into order_list(customer_id,note ,showroom_id,car_id,sales_id)
    value(rq_customer_id,rq_note ,rq_showroom_id,rq_car_id,1);
END //
DELIMITER ;
call create_request(10004,null,100001,100002);

DELIMITER //
CREATE PROCEDURE  request_process(rq_sales_id int,rq_order_id int)
BEGIN
    update order_list
    set state=2 , sales_id=rq_sales_id
    where (id=rq_order_id);
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE  already_get_car(rq_order_id int,rq_car_id int)
BEGIN
    update order_list
    set state=5 , get_car_time=now()
    where (id=rq_order_id);
    
    update car
    set quantity_in_stock=-1
    where id=rq_car_id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE  request_process_result(rq_sales_id int,rq_order_id int,result int)
BEGIN
	if(result=1) then
		update order_list
		set state=3 , processed_request_time=now()
		where id=rq_order_id and sales_id=rq_sales_id;
	else 
		update order_list
		set state=1 , sales_id=1
		where id=rq_order_id and sales_id=rq_sales_id;
	end if;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE  check_request_quantity(rq_sales_id int)
BEGIN
    select count(*) as quantity
    from order_list
    where sales_id=rq_sales_id and state=2 ;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE  processed_request(rq_sales_id int)
BEGIN
    select *
    from all_order
    where sales_id=rq_sales_id and state=3 ;
END //
DELIMITER ;
call processed_request(10003);

DELIMITER //
CREATE PROCEDURE  get_waiting_order(rq_showroom_id int)
BEGIN
    select *
    from all_order
    where showroom_id=rq_showroom_id and state=3 ;
END //
DELIMITER ;
call get_waiting_order(100001);

DELIMITER //
CREATE PROCEDURE  get_customer_order(rq_customer_id int)
BEGIN
    select *
    from all_order
    where customer_id=rq_customer_id and state!=0 ;
END //
DELIMITER ;
call get_customer_order(10004);
DELIMITER //
CREATE PROCEDURE  create_order(rq_order_id int,total_bill bigint)
BEGIN
    update order_list
    set state=4,bill=total_bill,create_order_time=now()
    where id=rq_order_id;
END //
DELIMITER ;
-- ---------------------------------------------------------------------------------------
DELIMITER //
CREATE PROCEDURE  get_model()
BEGIN
	select *
    from carmodel;
END //
DELIMITER ;
-- ---------------------------------------------------------------------------------------
DELIMITER //
CREATE PROCEDURE  get_saloon(rq_model_id int)
BEGIN
	if(rq_model_id=0) then
		select *
		from carsaloon;
	else
		select *
		from carsaloon
		where model_id=rq_model_id;
	end if;
END //
DELIMITER ;