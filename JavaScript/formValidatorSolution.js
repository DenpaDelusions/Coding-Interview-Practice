function validateUser(user) {
  // Input validation
  if (!user || typeof user !== 'object') {
    throw new Error('User object is required');
  }

  const errors = [];

  // Username validation
  if (!user.username) {
    errors.push('Username is required');
  } else if (typeof user.username !== 'string') {
    errors.push('Username must be a string');
  } else {
    if (user.username.length < 3) {
      errors.push('Username must be at least 3 characters');
    }
    if (user.username.length > 20) {
      errors.push('Username must not exceed 20 characters');
    }
    if (!/^[a-zA-Z0-9]+$/.test(user.username)) {
      errors.push('Username must contain only letters and numbers');
    }
  }

  // Email validation
  if (!user.email) {
    errors.push('Email is required');
  } else if (typeof user.email !== 'string') {
    errors.push('Email must be a string');
  } else {
    // Basic email validation: must contain @ and at least one dot after @
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(user.email)) {
      errors.push('Email must be valid (e.g., name@domain.com)');
    }
  }

  // Password validation
  if (!user.password) {
    errors.push('Password is required');
  } else if (typeof user.password !== 'string') {
    errors.push('Password must be a string');
  } else {
    if (user.password.length < 8) {
      errors.push('Password must be at least 8 characters');
    }
    if (!/[A-Z]/.test(user.password)) {
      errors.push('Password must contain at least one uppercase letter');
    }
    if (!/[0-9]/.test(user.password)) {
      errors.push('Password must contain at least one number');
    }
  }

  // Age validation
  if (user.age === undefined || user.age === null) {
    errors.push('Age is required');
  } else if (typeof user.age !== 'number') {
    errors.push('Age must be a number');
  } else {
    if (user.age < 18) {
      errors.push('You must be at least 18 years old');
    }
    if (user.age > 120) {
      errors.push('Age cannot exceed 120 years');
    }
    if (!Number.isInteger(user.age)) {
      errors.push('Age must be a whole number');
    }
  }

  return {
    isValid: errors.length === 0,
    errors: errors
  };
}

// Test with sample data
function test() {
  console.log('=== FORM VALIDATOR ===\n');
  
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
    },
    {
      username: "validUser123",
      email: "test@domain.co.uk",
      password: "StrongP@ss99",
      age: 30
    },
    {
      username: "user@name", // Invalid character
      email: "missing-at.com",
      password: "NoNumbers",
      age: 200
    }
  ];
  
  testUsers.forEach((user, index) => {
    console.log(`Test ${index + 1}:`);
    console.log('  Input:', user ? JSON.stringify(user) : 'null');
    
    try {
      const result = validateUser(user);
      console.log(`  Valid: ${result.isValid ? '✓' : '✗'}`);
      if (result.errors.length > 0) {
        console.log('  Errors:');
        result.errors.forEach(err => console.log(`    • ${err}`));
      } else {
        console.log('  ✓ All fields valid!');
      }
    } catch (error) {
      console.log('  ⚠ Error:', error.message);
    }
    console.log();
  });
}

test();