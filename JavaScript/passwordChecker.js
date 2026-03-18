/**
 * passwordChecker - Evaluate password strength
 * 
 * Implement a function that analyzes a password and returns a strength score
 * 
 * Requirements:
 * 1. Score 1 point for length >= 8 characters
 * 2. Score 1 point for containing uppercase letters
 * 3. Score 1 point for containing lowercase letters
 * 4. Score 1 point for containing numbers
 * 5. Score 1 point for containing special characters (!@#$%^&*)
 * 6. Return object with score (0-5) and feedback messages
 * 7. If password is empty or not string, return error
 * 
 * @param {string} password - The password to check
 * @returns {Object} - { score: number, feedback: string[], isValid: boolean }
 */

function checkPasswordStrength(password) {
  // TODO: Implement password strength checker
  
  // Steps to consider:
  // 1. Validate input (exists, is string)
  // 2. Initialize score and feedback array
  // 3. Check each requirement and add to score
  // 4. Add specific feedback messages
  // 5. Determine if valid (score >= 3)
  
  throw new Error('Not implemented');
}

// Test with sample data
function test() {
  const testPasswords = [
    "",                    // Empty
    "weak",                // Too short
    "onlylowercase",       // No uppercase, numbers, special
    "OnlyLower",           // Has uppercase and lowercase
    "GoodPass1",           // Length, upper, lower, number
    "Strong@Pass1",        // All criteria
    12345                  // Invalid type
  ];
  
  testPasswords.forEach(pwd => {
    console.log(`\nTesting: "${pwd}"`);
    try {
      const result = checkPasswordStrength(pwd);
      console.log(result);
    } catch (error) {
      console.log("Error:", error.message);
    }
  });
}

test();

// Expected output:
// Testing: ""
// Error: Password must be a non-empty string

// Testing: "weak"
// { score: 1, feedback: ["Length should be at least 8 characters"], isValid: false }

// Testing: "onlylowercase"
// { score: 2, feedback: ["Add uppercase letters", "Add numbers", "Add special characters"], isValid: false }

// Testing: "GoodPass1"
// { score: 4, feedback: ["Add special characters for maximum strength"], isValid: true }

// Testing: "Strong@Pass1"
// { score: 5, feedback: ["Password is strong!"], isValid: true }