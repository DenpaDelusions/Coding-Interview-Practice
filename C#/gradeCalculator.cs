/*
 * GradeCalculator - Calculate statistics from student grades
 * 
 * Implement a function that processes an array of student grades
 * 
 * Requirements:
 * 1. Calculate average, highest, lowest grade
 * 2. Count how many passed (>=60) and failed (<60)
 * 3. Assign letter grades: A(90-100), B(80-89), C(70-79), D(60-69), F(<60)
 * 4. Return object with all statistics
 * 5. Handle empty array (throw ArgumentException)
 * 6. Ignore negative grades (filter them out with warnings)
 * 7. Cap grades at 100 (anything above becomes 100 with warning)
 */

using System;
using System.Collections.Generic;

public class GradeStatistics
{
    public double Average { get; set; }
    public int Highest { get; set; }
    public int Lowest { get; set; }
    public int Passed { get; set; }
    public int Failed { get; set; }
    public Dictionary<string, int> LetterGrades { get; set; }
    public int TotalValidGrades { get; set; }
    public int TotalInvalidGrades { get; set; }
    public List<string> Warnings { get; set; }
}

public class GradeCalculator
{
    public static GradeStatistics AnalyzeGrades(int[] grades)
    {
        // TODO: Implement grade analyzer
        
        // Steps to consider:
        // 1. Validate input (not null, not empty)
        // 2. Filter out invalid grades (negative, >100)
        // 3. Calculate statistics (average, highest, lowest)
        // 4. Count pass/fail
        // 5. Assign letter grades
        // 6. Track warnings for invalid grades
        // 7. Return formatted result
        
        throw new NotImplementedException();
    }
    
    public static void Test()
    {
        int[][] testCases = {
            new int[] { },
            new int[] { 95, 85, 72, 68, 45, -10, 92, 58 },
            new int[] { 100, 100, 100 },
            new int[] { 59, 60, 61 },
            new int[] { 105, 110, "abc" } // This will cause compilation error - fix it
        };
        
        foreach (var grades in testCases)
        {
            Console.WriteLine($"\nTesting: [{string.Join(", ", grades)}]");
            try
            {
                var result = AnalyzeGrades(grades);
                Console.WriteLine($"Average: {result.Average}");
                Console.WriteLine($"Highest: {result.Highest}, Lowest: {result.Lowest}");
                Console.WriteLine($"Passed: {result.Passed}, Failed: {result.Failed}");
                if (result.Warnings != null)
                {
                    Console.WriteLine("Warnings: " + string.Join(", ", result.Warnings));
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

// Expected output:
// Testing: []
// Error: Grades array cannot be empty

// Testing: [95, 85, 72, 68, 45, -10, 92, 58]
// Average: 73.57
// Highest: 95, Lowest: 45
// Passed: 5, Failed: 2
// Warnings: Ignored invalid grade: -10