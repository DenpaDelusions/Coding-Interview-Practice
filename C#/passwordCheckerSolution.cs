using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class PasswordResult
{
    public int Score { get; set; }
    public List<string> Feedback { get; set; } = new List<string>();
    public bool IsValid { get; set; }
}

public class PasswordChecker
{
    public static PasswordResult CheckStrength(string password)
    {
        // Input validation
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Password cannot be null or empty");
        }

        var result = new PasswordResult();

        // Check length
        if (password.Length >= 8)
        {
            result.Score++;
        }
        else
        {
            result.Feedback.Add("Length should be at least 8 characters");
        }

        // Check for uppercase letters
        if (Regex.IsMatch(password, "[A-Z]"))
        {
            result.Score++;
        }
        else
        {
            result.Feedback.Add("Add uppercase letters");
        }

        // Check for lowercase letters
        if (Regex.IsMatch(password, "[a-z]"))
        {
            result.Score++;
        }
        else
        {
            result.Feedback.Add("Add lowercase letters");
        }

        // Check for numbers
        if (Regex.IsMatch(password, "[0-9]"))
        {
            result.Score++;
        }
        else
        {
            result.Feedback.Add("Add numbers");
        }

        // Check for special characters
        if (Regex.IsMatch(password, "[!@#$%^&*]"))
        {
            result.Score++;
        }
        else
        {
            result.Feedback.Add("Add special characters (!@#$%^&*)");
        }

        // Determine validity
        result.IsValid = result.Score >= 3;

        // Add success message
        if (result.Feedback.Count == 0)
        {
            result.Feedback.Add("Password is strong!");
        }

        return result;
    }
    
    public static void Test()
    {
        Console.WriteLine("=== PASSWORD STRENGTH CHECKER ===\n");
        
        var testPasswords = new Dictionary<string, string>
        {
            ["Test 1: Empty"] = "",
            ["Test 2: Too short"] = "weak",
            ["Test 3: Only lowercase"] = "onlylowercase",
            ["Test 4: Upper and lower"] = "OnlyLower",
            ["Test 5: Good password"] = "GoodPass1",
            ["Test 6: Strong password"] = "Strong@Pass1"
        };
        
        foreach (var test in testPasswords)
        {
            Console.WriteLine($"{test.Key}: \"{test.Value}\"");
            try
            {
                var result = CheckStrength(test.Value);
                Console.WriteLine($"  Score: {result.Score}/5");
                Console.WriteLine($"  Valid: {(result.IsValid ? "✓" : "✗")}");
                Console.WriteLine("  Feedback:");
                foreach (var msg in result.Feedback)
                {
                    Console.WriteLine($"    • {msg}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("  ⚠ Error: " + ex.Message);
            }
            Console.WriteLine();
        }
    }
    
    public static void Main()
    {
        Test();
    }
}