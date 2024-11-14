select * from tblMain

sele

select p.pName [ProductName], qty,price,amount,tm.MainID
from tblMain tm
	join tblDetails tdb
		on tm.MainID = tdb.MainID
	join products p
		on p.pID = tdb.proId and tm.MainID =10

