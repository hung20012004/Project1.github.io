use project1;
insert into carmodel(id,name)
value (100001,"Sedans");

insert into carmodel(name)
value ("SUVs"),("Coupés"),("Vans/MPVs");

insert into carsaloon(id,name,model_id)
value (100001,"EQS Sedan",100001);

insert into carsaloon(name,model_id)
value ("A-Class Sedan",100001),
("C-Class Sedan",100001),
("E-Class Sedan",100001),
("S-Class Sedan",100001),
("Mercedes-Maybach S-Class Sedan",100001),
("GLA",100002),
("GLB",100002),
("GLC",100002),
("GLC Coupé",100002),
("GLE",100002),
("GLE Coupé",100002),
("GLS",100002),
("G-Class SUV",100002),
("Mercedes-Maybach GLS",100002),
("Mercedes-AMG GT Coupé",100003),
("V-Class",100004);

insert into car(id,name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price)
value (100001,"EQS 580 4MATIC",100001,"385kW-Electric-Automatic","Nautic Blue/Onyx Black","Leather-Black",0,0,5.216,1.954,1.512,2.620,210,5,4,5959000000);

insert into car(name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price)
value ("C 200 Avantgarde",100003,"150kW-Petrol-Automatic","Obsidian Black/ Cavansite Blue","ARTICO Leather-Brown/Artico Leather - Black",4,1.496,4.751,1.820,1.437,1.650,246,5,4,1669000000),
( "C 200 Avantgarde Plus",100003,"150kW-Petrol-Automatic"," Obsidian Black","Artico Leather - Black /ARTICO Leather-Brown",4,1.496,4.751,1.820,1.437,1.650,246,5,4,1789000000),
( "C 200 Avantgarde(V1) ",100003,"150kW-Petrol-Automatic"," Cavansite Blue / Graphite Grey / Obsidian Black","Artico Leather - Black/ ARTICO Leather-Brown ",4,1.496,4.751,1.820,1.437,1.650,246,5,4,1709000000),
("C 200 Avantgarde Plus (V1)",100003,"150kW-Petrol-Automatic","Obsidian Black / Cavansite Blue/Polar White ","Artico Leather - Black/ARTICO Leather-Brown",4,1.496,4.751,1.820,1.437,1.650,246,5,4,1914000000),
("C 300 AMG 206046",100003,"190kW-Petrol-Automatic","Graphite Grey / Obsidian Black","Leatherette ARTICO Black / ARTICO Man-Made Leather, Two-Tone - Sienna Brown/Black /  ",4,1.999,4.751,1.820,1.438,2.280,250,5,4,2089000000),
("C 300 AMG (V1)",100003,"190kW-Petrol-Automatic","Obsidian Black / Cavansite Blue / Graphite Grey / Polar White  "," Two-Tone - Sienna Brown/Black / Leatherette ARTICO Black/ ARTICO Man-Made Leather, Two-Tone - Sienna Brown / Black ",4,1.999,4.793,1.820,1.446,2.280,250,5,4,2199000000),
("C 300 AMG CBU ",100003,"190kW-Petrol-Automatic","Obsidian Black / Polar White  "," Two-Tone - Sienna Brown/Black /Leather - Power Red ",4,1.999,4.793,1.820,1.446,2.280,250,5,4,2399000000),
("Mercedes-Benz-AMG C 43 4MATIC ",100003,"300kW-Petrol-Automatic"," Polar White / "," Leather - Power Red /Leather Black/Black/ Leather Sienna Brown/Black ",4,1.999,4.793,1.820,1.446,2.280,250,5,4,2960000000);
insert into car(name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price)
value( "New E 180 (V1)",100004,"115kW-Petrol-Automatic"," Obsidian Black  / Polar White /Obsidian Black  ","ARTICO Leather-Brown/Artico Leather - Nut Brown/Black Artico Leather",0,1.497,4.930,1.870,1.460,2.295,223,5,4,2159000000),
( "New E200 Exclusive",100004,"145kW-Petrol-Automatic"," Obsidian Black/Polar White  ","Nut Brown Artico Leather / Black Artico Leather",0,1.991,4.930,1.852,1.468,2.315,240,5,4,2310000000),
( "New E200 Exclusive(V1)",100004,"145kW-Petrol-Automatic"," Polar White /Hyacinth Red ","Nut Brown Artico Leather / Black Artico Leather / Black Artico Leather",0,1.991,4.930,1.852,1.468,2.315,240,5,4,2540000000),
( "New E 300 AMG (V1)",100004,"190kW-Petrol-Automatic"," Polar White /Hyacinth Red ","Nappa Leather - Saddle Brown/Nappa Leather - Black",0,1.991,4.930,1.852,1.468,2.315,240,5,4,3209000000);
insert into car(name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price)
value( "S 450 4MATIC ",100005,"270kW-Petrol-Automatic"," Onyx Black /obsidian black metallic ","Nappa Leather - Black/Nappa Leather Macchiato Beige/Magma Grey / Nappa Leather - Black ",6,2.999,5.289,1.954,1.503,2.025,250,5,4,5039000000),
( "S 450 4MATIC Luxury ",100005,"270kW-Petrol-Automatic"," Emerald Green / obsidian black metallic / Onyx Black /obsidian black metallic","Brown / Exclusive Nappa Leather - Black/ Exclusive Nappa Leather - Black ",6,2.999,5.289,1.954,1.503,2.025,250,5,4,5559000000);
insert into car(name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price)
value( "Mercedes-Maybach S 450 4MATIC",100006,"270kW-Petrol-Automatic"," Emerald Green "," Exclusive Nappa Leather - Nut Brown",0,2.999,5.469,1.965,1.510,0,250,4,4,8199000000),
( "Mercedes-Maybach S 680 4MATIC",100006,"450kW-Petrol-Automatic"," Obsidian Black "," Exclusive Nappa Leather - Nut Brown /Exclusive Nappa Leather - Porcelain",0,5.980,5.469,1.921,1.510,2.890,250,4,4,15990000000);

