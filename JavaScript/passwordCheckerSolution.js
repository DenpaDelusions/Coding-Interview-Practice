function checkPasswordStrength(password) {
  // Input validation
  if (typeof password !== 'string' || password.length === 0) {
    throw new Error('Password must be a non-empty string');
  }

  // Initialize result
  let score = 0;
  const feedback = [];

  // Check length
  if (password.length >= 8) {
    score++;
  } else {
    feedback.push('Length should be at least 8 characters');
  }

  // Check for uppercase letters
  if (/[A-Z]/.test(password)) {
    score++;
  } else {
    feedback.push('Add uppercase letters');
  }

  // Check for lowercase letters
  if (/[a-z]/.test(password)) {
    score++;
  } else {
    feedback.push('Add lowercase letters');
  }

  // Check for numbers
  if (/[0-9]/.test(password)) {
    score++;
  } else {
    feedback.push('Add numbers');
  }

  // Check for special characters
  if (/[!@#$%^&*]/.test(password)) {
    score++;
  } else {
    feedback.push('Add special characters (!@#$%^&*)');
  }

  // Determine if password is valid (score >= 3)
  const isValid = score >= 3;

  // Add success message if no feedback
  if (feedback.length === 0) {
    feedback.push('Password is strong!');
  }

  return {
    score,
    feedback,
    isValid
  };
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
  
  console.log('=== PASSWORD STRENGTH CHECKER ===\n');
  
  testPasswords.forEach((pwd, index) => {
    console.log(`Test ${index + 1}: "${pwd}"`);
    try {
      const result = checkPasswordStrength(pwd);
      console.log(`  Score: ${result.score}/5`);
      console.log(`  Valid: ${result.isValid ? '✓' : '✗'}`);
      console.log('  Feedback:');
      result.feedback.forEach(msg => console.log(`    • ${msg}`));
    } catch (error) {
      console.log('  ⚠ Error:', error.message);
    }
    console.log();
  });
}

test();