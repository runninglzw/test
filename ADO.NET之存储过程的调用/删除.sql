--写好的存储过程必须执行或保存，SqlCommand类才能创建成功
use Student
go
create procedure studentupdate(@id int,@name char(10))
as
set nocount off--当 SET NOCOUNT 为 ON 时，不返回计数（表示受 Transact-SQL 语句影响的行数）。当 SET NOCOUNT 为 OFF 时，返回计数。
update customers
set name=@name
where id=@id; 