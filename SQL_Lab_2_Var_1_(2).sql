USE [SalesDB]

-- Информация о продуктах из США или КАНАДЫ стоимостью более 30
SELECT prod.ProductName, supp.Country, prod.UnitPrice
	FROM dbo.Product AS prod
		INNER JOIN dbo.[Supplier] AS supp ON prod.SupplierId = supp.Id
	WHERE Country IN (N'USA', N'Canada') AND UnitPrice > 30

--+ Информацию о продуктах, чье количество в заказе более 100
SELECT ProductName, Package, Quantity
	FROM dbo.[OrderItem] AS item
		LEFT OUTER JOIN dbo.Product AS prod ON item.ProductId = prod.Id
		WHERE item.Quantity > 100

--+ Информацию о заказах, имеющие от 1 до 3 позиций
	SELECT OrderId, OrderNumber , COUNT(ProductId) AS Positions
	FROM dbo.[Order] AS ord
		LEFT OUTER JOIN dbo.[OrderItem] AS item ON ord.Id = item.OrderId
	GROUP BY item.OrderId, OrderNumber
	HAVING COUNT(ProductId) BETWEEN 1 and 3
	ORDER BY OrderId

-- Первые 10 самых ранних заказов от клиентов из Франции
SELECT TOP(10) cust.FirstName, cust.LastName,cust.City,
CASE WHEN MIN([order].OrderDate) IS NOT NULL
	THEN MIN([order].OrderDate)
	ELSE 0
END AS CunstomerMinDateOrder
	FROM dbo.Customer AS cust
	LEFT OUTER JOIN dbo.[Order] AS [order] ON [order].CustomerId = cust.Id
	GROUP BY [order].CustomerId, cust.FirstName, cust.LastName, cust.City
	ORDER BY CunstomerMinDateOrder

-- Количество заказов по каждому клиенту(2 способа, через группировку и CROSS/OUTER APPLY), отсортировать по фамилии и имени клиента
SELECT cust.FirstName, cust.LastName,
	CASE WHEN COUNT(ord.OrderNumber) IS NOT NULL
		THEN COUNT(ord.OrderNumber)
		ELSE 0
	END AS CountOfOrder
	FROM dbo.Customer AS cust
		LEFT OUTER JOIN dbo.[Order] AS ord ON ord.CustomerId = cust.Id
	GROUP BY ord.CustomerId, cust.FirstName, cust.LastName

SELECT cust.FirstName, cust.LastName,
	CASE WHEN counts.CountOfOrder IS NOT NULL
		THEN counts.CountOfOrder
		ELSE 0
	END AS CountOfOrder
	FROM dbo.Customer AS cust
		OUTER APPLY(
		SELECT COUNT(OrderNumber) AS CountOfOrder
			FROM dbo.[Order]
			WHERE CustomerId = cust.Id
		) counts

--+ Для каждого клиента определить общую стоимость по кажому продукту. Вывести фамилию имя клиента название продукци и его стоимость.
WITH sumSource AS (
	SELECT CustomerId, ProductId, SUM(TotalAmount) AS sumProductCustomer
		FROM dbo.[Order] AS ord
			LEFT OUTER JOIN dbo.[OrderItem] AS item ON item.OrderId = ord.Id
			GROUP BY CustomerId, ProductId
	)
SELECT FirstName, LastName, ProductName, 
CASE WHEN sumProductCustomer IS NOT NULL
	THEN sumProductCustomer
	ELSE 0
END AS SumProduct
	FROM dbo.Customer AS cust
		LEFT OUTER JOIN sumSource ON sumSource.CustomerId = cust.Id
		LEFT OUTER JOIN dbo.Product AS prod ON sumSource.ProductId = prod.Id
		ORDER BY cust.Id

-- Поставщиков, которые поставляют только один товар (2 способа, с группировкой и без). Вывести имя компании, город, страну и наименование товаров.
;WITH IdProdName AS (
	SELECT SupplierId
		FROM dbo.Product
			GROUP BY SupplierId
			HAVING COUNT(ProductName) = 1
)
SELECT CompanyName, City, Country, ProductName
	FROM dbo.Supplier AS supp
		INNER JOIN IdProdName ON IdProdName.SupplierId = supp.Id
		INNER JOIN dbo.Product ON Product.SupplierId = supp.Id


SELECT CompanyName, City, Country, ProductName
	FROM dbo.Supplier AS supp
	INNER JOIN dbo.Product ON Product.SupplierId = supp.Id
		OUTER APPLY (
			SELECT COUNT(ProductName) AS SumTotalAmount
				FROM dbo.[Product]
				WHERE SupplierId = supp.Id
				) sums
				WHERE sums.SumTotalAmount = 1


-- Количество каждого продукта в заказах и его общую стоимость. ВЫвести информацию о продукте и его количество.
;WITH sumSource AS(
	SELECT ProductId, sum(TotalAmount) AS SumTotalAmount, sum(Quantity) AS SumQuantity
		FROM dbo.OrderItem AS item
			LEFT OUTER JOIN dbo.[Order] AS ord ON item.OrderId = ord.Id
			GROUP by ProductId
)
SELECT ProductName, Package, UnitPrice,
	CASE WHEN SumTotalAmount IS NOT NULL
		THEN SumTotalAmount
		ELSE 0
	END AS SumTotalAmount,
	CASE WHEN SumQuantity IS NOT NULL
		THEN SumQuantity
		ELSE 0
	END AS SumQuantity
	FROM dbo.Product AS prod
		LEFT OUTER JOIN sumSource ON prod.Id = sumSource.ProductId
