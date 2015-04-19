use Student
drop procedure studentinsert
go
create procedure studentinsert(@name char(20),@id int output)
as
set nocount off
select @id=MAX(id)+1
from Customers
insert into Customers
values(@name,@id);