insert into car(name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price)
value("Mercedes-AMG GLA 45 S 4MATIC+",100007,"310kW-Petrol-Automatic"," Obsidian Black   "," ARTICO leather / DINAMICA microfiber sports design in black ",4,1.991,4.436,1.849,1.585,0,265,5,4,243000000);

insert into car(name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price)
value( "GLB 200 AMG (V1)",100008,"120kW-Petrol-Automatic"," Denim Blue / Polar White / Galaxy Blue / Cosmos Black "," Artico Leather - Two Tone Nava Grey/Black  / Artico Leather/DINAMICA - Black ",0,1.332,4.634,2.020,1.659,0,207,7,5,2089000000),
( "Mercedes-AMG GLB 35 4MATIC (V1)",100008,"225kW-Petrol-Automatic","Mountain Grey /Polar White /Galaxy Blue /Cosmos Black / Patagonia red - metallic d / Denim Blue "," Artico Leather/DINAMICA - Black ",4,1.991,4.650,1.845,1.660,1800,250,5,4,2849000000);

insert into car(name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price)
value( "GLC 200 (V1)",100009,"145kW-Petrol-Automatic"," Polar White / Graphite Grey / Cavansite Blue / Hyacinth Red / Obsidian Black  "," Artico Leather - Black / Artico Leather - Silk Beige  ",0,1.991,4.670,1.900,1.650,2.330,217,5,5,1909000000),
( "GLC 200 4MATIC (V1) ",100009,"145kW-Petrol-Automatic"," Polar White / Cavansite Blue / Obsidian Black "," Artico Leather - Black",0,1.991,4.670,1.900,1.5650,2.370,215,5,5,2189000000),
( "GLC 200 4MATIC (X254) ",100009,"145kW-Petrol-Automatic"," Polar White / Cavansite Blue / Obsidian Black "," Artico Leather - Black / ARTICO Leather-Brown ",0,1.999,4.670,1.900,1.650,2.370,215,5,5,2299000000),
( "GLC 300 4MATIC (X254) ",100009,"145kW-Petrol-Automatic"," Graphite Grey / Obsidian Black / Hyacinth Red / Polar White "," Leather Sienna Brown/Black / Leather Black/Black  ",0,1.999,4.670,1.900,1.650,2.400,240,5,5,2799000000),
( "GLC 300 4MATIC (V1) ",100009,"190kW-Petrol-Automatic"," Polar White / Hyacinth Red / Obsidian Black "," Artico Leather - Black / ARTICO Leather-Brown ",0,1.991,4.670,1.900,1.650,2.400,240,5,5,2639000000);

