/**
 * departmentOrganizer - Organize employees by departments with analytics
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
 * @param {Array} employees - Array of employee objects
 * @returns {Object} - Organized by department with analytics
 */

function organizeByDepartment(employees) {
  // TODO: Implement department organizer
  
  // Steps to consider:
  // 1. Validate input
  // 2. Group employees by department
  // 3. Calculate department statistics
  // 4. Calculate tenure for each employee
  // 5. Identify upcoming anniversaries
  // 6. Sort employees by hire date
  // 7. Return comprehensive structure
  
  throw new Error('Not implemented');
}

// Test with sample data
function test() {
  const today = new Date('2024-03-15'); // Fixed date for testing
  
  const sampleEmployees = [
    { id: 1, name: "Alice", department: "Engineering", salary: 95000, hireDate: "2022-06-01" },
    { id: 2, name: "Bob", department: "Engineering", salary: 87000, hireDate: "2023-09-15" },
    { id: 3, name: "Charlie", department: "Marketing", salary: 65000, hireDate: "2021-03-20" },
    { id: 4, name: "Diana", department: "Marketing", salary: 72000, hireDate: "2024-02-01" },
    { id: 5, name: "Eve", department: "Engineering", salary: 105000, hireDate: "2020-11-10" },
    { id: 6, name: "Frank", department: "Sales", salary: 55000, hireDate: "2023-01-05" }
  ];

  const result = organizeByDepartment(sampleEmployees, today);
  console.log(JSON.stringify(result, null, 2));
}

test();

// Expected output structure:
// {
//   departments: {
//     Engineering: {
//       employees: [
//         { id: 2, name: "Bob", salary: 87000, hireDate: "2023-09-15", tenure: 0.5, ... },
//         { id: 1, name: "Alice", salary: 95000, hireDate: "2022-06-01", tenure: 1.8, ... },
//         { id: 5, name: "Eve", salary: 105000, hireDate: "2020-11-10", tenure: 3.3, ... }
//       ],
//       averageSalary: 95666.67,
//       highestPaid: { name: "Eve", salary: 105000 },
//       totalEmployees: 3,
//       upcomingAnniversaries: []
//     },
//     Marketing: {
//       employees: [...],
//       averageSalary: 68500,
//       highestPaid: { name: "Diana", salary: 72000 },
//       totalEmployees: 2,
//       upcomingAnniversaries: [
//         { name: "Diana", anniversaryDate: "2025-02-01", daysUntil: 323 } // Example
//       ]
//     }
//   },
//   companyWide: {
//     totalEmployees: 6,
//     averageSalary: 79833.33,
//     departments: ["Engineering", "Marketing", "Sales"]
//   }
// }