using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
	private static JsonSerializerSettings ExcalidrawSettings() =>
		new() {
			ContractResolver = new CamelCasePropertyNamesContractResolver()
			, NullValueHandling = NullValueHandling.Ignore
			, Converters = { new ExcalidrawElementConverter() }
		};

	/// <summary> Parses an <c>.excalidraw</c> JSON string into an <see cref="ExcalidrawDocument"/>. </summary>
	/// <param name="json">The full JSON text of the scene file.</param>
	/// <returns>A populated <see cref="ExcalidrawDocument"/> instance.</returns>
	/// <exception cref="JsonException">Thrown when deserialisation returns null or the JSON is malformed.</exception>
	public static ExcalidrawDocument ParseExcalidraw(string json) =>
		JsonConvert.DeserializeObject<ExcalidrawDocument>(json, ExcalidrawSettings())
		?? throw new JsonException("Deserialisation returned null.");

	/// <summary> Parses an <c>excalidraw/clipboard</c> JSON string into an <see cref="ExcalidrawClipboard"/> payload. </summary>
	/// <param name="json">The clipboard JSON string.</param>
	public static ExcalidrawClipboard ParseClipboard(string json) =>
		JsonConvert.DeserializeObject<ExcalidrawClipboard>(json, ExcalidrawSettings())
		?? throw new JsonException("Deserialisation returned null.");

	/// <summary> Synchronously reads an <paramref name="excalidraw"/> file from disk and parses it into an <see cref="ExcalidrawDocument"/>. </summary>
	public static ExcalidrawDocument ParseExcalidraw(this FileInfo excalidraw)
		=> ParseExcalidraw(File.ReadAllText(excalidraw.FullName));

	/// <summary>
	/// Returns <c>true</c> when the JSON string is a well-formed Excalidraw
	/// scene document (<c>type == "excalidraw"</c>, <c>version == 2</c>).
	/// </summary>
	/// <param name="json">JSON string to validate.</param>
	public static ExcalidrawDocument? IsValid(string json) {
		try {
			return ParseExcalidraw(json);
			// doc.type == "excalidraw" && doc.version == 2;
		} catch {
			return null;
		}
	}
}