insert into car(name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price)
value( "GLC 300 4MATIC Coupé (X253) ",100010,"190kW-Petrol-Automatic"," Graphite Grey / Obsidian Black / Hyacinth Red / Polar White "," Leather Sienna Brown/Black / Leather Black/Black / Leather Red Cranberry ",0,0,4.750,1.900,1.600,1.800,240,5,5,2799000000);

insert into car(name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price)
value( "GLE 450 4MATIC (V1) ",100011,"270kW-Petrol-Automatic"," Polar White / Obsidian Black/ Cavansite Blue  ","Leather - Black / Macchiato Beige  ",0,2.999,4.924,1.947,1.772,3.000,250,5,5,4559000000);

insert into car(name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price)
value( "GLE 450 4MATIC Coupé ",100012,"270kW-Pettrol-Automatic"," Polar White / Obsidian Black / Cavansite Blue  / Silver iridium / Silver Mojave / Briliant Blue / Emarald Blue / Selenite gGey   ","Leather - Black / Macchiato Beige  ",0,2.999,4.924,1.947,1.772,2220,250,5,5,4619000000),
( "Mercedes GLE 53 4Matic + Coupé ",100012,"320kW-Petrol-Automatic"," Obsidian Black /Selenite Grey  ","NAPPA LEATHER - TRUFFLE BROWN /  NAPPA LEATHER - BLACK /NAPPA LEATHER - RED PEPPER ",0,2.999,4.961,2.018,1.720,3.050,250,5,5,5679000000);

insert into car(name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price)
value( "GLS 450 4MATIC (V1)",100013,"270kW-Petrol-Automatic"," Polar White / Obsidian Black /Emerald Green  "," Leather - Black / Leather - Macchiato Beige ",0,2.999,5.226,2.030,1.845,3.340,246,7,5,5249000000),
( "GLS 450 4MATIC ",100013,"270kW-Petrol-Automatic"," Obsidian Black / Emerald Green   "," Leather - Macchiato Beige / Espresso Brown ",0,2.999,5.226,2.030,1.845,3.340,246,7,5,5309000000);

insert into car(name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price)
value( "Mercedes-Maybach GLS 480 4MATIC ",100015,"270-Electric-Automatic"," Polar White /Emerald Green / Obsidian Black "," NAPPA LEATHER - BLACK /NAPPA LEATHER - MAHOGANY BROWN   ",6,0,5.205,2.030,1.838,0,240,5,5,8679000000),
( "GLS600 4MATIC Maybach",100015,"410kW-Petrol-Automatic"," Obsidian Black  "," NAPPA LEATHER - MAHOGANY BROWN",0,3.982,5.205,2.030,1.838,3.250,250,5,5,11999000000);


insert into car(name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price)
value("Mercedes-AMG GT 53 4MATIC+ (Facelift)  ",100016,"300kW-Petrol-Automatic"," Obsidian Black / Cavansite Blue / Polar White  "," Leather - Power Red /Leather Black/Black / Leather Sienna Brown/Black ",4,2.999,5.051,1.953,1.451,2.515,250,5,5,6719000000);
 
insert into car(name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price)
value( "V250 " , 100017,"155kW-Petrol-Automatic"," Rock Crystal White/ Rock Crystal White/ Brilliant Silver "," Lugano Leather Black/ Lugano Leather Black ",0,1.991,5.370,1.928,1.909,3.430,210,6,5,3669000000);

