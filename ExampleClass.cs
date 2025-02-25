using System;
using System.ComponentModel.DataAnnotations;
public class ExampleClass : IExample
{
    public int exampleInt = 23;
    private int examplePrivateInt = 34;
    public string exampleString = "Hello, World!";
    public string exampleProtectedString = "other String";
    
    [Required]
    public string ExampleInteger { get; set; }
    public ExampleClass()
    {
        ExampleInteger = "Hello, World!";
    }
    public void ExampleMethodOne()
    {
        // Code here
    }

    public int ExampleMethodTwo()
    {
        return 0;
    }
}