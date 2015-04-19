use Student
drop procedure selectstudent
go
create procedure selectstudent(@id int)
as
select *
from Customers
where id<=@id