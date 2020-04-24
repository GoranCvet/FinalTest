--select*
--from Products p 
--left join Categories c on p.CategoryID = c.CategoryID
--where c.CategoryName = 'Beverages'


select top(1) with ties
	cus.CompanyName [Company Name],
	o.OrderID,
	DATEDIFF(day, o.OrderDate, o.ShippedDate)[Process Days]
from Customers cus
left join Orders o on cus.CustomerID = o.CustomerID
left join [Order Details] od on o.OrderID = od.OrderID
where od.ProductID in (select p.ProductID from Products p
left join Categories c on p.CategoryID = c.CategoryID
where c.CategoryName = 'Beverages' and o.OrderDate is not null and o.ShippedDate is not null)
order by [Process Days] asc