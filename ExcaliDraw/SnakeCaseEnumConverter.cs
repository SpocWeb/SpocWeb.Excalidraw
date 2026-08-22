namespace org.SpocWeb.PptxToJson.ExcaliDraw;

using Newtonsoft.Json;
using System;
using org.SpocWeb.root.Attributes;
using System.ComponentModel;

/// <summary> Newtonsoft.Json converter that... </summary>
/// <remarks>
/// - serialises enum values by converting their PascalCase C# name to snake_case, <br/>
/// - and deserializes by the reverse mapping. <br/>
///
/// Note: this converter does NOT handle values whose JSON key uses a hyphen (e.g. "cross-hatch").
/// Those still require [<see cref="System.Runtime.Serialization.EnumMemberAttribute"/>].
/// ## Meta
/// pass: 2
/// mtime: 2026-05-03T17:27:38Z
/// digest: a0b69328b4d8d1e16b2115a6ad606198be0bbe56a838aa8f570d82f6958174a0
/// updated: 2026-05-19
/// </remarks>
[DocState(Pass = 2, MTime = "2026-08-22T17:32:47Z", Digest = "2bec9cc2474af270007ab0ff7d64dae4a4c7ac6a3e7f54a84bb1843eb4750047", Stale = false, Path = "ExcaliDraw/SnakeCaseEnumConverter.cs", Since = "2026-08-22")]
[System.ComponentModel.Description("Newtonsoft.Json converter that...")]
public sealed class SnakeCaseEnumConverter : JsonConverter {

	/// <summary>Handles any enum type.</summary>
	[System.ComponentModel.Description("Handles any enum type.")]
	public override bool CanConvert(Type objectType)
		=> objectType.IsEnum
		   || (Nullable.GetUnderlyingType(objectType)?.IsEnum ?? false);

	/// <summary>Writes the snake_case string for the enum value.</summary>
	[System.ComponentModel.Description("Writes the snake_case string for the enum value.")]
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
		var enumType = value.GetType();
		var memberName = Enum.GetName(enumType, value)
		                 ?? throw new JsonException(
			                 $"No name found for value {value} in {enumType.Name}");

		var snake = enumType.ToSnakeCase(memberName);
		writer.WriteValue(snake);
	}

	/// <summary>Reads a snake_case string and returns the matching enum value.</summary>
	/// <remarks>
	/// <paramref name="existingValue"/> is filled when re-using an object Reference.
	/// </remarks>
	[System.ComponentModel.Description("Reads a snake_case string and returns the matching enum value.")]
	public override object? ReadJson(JsonReader reader, Type objectType, object existingValue
		, JsonSerializer serializer) {
		var underlyingType = Nullable.GetUnderlyingType(objectType) ?? objectType;
		if (reader.TokenType == JsonToken.Null) {
			if (Nullable.GetUnderlyingType(objectType) is null) {
				throw new JsonException(
					$"Cannot assign null to non-nullable enum {objectType.Name}");
			}
			return null;
		}
		if (reader.TokenType != JsonToken.String) {
			throw new JsonException(
				$"Expected string token for enum {underlyingType.Name}, " +
				$"got {reader.TokenType}");
		}
		var snake = (string) reader.Value!;
		var memberName = underlyingType.FromSnakeCase(snake);
		return Enum.Parse(underlyingType, memberName, ignoreCase: false);
	}

}