use project1;
create view search_car
as
	select c.id,c.name,c.engine,c.colors,c.uphostery,c.cylinder,c.displacement,c.length,c.width,c.height,c.weight,c.max_speed,c.seat_num,c.door_num,c.price,carsaloon.name as saloon,carmodel.name as model,carsaloon.id as saloon_id,carmodel.id as model_id,c.quantity_in_stock
    from carmodel 
    inner join carsaloon
    on carmodel.id=carsaloon.model_id
    inner join car as c
    on carsaloon.id= c.saloon_id
    where c.state=1;
    
create view all_order
as
	select ord.id,ord.customer_id,ord.sales_id,acc.name as customer,ac.name as sales,acc.phone,ord.request_time,ord.processed_request_time,ord.create_order_time,ord.get_car_time,ord.note,c.id as car_id,c.name as car,ord.state,ord.showroom_id,ord.bill,sr.name,sr.address,ac2.name as manager_name
    from order_list as ord
    inner join car as c
    on c.id=ord.car_id
    inner join accountant as acc
    on ord.customer_id=acc.id
    inner join showroom as sr
    on ord.showroom_id=sr.id
    inner join accountant as ac2
    on ac2.showroom_id=sr.id
    inner join accountant as ac
    on ord.sales_id=ac.id
    where ac2.department="Manager";
    
	