using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using org.SpocWeb.root.Attributes;
using System.ComponentModel;

namespace org.SpocWeb.PptxToJson.ExcaliDraw;

/// <summary> Custom Newtonsoft <see cref="JsonConverter{T}"/> that reads the `"type"` discriminator
/// from each element token and instantiates the correct
/// <see cref="Excalidraw.Element"/> subclass before populating it.
/// Write is intentionally disabled; the default serializer handles output.
/// </summary>
/// <remarks>
/// ## Meta
/// pass: 2
/// mtime: 2026-05-04T06:50:08Z
/// digest: 6bd1a4123c70999cdb57f1abbdadef8453fec2e9a8482179d72178918f415bcd
/// updated: 2026-05-19
/// </remarks>
[DocState(Pass = 2, MTime = "2026-08-22T17:32:47Z", Digest = "2a84a6a25114a9c263a9b773430d58c6912b15c02d8902a11e54e3ee03f5c3a5", Stale = false, Path = "ExcaliDraw/ExcalidrawElementConverter.cs", Since = "2026-08-22")]
[System.ComponentModel.Description("Custom Newtonsoft JsonConverter that reads the `\"type\"` discriminator from each element token and instantiates the correct Element subclass before populating it.")]
public sealed class ExcalidrawElementConverter : JsonConverter<Excalidraw.Element> {

	/// <summary> Disable custom write path; default serialisation should be sufficient. </summary>
	[System.ComponentModel.Description("Disable custom write path; default serialisation should be sufficient.")]
	public override bool CanWrite => false;

	/// <summary>
	/// Reads the `"type"` field and populates the matching subclass.
	/// Throws <see cref="JsonException"/> for unknown type strings.
	/// </summary>
	[System.ComponentModel.Description("Reads the `\"type\"` field and populates the matching subclass.")]
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