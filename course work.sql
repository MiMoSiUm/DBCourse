insert into workshops (workshop_name) values ('bruh customs');
insert into workshops (workshop_name) values ('yoink workshop');

insert into brigades (brigade_name) values ('THE brigade');

insert into personnel values (1, 123456789012, 1);

insert into failures values ('failure1', 1000);

insert into cars values ('12345', '67890', 'owner1', 'ABCDE');

insert into spare_parts values (1, 1, 'part1', 1000, 50);

insert into car_repair values (1, 1, current_date, current_date + '1 days'::interval, 1);

select * from personnel;