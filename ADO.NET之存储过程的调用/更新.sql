use Student
drop procedure studentdelete;
go
create procedure studentdelete(@id int)
as
set nocount off
delete from Customers
where id=@id
