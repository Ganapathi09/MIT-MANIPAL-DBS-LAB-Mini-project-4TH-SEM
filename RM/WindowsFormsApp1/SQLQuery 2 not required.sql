/*no need*/
-----------------------------------------------
SELECT MainID,tables.tname as TableName,staff.sName as WaiterName ,orderType,status,total
from tblMain 
join tables on tables.tid=tblMain.tableid
join staff on  staff.staffID=tblMain.Waiterid
                          where status <> 'Pending'
						  ------------------------------

Insert into tblMain(aDate,Time,tableid,waiterid,status,orderType,total,received,change) Values(@aDate,@aTime,(select top 1 tid from tables where tname=@TableName),(select top 1 staffID from staff where sname=@WaiterName),@status,@orderType,@total,@received,@change);
                    Select SCOPE_IDENTITY()

					---------------------------

Select tables.tname as TableName,staff.sName as WaiterName,Time,orderType from tblMain 
join tables on tables.tid=tblMain.tableid
join staff on  staff.staffID=tblMain.Waiterid

where status='Pending'

-----------------------------------------------------------------------------------------------------------
Select orderType,tables.tname as TableName,staff.sName as WaiterName,DetailID,pName as proName,proID,qty,price,amount from tblMain m
        inner join tblDetails d on m.MainID=d.MainID
        inner join products p on p.pID=d.proID
		join tables on tables.tid=m.tableid
		join staff on  staff.staffID=m.Waiterid
                             where m.MainID=" + id + "


							 select * from products
