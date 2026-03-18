/**
 * formValidator - Validate user registration form
 * 
 * Implement a function that validates user input fields
 * 
 * Requirements:
 * 1. Username: 3-20 characters, alphanumeric only
 * 2. Email: Valid format (must contain @ and .domain)
 * 3. Password: Min 8 chars, at least 1 number, 1 uppercase
 * 4. Age: Must be between 18 and 120
 * 5. Return object with isValid flag and array of error messages
 * 6. All fields required (can't be empty or null)
 * 
 * @param {Object} user - { username, email, password, age }
 * @returns {Object} - { isValid: boolean, errors: string[] }
 */

function validateUser(user) {
  // TODO: Implement user validator
  
  // Steps to consider:
  // 1. Check if user object exists
  // 2. Validate each field
  // 3. Collect error messages
  // 4. Return validation result
  
  throw new Error('Not implemented');
}

// Test with sample data
function test() {
  const testUsers = [
    null,
    {},
    {
      username: "john_doe",
      email: "john@example.com",
      password: "Pass1234",
      age: 25
    },
    {
      username: "a",
      email: "invalid-email",
      password: "weak",
      age: 15
    }
  ];
  
  testUsers.forEach((user, index) => {
    console.log(`\nTest ${index + 1}:`, user);
    try {
      const result = validateUser(user);
      console.log(result);
    } catch (error) {
      console.log("Error:", error.message);
    }
  });
}

test();

// Expected output:
// Test 1: null
// Error: User object is required

// Test 2: {}
// {
//   isValid: false,
//   errors: [
//     "Username is required",
//     "Email is required",
//     "Password is required",
//     "Age is required"
//   ]
// }