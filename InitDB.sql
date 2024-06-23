-- Создание таблицы clients

CREATE TABLE clients (

clientid SERIAL PRIMARY KEY,

clientname VARCHAR(255) NOT NULL,

phone VARCHAR(50),

address VARCHAR(255)

);

-- Создание таблицы products

CREATE TABLE products (

productid SERIAL PRIMARY KEY,

productname VARCHAR(255) NOT NULL,

price NUMERIC(10, 2) NOT NULL

);

-- Создание таблицы contracts

CREATE TABLE contracts (

contractid SERIAL PRIMARY KEY,

clientid INT REFERENCES clients(clientid),

contractdate DATE NOT NULL,

prepayment NUMERIC(10, 2) NOT NULL

);

-- Создание таблицы contractitems

CREATE TABLE contractitems (

contractitemid SERIAL PRIMARY KEY,

contractid INT REFERENCES contracts(contractid) ON DELETE CASCADE,

productid INT REFERENCES products(productid),

quantity INT NOT NULL,

amount NUMERIC(10, 2) NOT NULL

);

-- Создание таблицы payments

CREATE TABLE payments (

paymentid SERIAL PRIMARY KEY,

contractid INT REFERENCES contracts(contractid) ON DELETE CASCADE,

paymentdate DATE NOT NULL,

amount NUMERIC(10, 2) NOT NULL,

paymenttype VARCHAR(50) NOT NULL

);

-- Создание таблицы invoices

CREATE TABLE invoices (

invoiceid SERIAL PRIMARY KEY,

clientid INT REFERENCES clients(clientid),

invoicedate DATE NOT NULL,

totalsum NUMERIC(10, 2) NOT NULL

);

-- Создание таблицы invoiceitems

CREATE TABLE invoiceitems (

invoiceitemid SERIAL PRIMARY KEY,

invoiceid INT REFERENCES invoices(invoiceid) ON DELETE CASCADE,

productid INT REFERENCES products(productid),

quantity INT NOT NULL,

amount NUMERIC(10, 2) NOT NULL

);

-- Создание функции для проверки предоплаты

CREATE OR REPLACE FUNCTION check_prepayment() RETURNS TRIGGER AS $$

BEGIN

IF NEW.prepayment < 0.3 * (SELECT SUM(ci.quantity * p.price)

FROM contractitems ci

JOIN products p ON ci.productid = p.productid

WHERE ci.contractid = NEW.contractid) THEN

RAISE EXCEPTION 'Prepayment must be at least 30%% of the total contract amount';

END IF;

RETURN NEW;

END;

$$ LANGUAGE plpgsql;

-- Создание триггера, который будет вызывать функцию перед вставкой и обновлением в таблице contracts

CREATE TRIGGER prepayment_trigger

BEFORE INSERT OR UPDATE ON contracts

FOR EACH ROW EXECUTE FUNCTION check_prepayment();

CREATE OR REPLACE FUNCTION insert_futurapr_info() RETURNS TRIGGER AS $ad_fi_trigger$

BEGIN

UPDATE futurapr SET totalsum = totalsum + NEW.quantity*NEW.unitprice

WHERE futurapr.id = NEW.futurapr_id;

RETURN NULL;

END

$ad_fi_trigger$LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION delete_futurapr_info() RETURNS TRIGGER AS $del_fi_trigger$

BEGIN

UPDATE futurapr SET totalsum = totalsum - OLD.quantity*OLD.unitprice

WHERE futurapr.id = OLD.futurapr_id;

RETURN NULL;

END

$del_fi_trigger$LANGUAGE plpgsql;

