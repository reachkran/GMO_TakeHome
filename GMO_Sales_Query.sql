select * from customers;
select * from Products;
select * from Sales where CustomerID in (5);

--1.	For all sales in the month of October 2005, return the first and last name of the customer, the product name, and final sale price.
select cust.FirstName,cust.LastName, prod.ProductName,sal.SalePrice from Customers cust
left join sales sal on cust.CustomerID=sal.CustomerID
left join products prod on prod.ProductID = sal.ProductID 
where sal.SaleDate between '2005-10-01' and '2005-10-31';

--2.	For all customers who have made no purchases, return the Customer ID, first and last name of those individuals from the customer table
select CustomerID,FirstName,LastName from Customers 
where CustomerID not in (select CustomerID from Sales);

--4.	Return the average price by product category.
select Category,AVG(recommendedprice) from Products
group by Category;

--6.	Delete the customer(s) from the database who are from the state of California. 
Delete from Customers where State ='CA';

--7.	For those customers who have purchased two or more products, return the product category and the average sale price
select 
prod.Category,AVG(saleprice) AvgPrice
--cust.CustomerID,sal.ProductID, prod.Category
from customers cust
left join Sales sal on cust.CustomerID = sal.CustomerID
left join Products prod on prod.ProductID = sal.ProductID
group by cust.CustomerID,sal.ProductID, prod.Category
having count(sal.ProductID)>=2

--8.	Update the sale price to the recommended sale price of those sales occurring between 6/10/2005 and 6/20/2005.
update sal
set saleprice = y.RecommendedPrice
--select y.ProductID, y.RecommendedPrice
from sales sal 
inner join(
select prod.ProductID,prod.RecommendedPrice from Sales sal
left join Products prod on prod.ProductID = sal.ProductID
where sal.SaleDate between '2005-10-06' and '2005-10-20') AS Y
on sal.ProductID = y.ProductID
where sal.SaleDate between '2005-10-06' and '2005-10-20';