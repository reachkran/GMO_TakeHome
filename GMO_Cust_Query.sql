--•	The Customer table has the columns CustomerId, CustomerName, and Status.
--•	The Order table has the columns OrderId, CustomerId, OrderDate, and OrderAmount.
--•	The OrderDetail table has the columns OrderId, ItemId, Quantity, and Amount.
--•	The Item table has the columns ItemId, CategoryId, and ItemName.
--•	The Category table has the columns CategoryId and CategoryName

CREATE TABLE Customer

(

CustomerID INT IDENTITY PRIMARY KEY,

FirstName VARCHAR(50),

LastName VARCHAR(50),

Status VARCHAR(10),

City VARCHAR(50),

State CHAR(2),

Zip VARCHAR(10)

)
GO

CREATE TABLE [Order]

(

OrderId TINYINT IDENTITY PRIMARY KEY,

CustomerID INT NOT NULL REFERENCES Customers(CustomerID),

OrderDate Datetime2 NOT NULL,

OrderAmount MONEY

)

GO

CREATE TABLE Category

(

CategoryId INT IDENTITY PRIMARY KEY,

CategoryName VARCHAR(10)

)

GO


CREATE TABLE Item

(

ItemId INT IDENTITY PRIMARY KEY,

CategoryId INT NOT NULL REFERENCES Category(CategoryId),

ItemName VARCHAR(10)

)

GO

CREATE TABLE OrderDetail

(

OrderId INT IDENTITY PRIMARY KEY,

ItemId INT NOT NULL REFERENCES Item(ItemId),

Quantity INT NOT NULL,

Amount MONEY NOT NULL

)

GO


--1.	Get all customers who have NOT bought an item with id 100 in the last year.
select CONCAT(cust.FirstName,cust.LastName) AS Customername from Customer cust
left join [order] od on od.customerid = cust.customerid
left join orderdetail ord on ord.orderid = od.orderid
left join item it on it.itemid = ord.itemid
where it.itemid not in (100) and od.orderdate between '2018-01-01' and '2018-12-31';

--2.	Get the single customer with the highest order amount on orders with 5 or more different items.
select CONCAT(cust.FirstName,cust.LastName) AS Customername,max(od.orderamount) from customer cust
left join [order] od on od.customerid = cust.customerid
left join orderdetail ord on ord.orderid = od.orderid
left join item it on it.itemid = ord.itemid
group by cust.customerid,ord.itemid, CONCAT(cust.FirstName,cust.LastName)
having count(ord.itemid)>=5;

--3.	Get all items that have a quantity greater than 10 in an order and return the OrderId, OrderDate, CategoryName, ItemName and Quantity.

select od.orderid,od.orderdate,cat.categoryname,it.itemname,ord.quantity from customer cust
left join [order] od on od.customerid = cust.customerid
left join orderdetail ord on ord.orderid = od.orderid
left join item it on it.itemid = ord.itemid
left join category cat on cat.categoryid = it.categoryid
group by od.orderid,od.orderdate,cat.categoryname,it.itemname,ord.quantity
having count(ord.quantity)>10;

--4.	Set the status field to inactive for all customers who have not placed any order in the last year.
update cust
set [status] ='Inactive'
from customer cust
inner join  
(
select cust.customerid from customer cust where customerid not in(
		select cust.CustomerId	from customer cust
		left join [order] od on od.customerid = cust.customerid
		left join orderdetail ord on ord.orderid = od.orderid
		where od.orderdate between '2018-01-01' and '2018-12-31'
		group by cust.customerid
		)
) AS Temp
on temp.customerid = cust.customerid;
