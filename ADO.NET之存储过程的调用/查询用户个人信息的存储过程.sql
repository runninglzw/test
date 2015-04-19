use market
go
create procedure selectgerenxinxi(@name char(10))
as
select *
from Customers
where Cname=@name;