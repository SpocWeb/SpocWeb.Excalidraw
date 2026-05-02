using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace org.SpocWeb.PptxToJson.ExcaliDraw; 

/// <summary>
/// Custom Newtonsoft.Json converter that reads the <c>"type"</c> discriminator
/// from each element token and instantiates the correct
/// <see cref="Excalidraw.Element"/> subclass before populating it.
/// Write is intentionally disabled; the default serialiser handles output.
/// </summary>
public sealed class ExcalidrawElementConverter : JsonConverter<Excalidraw.Element> {
	/// <summary>
	/// Disable custom write path; default serialisation is sufficient.
	/// </summary>
	public override bool CanWrite => false;

	/// <summary>
	/// Reads the <c>"type"</c> field and populates the matching subclass.
	/// Throws <see cref="JsonException"/> for unknown type strings.
	/// </summary>
	public override Excalidraw.Element ReadJson(
		JsonReader reader, Type objectType,
		Excalidraw.Element existingValue, bool hasExistingValue,
		JsonSerializer serializer) {
		var token = JObject.Load(reader);
		var typeValue = token["type"]?.Value<string>() ?? string.Empty;

		Excalidraw.Element element = typeValue switch {
			"rectangle" => new Excalidraw.RectangleElement()
			, "ellipse" => new Excalidraw.EllipseElement()
			, "diamond" => new Excalidraw.DiamondElement()
			, "arrow" => new Excalidraw.Arrow()
			, "line" => new Excalidraw.LineElement()
			, "freedraw" => new Excalidraw.FreedrawElement()
			, "text" => new Excalidraw.TextElement(), "image" => new Excalidraw.ImageElement()
			, "frame" => new Excalidraw.FrameElement()
			, "magicframe" => new Excalidraw.MagicFrameElement()
			, "embeddable" => new Excalidraw.EmbeddableElement()
			, "iframe" => new Excalidraw.IFrameElement(), _ => throw new JsonException(
				$"Unrecognised Excalidraw element type: '{typeValue}'")
		};

		serializer.Populate(token.CreateReader(), element);
		return element;
	}

	/// <inheritdoc/>
	public override void WriteJson(
		JsonWriter writer, Excalidraw.Element value, JsonSerializer serializer)
		=> throw new NotSupportedException(
			"ExcalidrawElementConverter is read-only; use default serialisation.");
}