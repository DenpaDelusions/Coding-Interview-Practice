using System;
using System.Collections.Generic;
using System.Linq;

public class GradeStatistics
{
    public double Average { get; set; }
    public int Highest { get; set; }
    public int Lowest { get; set; }
    public int Passed { get; set; }
    public int Failed { get; set; }
    public Dictionary<string, int> LetterGrades { get; set; } = new Dictionary<string, int>();
    public int TotalValidGrades { get; set; }
    public int TotalInvalidGrades { get; set; }
    public List<string> Warnings { get; set; }
}

public class GradeCalculator
{
    public static GradeStatistics AnalyzeGrades(int[] grades)
    {
        // Input validation
        if (grades == null)
        {
            throw new ArgumentException("Grades array cannot be null");
        }
        
        if (grades.Length == 0)
        {
            throw new ArgumentException("Grades array cannot be empty");
        }

        // Filter out invalid grades
        var validGrades = new List<int>();
        var warnings = new List<string>();
        
        foreach (var grade in grades)
        {
            if (grade < 0)
            {
                warnings.Add($"Ignored invalid grade: {grade}");
            }
            else if (grade > 100)
            {
                validGrades.Add(100);
                warnings.Add($"Capped grade at 100: {grade}");
            }
            else
            {
                validGrades.Add(grade);
            }
        }

        if (validGrades.Count == 0)
        {
            throw new ArgumentException("No valid grades to analyze");
        }

        // Calculate statistics
        var statistics = new GradeStatistics
        {
            Average = Math.Round(validGrades.Average(), 2),
            Highest = validGrades.Max(),
            Lowest = validGrades.Min(),
            Passed = validGrades.Count(g => g >= 60),
            Failed = validGrades.Count(g => g < 60),
            TotalValidGrades = validGrades.Count,
            TotalInvalidGrades = grades.Length - validGrades.Count,
            LetterGrades = new Dictionary<string, int>
            {
                ["A"] = validGrades.Count(g => g >= 90),
                ["B"] = validGrades.Count(g => g >= 80 && g < 90),
                ["C"] = validGrades.Count(g => g >= 70 && g < 80),
                ["D"] = validGrades.Count(g => g >= 60 && g < 70),
                ["F"] = validGrades.Count(g => g < 60)
            }
        };

        if (warnings.Count > 0)
        {
            statistics.Warnings = warnings;
        }

        return statistics;
    }
    
    public static void Test()
    {
        Console.WriteLine("=== STUDENT GRADE CALCULATOR ===\n");
        
        var testCases = new[]
        {
            new int[] { },
            new int[] { 95, 85, 72, 68, 45, -10, 92, 58 },
            new int[] { 100, 100, 100 },
            new int[] { 59, 60, 61 },
            new int[] { 105, 110, 75 }
        };
        
        for (int i = 0; i < testCases.Length; i++)
        {
            Console.Write($"Test {i + 1}: Input: [");
            Console.WriteLine(string.Join(", ", testCases[i]) + "]");
            
            try
            {
                var result = AnalyzeGrades(testCases[i]);
                Console.WriteLine($"  Average: {result.Average}");
                Console.WriteLine($"  Highest: {result.Highest}, Lowest: {result.Lowest}");
                Console.WriteLine($"  Passed: {result.Passed}, Failed: {result.Failed}");
                Console.WriteLine($"  Letter Grades: A:{result.LetterGrades["A"]} B:{result.LetterGrades["B"]} C:{result.LetterGrades["C"]} D:{result.LetterGrades["D"]} F:{result.LetterGrades["F"]}");
                
                if (result.Warnings != null)
                {
                    Console.WriteLine("  Warnings:");
                    foreach (var w in result.Warnings)
                    {
                        Console.WriteLine($"    • {w}");
                    }
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