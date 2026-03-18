/**
 * gradeCalculator - Calculate statistics from student grades
 * 
 * Implement a function that processes an array of student grades
 * 
 * Requirements:
 * 1. Calculate average, highest, lowest grade
 * 2. Count how many passed (>=60) and failed (<60)
 * 3. Assign letter grades: A(90-100), B(80-89), C(70-79), D(60-69), F(<60)
 * 4. Return object with all statistics
 * 5. Handle empty array (return error)
 * 6. Ignore negative grades (filter them out with warning)
 * 
 * @param {number[]} grades - Array of numerical grades
 * @returns {Object} - Statistics object
 */

function analyzeGrades(grades) {
  // TODO: Implement grade analyzer
  
  // Steps to consider:
  // 1. Validate input (array, not empty)
  // 2. Filter out invalid grades (negative)
  // 3. Calculate statistics
  // 4. Assign letter grades
  // 5. Count pass/fail
  // 6. Return formatted result
  
  throw new Error('Not implemented');
}

// Test with sample data
function test() {
  const testCases = [
    [],
    [95, 85, 72, 68, 45, -10, 92, 58],
    [100, 100, 100],
    [59, 60, 61]
  ];
  
  testCases.forEach((grades, index) => {
    console.log(`\nTest ${index + 1}:`, grades);
    try {
      const result = analyzeGrades(grades);
      console.log(result);
    } catch (error) {
      console.log("Error:", error.message);
    }
  });
}

test();

// Expected output:
// Test 1: []
// Error: Grades array cannot be empty

// Test 2: [95, 85, 72, 68, 45, -10, 92, 58]
// {
//   average: 73.57,
//   highest: 95,
//   lowest: 45,
//   passed: 5,
//   failed: 2,
//   letterGrades: { A: 2, B: 1, C: 1, D: 1, F: 2 },
//   warnings: ["Ignored invalid grade: -10"]
// }