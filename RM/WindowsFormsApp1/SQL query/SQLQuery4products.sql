create table products
(
pID int primary key identity,
pName varchar(50),
pPrice float,
CategoryID int,
pImage image

)

--select pID,pName,pPrice,CategoryID,c.catName from products p inner join category on c.catID = p.CategoryID

select * from products

SELECT p.pID, p.pName, p.pPrice, p.CategoryID, c.catName 
FROM products p 
INNER JOIN category c ON c.catID = p.CategoryID;