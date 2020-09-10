USE [SalesDB]

SELECT Id, CompanyName, ContactName, City, Country, Phone, Fax
	FROM dbo.Supplier;

SELECT Id, CompanyName, ContactName, ContactTitle, City, Country, Phone, Fax
	FROM dbo.Supplier;

SELECT Id, FirstName, LastName, City, Country, Phone
	FROM dbo.Customer

	--1
SELECT * FROM dbo.Customer

SELECT Id, FirstName, LastName, City, Country, Phone
	FROM dbo.Customer

	--2
SELECT FirstName, LastName, Phone
	FROM dbo.Customer

	--3
SELECT CONCAT(FirstName, N' ', LastName, N' из ', City, N', ', Country) AS CustomerDetails
	FROM dbo.Customer

SELECT (FirstName + N' ' + LastName + N' из ' + City + N', ' + Country) AS CustomerDetails
	FROM dbo.Customer

	--4
SELECT * FROM dbo.Customer AS cust
	INNER JOIN dbo.[Order] AS [order] ON cust.Id = [order].CustomerId

SELECT cust.Id, cust.FirstName, cust.FirstName, cust.City, cust.Country, cust.Phone,
	   [order].Id, [order].OrderDate, [order].OrderNumber, [order].CustomerId, [order].TotalAmount
	FROM dbo.Customer AS cust
	INNER JOIN dbo.[Order] AS [order] ON cust.Id = [order].CustomerId

	--5
SELECT * FROM dbo.Customer AS cust
	LEFT OUTER JOIN dbo.[Order] AS [order] ON cust.Id = [order].CustomerId

SELECT * FROM dbo.Customer AS cust
	CROSS JOIN dbo.[Order] AS [order]

	--6
SELECT cust.FirstName, cust.LastName, [order].OrderDate, [order].OrderNumber, dbo.Product.ProductName, item.Quantity
	FROM dbo.Customer AS cust
		INNER JOIN dbo.[Order] AS [order] ON cust.Id = [order].CustomerId
		INNER JOIN dbo.OrderItem AS item ON [order].Id = item.OrderId
		INNER JOIN dbo.Product ON dbo.Product.Id = item.ProductId

	--7
SELECT * FROM dbo.Customer
	WHERE Country = N'Germany'

	--8
SELECT * FROM dbo.Customer
	WHERE Country LIKE N'U%' OR Country LIKE N'%A'

	--9
SELECT * FROM dbo.Customer
	WHERE Country = N'USA' OR Country = N'UK' OR Country = N'Canada'

SELECT * FROM dbo.Customer
	WHERE Country IN (N'USA', N'UK', N'Canada')

	--10
SELECT DISTINCT cust.FirstName, cust.LastName
	FROM dbo.Customer AS cust
		INNER JOIN dbo.[Order] AS ord ON ord.CustomerId = cust.Id
	WHERE ord.TotalAmount > 1000

SELECT FirstName, LastName
	FROM dbo.Customer AS cust
	WHERE cust.Id IN 
	(SELECT CustomerId
		FROM dbo.[Order]
		WHERE TotalAmount > 1000)

	--11
SELECT DISTINCT cust.FirstName, cust.LastName
	FROM dbo.Customer AS cust
		INNER JOIN dbo.[Order] AS ord ON ord.CustomerId = cust.Id
	WHERE ord.TotalAmount > 1000 AND ord.OrderNumber >= 542500 AND ord.OrderNumber <= 542600

SELECT FirstName, LastName
	FROM dbo.Customer AS cust
	WHERE cust.Id IN 
	(SELECT CustomerId
		FROM dbo.[Order]
		WHERE TotalAmount > 1000 AND OrderNumber BETWEEN 542500 AND 542600)

	--12
SELECT
	COUNT(TotalAmount) AS TotalCount,
	SUM(TotalAmount) AS SumTotalAmount,
	AVG(TotalAmount) AS AvgTotalAmount,
	MAX(TotalAmount) AS MaxTotalAmount,
	MIN(TotalAmount) AS MinTotalAmount
FROM dbo.[Order]

	--13
SELECT cust.FirstName, cust.LastName,
	CASE WHEN SUM(ord.TotalAmount) IS NOT NULL
		THEN SUM(ord.TotalAmount)
		ELSE 0
	END AS CustomerTotalAmount
	FROM dbo.Customer AS cust
		LEFT OUTER JOIN dbo.[Order] AS ord ON cust.Id = ord.CustomerId
	GROUP BY ord.CustomerId, cust.FirstName, cust.LastName


SELECT cust.FirstName, cust.LastName,
	CASE WHEN sums.SumTotalAmount IS NOT NULL
		THEN sums.SumTotalAmount
		ELSE 0
	END AS CustomerTotalAmount
	FROM dbo.Customer AS cust
		OUTER APPLY (
			SELECT SUM(TotalAmount) AS SumTotalAmount
				FROM dbo.[Order]
				WHERE CustomerId = cust.Id
				) sums

