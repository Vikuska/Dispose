--Server=(local);Database=master;Integrated Security=SSPI;App=LINQPad;Max pool size=215;Connection Timeout=2;

select count(*)
from [master].[dbo].[sysprocesses]
where program_name = 'LINQPad'


select program_name, COUNT(*) from [master].[dbo].[sysprocesses] with (nolock)
where program_name like '%Apiv2%' OR program_name like '%AutoTestsApiv2%' OR program_name like '%cms%'
GROUP BY program_name



select program_name, COUNT(*) from [master].[dbo].[sysprocesses] with (nolock)
where program_name = 'Teest'
GROUP BY program_name
