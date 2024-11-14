create or alter procedure orderdetailsForBilling
(
@MainId int
)
as
begin
select p.pName [ProductName], qty,price,amount,tm.MainID,tables.tname as TableName,
staff.sName as WaiterName ,orderType,status,total,tm.aDate, tm.Time,Change,Received
from tblMain tm
	join tblDetails tdb
		on tm.MainID = tdb.MainID and tm.MainID=@mainID
	join products p
		on p.pID = tdb.proId
		join tables on tables.tid=tm.tableid
                          join staff on  staff.staffID=tm.Waiterid


end

exec orderdetailsForBilling @mainID=10
