-- Task 4
select * from Departments

-- Task 5
select Name from Departments

-- Task 6
select Salary from Employees

-- Task 7
select FirstName + ' ' + LastName as [Full name] from Employees

-- Task 8
select FirstName + '.' + LastName + '@telerik.com' as [Full Email Address] from Employees

-- Task 9
select distinct Salary from Employees

-- Task 10
select * from Employees e
where e.JobTitle = 'Sales Representative'

-- Task 11
select FirstName from Employees
where FirstName like 'Sa%'

-- Task 12
select LastName from Employees
where LastName like '%ei%'

-- Task 13
select FirstName + ' ' + LastName as [Full name], Salary
from Employees
where Salary >= 20000 and Salary <= 30000

-- Tast 14
select FirstName + ' ' + LastName as [Full name], Salary
from Employees
where Salary in (25000, 14000, 12500, 23600)

-- Task 15
select e.FirstName + ' ' + e.LastName as [Full name]
from Employees e
where e.ManagerID is NULL

-- Task 16
select e.FirstName + ' ' + e.LastName as [Full name], e.Salary
from Employees e
where e.Salary >= 50000
order by Salary desc

-- Task 17
select top 5 FirstName + ' ' + LastName as [Full name], Salary
from Employees
order by Salary desc

-- Task 18
select e.FirstName + ' ' + e.LastName as [Full name], e.AddressID, a.AddressID, a.AddressText
from Employees e join Addresses a
on e.AddressID = a.AddressID

-- Task 19
select e.FirstName + ' ' + e.LastName as [Full name], e.AddressID, a.AddressID, a.AddressText
from Employees e, Addresses a
where e.AddressID = a.AddressID

-- Task 20
select e.FirstName + ' ' + e.LastName as [EmployeeName], m.FirstName + ' ' + m.LastName as [ManagerName]
from Employees e
	left join Employees m
	  on e.ManagerID = m.EmployeeID
order by ManagerName

-- Task 21
select e.FirstName + ' ' + e.LastName as [EmployeeName], m.FirstName + ' ' + m.LastName as [ManagerName], a.AddressText as [EmployeeAddress]
from Employees e
	left join Employees m
	  on e.ManagerID = m.EmployeeID
	join Addresses a
	  on e.AddressID = a.AddressID
order by ManagerName

-- Task 22
select Name from Departments
union
select Name from Towns

-- Task 23
select e.FirstName + ' ' + e.LastName as [EmployeeName], m.FirstName + ' ' + m.LastName as [ManagerName]
from Employees m right join Employees e
on m.EmployeeID = e.ManagerID

select e.FirstName + ' ' + e.LastName as [EmployeeName], m.FirstName + ' ' + m.LastName as [ManagerName]
from Employees e left join Employees m
on e.ManagerID = m.EmployeeID

-- Task 24
select e.FirstName + ' ' + e.LastName as [FullName], e.HireDate, d.Name as [DepartmentName]
from Employees e join Departments d
	on e.DepartmentID = d.DepartmentID
where d.Name in ('Sales', 'Finance') and 
	  e.HireDate >= '1/1/1995' and e.HireDate <= '1/1/2005'
