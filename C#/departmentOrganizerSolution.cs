using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; }
}

public class EnrichedEmployee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; }
    public double Tenure { get; set; }
    public AnniversaryInfo Anniversary { get; set; }
}

public class AnniversaryInfo
{
    public bool IsUpcoming { get; set; }
    public DateTime AnniversaryDate { get; set; }
    public int DaysUntil { get; set; }
}

public class DepartmentInfo
{
    public List<EnrichedEmployee> Employees { get; set; } = new List<EnrichedEmployee>();
    public decimal AverageSalary { get; set; }
    public (string Name, decimal Salary) HighestPaid { get; set; }
    public int TotalEmployees { get; set; }
    public List<UpcomingAnniversary> UpcomingAnniversaries { get; set; } = new List<UpcomingAnniversary>();
}

public class UpcomingAnniversary
{
    public string Name { get; set; }
    public DateTime AnniversaryDate { get; set; }
    public int DaysUntil { get; set; }
}

public class CompanyWideStats
{
    public int TotalEmployees { get; set; }
    public decimal AverageSalary { get; set; }
    public List<string> Departments { get; set; } = new List<string>();
}

public class OrganizationResult
{
    public Dictionary<string, DepartmentInfo> Departments { get; set; } = new Dictionary<string, DepartmentInfo>();
    public CompanyWideStats CompanyWide { get; set; } = new CompanyWideStats();
}

public class DepartmentOrganizer
{
    public static OrganizationResult OrganizeByDepartment(Employee[] employees, DateTime? referenceDate = null)
    {
        var refDate = referenceDate ?? DateTime.Now;
        
        // Input validation
        if (employees == null)
        {
            throw new ArgumentException("Employees array cannot be null");
        }

        var result = new OrganizationResult();
        
        if (employees.Length == 0)
        {
            return result;
        }

        result.CompanyWide.TotalEmployees = employees.Length;

        // Helper function to calculate tenure
        double CalculateTenure(DateTime hireDate)
        {
            var diff = refDate - hireDate;
            return Math.Round(diff.TotalDays / 365.25, 1);
        }

        // Helper function to check upcoming anniversary
        AnniversaryInfo CheckUpcomingAnniversary(DateTime hireDate)
        {
            var nextAnniversary = new DateTime(refDate.Year, hireDate.Month, hireDate.Day);
            
            if (nextAnniversary < refDate)
            {
                nextAnniversary = nextAnniversary.AddYears(1);
            }
            
            var daysUntil = (int)Math.Ceiling((nextAnniversary - refDate).TotalDays);
            
            return new AnniversaryInfo
            {
                IsUpcoming = daysUntil <= 30,
                AnniversaryDate = nextAnniversary,
                DaysUntil = daysUntil
            };
        }

        // Group employees by department
        foreach (var emp in employees)
        {
            if (!result.Departments.ContainsKey(emp.Department))
            {
                result.Departments[emp.Department] = new DepartmentInfo();
                result.CompanyWide.Departments.Add(emp.Department);
            }

            var tenure = CalculateTenure(emp.HireDate);
            var anniversary = CheckUpcomingAnniversary(emp.HireDate);

            var enrichedEmp = new EnrichedEmployee
            {
                Id = emp.Id,
                Name = emp.Name,
                Salary = emp.Salary,
                HireDate = emp.HireDate,
                Tenure = tenure,
                Anniversary = anniversary
            };

            result.Departments[emp.Department].Employees.Add(enrichedEmp);

            // Track highest paid
            if (emp.Salary > result.Departments[emp.Department].HighestPaid.Salary)
            {
                result.Departments[emp.Department].HighestPaid = (emp.Name, emp.Salary);
            }

            // Track upcoming anniversaries
            if (anniversary.IsUpcoming)
            {
                result.Departments[emp.Department].UpcomingAnniversaries.Add(new UpcomingAnniversary
                {
                    Name = emp.Name,
                    AnniversaryDate = anniversary.AnniversaryDate,
                    DaysUntil = anniversary.DaysUntil
                });
            }
        }

        // Calculate department statistics
        decimal totalSalary = 0;
        
        foreach (var dept in result.Departments.Keys.ToList())
        {
            var deptData = result.Departments[dept];
            
            deptData.AverageSalary = Math.Round(deptData.Employees.Average(e => e.Salary), 2);
            deptData.TotalEmployees = deptData.Employees.Count;
            
            // Sort employees by hire date (newest first)
            deptData.Employees = deptData.Employees
                .OrderByDescending(e => e.HireDate)
                .ToList();
            
            totalSalary += deptData.Employees.Sum(e => e.Salary);
        }

        // Calculate company-wide statistics
        result.CompanyWide.AverageSalary = Math.Round(totalSalary / employees.Length, 2);
        result.CompanyWide.Departments.Sort();

        return result;
    }
    
