use Student
drop procedure returnstudent
go
create procedure returnstudent(@id int,@rid int output,@rname char(20) output)
as
select @rid=id,@rname=Name
from Customers
where id=@id;