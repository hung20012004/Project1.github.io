Create database project1;
use project1;
Create table carmodel(
id int primary key auto_increment,
name varchar(50));
Create table carsaloon(
id int primary key auto_increment,
name varchar(50),
model_id int,
foreign key (model_id) references carmodel(id));
Create table car(
id int primary key auto_increment,
name varchar(50) unique,
saloon_id int,
engine varchar(100),
colors varchar(200),
uphostery varchar(200),
cylinder int,
displacement double,
length double,
width double,
height double,
weight double,
max_speed int,
seat_num int,
door_num int,
price bigint,
quantity_in_stock int,
foreign key (saloon_id) references carsaloon(id),
state int );
Create table showroom(
id int primary key auto_increment,
name varchar(50),
address varchar(200),
hotline varchar(50));
Create table accountant(
id int primary key auto_increment,
name varchar(50),
username varchar(50),
password varchar(50),
phone varchar(50),
department varchar(50),
showroom_id int,
foreign key (showroom_id) references showroom(id));
Create table order_list(
id int primary key auto_increment,
customer_id int,
foreign key (customer_id) references accountant(id),
car_id int,
foreign key (car_id) references car(id),
request_time datetime,
processed_request_time datetime,
create_order_time datetime,
get_car_time datetime,
note varchar(50),
bill bigint,
sales_id int,
foreign key (sales_id) references accountant(id),
showroom_id int,
foreign key (showroom_id) references showroom(id),
state int );


