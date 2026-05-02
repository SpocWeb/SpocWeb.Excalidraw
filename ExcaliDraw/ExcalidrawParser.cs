using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using static org.SpocWeb.PptxToJson.ExcaliDraw.Excalidraw;

namespace org.SpocWeb.PptxToJson.ExcaliDraw;

/// <summary>
/// Parses <c>.excalidraw</c> JSON strings and files into the
/// <see cref="Document"/> object model using Newtonsoft.Json.
/// All methods are stateless and thread-safe.
/// </summary>
public static class ExcalidrawParser {
	/// <summary>
	/// Builds a <see cref="JsonSerializerSettings"/> instance configured for
	/// Excalidraw: camelCase contract resolver, null-ignoring, and the
	/// polymorphic element converter.
	/// </summary>
	private static JsonSerializerSettings BuildSettings() =>
		new JsonSerializerSettings {
			ContractResolver = new CamelCasePropertyNamesContractResolver()
			, NullValueHandling = NullValueHandling.Ignore
			, Converters = { new ExcalidrawElementConverter() }
		};

	/// <summary>
	/// Parses an <c>.excalidraw</c> JSON string into an
	/// <see cref="Document"/>.
	/// </summary>
	/// <param name="json">The full JSON text of the scene file.</param>
	/// <returns>A populated <see cref="Document"/> instance.</returns>
	/// <exception cref="JsonException">Thrown when deserialisation returns null or the JSON is malformed.</exception>
	public static Document ParseDocument(string json) =>
		JsonConvert.DeserializeObject<Document>(json, BuildSettings())
		?? throw new JsonException("Deserialisation returned null.");

	/// <summary>
	/// Parses an <c>excalidraw/clipboard</c> JSON string into an
	/// <see cref="Clipboard"/> payload.
	/// </summary>
	/// <param name="json">The clipboard JSON string.</param>
	public static Clipboard ParseClipboard(string json) =>
		JsonConvert.DeserializeObject<Clipboard>(json, BuildSettings())
		?? throw new JsonException("Deserialisation returned null.");

	/// <summary>
	/// Synchronously reads an <c>.excalidraw</c> file from disk and
	/// parses it into an <see cref="Document"/>.
	/// </summary>
	/// <param name="filePath">Absolute or relative path to the <c>.excalidraw</c> file.</param>
	public static Document ParseFile(string filePath) =>
		ParseDocument(File.ReadAllText(filePath));

	/// <summary>
	/// Asynchronously reads an <c>.excalidraw</c> file from disk and
	/// parses it into an <see cref="Document"/>.
	/// </summary>
	/// <param name="filePath">Absolute or relative path to the <c>.excalidraw</c> file.</param>
	public static Document ParseFileAsync(string filePath) => ParseDocument(File.ReadAllText(filePath));

	/// <summary>
	/// Returns <c>true</c> when the JSON string is a well-formed Excalidraw
	/// scene document (<c>type == "excalidraw"</c>, <c>version == 2</c>).
	/// </summary>
	/// <param name="json">JSON string to validate.</param>
	public static bool IsValid(string json) {
		try {
			var doc = ParseDocument(json);
			return doc.type == "excalidraw" && doc.version == 2;
		} catch {
			return false;
		}
	}
}
