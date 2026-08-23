using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.RegularExpressions;
using static org.SpocWeb.PptxToJson.ExcaliDraw.Excalidraw;
using org.SpocWeb.root.Attributes;
using System.ComponentModel;

namespace org.SpocWeb.PptxToJson.ExcaliDraw;

/// <summary> Serializes and parses Excalidraw scene and clipboard documents to and from JSON. </summary>
/// <remarks>
/// ## Meta
/// pass: 2
/// mtime: 2026-05-15T20:56:05Z
/// digest: beb3737587544cb4f2871cfd7db7397dbf510d7d76ef91e74d4561c5a2c315bf
/// updated: 2026-05-19
/// </remarks>
[DocState(Pass = 2, MTime = "2026-08-22T20:36:28Z", Digest = "d7948bddfa4f7b7cdf2c9e3c444807d5a1e9d36be9e4aea29dee0b4806a85cdd", Stale = false, Path = "ExcaliDraw/ExcalidrawParser.cs", Since = "2026-08-22")]
[System.ComponentModel.Description("Serializes and parses Excalidraw scene and clipboard documents to and from JSON.")]
public static class ExcalidrawParser {

	/// <summary> Builds new <see cref="JsonSerializerSettings"/> instance
	/// configured for Excalidraw: <BR/>
	/// - camelCase contract resolver, <BR/>
	/// - null-ignoring,  <BR/>
	/// - polymorphic element converter. <BR/>
	/// </summary>
	[System.ComponentModel.Description("Builds new JsonSerializerSettings instance configured for Excalidraw:   - camelCase contract resolver,   - null-ignoring,    - polymorphic element converter.")]
	public static JsonSerializerSettings ExcalidrawSettings() => new() {
			ContractResolver = new CamelCasePropertyNamesContractResolver()
			, NullValueHandling = NullValueHandling.Ignore
			, Converters = { new ExcalidrawElementConverter(), new SnakeCaseEnumConverter() }
		};

	/// <summary> Converts the <paramref name="excaliDraw"/> <see cref="Document"/> to a JSON String </summary>
	[System.ComponentModel.Description("Converts the excaliDraw Document to a JSON String")]
	public static string ToJson(this Document excaliDraw, Formatting formatting = Formatting.Indented)
		=> JsonConvert.SerializeObject(excaliDraw, formatting, ExcalidrawSettings());

	/// <summary> Serializes the <paramref name="excaliDraw"/> document to a JSON string and writes it to <paramref name="filePath"/>. </summary>
	[System.ComponentModel.Description("Serializes the excaliDraw document to a JSON string and writes it to filePath.")]
	public static string ToFile(this Document excaliDraw, string filePath, Formatting formatting = Formatting.Indented)
		=> JsonConvert.SerializeObject(excaliDraw, formatting, ExcalidrawSettings());

	/// <summary> Parses an `.excalidraw` JSON string into an <see cref="Document"/>. </summary>
	/// <param name="json">The full JSON text of the scene file.</param>
	/// <returns>A populated <see cref="Document"/> instance.</returns>
	/// <exception cref="JsonException">Thrown when deserialisation returns null or the JSON is malformed.</exception>
	[System.ComponentModel.Description("Parses an `.excalidraw` JSON string into an Document.")]
	public static Document ParseExcalidraw(string json)
		=> JsonConvert.DeserializeObject<Document>(json, ExcalidrawSettings())
		   ?? throw new JsonException("Deserialisation returned null.");

	/// <summary> Parses an `excalidraw/clipboard` JSON string into an <see cref="Clipboard"/> payload. </summary>
	/// <param name="json">The clipboard JSON string.</param>
	[System.ComponentModel.Description("Parses an `excalidraw/clipboard` JSON string into an Clipboard payload.")]
	public static Clipboard ParseClipboard(string json)
		=> JsonConvert.DeserializeObject<Clipboard>(json, ExcalidrawSettings())
		   ?? throw new JsonException("Deserialisation returned null.");

	/// <summary> Synchronously reads an <paramref name="excalidraw"/> file from disk and parses it into an <see cref="Document"/>. </summary>
	[System.ComponentModel.Description("Synchronously reads an excalidraw file from disk and parses it into an Document.")]
	public static Document ParseExcalidraw(this FileInfo excalidraw)
		=> ParseExcalidraw(File.ReadAllText(excalidraw.FullName));

	/// <summary>
	/// Returns `true` when the JSON string is a well-formed Excalidraw
	/// scene document (`type == "excalidraw"`, `version == 2`).
	/// </summary>
	/// <param name="json">JSON string to validate.</param>
	[System.ComponentModel.Description("Returns `true` when the JSON string is a well-formed Excalidraw scene document (`type == \"excalidraw\"`, `version == 2`).")]
	public static Document? IsValid(string json) {
		try {
			return ParseExcalidraw(json);
			// doc.type == "excalidraw" && doc.version == 2;
		} catch {
			return null;
		}
	}

	/// <summary> Generates an ID from the <paramref name="label"/> that is not <see cref="used"/> yet </summary>
	[System.ComponentModel.Description("Generates an ID from the label that is not used yet")]
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
