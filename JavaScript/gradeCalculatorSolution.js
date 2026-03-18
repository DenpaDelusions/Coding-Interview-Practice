function analyzeGrades(grades) {
  // Input validation
  if (!Array.isArray(grades)) {
    throw new Error('Grades must be an array');
  }
  
  if (grades.length === 0) {
    throw new Error('Grades array cannot be empty');
  }

  // Filter out invalid grades (negative)
  const validGrades = [];
  const warnings = [];
  
  for (const grade of grades) {
    if (typeof grade !== 'number') {
      warnings.push(`Ignored non-numeric grade: ${grade}`);
    } else if (grade < 0) {
      warnings.push(`Ignored invalid grade: ${grade}`);
    } else if (grade > 100) {
      validGrades.push(100); // Cap at 100
      warnings.push(`Capped grade at 100: ${grade}`);
    } else {
      validGrades.push(grade);
    }
  }

  if (validGrades.length === 0) {
    throw new Error('No valid grades to analyze');
  }

  // Calculate statistics
  const sum = validGrades.reduce((acc, grade) => acc + grade, 0);
  const average = Math.round((sum / validGrades.length) * 100) / 100;
  const highest = Math.max(...validGrades);
  const lowest = Math.min(...validGrades);

  // Count pass/fail
  let passed = 0;
  let failed = 0;
  const letterGrades = { A: 0, B: 0, C: 0, D: 0, F: 0 };

  validGrades.forEach(grade => {
    if (grade >= 60) {
      passed++;
    } else {
      failed++;
    }

    // Assign letter grades
    if (grade >= 90) letterGrades.A++;
    else if (grade >= 80) letterGrades.B++;
    else if (grade >= 70) letterGrades.C++;
    else if (grade >= 60) letterGrades.D++;
    else letterGrades.F++;
  });

  return {
    average,
    highest,
    lowest,
    passed,
    failed,
    letterGrades,
    totalValidGrades: validGrades.length,
    totalInvalidGrades: grades.length - validGrades.length,
    warnings: warnings.length > 0 ? warnings : undefined
  };
}

// Test with sample data
function test() {
  console.log('=== STUDENT GRADE CALCULATOR ===\n');
  
  const testCases = [
    [],
    [95, 85, 72, 68, 45, -10, 92, 58],
    [100, 100, 100],
    [59, 60, 61],
    [105, 110, "abc", null, 75]
  ];
  
  testCases.forEach((grades, index) => {
    console.log(`Test ${index + 1}: Input: [${grades}]`);
    try {
      const result = analyzeGrades(grades);
      console.log(`  Average: ${result.average}`);
      console.log(`  Highest: ${result.highest}, Lowest: ${result.lowest}`);
      console.log(`  Passed: ${result.passed}, Failed: ${result.failed}`);
      console.log(`  Letter Grades: A:${result.letterGrades.A} B:${result.letterGrades.B} C:${result.letterGrades.C} D:${result.letterGrades.D} F:${result.letterGrades.F}`);
      if (result.warnings) {
        console.log('  Warnings:');
        result.warnings.forEach(w => console.log(`    • ${w}`));
      }
    } catch (error) {
      console.log('  ⚠ Error:', error.message);
    }
    console.log();
  });
}

test();