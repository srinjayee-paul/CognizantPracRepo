create database OnlineRetailStore;
use OnlineRetailStore;

create table Products(
    ProductID int primary key,
    ProductName varchar(100),
    Category varchar(50),
    Price decimal(10,2)
);

insert Products (ProductID, ProductName, Category, Price) values
(101,'HP Laptop','Electronics',85000.00),
(124,'Classmate Notebook','Stationery',120.00),
(206,'Mayonnaise','Grocery',150.00),
(114,'Boat Speakers','Electronics',3500.00),
(280,'Dove Shampoo','Cosmetics',210.00),
(138,'Sharpner','Stationery',20.00),
(213,'Chilli Flakes','Grocery',80.00),
(266,'Toothpaste','Cosmetics',50.00),
(105,'Apple Laptop','Electronics',120000.00),
(211,'Ketchup','Grocery',60.00),
(136,'Eraser','Stationery',10.00),
(250,'Rajma','Grocery',140.00),
(263,'Masoor Dal','Grocery',90.00),
(284,'Pears Soap','Cosmetics',70.00),
(298,'Perfume','Cosmetics',220.00);

select * from Products;

with Ranked as (
  select *, row_number() over (partition by Category order by Price desc) as RowNum
  from Products
) select * from Ranked where RowNum<=3;

with Ranked as (
  select *, rank() over (partition by Category order by Price desc) as RankNum
  from Products
) select * from Ranked where RankNum<=3;

with Ranked as (
  select *, dense_rank() over (partition by Category order by Price desc) as DenseRankNum
  from Products
) select * from Ranked where DenseRankNum<=3;