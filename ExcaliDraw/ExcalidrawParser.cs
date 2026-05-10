using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.RegularExpressions;
using static org.SpocWeb.PptxToJson.ExcaliDraw.Excalidraw;

namespace org.SpocWeb.PptxToJson.ExcaliDraw;

/// <inheritdoc cref="ParseExcalidraw(string)"/>
public static class ExcalidrawParser {

	/// <summary> Builds new <see cref="JsonSerializerSettings"/> instance
	/// configured for Excalidraw: <BR/>
	/// - camelCase contract resolver, <BR/>
	/// - null-ignoring,  <BR/>
	/// - polymorphic element converter. <BR/>
	/// </summary>
	public static JsonSerializerSettings ExcalidrawSettings() => new() {
			ContractResolver = new CamelCasePropertyNamesContractResolver()
			, NullValueHandling = NullValueHandling.Ignore
			, Converters = { new ExcalidrawElementConverter(), new SnakeCaseEnumConverter() }
		};

	/// <summary> Converts the <paramref name="excaliDraw"/> <see cref="Document"/> to a JSON String </summary>
	public static string ToJson(this Document excaliDraw, Formatting formatting = Formatting.Indented)
		=> JsonConvert.SerializeObject(excaliDraw, formatting, ExcalidrawSettings());

	public static string ToFile(this Document excaliDraw, string filePath, Formatting formatting = Formatting.Indented)
		=> JsonConvert.SerializeObject(excaliDraw, formatting, ExcalidrawSettings());

	/// <summary> Parses an <c>.excalidraw</c> JSON string into an <see cref="Document"/>. </summary>
	/// <param name="json">The full JSON text of the scene file.</param>
	/// <returns>A populated <see cref="Document"/> instance.</returns>
	/// <exception cref="JsonException">Thrown when deserialisation returns null or the JSON is malformed.</exception>
	public static Document ParseExcalidraw(string json)
		=> JsonConvert.DeserializeObject<Document>(json, ExcalidrawSettings())
		   ?? throw new JsonException("Deserialisation returned null.");

	/// <summary> Parses an <c>excalidraw/clipboard</c> JSON string into an <see cref="Clipboard"/> payload. </summary>
	/// <param name="json">The clipboard JSON string.</param>
	public static Clipboard ParseClipboard(string json)
		=> JsonConvert.DeserializeObject<Clipboard>(json, ExcalidrawSettings())
		   ?? throw new JsonException("Deserialisation returned null.");

	/// <summary> Synchronously reads an <paramref name="excalidraw"/> file from disk and parses it into an <see cref="Document"/>. </summary>
	public static Document ParseExcalidraw(this FileInfo excalidraw)
		=> ParseExcalidraw(File.ReadAllText(excalidraw.FullName));

	/// <summary>
	/// Returns <c>true</c> when the JSON string is a well-formed Excalidraw
	/// scene document (<c>type == "excalidraw"</c>, <c>version == 2</c>).
	/// </summary>
	/// <param name="json">JSON string to validate.</param>
	public static Document? IsValid(string json) {
		try {
			return ParseExcalidraw(json);
			// doc.type == "excalidraw" && doc.version == 2;
		} catch {
			return null;
		}
	}

	/// <summary> Generates an ID from the <paramref name="label"/> that is not <see cref="used"/> yet </summary>
	public static string MakeUniqueId(this HashSet<string> used, string label, string fallback) {
		var raw = Regex.Replace(label, @"[^A-Za-z0-9_]", "_");
		if (string.IsNullOrEmpty(raw) || raw.All(c => c == '_')) {
			raw = "N_" + Regex.Replace(fallback, @"[^A-Za-z0-9_]", "_").Substring(0, Math.Min(8, fallback.Length));
		}
		if (char.IsDigit(raw[0])) {
			raw = "N" + raw;
		}
		raw = raw.Length > 40 ? raw.Substring(0, 40) : raw;
		var candidate = raw;
		var suffix = 1;
		while (used.Contains(candidate)) {
			candidate = $"{raw}_{suffix++}";
		}
		used.Add(candidate);
		return candidate;
	}
}
