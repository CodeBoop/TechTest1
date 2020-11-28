USE MMTShop

go

Create table Categories(
	[Id] int not null primary key identity(1,1),
	[Name] nvarchar(1000) not null,
	[SkuPrefix] varchar(100) not null
)


go

Create table Products(
	[Id] int not null primary key identity(1,1),
	[Sku] varchar(100) not null unique,
	[Name] nvarchar(1000) not null,
	[Description] nvarchar(4000) null,
	[Price] decimal(10,2) not null
)

go

 insert into Categories([Name],[SkuPrefix])
 values('Home','1'),
('Garden','2'),
('Electronics','3'),
('Fitness','4'),
('Toys','5')


go

 insert into Products([Sku], [Name], [Description], [Price])
 values('1001','Sofa','4 seater',400),
('1002','Sofa','5 seater',500),
('1003','Sofa','6 seater',600),
('1005','Chair','Wooden',10.05),
('2001','Lawn',null,1000),
('2002','Lawn Chair','A fancier wooden chair',11.89),
('2015','Plants','Green ones, blue ones, we''ve got them all',10),
('3001','IPhone M','It''s the 1000th iteration of the IPhone',999999.99),
('3002','Windows 10 PC',null,1000.99),
('3003','Kettle','It uses electricity, that''s why it''s in this category',1),
('4001','Bumbbells','Which pandemic body are you going to have at the end?',99.98),
('4002','Tredmill','When running stationary is not up the street',100),
('4003','Skipping rope',null,5.99),
('5001','Bear','It''s a stuffed toy',9.50)







