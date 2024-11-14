select * from users


create table users(
userID int primary key identity,
username varchar(50) not null,
upass varchar(10)not null,
uName varchar(50) not null,
uphone varchar(20)
)