using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

public class DocumentationGenerator
{
    private Dictionary<string, Type> _typeMap;
    private string _outputDirectory;

    public DocumentationGenerator(Dictionary<string, object> instances, string outputDirectory)
    {
        _typeMap = instances.ToDictionary(
            kvp => kvp.Key, 
            kvp => kvp.Value.GetType()
        );
        _outputDirectory = outputDirectory;
        
        // Ensure output directory exists
        if (!Directory.Exists(_outputDirectory))
        {
            Directory.CreateDirectory(_outputDirectory);
        }
    }

    public void GenerateAllDocumentation()
    {
        // Generate index page
        GenerateIndexPage();
        
        // Generate individual class pages
        foreach (var kvp in _typeMap)
        {
            GenerateClassDocumentation(kvp.Key, kvp.Value);
        }
    }

    private void GenerateIndexPage()
    {
        StringBuilder index = new StringBuilder();
        index.AppendLine("# Class Documentation Index");
        index.AppendLine();
        index.AppendLine("## Available Classes");
        index.AppendLine();
        
        // Sort classes alphabetically
        var sortedClasses = _typeMap.Keys.OrderBy(k => k).ToList();
        
        foreach (var className in sortedClasses)
        {
            index.AppendLine($"- [{className}]({className}.md)");
        }
        
        File.WriteAllText(Path.Combine(_outputDirectory, "index.md"), index.ToString());
    }

    private void GenerateClassDocumentation(string className, Type type)
    {
        StringBuilder doc = new StringBuilder();
        
        // Class Header
        doc.AppendLine($"# {className} ({type.Name})");
        doc.AppendLine();
        
        // Quick Navigation
        doc.AppendLine("## Quick Navigation");
        doc.AppendLine("- [Properties](#properties)");
        doc.AppendLine("- [Methods](#methods)");
        doc.AppendLine("- [Constructors](#constructors)");
        doc.AppendLine("- [Interfaces](#interfaces)");
        doc.AppendLine("- [Inheritance](#inheritance)");
        doc.AppendLine("- [Back to Index](index.md)");
        doc.AppendLine();
        
        // Properties Section
        doc.AppendLine("<a id='properties'></a>");
        doc.AppendLine("## Properties");
        
        // Public Properties
        doc.AppendLine("### Public Properties");
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        if (properties.Length > 0)
        {
            doc.AppendLine("| Name | Type | Description |");
            doc.AppendLine("|------|------|-------------|");
            foreach (var prop in properties)
            {
                string linkedType = GetTypeLink(prop.PropertyType);
                doc.AppendLine($"| {prop.Name} | {linkedType} | |");
            }
        }
        else
        {
            doc.AppendLine("*No public properties*");
        }
        doc.AppendLine();
        
        // Private Properties (if needed)
        doc.AppendLine("### Private Properties");
        var privateProperties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
        if (privateProperties.Length > 0)
        {
            doc.AppendLine("| Name | Type |");
            doc.AppendLine("|------|------|");
            foreach (var prop in privateProperties)
            {
                string linkedType = GetTypeLink(prop.PropertyType);
                doc.AppendLine($"| {prop.Name} | {linkedType} |");
            }
        }
        else
        {
            doc.AppendLine("*No private properties*");
        }
        doc.AppendLine();
        
        // Methods Section
        doc.AppendLine("<a id='methods'></a>");
        doc.AppendLine("## Methods");
        
        // Public Methods
        doc.AppendLine("### Public Methods");
        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Where(m => !m.IsSpecialName) // Filter out property accessors
            .ToArray();
            
        if (methods.Length > 0)
        {
            doc.AppendLine("| Name | Return Type | Parameters |");
            doc.AppendLine("|------|-------------|------------|");
            foreach (var method in methods)
            {
                var parameters = method.GetParameters();
                var paramList = new List<string>();
                foreach (var param in parameters)
                {
                    string linkedParamType = GetTypeLink(param.ParameterType);
                    paramList.Add($"{linkedParamType} {param.Name}");
                }
                string paramString = string.Join(", ", paramList);
                string linkedReturnType = GetTypeLink(method.ReturnType);
                doc.AppendLine($"| {method.Name} | {linkedReturnType} | {paramString} |");
            }
        }
        else
        {
            doc.AppendLine("*No public methods*");
        }
        doc.AppendLine();
        
        // Constructors Section
        doc.AppendLine("<a id='constructors'></a>");
        doc.AppendLine("## Constructors");
        var constructors = type.GetConstructors();
        if (constructors.Length > 0)
        {
            doc.AppendLine("| Constructor | Parameters |");
            doc.AppendLine("|------------|------------|");
            foreach (var constructor in constructors)
            {
                var parameters = constructor.GetParameters();
                var paramList = new List<string>();
                foreach (var param in parameters)
                {
                    string linkedParamType = GetTypeLink(param.ParameterType);
                    paramList.Add($"{linkedParamType} {param.Name}");
                }
                string paramString = string.Join(", ", paramList);
                doc.AppendLine($"| {type.Name} | {paramString} |");
            }
        }
        else
        {
            doc.AppendLine("*No explicit constructors*");
        }
        doc.AppendLine();
        
        // Interfaces Section
        doc.AppendLine("<a id='interfaces'></a>");
        doc.AppendLine("## Implemented Interfaces");
        var interfaces = type.GetInterfaces();
        if (interfaces.Length > 0)
        {
            foreach (var inter in interfaces)
            {
                string linkedInterface = GetTypeLink(inter);
                doc.AppendLine($"- {linkedInterface}");
            }
        }
        else
        {
            doc.AppendLine("*No implemented interfaces*");
        }
        doc.AppendLine();
        
        // Inheritance Section
        doc.AppendLine("<a id='inheritance'></a>");
        doc.AppendLine("## Inheritance");
        var baseType = type.BaseType;
        if (baseType != null && baseType != typeof(object))
        {
            string linkedBaseType = GetTypeLink(baseType);
            doc.AppendLine($"Inherits from: {linkedBaseType}");
            doc.AppendLine();
            
            doc.AppendLine("### Inheritance Chain");
            doc.AppendLine("```");
            doc.AppendLine(GetInheritanceChain(type));
            doc.AppendLine("```");
        }
        else
        {
            doc.AppendLine($"Inherits from: `{typeof(object).Name}`");
        }
        
        // Write to file
        File.WriteAllText(Path.Combine(_outputDirectory, $"{className}.md"), doc.ToString());
    }

