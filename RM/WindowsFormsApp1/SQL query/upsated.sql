select * from products

alter table products 
add Active bit default 1

update products 
set Active =1



select * from category


alter table category 
add Active bit default 1

update category
set Active =1

select * from tables

select * from tblMain



Select tables.tname as TableName,staff.sName as WaiterName,Time,orderType from tblMain 
                join tables on tables.tid=tblMain.tableid
                join staff on  staff.staffID=tblMain.Waiterid
                where status='Pending'

				Select * from tblMain m
                            inner join tblDetails d on m.MainID=d.MainID
                            inner join products p on p.pID=d.proID