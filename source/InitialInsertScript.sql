USE [CustomerTestDatabase]
GO

INSERT INTO [dbo].[Customers]
	([Name], [Email], [MobileNumber])
VALUES
    ('Test1 Test1', 'test1@example.com', 1234567890),
    ('Test2 Test2', 'test2@example.com', 2345678901),
    ('Test3 Test3', 'test3@example.com', 3456789012),
    ('Test4 Test4', 'test4@example.com', 4567890123);
GO

Declare @Datetime datetime = GETDATE();

INSERT INTO [dbo].[Transactions]
	([DateTime], [Amount], [Code], [Status], [CustomerId])
VALUES
	(@Datetime, 120.50, 0, 0, 1),
	(@Datetime, 1314.54, 0, 0, 1),
	(@Datetime, 1400.50, 1, 0, 1),
	(@Datetime, 120.50, 1, 0, 1),
	(@Datetime, 120200.50, 1, 1, 1),
	(@Datetime, 20120.55, 2, 1, 1),
	(@Datetime, 1211.20, 2, 1, 1),
	(@Datetime, 100.00, 2, 2, 1),
	(@Datetime, 120.51, 3, 2, 2),
	(@Datetime, 130.50, 3, 2, 3),
	(@Datetime, 4520.54, 3, 2, 3)
GO