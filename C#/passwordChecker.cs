/*
 * PasswordChecker - Evaluate password strength
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
 * 7. If password is empty or null, throw ArgumentException
 */

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
        // TODO: Implement password strength checker
        
        // Steps to consider:
        // 1. Validate input
        // 2. Initialize result
        // 3. Check each requirement
        // 4. Add feedback
        // 5. Determine validity
        
        throw new NotImplementedException();
    }
    
    public static void Test()
    {
        string[] testPasswords = {
            "",
            "weak",
            "onlylowercase",
            "OnlyLower",
            "GoodPass1",
            "Strong@Pass1"
        };
        
        foreach (var pwd in testPasswords)
        {
            Console.WriteLine($"\nTesting: \"{pwd}\"");
            try
            {
                var result = CheckStrength(pwd);
                Console.WriteLine($"Score: {result.Score}");
                Console.WriteLine($"Valid: {result.IsValid}");
                Console.WriteLine("Feedback: " + string.Join(", ", result.Feedback));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}