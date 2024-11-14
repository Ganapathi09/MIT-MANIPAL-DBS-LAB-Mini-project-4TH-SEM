﻿create table tblMain
(
MainID int Primary key identity,
aDate date,
Time varchar(15),
TableName varchar(10),
WaiterName varchar(15),
status varchar(15),
orderType varchar(15),
total float,
received float,
change float,
)



create table tblDetails
(
DetailID int  Primary key identity,
MainID int,
proID int,
qty int,
price float,
amount float,
)

truncate table tblDetails;
truncate table tblMain;

select * from tblMain m
inner join tblDetails d on m.MainID=d.MainID;