WITH sumSource AS (
	SELECT CustomerID, SUM(TotalAmount) AS SumTotalAmount
	FROM dbo.[Order]
	GROUP BY CustomerId
	)
	SELECT cust.FirstName, cust.LastName,
		CASE WHEN SumTotalAmount IS NOT NULL
			THEN SumTotalAmount
			ELSE 0
		END AS CustomerTotalAmount
	FROM dbo.Customer AS cust
		LEFT OUTER JOIN sumSource ON sumSource.CustomerId = cust.id

	--14
SELECT cust.FirstName, cust.LastName,
	CASE WHEN SUM(ord.TotalAmount) IS NOT NULL
		THEN SUM(ord.TotalAmount)
		ELSE 0
	END AS CustimerTotalAmount
	FROM dbo.Customer AS cust
	LEFT OUTER JOIN dbo.[Order] AS ord ON ord.CustomerId = cust.Id
	GROUP BY ord.CustomerId, cust.FirstName, cust.LastName
	HAVING SUM(ord.TotalAmount) > 1000

SELECT cust.FirstName, cust.LastName,
	CASE WHEN sums.SumTotalAmount IS NOT NULL
		THEN sums.SumTotalAmount
		ELSE 0
	END AS CustumerTotalAmount
	FROM dbo.Customer AS cust
		OUTER APPLY(
	SELECT SUM(TotalAmount) AS SumTotalAmount
		FROM dbo.[Order]
		WHERE CustomerId = cust.Id
		) sums
	WHERE sums.SumTotalAmount > 10000

WITH sumSource AS(
	SELECT CustomerId, SUM(TotalAmount) AS SumTotalAmount
		FROM dbo.[Order]
		GROUP BY CustomerId
)
SELECT cust.FirstName, cust.LastName,
	CASE WHEN SumTotalAmount IS NOT NULL
		THEN SumTotalAmount
		ELSE 0
	END AS CustumerTotalAmount
	FROM dbo.Customer AS cust
		INNER JOIN sumSource ON sumSource.CustomerId = cust.Id
		WHERE SumTotalAmount > 10000

	-- 15
SELECT * FROM dbo.Customer
	ORDER BY LastName, FirstName

	--16
WITH sumSourse AS (
	SELECT CustomerID, SUM(TotalAmount) AS SumTotalAmount FROM dbo.[Order]
		GROUP BY CustomerId
	)
	SELECT TOP(10) cust.FirstName, cust.LastName,
		CASE WHEN SumTotalAmount IS NOT NULL
			THEN SumTotalAmount Else 0
		END AS CustomerTotalAmount
	FROM dbo.Customer AS cust
		LEFT OUTER JOIN sumSourse ON sumSourse.CustomerId = cust.Id
	ORDER BY CustomerTotalAmount DESC

SELECT TOP(10) cust.FirstName, cust.LastName,
	CASE WHEN SUM(ord.TotalAmount) IS NOT NULL
	THEN SUM(ord.TotalAmount)
	END AS CustomerTotalAmount
	FROM dbo.Customer AS cust
		LEFT OUTER JOIN dbo.[Order] AS ord ON cust.Id = ord.CustomerId
	GROUP BY ord.CustomerId, cust.FirstName, cust.LastName
	ORDER BY CustomerTotalAmount DESC

	--17
SELECT * FROM
	(SELECT DISTINCT Country FROM dbo.Customer) AS coutries
	CROSS APPLY(
	SELECT TOP(1) cust.LastName, cust.FirstName, SUM(ord.TotalAmount) AS SumTotalAmount
		FROM dbo.[Order] AS ord
			INNER JOIN dbo.Customer AS cust ON ord.CustomerId = cust.Id
		WHERE cust.Country = coutries.Country
		GROUP BY CustomerId, cust.FirstName, cust.LastName
		ORDER BY SumTotalAmount DESC
	) customerOfCountry
	ORDER BY Country

SELECT cust.Country, cust.LastName, cust.FirstName, customersOrdered.SumTotalAmount
	FROM dbo.Customer AS cust
	INNER JOIN(
		SELECT customersAgg.CustomerId, customersAgg.SumTotalAmount, 
		ROW_NUMBER() OVER (PARTITION BY customerAgg.Country ORDER BY
		customersAgg.SumTotalAmount DESC) AS OrderWithinCountry
			FROM (
			SELECT CustomerId, Country, SUM(ord.TotalAmount) AS SumTotalAmount
			FROM dbo.Customer AS cust
				INNER JOIN dbo.[Order] AS ord ON cust.Id = ord.CustomerId
			GROUP BY CustomerId, Country
			) AS customersAgg
	) AS customersOrdered ON cust.Id = customersOrdered.CustomerId
	WHERE OrderWithinCountry = 1
	ORDER BY Country