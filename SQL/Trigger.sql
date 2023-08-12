DELIMITER $$

create trigger before_car_insert
before insert on car
for each row
begin
set 
	new.state = 1;
end$$

DELIMITER ;

DELIMITER $$

create trigger before_account_insert
before insert on accountant
for each row
begin
set 
	new.state = 1;
end$$

DELIMITER ;

DELIMITER $$

create trigger before_order_insert
before insert on order_list
for each row
begin
set 
	new.state = 1,
    new.request_time=now() ;
end$$

DELIMITER ;


