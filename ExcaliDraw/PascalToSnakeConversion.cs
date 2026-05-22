using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace org.SpocWeb.PptxToJson.ExcaliDraw; 

/// <summary>Thread-safe cached PascalCase-to-snake_case conversion utilities for enum serialization.</summary>
/// <remarks>
/// ## Meta
/// pass: 2
/// mtime: 2026-05-03T17:35:31Z
/// digest: d4f126731646bc73bcfb4d9d181bb63fa8e639c8fc2319eb96508113d82ce6d5
/// updated: 2026-05-19
/// </remarks>
public static partial class PascalToSnakeConversion {

	/// <summary> Cache of (EnumType → (MemberName → SnakeCaseString)) for serialisation. </summary>
	private static readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, string>>
		ToSnakeCache = new();

	/// <summary> Cache of (EnumType → (SnakeCaseString → MemberName)) for deserialisation. </summary>
	private static readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, string>>
		FromSnakeCache = new();

	/// <summary> Regular Expression to detect a lower-case character followed by an upper-case character </summary>
	//[RegexPattern]
	public const string RxLowerUpper = "(?<=[a-z0-9])([A-Z])";

	//[GeneratedRegex(RxLowerUpper)]
	/// <summary>TODO: LLM</summary>
 	public static Regex LowerUpper() => _LowerUpper ??= new (RxLowerUpper);
	static Regex? _LowerUpper;

	/// <summary> Returns the snake_case string for a given enum member name,
	/// reading from cache or computing and storing on first access. </summary>
	public static string ToSnakeCase(this Type enumType, string memberName) {
		var forward = ToSnakeCache.GetOrAdd(enumType
			, _ => new ());

		return forward.GetOrAdd(memberName, PascalToSnake);
	}

	/// <summary> Returns the C# member name for a given snake_case string,
	/// reading from cache or computing and storing on first access.
	/// </summary>
	public static string FromSnakeCase(this Type enumType, string snake) {
		var reverse = FromSnakeCache.GetOrAdd(enumType
			, type => {
				var map = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
				foreach (var name in Enum.GetNames(type)) {
					map[PascalToSnake(name)] = name;
				}
				return map;
			});
		if (!reverse.TryGetValue(snake, out var memberName)) {
			throw new JsonException(
				$"Value \"{snake}\" is not a valid snake_case member " +
				$"of enum {enumType.Name}");
		}
		return memberName;
	}

	/// <summary> Converts a PascalCase identifier to snake_case. </summary>
	/// <remarks>
	/// Inserts an underscore before each uppercase letter that follows
	/// a lowercase letter or digit, then lowercases the whole string.
	/// Examples:
	/// </remarks>
#if NUNIT
	[TestCase("CrossHatch", ExpectedResult = "cross_hatch")]
	[TestCase("CircleOutline", ExpectedResult = "circle_outline")]
	[TestCase("CardinalityOne", ExpectedResult = "cardinality_one")]
	[TestCase("ZigZag", ExpectedResult = "zig_zag")]
	[TestCase("Solid", ExpectedResult = "solid")]
	[TestCase("IFrame", ExpectedResult = "i_frame")]
#endif //NUNIT
	public static string PascalToSnake(string pascal)
		=> LowerUpper().Replace(pascal, "_$1").ToLowerInvariant();
}
