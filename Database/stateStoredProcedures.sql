DROP PROCEDURE IF EXISTS usp_StateDelete;
DELIMITER // 
CREATE PROCEDURE usp_StateDelete (in code varchar(2), in conCurrId int)
BEGIN
	Delete from states where statecode = code and ConcurrencyID = conCurrId;
END //
DELIMITER ; 

DROP PROCEDURE IF EXISTS usp_StateCreate;
DELIMITER // 
CREATE PROCEDURE usp_StateCreate (in code varchar(2), in name varchar(20))
BEGIN
	Insert into states (statecode, statename) values (code, name);
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS usp_StateSelect;
DELIMITER // 
CREATE PROCEDURE usp_StateSelect (in code varchar(2))
BEGIN
	Select * from states where statecode=code;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS usp_StateSelectAll;
DELIMITER // 
CREATE PROCEDURE usp_StateSelectAll ()
BEGIN
	Select * from states order by statename;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS usp_StateUpdate;
DELIMITER // 
CREATE PROCEDURE usp_StateUpdate (in code varchar(2), in name varchar(20), in conCurrId int)
BEGIN
	Update states
    Set statename = name, concurrencyid = (concurrencyid + 1)
    Where statecode = code and concurrencyid = conCurrId;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS usp_CustomerDelete;
DELIMITER // 
CREATE PROCEDURE usp_CustomerDelete (in custId int, in conCurrId int)
BEGIN
	Delete from customers where CustomerID = custId and ConcurrencyID = conCurrId;
END //
DELIMITER ; 

DROP PROCEDURE IF EXISTS usp_CustomerSelect;
DELIMITER // 
CREATE PROCEDURE usp_CustomerSelect (in custId int)
BEGIN
	Select * from customers where CustomerID = custId;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS usp_CustomerSelectAll;
DELIMITER // 
CREATE PROCEDURE usp_CustomerSelectAll ()
BEGIN
	Select * from customers order by CustomerID;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS usp_CustomerUpdate;
DELIMITER // 
CREATE PROCEDURE usp_CustomerUpdate (in custId int, in name_p varchar(100), in address_p varchar(50), in city_p varchar(20), in state_p varchar (12), in zipcode_p int)
BEGIN
	Update customers
    Set CustomerID = custId, Name = name_p, Address = address_p, City = city_p, State = state_p, ZipCode = zipcode_p, concurrencyid = (concurrencyid + 1)
    Where CustomerID = custId and concurrencyid = conCurrId;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS usp_CustomerCreate;
DELIMITER // 
CREATE PROCEDURE usp_CustomerCreate (out custId int, in name_p varchar(100), in address_p varchar(50), in city_p varchar(20), in state_p varchar(12), in zipcode_p int)
BEGIN
	Insert into customers (custId, name_p, address_p, city_p, state_p, zipcode_p, concurrencyid)
    Values (custId, name_p, address_p, city_p, state_p, zipcode_p, 1);
    Select LAST_INSERT_ID() into custId;
    
END //
DELIMITER ; 

DROP PROCEDURE IF EXISTS usp_ProductDelete;
DELIMITER // 
CREATE PROCEDURE usp_ProductDelete (in prodId int, in conCurrId int)
BEGIN
	Delete from products where ProductId = prodId and ConcurrencyID = conCurrId;
END //
DELIMITER ; 

DROP PROCEDURE IF EXISTS usp_ProductCreate;
DELIMITER // 
CREATE PROCEDURE usp_ProductCreate (in prodId int, in prodCode varchar(10))
BEGIN
	Insert into products (ProductId, ProductCode) values (prodId, prodCode);
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS usp_ProductSelect;
DELIMITER // 
CREATE PROCEDURE usp_ProductSelect (in prodId int)
BEGIN
	Select * from products where ProductId = prodId;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS usp_ProductSelectAll;
DELIMITER // 
CREATE PROCEDURE usp_ProductSelectAll ()
BEGIN
	Select * from products order by ProductId;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS usp_ProductUpdate;
DELIMITER // 
CREATE PROCEDURE usp_ProductUpdate (in prodId int, in prodCode varchar(10), in prodDesc varchar(50), in prodPrice decimal, in prodQuant int, in conCurrId int)
BEGIN
	Update products
    Set ProductId = prodId, ProductCode = prodCode, Description = prodDesc, UnitPrice = prodPrice, OnHandQuantity = prodQuant, ConcurrencyID = (ConcurrencyID + 1)
    Where ProductCode = prodCode and ConcurrencyID = conCurrId;
END //
DELIMITER ;