using Newtonsoft.Json;
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace org.SpocWeb.PptxToJson.ExcaliDraw; 

/// <summary>Partial class hosting the Excalidraw model types: Roundness, BoundElement, PointBinding, BinaryFileData and AppState.</summary>
/// <remarks>
/// ## Meta
/// pass: 2
/// mtime: 2026-05-15T20:56:12Z
/// digest: 8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
/// updated: 2026-05-19
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T14:22:10Z
/// digest: e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855
/// </code>
/// </example>
static partial class Excalidraw {

	/// <summary>
	/// Corner-rounding configuration attached to any closed shape element.
	/// Serializes to `{ "type": number, "value"?: number }`.
	/// Source: `_ExcalidrawElementBase.roundness` in types.ts.
	/// </summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:56:12Z
	/// digest: 8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-05-24T14:22:10Z
	/// digest: 6298ab8a2f2fc4f8de29a9bcb35de669f7a95dab4d52671507298107b76d10ef
	/// </code>
	/// </example>
	public sealed class Roundness {
		/// <summary> Algorithm used to compute the corner radius. <see cref="RoundnessType"/> for values. </summary>
		public RoundnessType type { get; set; }

		/// <summary> Optional explicit radius value whose meaning depends on <see cref="type"/>.
		/// Absent when not applicable.
		/// </summary>
		public double? value { get; set; }
	}

	/// <summary> Reference from a container element to a bound arrow or text element. </summary>
	/// <remarks>
	/// Stored in <see cref="Excalidraw.Element.boundElements"/>.
	/// Unlike <see cref="PointBinding"/> which describes attached Lines.
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:56:12Z
	/// digest: 8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-05-24T14:22:10Z
	/// digest: 066472cd92cb1e65c35dcb9a7005588ea9959e360fe342f475d86a4c147ed5b0
	/// </code>
	/// </example>
	public sealed class BoundElement {
		/// <summary> ID of the bound element (arrow or text). </summary>
		public string id { get; set; }

		/// <summary> Type of the bound element: `"arrow"` or `"text"`. </summary>
		public ElementType type { get; set; }
	}

	//record BindingObject(string ElementId, double Focus, double gap);

	/// <summary> binding that attaches an arrow tip to a specific point on a bindable Shape. </summary>
	/// <remarks>
	/// Unlike <see cref="BoundElement"/> which describes nested Elements.
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:56:12Z
	/// digest: 8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-05-24T14:22:10Z
	/// digest: f516121ad2c29449876cf47ab4ab1d09e250672aef71db59b59eff38fe7d4a70
	/// </code>
	/// </example>
	public sealed class PointBinding {

		/// <summary> Initializes an empty, unbound <see cref="PointBinding"/>. </summary>
		public PointBinding(){}
		/// <summary> Initializes a <see cref="PointBinding"/> attaching to <paramref name="ElementId"/>. </summary>
		public PointBinding(string? ElementId, double Focus = 0, double Gap = 0) {
			elementId= ElementId;
			focus = Focus;
			gap = Gap;
		}

		/// <summary> ID of the bound target element. </summary>
		public string? elementId { get; set; }

		/// <summary> indicates where along the bound element’s perimeter/axis the arrow attaches </summary>
		public double focus { get; set; }

		/// <summary> distance between the arrow endpoint and the bound element. Commonly this is 0 for a visually attached connector </summary>
		public double gap { get; set; }

		/// <summary> [x, y] fixed point Normalized to the bound element's width and height (typically 0.0–1.0). </summary>
		/// <remarks>
		/// used when the binding should stay attached to a specific point rather than being freely recalculated around the Border.
		/// </remarks>
		public double[]? fixedPoint { get; set; }

		/// <summary> Binding mode: `"inside"` allows the arrow tip inside the shape;
		/// `"orbit"` keeps it on the outline; `"skip"` disables attachment.
		/// </summary>
		/// <remarks>
		/// it is ephemeral and never written to the file.
		/// </remarks>
		public string? mode { get; set; } = "orbit";
	}

	/// <summary>
	/// Binary file entry stored in the document-level `files` map.
	/// Keyed by a SHA-1 FileId string.
	/// Source: `BinaryFileData` in excalidraw/types.ts.
	/// </summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:56:12Z
	/// digest: 8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-05-24T14:22:10Z
	/// digest: 1eac90f0ec8e34ad3b55f8771984b54d2ceb72c1fa044a7f0a547e69c59ffa07
	/// </code>
	/// </example>
	public sealed class BinaryFileData {
		/// <summary>
		/// MIME type of the file, e.g. `"image/png"`, `"image/svg+xml"`.
		/// JSON key: `"mimeType"`.
		/// </summary>
		public string mimeType { get; set; }