    public static void Test()
    {
        Console.WriteLine("=== DEPARTMENT ORGANIZER ===\n");
        
        var today = new DateTime(2024, 3, 15);
        
        var employees = new[]
        {
            new Employee { Id = 1, Name = "Alice", Department = "Engineering", Salary = 95000m, HireDate = new DateTime(2022, 6, 1) },
            new Employee { Id = 2, Name = "Bob", Department = "Engineering", Salary = 87000m, HireDate = new DateTime(2023, 9, 15) },
            new Employee { Id = 3, Name = "Charlie", Department = "Marketing", Salary = 65000m, HireDate = new DateTime(2021, 3, 20) },
            new Employee { Id = 4, Name = "Diana", Department = "Marketing", Salary = 72000m, HireDate = new DateTime(2024, 2, 1) },
            new Employee { Id = 5, Name = "Eve", Department = "Engineering", Salary = 105000m, HireDate = new DateTime(2020, 11, 10) },
            new Employee { Id = 6, Name = "Frank", Department = "Sales", Salary = 55000m, HireDate = new DateTime(2023, 1, 5) }
        };

        var result = OrganizeByDepartment(employees, today);
        
        Console.WriteLine("Company Wide Statistics:");
        Console.WriteLine($"  Total Employees: {result.CompanyWide.TotalEmployees}");
        Console.WriteLine($"  Average Salary: ${result.CompanyWide.AverageSalary:N0}");
        Console.WriteLine($"  Departments: {string.Join(", ", result.CompanyWide.Departments)}");
        
        Console.WriteLine("\nDepartment Details:");
        foreach (var dept in result.Departments.Keys.OrderBy(k => k))
        {
            var deptData = result.Departments[dept];
            Console.WriteLine($"\n  {dept}:");
            Console.WriteLine($"    Employees: {deptData.TotalEmployees}");
            Console.WriteLine($"    Average Salary: ${deptData.AverageSalary:N0}");
            Console.WriteLine($"    Highest Paid: {deptData.HighestPaid.Name} (${deptData.HighestPaid.Salary:N0})");
            
            if (deptData.UpcomingAnniversaries.Any())
            {
                Console.WriteLine("    Upcoming Anniversaries:");
                foreach (var a in deptData.UpcomingAnniversaries)
                {
                    Console.WriteLine($"      • {a.Name} in {a.DaysUntil} days ({a.AnniversaryDate:yyyy-MM-dd})");
                }
            }
            
            Console.WriteLine("    Employees (newest first):");
            foreach (var emp in deptData.Employees)
            {
                var anniversaryNote = emp.Anniversary.IsUpcoming ? " 🎉 Anniversary soon!" : "";
                Console.WriteLine($"      • {emp.Name} - Hired: {emp.HireDate:yyyy-MM-dd} ({emp.Tenure} years){anniversaryNote}");
            }
        }
    }
    
    public static void Main()
    {
        Test();
    }
}