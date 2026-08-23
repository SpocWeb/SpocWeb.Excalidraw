using Newtonsoft.Json;
using org.SpocWeb.root.Attributes;
using System.ComponentModel;
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
[DocState(Pass = 2, MTime = "2026-08-22T20:36:28Z", Digest = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", Stale = false, Path = "ExcaliDraw/Excalidraw.model.cs", Since = "2026-08-22")]
static partial class Excalidraw {

	/// <summary>Corner-rounding configuration attached to any closed shape element.
	/// Serializes to `{ "type": number, "value"?: number }`.
	/// Source: `_ExcalidrawElementBase.roundness` in types.ts.<br/>
	/// Algorithm used to compute the corner radius. <see cref="RoundnessType"/> for values.</summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:56:12Z
	/// digest: 8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
	/// updated: 2026-05-19
	/// </remarks>
	[DocState(Pass = 2, MTime = "2026-08-22T20:36:28Z", Digest = "ce8a1f630b9734b89db1448418014a5634797e81a7851078d02a626bfc3aa5a1", Stale = false, Path = "ExcaliDraw/Excalidraw.model.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Corner-rounding configuration attached to any closed shape element.")]
	public sealed class Roundness {
		/// <summary>Gets or sets the type.</summary>
		[System.ComponentModel.Description("Gets or sets the type.")]
		public RoundnessType type { get; set; }

		/// <summary> Optional explicit radius value whose meaning depends on <see cref="type"/>.
		/// Absent when not applicable.
		/// </summary>
		[System.ComponentModel.Description("Optional explicit radius value whose meaning depends on type.")]
		public double? value { get; set; }
	}

	/// <summary>Reference from a container element to a bound arrow or text element.<br/>
	/// ID of the bound element (arrow or text).</summary>
	/// <remarks>
	/// Stored in <see cref="Excalidraw.Element.boundElements"/>.
	/// Unlike <see cref="PointBinding"/> which describes attached Lines.
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:56:12Z
	/// digest: 8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
	/// updated: 2026-05-19
	/// </remarks>
	[DocState(Pass = 2, MTime = "2026-08-22T20:36:28Z", Digest = "0aa270a8eec5f47a19c4c7eee4fd2f4d84a9c41b72cead9eea41009ae7e9071d", Stale = false, Path = "ExcaliDraw/Excalidraw.model.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Reference from a container element to a bound arrow or text element.")]
	public sealed class BoundElement {
		/// <summary>Gets or sets the id.</summary>
		[System.ComponentModel.Description("Gets or sets the id.")]
		public string id { get; set; }

		/// <summary> Type of the bound element: `"arrow"` or `"text"`. </summary>
		[System.ComponentModel.Description("Type of the bound element: `\"arrow\"` or `\"text\"`.")]
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
	[DocState(Pass = 2, MTime = "2026-08-23T11:42:50Z", Digest = "e10b9e2acf0c4a083d79030944c19f9db15d9f05f988267a2dca5f1cba6cee08", Stale = true, Path = "ExcaliDraw/Excalidraw.model.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("binding that attaches an arrow tip to a specific point on a bindable Shape.")]
	public sealed class PointBinding {

		/// <summary>Initializes an empty, unbound <see cref="PointBinding"/>.</summary>
		[System.ComponentModel.Description("Initializes an empty, unbound PointBinding.")]
		public PointBinding(){}
		/// <summary>Initializes a <see cref="PointBinding"/> attaching to <paramref name="ElementId"/><br/>
		/// with the specified <paramref name="Focus"/> and <paramref name="Gap"/>.</summary>
		[System.ComponentModel.Description("Initializes a PointBinding attaching to ElementId  with the specified Focus and Gap.")]
		public PointBinding(string? ElementId, double Focus = 0, double Gap = 0) {
			elementId= ElementId;
			focus = Focus;
			gap = Gap;
		}

		/// <summary> ID of the bound target element. </summary>
		[System.ComponentModel.Description("ID of the bound target element.")]
		public string? elementId { get; set; }

		/// <summary> indicates where along the bound element’s perimeter/axis the arrow attaches </summary>
		[System.ComponentModel.Description("indicates where along the bound element’s perimeter/axis the arrow attaches")]
		public double focus { get; set; }

		/// <summary> distance between the arrow endpoint and the bound element. Commonly this is 0 for a visually attached connector </summary>
		[System.ComponentModel.Description("distance between the arrow endpoint and the bound element.")]
		public double gap { get; set; }

		/// <summary> [x, y] fixed point Normalized to the bound element's width and height (typically 0.0–1.0). </summary>
		/// <remarks>
		/// used when the binding should stay attached to a specific point rather than being freely recalculated around the Border.
		/// </remarks>
		[System.ComponentModel.Description("[x, y] fixed point Normalized to the bound element's width and height (typically 0.0–1.0).")]
		public double[]? fixedPoint { get; set; }

		/// <summary> Binding mode: `"inside"` allows the arrow tip inside the shape;
		/// `"orbit"` keeps it on the outline; `"skip"` disables attachment.
		/// </summary>
		/// <remarks>
		/// it is ephemeral and never written to the file.
		/// </remarks>
		[System.ComponentModel.Description("Binding mode: `\"inside\"` allows the arrow tip inside the shape; `\"orbit\"` keeps it on the outline; `\"skip\"` disables attachment.")]
		public string? mode { get; set; } = "orbit";
	}

	/// <summary>Binary file entry stored in the document-level `files` map.
	/// Keyed by a SHA-1 FileId string.
	/// Source: `BinaryFileData` in excalidraw/types.ts.<br/>
	/// MIME type of the file, e.g. `"image/png"`, `"image/svg+xml"`.
	/// JSON key: `"mimeType"`.</summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:56:12Z
	/// digest: 8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
	/// updated: 2026-05-19
	/// </remarks>
	[DocState(Pass = 2, MTime = "2026-08-23T11:34:30Z", Digest = "2f3e8196af6a5616b4815cf499df16440f7e8735e632f29997d95630ad4ab1f1", Stale = false, Path = "ExcaliDraw/Excalidraw.model.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Binary file entry stored in the document-level `files` map.")]
	public sealed class BinaryFileData {
		/// <summary>Gets or sets the mime Type.</summary>
		[System.ComponentModel.Description("Gets or sets the mime Type.")]
		public string mimeType { get; set; }

		/// <summary>
		/// SHA-1 FileId that matches the key in the `files` map.
		/// JSON key: `"id"`.
		/// </summary>
		[System.ComponentModel.Description("SHA-1 FileId that matches the key in the `files` map.")]
		public string id { get; set; }

		/// <summary>
		/// Base-64 data URL of the file content, e.g.
		/// `"data:image/png;base64,..."`.
		/// JSON key: `"dataURL"`.
		/// <para>
		/// Note: C# name `DataURL` → first char lowercased → `dataURL`. ✓
		/// </para>
		/// </summary>
		[System.ComponentModel.Description("Base-64 data URL of the file content, e.g.")]
		public string DataURL { get; set; }

		/// <summary>
		/// Unix epoch timestamp (ms) when this file was created.
		/// JSON key: `"created"`.
		/// </summary>
		[System.ComponentModel.Description("Unix epoch timestamp (ms) when this file was created.")]
		public long created { get; set; }

		/// <summary>
		/// Unix epoch timestamp (ms) of the last retrieval from storage.
		/// Used to decide whether unused files may be deleted.
		/// JSON key: `"lastRetrieved"`.
		/// </summary>
		[System.ComponentModel.Description("Unix epoch timestamp (ms) of the last retrieval from storage.")]
		public long? lastRetrieved { get; set; }

		/// <summary>
		/// Optional schema version of the file data.
		/// Incremented when the dataURL changes due to a restore migration.
		/// JSON key: `"version"`.
		/// </summary>
		[System.ComponentModel.Description("Optional schema version of the file data.")]
		public int? version { get; set; }
	}

	/// <summary>Serializable subset of editor application state written to disk.<br/>
	/// Background colour of the canvas viewport (CSS colour string).
	/// JSON key: `"viewBackgroundColor"`.</summary>
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
	[DocState(Pass = 2, MTime = "2026-08-23T11:42:50Z", Digest = "f76463adda97f8804886d29b64f7ffc72c9ea599fd1e4a42ab32302f39598161", Stale = true, Path = "ExcaliDraw/Excalidraw.model.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Serializable subset of editor application state written to disk.")]
	public sealed class AppState {
		/// <summary>Gets or sets the view Background Color.</summary>
		[System.ComponentModel.Description("Gets or sets the view Background Color.")]
		public string viewBackgroundColor { get; set; }

		/// <summary>
		/// Grid cell size in pixels. `null` indicates grid is disabled.
		/// JSON key: `"gridSize"`.
		/// </summary>
		[System.ComponentModel.Description("Grid cell size in pixels.")]
		public int? gridSize { get; set; }

		/// <summary>
		/// Number of grid cells per major grid line.
		/// JSON key: `"gridStep"`.
		/// </summary>
		[System.ComponentModel.Description("Number of grid cells per major grid line.")]
		public int? gridStep { get; set; }

		/// <summary>
		/// Active UI theme: `"light"` or `"dark"`.
		/// JSON key: `"theme"`.
		/// </summary>
		[System.ComponentModel.Description("Active UI theme: `\"light\"` or `\"dark\"`.")]
		public string theme { get; set; }

		/// <summary>Stroke colour applied to newly created items. JSON key: `"currentItemStrokeColor"`.</summary>
		[System.ComponentModel.Description("Stroke colour applied to newly created items.")]
		public string currentItemStrokeColor { get; set; }

		/// <summary>Fill colour applied to newly created items. JSON key: `"currentItemBackgroundColor"`.</summary>
		[System.ComponentModel.Description("Fill colour applied to newly created items.")]
		public string currentItemBackgroundColor { get; set; }

		/// <summary>Fill style applied to newly created items. JSON key: `"currentItemFillStyle"`.</summary>
		[System.ComponentModel.Description("Fill style applied to newly created items.")]
		public string currentItemFillStyle { get; set; }

		/// <summary>Stroke width applied to newly created items (px). JSON key: `"currentItemStrokeWidth"`.</summary>
		[System.ComponentModel.Description("Stroke width applied to newly created items (px).")]
		public int? currentItemStrokeWidth { get; set; }

		/// <summary>Stroke dash style for newly created items. JSON key: `"currentItemStrokeStyle"`.</summary>
		[System.ComponentModel.Description("Stroke dash style for newly created items.")]
		public string currentItemStrokeStyle { get; set; }

		/// <summary>
		/// RoughJS roughness level (0 = architect, 1 = artist, 2 = cartoonist)
		/// for newly created items. JSON key: `"currentItemRoughness"`.
		/// </summary>
		[System.ComponentModel.Description("RoughJS roughness level (0 = architect, 1 = artist, 2 = cartoonist) for newly created items.")]
		public int? currentItemRoughness { get; set; }

		/// <summary>Opacity (0–100) for newly created items. JSON key: `"currentItemOpacity"`.</summary>
		[System.ComponentModel.Description("Opacity (0–100) for newly created items.")]
		public int? currentItemOpacity { get; set; }

		/// <summary>Font family numeric ID for newly created text. JSON key: `"currentItemFontFamily"`.</summary>
		[System.ComponentModel.Description("Font family numeric ID for newly created text.")]
		public int? currentItemFontFamily { get; set; }

		/// <summary>Font size (px) for newly created text. JSON key: `"currentItemFontSize"`.</summary>
		[System.ComponentModel.Description("Font size (px) for newly created text.")]
		public int? currentItemFontSize { get; set; }

		/// <summary>Text alignment for newly created text elements. JSON key: `"currentItemTextAlign"`.</summary>
		[System.ComponentModel.Description("Text alignment for newly created text elements.")]
		public string currentItemTextAlign { get; set; }

		/// <summary>
		/// Horizontal canvas scroll offset in pixels.
		/// JSON key: `"scrollX"`.
		/// </summary>
		[System.ComponentModel.Description("Horizontal canvas scroll offset in pixels.")]
		public double? scrollX { get; set; }

		/// <summary>
		/// Vertical canvas scroll offset in pixels.
		/// JSON key: `"scrollY"`.
		/// </summary>
		[System.ComponentModel.Description("Vertical canvas scroll offset in pixels.")]
		public double? scrollY { get; set; }

		/// <summary>
		/// Current zoom level as `{ "value": number }`.
		/// Stored as `object` to handle both the legacy plain-number format
		/// and the current object format without a custom converter.
		/// JSON key: `"zoom"`.
		/// </summary>
		[System.ComponentModel.Description("Current zoom level as `{ \"value\": number }`.")]
		public object zoom { get; set; }

		/// <summary>
		/// Bucket for any additional appState fields not explicitly modelled here.
		/// Preserved during round-trips via Newtonsoft's extension-data mechanism.
		/// </summary>
		[System.ComponentModel.Description("Bucket for any additional appState fields not explicitly modelled here.")]
		[JsonExtensionData]
		public IDictionary<string, object> AdditionalData { get; set; }
	}
}
