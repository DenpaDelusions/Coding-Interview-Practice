function organizeByDepartment(employees, referenceDate = new Date()) {
  // Input validation
  if (!Array.isArray(employees)) {
    throw new Error('Employees must be an array');
  }

  if (employees.length === 0) {
    return {
      departments: {},
      companyWide: {
        totalEmployees: 0,
        averageSalary: 0,
        departments: []
      }
    };
  }

  const result = {
    departments: {},
    companyWide: {
      totalEmployees: employees.length,
      averageSalary: 0,
      departments: []
    }
  };

  // Helper function to calculate tenure in years
  function calculateTenure(hireDate) {
    const hire = new Date(hireDate);
    const diffTime = Math.abs(referenceDate - hire);
    const diffYears = diffTime / (1000 * 60 * 60 * 24 * 365.25);
    return Math.round(diffYears * 10) / 10; // Round to 1 decimal
  }

  // Helper function to check upcoming anniversary (within 30 days)
  function checkUpcomingAnniversary(hireDate) {
    const hire = new Date(hireDate);
    const nextAnniversary = new Date(referenceDate);
    
    // Set to same month/day as hire date
    nextAnniversary.setMonth(hire.getMonth());
    nextAnniversary.setDate(hire.getDate());
    
    // If this year's anniversary already passed, use next year
    if (nextAnniversary < referenceDate) {
      nextAnniversary.setFullYear(referenceDate.getFullYear() + 1);
    }
    
    const diffDays = Math.ceil((nextAnniversary - referenceDate) / (1000 * 60 * 60 * 24));
    
    return {
      isUpcoming: diffDays <= 30,
      anniversaryDate: nextAnniversary.toISOString().split('T')[0],
      daysUntil: diffDays
    };
  }

  // Group employees by department
  employees.forEach(emp => {
    const dept = emp.department;
    
    if (!result.departments[dept]) {
      result.departments[dept] = {
        employees: [],
        averageSalary: 0,
        highestPaid: { name: '', salary: 0 },
        totalEmployees: 0,
        upcomingAnniversaries: []
      };
      
      // Add to company-wide departments list
      if (!result.companyWide.departments.includes(dept)) {
        result.companyWide.departments.push(dept);
      }
    }
    
    // Calculate tenure
    const tenure = calculateTenure(emp.hireDate);
    const anniversary = checkUpcomingAnniversary(emp.hireDate);
    
    // Create enriched employee object
    const enrichedEmp = {
      id: emp.id,
      name: emp.name,
      salary: emp.salary,
      hireDate: emp.hireDate,
      tenure,
      anniversary: anniversary.isUpcoming ? anniversary : null
    };
    
    // Add to department employees array
    result.departments[dept].employees.push(enrichedEmp);
    
    // Update highest paid
    if (emp.salary > result.departments[dept].highestPaid.salary) {
      result.departments[dept].highestPaid = {
        name: emp.name,
        salary: emp.salary
      };
    }
    
    // Track upcoming anniversaries
    if (anniversary.isUpcoming) {
      result.departments[dept].upcomingAnniversaries.push({
        name: emp.name,
        anniversaryDate: anniversary.anniversaryDate,
        daysUntil: anniversary.daysUntil
      });
    }
  });

  // Calculate department averages and sort employees
  let totalSalary = 0;
  
  Object.keys(result.departments).forEach(dept => {
    const deptData = result.departments[dept];
    
    // Calculate average salary
    const salarySum = deptData.employees.reduce((sum, emp) => sum + emp.salary, 0);
    deptData.averageSalary = Math.round((salarySum / deptData.employees.length) * 100) / 100;
    deptData.totalEmployees = deptData.employees.length;
    
    // Sort employees by hire date (newest first)
    deptData.employees.sort((a, b) => new Date(b.hireDate) - new Date(a.hireDate));
    
    // Add to company total salary
    totalSalary += salarySum;
  });

  // Calculate company-wide average
  result.companyWide.averageSalary = Math.round((totalSalary / employees.length) * 100) / 100;
  result.companyWide.departments.sort();

  return result;
}

// Test with sample data
function test() {
  console.log('=== DEPARTMENT ORGANIZER ===\n');
  
  const today = new Date('2024-03-15');
  
  const sampleEmployees = [
    { id: 1, name: "Alice", department: "Engineering", salary: 95000, hireDate: "2022-06-01" },
    { id: 2, name: "Bob", department: "Engineering", salary: 87000, hireDate: "2023-09-15" },
    { id: 3, name: "Charlie", department: "Marketing", salary: 65000, hireDate: "2021-03-20" },
    { id: 4, name: "Diana", department: "Marketing", salary: 72000, hireDate: "2024-02-01" },
    { id: 5, name: "Eve", department: "Engineering", salary: 105000, hireDate: "2020-11-10" },
    { id: 6, name: "Frank", department: "Sales", salary: 55000, hireDate: "2023-01-05" }
  ];

  const result = organizeByDepartment(sampleEmployees, today);
  
  // Pretty print the result
  console.log('Company Wide Statistics:');
  console.log(`  Total Employees: ${result.companyWide.totalEmployees}`);
  console.log(`  Average Salary: $${result.companyWide.averageSalary.toLocaleString()}`);
  console.log(`  Departments: ${result.companyWide.departments.join(', ')}`);
  
  console.log('\nDepartment Details:');
  Object.keys(result.departments).forEach(dept => {
    const deptData = result.departments[dept];
    console.log(`\n  ${dept}:`);
    console.log(`    Employees: ${deptData.totalEmployees}`);
    console.log(`    Average Salary: $${deptData.averageSalary.toLocaleString()}`);
    console.log(`    Highest Paid: ${deptData.highestPaid.name} ($${deptData.highestPaid.salary.toLocaleString()})`);
    
    if (deptData.upcomingAnniversaries.length > 0) {
      console.log('    Upcoming Anniversaries:');
      deptData.upcomingAnniversaries.forEach(a => {
        console.log(`      • ${a.name} in ${a.daysUntil} days (${a.anniversaryDate})`);
      });
    }
    
    console.log('    Employees (newest first):');
    deptData.employees.forEach(emp => {
      const anniversaryNote = emp.anniversary ? ' 🎉 Anniversary soon!' : '';
      console.log(`      • ${emp.name} - Hired: ${emp.hireDate} (${emp.tenure} years)${anniversaryNote}`);
    });
  });
}

test();