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
static partial class Excalidraw {

	/// <summary>
	/// Corner-rounding configuration attached to any closed shape element.
	/// Serializes to <c>{ "type": number, "value"?: number }</c>.
	/// Source: <c>_ExcalidrawElementBase.roundness</c> in types.ts.
	/// </summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:56:12Z
	/// digest: 8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
	/// updated: 2026-05-19
	/// </remarks>
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
	public sealed class BoundElement {
		/// <summary> ID of the bound element (arrow or text). </summary>
		public string id { get; set; }

		/// <summary> Type of the bound element: <c>"arrow"</c> or <c>"text"</c>. </summary>
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

		/// <summary> Binding mode: <c>"inside"</c> allows the arrow tip inside the shape;
		/// <c>"orbit"</c> keeps it on the outline; <c>"skip"</c> disables attachment.
		/// </summary>
		/// <remarks>
		/// it is ephemeral and never written to the file.
		/// </remarks>
		public string? mode { get; set; } = "orbit";
	}

	/// <summary>
	/// Binary file entry stored in the document-level <c>files</c> map.
	/// Keyed by a SHA-1 FileId string.
	/// Source: <c>BinaryFileData</c> in excalidraw/types.ts.
	/// </summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:56:12Z
	/// digest: 8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
	/// updated: 2026-05-19
	/// </remarks>
	public sealed class BinaryFileData {
		/// <summary>
		/// MIME type of the file, e.g. <c>"image/png"</c>, <c>"image/svg+xml"</c>.
		/// JSON key: <c>"mimeType"</c>.
		/// </summary>
		public string mimeType { get; set; }

		/// <summary>
		/// SHA-1 FileId that matches the key in the <c>files</c> map.
		/// JSON key: <c>"id"</c>.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Base-64 data URL of the file content, e.g.
		/// <c>"data:image/png;base64,..."</c>.
		/// JSON key: <c>"dataURL"</c>.
		/// <para>
		/// Note: C# name <c>DataURL</c> → first char lowercased → <c>dataURL</c>. ✓
		/// </para>
		/// </summary>
		public string DataURL { get; set; }

		/// <summary>
		/// Unix epoch timestamp (ms) when this file was created.
		/// JSON key: <c>"created"</c>.
		/// </summary>
		public long created { get; set; }

		/// <summary>
		/// Unix epoch timestamp (ms) of the last retrieval from storage.
		/// Used to decide whether unused files may be deleted.
		/// JSON key: <c>"lastRetrieved"</c>.
		/// </summary>
		public long? lastRetrieved { get; set; }

		/// <summary>
		/// Optional schema version of the file data.
		/// Incremented when the dataURL changes due to a restore migration.
		/// JSON key: <c>"version"</c>.
		/// </summary>
		public int? version { get; set; }
	}

	/// <summary> Serializable subset of editor application state written to disk. </summary>
	/// <remarks>
	/// Ephemeral UI state (selection, cursor, viewport offsets) is stripped
	/// by <c>cleanAppStateForExport()</c> before serialisation.
	///
	/// Source: <c>AppState</c> interface in excalidraw/types.ts.
	/// (background colour, grid size, theme, tool preferences, etc.).
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:56:12Z
	/// digest: 8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
	/// updated: 2026-05-19
	/// </remarks>
	public sealed class AppState {
		/// <summary>
		/// Background colour of the canvas viewport (CSS colour string).
		/// JSON key: <c>"viewBackgroundColor"</c>.
		/// </summary>
		public string viewBackgroundColor { get; set; }

		/// <summary>
		/// Grid cell size in pixels. <c>null</c> indicates grid is disabled.
		/// JSON key: <c>"gridSize"</c>.
		/// </summary>
		public int? gridSize { get; set; }

		/// <summary>
		/// Number of grid cells per major grid line.
		/// JSON key: <c>"gridStep"</c>.
		/// </summary>
		public int? gridStep { get; set; }

		/// <summary>
		/// Active UI theme: <c>"light"</c> or <c>"dark"</c>.
		/// JSON key: <c>"theme"</c>.
		/// </summary>
		public string theme { get; set; }

		/// <summary>Stroke colour applied to newly created items. JSON key: <c>"currentItemStrokeColor"</c>.</summary>
		public string currentItemStrokeColor { get; set; }

		/// <summary>Fill colour applied to newly created items. JSON key: <c>"currentItemBackgroundColor"</c>.</summary>
		public string currentItemBackgroundColor { get; set; }

		/// <summary>Fill style applied to newly created items. JSON key: <c>"currentItemFillStyle"</c>.</summary>
		public string currentItemFillStyle { get; set; }

		/// <summary>Stroke width applied to newly created items (px). JSON key: <c>"currentItemStrokeWidth"</c>.</summary>
		public int? currentItemStrokeWidth { get; set; }

		/// <summary>Stroke dash style for newly created items. JSON key: <c>"currentItemStrokeStyle"</c>.</summary>
		public string currentItemStrokeStyle { get; set; }

		/// <summary>
		/// RoughJS roughness level (0 = architect, 1 = artist, 2 = cartoonist)
		/// for newly created items. JSON key: <c>"currentItemRoughness"</c>.
		/// </summary>
		public int? currentItemRoughness { get; set; }

		/// <summary>Opacity (0–100) for newly created items. JSON key: <c>"currentItemOpacity"</c>.</summary>
		public int? currentItemOpacity { get; set; }

		/// <summary>Font family numeric ID for newly created text. JSON key: <c>"currentItemFontFamily"</c>.</summary>
		public int? currentItemFontFamily { get; set; }

		/// <summary>Font size (px) for newly created text. JSON key: <c>"currentItemFontSize"</c>.</summary>
		public int? currentItemFontSize { get; set; }

		/// <summary>Text alignment for newly created text elements. JSON key: <c>"currentItemTextAlign"</c>.</summary>
		public string currentItemTextAlign { get; set; }

		/// <summary>
		/// Horizontal canvas scroll offset in pixels.
		/// JSON key: <c>"scrollX"</c>.
		/// </summary>
		public double? scrollX { get; set; }

		/// <summary>
		/// Vertical canvas scroll offset in pixels.
		/// JSON key: <c>"scrollY"</c>.
		/// </summary>
		public double? scrollY { get; set; }

		/// <summary>
		/// Current zoom level as <c>{ "value": number }</c>.
		/// Stored as <c>object</c> to handle both the legacy plain-number format
		/// and the current object format without a custom converter.
		/// JSON key: <c>"zoom"</c>.
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
