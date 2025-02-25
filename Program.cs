using System;
using System.Reflection;
using NJsonSchema;
using System.Collections.Generic;

public class Program {
    static void Main(string[] args) {
        Dictionary<string, object> tDict = new Dictionary<string, object>();
        tDict.Add("ExampleClass", new ExampleClass());
        tDict.Add("SecondExampleClass", new SecondExampleClass());
        tDict.Add("ExampleString", "Hello, World!");
        tDict.Add("ExampleSubClass", new SubExampleClass());
        // Console.WriteLine(ReflectionsInfo(tDict["ExampleClass"]));
        // Console.WriteLine(ReflectionsInfo(tDict["ExampleSubClass"]));
        DocumentationGenerator docGen = new DocumentationGenerator(tDict, "output");
        docGen.GenerateAllDocumentation();
        // foreach(var (key, value) in tDict) {
        //     Console.WriteLine(ReflectionsInfo(value));
            // Console.WriteLine("value: " + value);
        // }
    }
    public static string ReflectionsInfo(object obj)
    {
        
        Type objType = obj.GetType();
        string info = "";
        info += $"🔹 Public Properties of {objType.Name}:\n";
        // Get all public properties
        var properties = objType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in properties)
        {
            info += $"- {prop.Name}: {prop.PropertyType.Name}\n";
        }

        info += $"\n🔹 Private Properties of {objType.Name}:\n";
        var privateProperties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var prop in privateProperties)
        {
            info += $"- {prop.Name}: {prop.PropertyType.Name}\n";
        }

        info += "\n🔹 Public Methods:\n";
        // Get Public Methods
        var methods = objType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        foreach (var method in methods)
        {
            info += $"- {method.Name}()\n";
        }

        info += $"\n🔹 Private Methods of {objType.Name}:\n";
        // Get all private methods
        var privateMethods = objType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var method in privateMethods)
        {
            info += $"- {method.Name}()\n";
        }

        info += "\n🔹 Constructors & Parameters:\n";
        // Get Constructors and Parameters
        var constructors = objType.GetConstructors();
        foreach (var constructor in constructors)
        {
            var parameters = constructor.GetParameters();
            string paramList = string.Join(", ", parameters.Select(p => $"{p.ParameterType.Name} {p.Name}"));
            info += $"- Constructor({paramList})\n";
        }
        
        info += "\n🔹 Tnterfaces:\n";
        var interfaces = objType.GetInterfaces();
        foreach (var inter in interfaces)
        {
            info += $"- {inter.Name}\n";
        }

        // Get Base Class (Inheritance
        var baseType = objType.BaseType;
        if (baseType != null && baseType != typeof(object))
        {
            info += ($"🔹 Inherits From: {baseType.Name}\n");
        }
        info += "\n🔹 Inheritance Infomation\n";
        info += InheritanceRecursion(objType, objType.Name);
        return info;
    }
    public static string InheritanceRecursion(Type t, string str) {        
        var baseType = t.BaseType;
        if (baseType == null || baseType == typeof(object))
        {
            return str + $" -> {baseType.Name}";
        }
        return InheritanceRecursion(baseType, $"{str} -> {baseType.Name}");
    }
}
