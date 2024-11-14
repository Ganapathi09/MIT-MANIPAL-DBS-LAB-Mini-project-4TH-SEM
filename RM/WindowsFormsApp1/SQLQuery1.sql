select  * from tblMain 
select * from tables
select * from staff
select * from tblDetails
select * from products

alter table tblmain
add  tableid int 

update tblmain 
set tableid=tid 
from tables
where tables.tname= tblMain.TableName


alter table tblmain
add constraint fk_tableMain_table foreign key(tableid) references tables(tid)



-------------------------------------------------------------------------------------------------------------

alter table tblmain
add  waiterid int 

update tblmain 
set waiterid=staffID
from staff
where staff.sname= tblMain.WaiterName


alter table tblmain
add constraint fk_tableMain_staff foreign key(waiterid) references staff(staffid)


------------------------------------------------
alter table tblmain 
drop column tableName

alter table tblmain 
drop column waitername
------------------------------------------------------------------------------

alter table tblDetails
add constraint fk_tableDetails_tableMain foreign key(Mainid) references tblMain(Mainid)

alter table tblDetails
add constraint fk_tableDetails_products foreign key(proid) references products(pid)
----------------------------------------------------------------------------------------

alter table products
add constraint fk_products_category foreign key(CategoryID) references category(catid)









-----------------------------------------------------------------