		/// <summary>
		/// SHA-1 FileId that matches the key in the `files` map.
		/// JSON key: `"id"`.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Base-64 data URL of the file content, e.g.
		/// `"data:image/png;base64,..."`.
		/// JSON key: `"dataURL"`.
		/// <para>
		/// Note: C# name `DataURL` → first char lowercased → `dataURL`. ✓
		/// </para>
		/// </summary>
		public string DataURL { get; set; }

		/// <summary>
		/// Unix epoch timestamp (ms) when this file was created.
		/// JSON key: `"created"`.
		/// </summary>
		public long created { get; set; }

		/// <summary>
		/// Unix epoch timestamp (ms) of the last retrieval from storage.
		/// Used to decide whether unused files may be deleted.
		/// JSON key: `"lastRetrieved"`.
		/// </summary>
		public long? lastRetrieved { get; set; }

		/// <summary>
		/// Optional schema version of the file data.
		/// Incremented when the dataURL changes due to a restore migration.
		/// JSON key: `"version"`.
		/// </summary>
		public int? version { get; set; }
	}

	/// <summary> Serializable subset of editor application state written to disk. </summary>
	/// <remarks>
	/// Ephemeral UI state (selection, cursor, viewport offsets) is stripped
	/// by `cleanAppStateForExport()` before serialisation.
	///
	/// Source: `AppState` interface in excalidraw/types.ts.
	/// (background colour, grid size, theme, tool preferences, etc.).
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:56:12Z
	/// digest: 8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-05-24T14:22:10Z
	/// digest: 19ef3883807c7171bfb6b9adeeabf68538a91dab0e791756b9390739121ce6cb
	/// </code>
	/// </example>
	public sealed class AppState {
		/// <summary>
		/// Background colour of the canvas viewport (CSS colour string).
		/// JSON key: `"viewBackgroundColor"`.
		/// </summary>
		public string viewBackgroundColor { get; set; }

		/// <summary>
		/// Grid cell size in pixels. `null` indicates grid is disabled.
		/// JSON key: `"gridSize"`.
		/// </summary>
		public int? gridSize { get; set; }

		/// <summary>
		/// Number of grid cells per major grid line.
		/// JSON key: `"gridStep"`.
		/// </summary>
		public int? gridStep { get; set; }

		/// <summary>
		/// Active UI theme: `"light"` or `"dark"`.
		/// JSON key: `"theme"`.
		/// </summary>
		public string theme { get; set; }

		/// <summary>Stroke colour applied to newly created items. JSON key: `"currentItemStrokeColor"`.</summary>
		public string currentItemStrokeColor { get; set; }

		/// <summary>Fill colour applied to newly created items. JSON key: `"currentItemBackgroundColor"`.</summary>
		public string currentItemBackgroundColor { get; set; }

		/// <summary>Fill style applied to newly created items. JSON key: `"currentItemFillStyle"`.</summary>
		public string currentItemFillStyle { get; set; }

		/// <summary>Stroke width applied to newly created items (px). JSON key: `"currentItemStrokeWidth"`.</summary>
		public int? currentItemStrokeWidth { get; set; }

		/// <summary>Stroke dash style for newly created items. JSON key: `"currentItemStrokeStyle"`.</summary>
		public string currentItemStrokeStyle { get; set; }

		/// <summary>
		/// RoughJS roughness level (0 = architect, 1 = artist, 2 = cartoonist)
		/// for newly created items. JSON key: `"currentItemRoughness"`.
		/// </summary>
		public int? currentItemRoughness { get; set; }

		/// <summary>Opacity (0–100) for newly created items. JSON key: `"currentItemOpacity"`.</summary>
		public int? currentItemOpacity { get; set; }

		/// <summary>Font family numeric ID for newly created text. JSON key: `"currentItemFontFamily"`.</summary>
		public int? currentItemFontFamily { get; set; }

		/// <summary>Font size (px) for newly created text. JSON key: `"currentItemFontSize"`.</summary>
		public int? currentItemFontSize { get; set; }

		/// <summary>Text alignment for newly created text elements. JSON key: `"currentItemTextAlign"`.</summary>
		public string currentItemTextAlign { get; set; }

		/// <summary>
		/// Horizontal canvas scroll offset in pixels.
		/// JSON key: `"scrollX"`.
		/// </summary>
		public double? scrollX { get; set; }

		/// <summary>
		/// Vertical canvas scroll offset in pixels.
		/// JSON key: `"scrollY"`.
		/// </summary>
		public double? scrollY { get; set; }

		/// <summary>
		/// Current zoom level as `{ "value": number }`.
		/// Stored as `object` to handle both the legacy plain-number format
		/// and the current object format without a custom converter.
		/// JSON key: `"zoom"`.
		/// </summary>
		public object zoom { get; set; }

		/// <summary>
		/// Bucket for any additional appState fields not explicitly modelled here.
		/// Preserved during round-trips via Newtonsoft's extension-data mechanism.
		/// </summary>
		[JsonExtensionData]
		public IDictionary<string, object> AdditionalData { get; set; }
	}
}
