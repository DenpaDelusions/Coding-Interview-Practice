/*
 * DepartmentOrganizer - Organize employees by departments with analytics
 * 
 * Implement a function that processes employee data
 * 
 * Requirements:
 * 1. Group employees by department
 * 2. Calculate average salary per department
 * 3. Find highest paid employee in each department
 * 4. Sort employees within department by hire date (newest first)
 * 5. Add tenure calculation (years with company)
 * 6. Flag employees with upcoming work anniversaries (within 30 days)
 * 7. Return organized structure with department summaries
 * 
 * @param {Employee[]} employees - Array of employee objects
 * @param {DateTime?} referenceDate - Date to calculate from (defaults to now)
 * @returns {OrganizationResult} - Organized by department with analytics
 */

using System;
using System.Collections.Generic;

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

public class UpcomingAnniversary
{
    public string Name { get; set; }
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
        // TODO: Implement department organizer
        
        // Steps to consider:
        // 1. Validate input
        // 2. Set reference date (use current if not provided)
        // 3. Group employees by department
        // 4. Calculate tenure for each employee
        // 5. Check for upcoming anniversaries
        // 6. Calculate department statistics
        // 7. Sort employees by hire date
        // 8. Return organized structure
        
        throw new NotImplementedException();
    }
    
    public static void Test()
    {
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
        
        // Print results (simplified for question file)
        Console.WriteLine("Company Wide:");
        Console.WriteLine($"  Total Employees: {result.CompanyWide.TotalEmployees}");
        Console.WriteLine($"  Departments: {string.Join(", ", result.CompanyWide.Departments)}");
        
        foreach (var dept in result.Departments.Keys)
        {
            Console.WriteLine($"\n{dept}:");
            Console.WriteLine($"  Employees: {result.Departments[dept].TotalEmployees}");
            Console.WriteLine($"  Average Salary: ${result.Departments[dept].AverageSalary}");
        }
    }
}

// Expected output structure:
// Company Wide:
//   Total Employees: 6
//   Departments: Engineering, Marketing, Sales
//
// Engineering:
//   Employees: 3
//   Average Salary: $95666.67
//
// Marketing:
//   Employees: 2
//   Average Salary: $68500.00
//
// Sales:
//   Employees: 1
//   Average Salary: $55000.00