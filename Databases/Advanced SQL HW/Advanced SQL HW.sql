-- Task 1
select FirstName + ' ' + LastName as [FullName], Salary
from Employees
where Salary = (select min(Salary) from Employees)

-- Task 2
select FirstName + ' ' + LastName as [FullName], Salary
from Employees
where salary between
	(select min(Salary) from Employees) and
	(select min(Salary) + min(Salary) * 0.1 from Employees)
order by Salary

-- Tast 3
select e.FirstName + ' ' + e.LastName as [FullName], e.Salary, e.DepartmentID
from Employees e
	join Departments d
		on e.DepartmentID = d.DepartmentID
where e.Salary = (select min(Salary) from Employees
				  where d.DepartmentID = DepartmentID)
order by Salary

-- Task 4
select DepartmentID, avg(Salary) as [AverageSalary]
from Employees
group by DepartmentID
having DepartmentID = 1

-- Task 5
select d.Name as [DepartmentName], avg(Salary) as [AverageSalary]
from Employees e
	join Departments d
		on e.DepartmentID = d.DepartmentID
group by d.Name
having d.Name = 'Sales'

-- Task 6
select d.Name as [DepartmentName], Count(*) as [EmployeesCount]
from Employees e
	join Departments d
		on e.DepartmentID = d.DepartmentID
group by d.Name
having d.Name = 'Sales'

-- Task 7
select count(ManagerID) as [EmployeesWithManagerCount]
from Employees

-- Task 8
select count(*) - count(ManagerID) as [EmployeesWithNoManagerCount]
from Employees

-- Task 9
select d.Name, avg(Salary) as [AverageDepartmentSalary]
from Employees e
	join Departments d
		on e.DepartmentID = d.DepartmentID
group by d.Name

-- Task 10
select d.Name as [DepartmentName], count(*) as [EmployeesCount]
from Employees e
	join Departments d
	on e.DepartmentID = d.DepartmentID
	join Addresses a
	on e.AddressID = a.AddressID
	join Towns t
	on t.TownID = a.TownID
group by d.Name

-- Task 11
select m.FirstName + ' ' + m.LastName as [ManagerName], count(*) as [EmployeesCount]
from Employees e
	join Employees m
	on e.ManagerID = m.EmployeeID
group by m.FirstName, m.LastName
having count(*) = 5;

-- Task 12
select e.FirstName + ' ' + e.LastName as [EmployeeName], coalesce(m.FirstName + ' ' + m.LastName, '(no manager)') as [ManagerName]
from Employees e
	left join Employees m
	on e.ManagerID = m.EmployeeID

-- Task 13
select LastName
from Employees
where len(LastName) = 5

-- Task 14
select convert(varchar(50), getdate(), 113) as [DateTime.NOW]

-- Task 15
create table Users (
	UserID int identity,
	Username nvarchar(50) not null,
	Pass nvarchar(30) not null,
	FullName nvarchar(50) not null,
	LastLogin date,
	constraint PK_Users primary key (UserID),
	constraint UK_Username unique (Username),
	constraint CK_Long_Pass check (len(Pass) >= 5)
)

-- Task 16
create view UsersLoggedToday
as
select * from Users
where datepart(dayofyear, LastLogin) = datepart(dayofyear, getdate()) and
      datepart(year, LastLogin) = datepart(year, getdate())

insert into Users values ('Pesho', '123456', 'Pesho', getdate());
insert into Users values ('Gosho', '654321', 'Gosho', dateadd(DAY, -10, getdate()))

select * from UsersLoggedToday

-- Task 17
create table Groups (
	GroupID int identity,
	Name nvarchar(50),
	constraint PK_Groups primary key (GroupID),
	constraint UK_Name unique (Name)
)

-- Task 18
alter table Users add GroupID int

insert into Groups values ('Group I')
insert into Groups values ('Group II')
insert into Groups values ('Group III')
insert into Groups values ('Group IV')

alter table Users
add constraint FK_Users_Groups
	foreign key (GroupID)
	references Groups(GroupID)

insert into Users values ('Petkan', 'petkancho', 'Petkan', GETDATE(), 4)

-- Task 19
insert into Groups values ('Group V')
insert into Groups values ('Group VI')
insert into Groups values ('Group VII')
insert into Groups values ('Group VIII')

insert into Users values ('Petkan1', 'petkancho', 'Petkan', GETDATE(), 4)
insert into Users values ('Petkan2', 'petkancho', 'Petkan', GETDATE(), 3)
insert into Users values ('Petkan3', 'petkancho', 'Petkan', GETDATE(), 6)

-- Task 20
update Users
set Username = 'Mimito'
where Username = 'Petkan'

update Groups
set Name = 'Unknown'
where Name = 'Group VIII'

-- Task 21
delete from Users
where Username = 'Petkan2'

delete from Groups
where Name = 'Group V'

-- Task 22
insert into Users
select
	lower(left(e.FirstName, 1) + '.' + e.LastName) as Username,
	lower(left(e.FirstName, 1) + '.' + e.LastName + '_pass') as Pass,
	e.FirstName + ' ' + e.LastName as FullName,
	NULL as LastLogin,
	3 as GroupID
from Employees e

-- Task 23
update Users
set Pass = NULL
where LastLogin <= '2010-03-10'

-- Task 24
delete from Users
where Pass is NULL

-- Task 25
select e.DepartmentID, e.JobTitle, avg(e.Salary) as [AverageSalaries]
from Employees e
group by e.DepartmentID, e.JobTitle
order by [AverageSalaries]

-- Task 26
select e.DepartmentID, e.FirstName + ' ' + e.LastName as [FullName], e.JobTitle, min(e.Salary) as [MinSalary]
from Employees e
group by e.DepartmentID, e.FirstName, e.LastName, e.JobTitle
order by [MinSalary]

-- Task 27
select top 1 t.Name, count(*) [Employees]
from 
	Employees e
	join Addresses a 
	  on a.AddressID = e.AddressID
	join Towns t 
	  on t.TownID = a.TownID
group by t.Name
order by count(*) desc

-- Task 28
select t.Name, count(*) [Managers]
from 
	Employees e
	join Employees m
	  on e.ManagerID = m.EmployeeID
	join Addresses a 
	  on a.AddressID = e.AddressID
	join Towns t 
	  on t.TownID = a.TownID
group by t.Name
order by count(*)

-- Task 30
begin tran
delete from Employees
	select d.Name
	from Employees e join Departments d
	on e.DepartmentID = d.DepartmentID
	group by d.Name
	having d.Name = 'Sales'
rollback tran

-- Task 31
begin tran
drop table EmployeesProjects
rollback tran

-- Task 32
create table #TemporaryTable(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL
)

insert into #TemporaryTable
select EmployeeID, ProjectID
from EmployeesProjects

drop table EmployeesProjects

create table EmployeesProjects(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL,
	constraint PK_EmployeesProjects primary key(EmployeeID, ProjectID),
	constraint FK_EP_Employee foreign key(EmployeeID) references Employees(EmployeeID),
	constraint FK_EP_Project foreign key(ProjectID) references Projects(ProjectID)
)

insert into EmployeesProjects
select EmployeeID, ProjectID
from #TemporaryTable