insert into car(name,saloon_id,engine,colors,uphostery,cylinder,displacement,length,width,height,weight,max_speed,seat_num,door_num,price)
value("Mercedes-AMG GT 4-door Coupé ",100016,"432kW-Petrol-Automatic"," Polar White / Jubiter Red / Black Obsidian /Blue Brilliant "," Leather - Power Red /Leather Black/Black/ Leather Sienna Brown/Black ",4,1.999,5.051,1.953,1.451,2.280,250,5,4,6719000000);

UPDATE `project1`.`car` SET `quantity_in_stock` = '2' WHERE (`id` = '100001');
UPDATE `project1`.`car` SET `quantity_in_stock` = '6' WHERE (`id` = '100002');
UPDATE `project1`.`car` SET `quantity_in_stock` = '3' WHERE (`id` = '100003');
UPDATE `project1`.`car` SET `quantity_in_stock` = '2' WHERE (`id` = '100004');
UPDATE `project1`.`car` SET `quantity_in_stock` = '4' WHERE (`id` = '100005');
UPDATE `project1`.`car` SET `quantity_in_stock` = '5' WHERE (`id` = '100006');
UPDATE `project1`.`car` SET `quantity_in_stock` = '5' WHERE (`id` = '100010');
UPDATE `project1`.`car` SET `quantity_in_stock` = '1' WHERE (`id` = '100014');
UPDATE `project1`.`car` SET `quantity_in_stock` = '2' WHERE (`id` = '100015');
UPDATE `project1`.`car` SET `quantity_in_stock` = '5' WHERE (`id` = '100019');
UPDATE `project1`.`car` SET `quantity_in_stock` = '4' WHERE (`id` = '100020');
UPDATE `project1`.`car` SET `quantity_in_stock` = '2' WHERE (`id` = '100027');
UPDATE `project1`.`car` SET `quantity_in_stock` = '2' WHERE (`id` = '100028');
UPDATE `project1`.`car` SET `quantity_in_stock` = '1' WHERE (`id` = '100029');
UPDATE `project1`.`car` SET `quantity_in_stock` = '1' WHERE (`id` = '100032');
UPDATE `project1`.`car` SET `quantity_in_stock` = '1' WHERE (`id` = '100033');
UPDATE `project1`.`car` SET `quantity_in_stock` = '1' WHERE (`id` = '100034');
UPDATE `project1`.`car` SET `quantity_in_stock` = '2' WHERE (`id` = '100036');
INSERT INTO `project1`.`car` (`quantity_in_stock`) VALUES ('4');
UPDATE `project1`.`car` SET `quantity_in_stock` = '3' WHERE (`id` = '100023');
UPDATE `project1`.`car` SET `quantity_in_stock` = '2' WHERE (`id` = '100009');
UPDATE `project1`.`car` SET `quantity_in_stock` = '0' WHERE (`id` = '100017');
UPDATE `project1`.`car` SET `quantity_in_stock` = '8' WHERE (`id` = '100025');
UPDATE `project1`.`car` SET `quantity_in_stock` = '0' WHERE (`id` = '100007');
UPDATE `project1`.`car` SET `quantity_in_stock` = '2' WHERE (`id` = '100008');
UPDATE `project1`.`car` SET `quantity_in_stock` = '0' WHERE (`id` = '100011');
UPDATE `project1`.`car` SET `quantity_in_stock` = '6' WHERE (`id` = '100012');
UPDATE `project1`.`car` SET `quantity_in_stock` = '2' WHERE (`id` = '100013');
UPDATE `project1`.`car` SET `quantity_in_stock` = '0' WHERE (`id` = '100016');
UPDATE `project1`.`car` SET `quantity_in_stock` = '6' WHERE (`id` = '100018');
UPDATE `project1`.`car` SET `quantity_in_stock` = '10' WHERE (`id` = '100021');
UPDATE `project1`.`car` SET `quantity_in_stock` = '2' WHERE (`id` = '100022');