    private string GetTypeLink(Type type)
    {
        // Handle arrays, generics, etc.
        if (type.IsArray)
        {
            Type elementType = type.GetElementType();
            string elementTypeLink = GetTypeLink(elementType);
            return $"{elementTypeLink}[]";
        }
        
        if (type.IsGenericType)
        {
            Type genericTypeDef = type.GetGenericTypeDefinition();
            string genericName = genericTypeDef.Name.Split('`')[0];
            
            var genericArgs = type.GetGenericArguments();
            var linkedArgs = genericArgs.Select(GetTypeLink);
            
            return $"{genericName}<{string.Join(", ", linkedArgs)}>";
        }
        
        // Check if we have this type in our map
        var typeKey = _typeMap.FirstOrDefault(x => x.Value == type).Key;
        if (typeKey != null)
        {
            // We have this type, create a link
            return $"[`{type.Name}`]({typeKey}.md)";
        }
        
        // Regular type formatting
        return $"`{type.Name}`";
    }

    private string GetInheritanceChain(Type type)
    {
        var baseType = type.BaseType;
        if (baseType == null || baseType == typeof(object))
        {
            return $"{type.Name} → {typeof(object).Name}";
        }
        
        return $"{type.Name} → {GetInheritanceChain(baseType)}";
    }
    
    private void AppendMermaidInheritanceGraph(StringBuilder sb, Type type, HashSet<Type> processedTypes)
    {
        // Prevent infinite recursion with circular references
        if (processedTypes.Contains(type))
            return;
            
        processedTypes.Add(type);
        
        // Find the key associated with this type (if it exists in our map)
        string typeId = GetMermaidNodeId(type);
        
        // Add base class relationship
        if (type.BaseType != null && type.BaseType != typeof(object))
        {
            string baseTypeId = GetMermaidNodeId(type.BaseType);
            
            // Add the node for the current type
            sb.AppendLine($"    {typeId}[\"{type.Name}\"]");
            
            // Add the node for the base type if it's in our map
            var baseTypeKey = _typeMap.FirstOrDefault(x => x.Value == type.BaseType).Key;
            if (baseTypeKey != null)
            {
                sb.AppendLine($"    {baseTypeId}[\"{type.BaseType.Name}\"]");
                sb.AppendLine($"    click {baseTypeId} \"{baseTypeKey}.md\"");
            }
            else
            {
                sb.AppendLine($"    {baseTypeId}[\"{type.BaseType.Name}\"]");
            }
            
            // Add the inheritance link
            sb.AppendLine($"    {typeId} -->|\"inherits\"| {baseTypeId}");
            
            // Continue with base type if it's in our map
            if (baseTypeKey != null)
            {
                AppendMermaidInheritanceGraph(sb, type.BaseType, processedTypes);
            }
        }
        else
        {
            // Just add the current node
            sb.AppendLine($"    {typeId}[\"{type.Name}\"]");
            
            // Add object as base if needed
            if (type.BaseType == typeof(object))
            {
                string objectId = GetMermaidNodeId(typeof(object));
                sb.AppendLine($"    {objectId}[\"{typeof(object).Name}\"]");
                sb.AppendLine($"    {typeId} -->|\"inherits\"| {objectId}");
            }
        }
        
        // Add interfaces
        foreach (var interfaceType in type.GetInterfaces())
        {
            string interfaceId = GetMermaidNodeId(interfaceType);
            sb.AppendLine($"    {interfaceId}[\"{interfaceType.Name}\"]");
            sb.AppendLine($"    {typeId} -->|\"implements\"| {interfaceId}");
        }
        
        // Add click handler for the current type node
        var typeKey = _typeMap.FirstOrDefault(x => x.Value == type).Key;
        if (typeKey != null)
        {
            sb.AppendLine($"    click {typeId} \"{typeKey}.md\"");
        }
    }
    
    private string GetMermaidNodeId(Type type)
    {
        // Create a unique and valid mermaid node ID
        return $"{type.Name.Replace("<", "_").Replace(">", "_").Replace(".", "_")}_{Math.Abs(type.GetHashCode())}";
    }
}