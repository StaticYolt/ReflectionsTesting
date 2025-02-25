# ExampleString (String)

## Quick Navigation
- [Properties](#properties)
- [Methods](#methods)
- [Constructors](#constructors)
- [Interfaces](#interfaces)
- [Inheritance](#inheritance)
- [Back to Index](index.md)

<a id='properties'></a>
## Properties
### Public Properties
| Name | Type | Description |
|------|------|-------------|
| Chars | `Char` | |
| Length | `Int32` | |

### Private Properties
*No private properties*

<a id='methods'></a>
## Methods
### Public Methods
| Name | Return Type | Parameters |
|------|-------------|------------|
| CompareTo | `Int32` | `Object` value |
| CompareTo | `Int32` | [`String`](ExampleString.md) strB |
| EndsWith | `Boolean` | [`String`](ExampleString.md) value |
| EndsWith | `Boolean` | [`String`](ExampleString.md) value, `StringComparison` comparisonType |
| EndsWith | `Boolean` | [`String`](ExampleString.md) value, `Boolean` ignoreCase, `CultureInfo` culture |
| EndsWith | `Boolean` | `Char` value |
| Equals | `Boolean` | `Object` obj |
| Equals | `Boolean` | [`String`](ExampleString.md) value |
| Equals | `Boolean` | [`String`](ExampleString.md) value, `StringComparison` comparisonType |
| GetHashCode | `Int32` |  |
| GetHashCode | `Int32` | `StringComparison` comparisonType |
| StartsWith | `Boolean` | [`String`](ExampleString.md) value |
| StartsWith | `Boolean` | [`String`](ExampleString.md) value, `StringComparison` comparisonType |
| StartsWith | `Boolean` | [`String`](ExampleString.md) value, `Boolean` ignoreCase, `CultureInfo` culture |
| StartsWith | `Boolean` | `Char` value |
| Clone | `Object` |  |
| CopyTo | `Void` | `Int32` sourceIndex, `Char`[] destination, `Int32` destinationIndex, `Int32` count |
| CopyTo | `Void` | Span<`Char`> destination |
| TryCopyTo | `Boolean` | Span<`Char`> destination |
| ToCharArray | `Char`[] |  |
| ToCharArray | `Char`[] | `Int32` startIndex, `Int32` length |
| GetPinnableReference | `Char&` |  |
| ToString | [`String`](ExampleString.md) |  |
| ToString | [`String`](ExampleString.md) | `IFormatProvider` provider |
| GetEnumerator | `CharEnumerator` |  |
| EnumerateRunes | `StringRuneEnumerator` |  |
| GetTypeCode | `TypeCode` |  |
| IsNormalized | `Boolean` |  |
| IsNormalized | `Boolean` | `NormalizationForm` normalizationForm |
| Normalize | [`String`](ExampleString.md) |  |
| Normalize | [`String`](ExampleString.md) | `NormalizationForm` normalizationForm |
| Insert | [`String`](ExampleString.md) | `Int32` startIndex, [`String`](ExampleString.md) value |
| PadLeft | [`String`](ExampleString.md) | `Int32` totalWidth |
| PadLeft | [`String`](ExampleString.md) | `Int32` totalWidth, `Char` paddingChar |
| PadRight | [`String`](ExampleString.md) | `Int32` totalWidth |
| PadRight | [`String`](ExampleString.md) | `Int32` totalWidth, `Char` paddingChar |
| Remove | [`String`](ExampleString.md) | `Int32` startIndex, `Int32` count |
| Remove | [`String`](ExampleString.md) | `Int32` startIndex |
| Replace | [`String`](ExampleString.md) | [`String`](ExampleString.md) oldValue, [`String`](ExampleString.md) newValue, `Boolean` ignoreCase, `CultureInfo` culture |
| Replace | [`String`](ExampleString.md) | [`String`](ExampleString.md) oldValue, [`String`](ExampleString.md) newValue, `StringComparison` comparisonType |
| Replace | [`String`](ExampleString.md) | `Char` oldChar, `Char` newChar |
| Replace | [`String`](ExampleString.md) | [`String`](ExampleString.md) oldValue, [`String`](ExampleString.md) newValue |
| ReplaceLineEndings | [`String`](ExampleString.md) |  |
| ReplaceLineEndings | [`String`](ExampleString.md) | [`String`](ExampleString.md) replacementText |
| Split | [`String`](ExampleString.md)[] | `Char` separator, `StringSplitOptions` options |
| Split | [`String`](ExampleString.md)[] | `Char` separator, `Int32` count, `StringSplitOptions` options |
| Split | [`String`](ExampleString.md)[] | `Char`[] separator |
| Split | [`String`](ExampleString.md)[] | `Char`[] separator, `Int32` count |
| Split | [`String`](ExampleString.md)[] | `Char`[] separator, `StringSplitOptions` options |
| Split | [`String`](ExampleString.md)[] | `Char`[] separator, `Int32` count, `StringSplitOptions` options |
| Split | [`String`](ExampleString.md)[] | [`String`](ExampleString.md) separator, `StringSplitOptions` options |
| Split | [`String`](ExampleString.md)[] | [`String`](ExampleString.md) separator, `Int32` count, `StringSplitOptions` options |
| Split | [`String`](ExampleString.md)[] | [`String`](ExampleString.md)[] separator, `StringSplitOptions` options |
| Split | [`String`](ExampleString.md)[] | [`String`](ExampleString.md)[] separator, `Int32` count, `StringSplitOptions` options |
| Substring | [`String`](ExampleString.md) | `Int32` startIndex |
| Substring | [`String`](ExampleString.md) | `Int32` startIndex, `Int32` length |
| ToLower | [`String`](ExampleString.md) |  |
| ToLower | [`String`](ExampleString.md) | `CultureInfo` culture |
| ToLowerInvariant | [`String`](ExampleString.md) |  |
| ToUpper | [`String`](ExampleString.md) |  |
| ToUpper | [`String`](ExampleString.md) | `CultureInfo` culture |
| ToUpperInvariant | [`String`](ExampleString.md) |  |
| Trim | [`String`](ExampleString.md) |  |
| Trim | [`String`](ExampleString.md) | `Char` trimChar |
| Trim | [`String`](ExampleString.md) | `Char`[] trimChars |
| TrimStart | [`String`](ExampleString.md) |  |
| TrimStart | [`String`](ExampleString.md) | `Char` trimChar |
| TrimStart | [`String`](ExampleString.md) | `Char`[] trimChars |
| TrimEnd | [`String`](ExampleString.md) |  |
| TrimEnd | [`String`](ExampleString.md) | `Char` trimChar |
| TrimEnd | [`String`](ExampleString.md) | `Char`[] trimChars |
| Contains | `Boolean` | [`String`](ExampleString.md) value |
| Contains | `Boolean` | [`String`](ExampleString.md) value, `StringComparison` comparisonType |
| Contains | `Boolean` | `Char` value |
| Contains | `Boolean` | `Char` value, `StringComparison` comparisonType |
| IndexOf | `Int32` | `Char` value |
| IndexOf | `Int32` | `Char` value, `Int32` startIndex |
| IndexOf | `Int32` | `Char` value, `StringComparison` comparisonType |
| IndexOf | `Int32` | `Char` value, `Int32` startIndex, `Int32` count |
| IndexOfAny | `Int32` | `Char`[] anyOf |
| IndexOfAny | `Int32` | `Char`[] anyOf, `Int32` startIndex |
| IndexOfAny | `Int32` | `Char`[] anyOf, `Int32` startIndex, `Int32` count |
| IndexOf | `Int32` | [`String`](ExampleString.md) value |
| IndexOf | `Int32` | [`String`](ExampleString.md) value, `Int32` startIndex |
| IndexOf | `Int32` | [`String`](ExampleString.md) value, `Int32` startIndex, `Int32` count |
| IndexOf | `Int32` | [`String`](ExampleString.md) value, `StringComparison` comparisonType |
| IndexOf | `Int32` | [`String`](ExampleString.md) value, `Int32` startIndex, `StringComparison` comparisonType |
| IndexOf | `Int32` | [`String`](ExampleString.md) value, `Int32` startIndex, `Int32` count, `StringComparison` comparisonType |
| LastIndexOf | `Int32` | `Char` value |
| LastIndexOf | `Int32` | `Char` value, `Int32` startIndex |
| LastIndexOf | `Int32` | `Char` value, `Int32` startIndex, `Int32` count |
| LastIndexOfAny | `Int32` | `Char`[] anyOf |
| LastIndexOfAny | `Int32` | `Char`[] anyOf, `Int32` startIndex |
| LastIndexOfAny | `Int32` | `Char`[] anyOf, `Int32` startIndex, `Int32` count |
| LastIndexOf | `Int32` | [`String`](ExampleString.md) value |
| LastIndexOf | `Int32` | [`String`](ExampleString.md) value, `Int32` startIndex |
| LastIndexOf | `Int32` | [`String`](ExampleString.md) value, `Int32` startIndex, `Int32` count |
| LastIndexOf | `Int32` | [`String`](ExampleString.md) value, `StringComparison` comparisonType |
| LastIndexOf | `Int32` | [`String`](ExampleString.md) value, `Int32` startIndex, `StringComparison` comparisonType |
| LastIndexOf | `Int32` | [`String`](ExampleString.md) value, `Int32` startIndex, `Int32` count, `StringComparison` comparisonType |

<a id='constructors'></a>
## Constructors
| Constructor | Parameters |
|------------|------------|
| String | `Char`[] value |
| String | `Char`[] value, `Int32` startIndex, `Int32` length |
| String | `Char*` value |
| String | `Char*` value, `Int32` startIndex, `Int32` length |
| String | `SByte*` value |
| String | `SByte*` value, `Int32` startIndex, `Int32` length |
| String | `SByte*` value, `Int32` startIndex, `Int32` length, `Encoding` enc |
| String | `Char` c, `Int32` count |
| String | ReadOnlySpan<`Char`> value |

<a id='interfaces'></a>
## Implemented Interfaces
- `IComparable`
- `IEnumerable`
- `IConvertible`
- IEnumerable<`Char`>
- IComparable<[`String`](ExampleString.md)>
- IEquatable<[`String`](ExampleString.md)>
- `ICloneable`
- ISpanParsable<[`String`](ExampleString.md)>
- IParsable<[`String`](ExampleString.md)>

<a id='inheritance'></a>
## Inheritance
Inherits from: `Object`
