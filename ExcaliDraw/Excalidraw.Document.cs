using org.SpocWeb.root.Attributes;
using System.ComponentModel;
namespace org.SpocWeb.PptxToJson.ExcaliDraw;

/// <summary>Partial class hosting the Excalidraw scene document and clipboard types.</summary>
/// <remarks>
/// ## Meta
/// pass: 2
/// mtime: 2026-05-03T11:15:42Z
/// digest: 20970f1734f1138a24fae14a8a5d46479de0c31d4930f22a962f48fbbc1bd435
/// updated: 2026-05-19
/// </remarks>
[Facets(Layer = "domain", Status = "active", Complexity = 1)]
[Tags("code/dto")]
[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", Stale = false, Path = "ExcaliDraw/Excalidraw.Document.cs", Since = "2026-08-22")]
[System.ComponentModel.Description("Partial class hosting the Excalidraw scene document and clipboard types.")]
[Concept("excalidraw_diagram_format")]
static partial class Excalidraw {

	/// <summary> Root object for an `.excalidraw` scene file (schema version 2). </summary>
	/// <remarks>
	/// Serialises to the top-level JSON structure defined at
	/// https://docs.excalidraw.com/docs/codebase/json-schema.
	/// <br/>
	/// - The <see cref="elements"/> are flattened. <br/>
	/// - Relations are established using the <see cref="Element.id"/>. <br/>
	///  <br/>
	/// | Relation kind | Forward field | reverse field | <br/>
	/// |---|---|---| <br/>
	/// | in-text → shape | `containerId`	| `boundElements` | <br/>
	/// | Arrow   → shape | `startBinding`	/ `endBinding` | `boundElements` | <br/>
	/// | Element → frame | `frameId`		| No reverse field on frame | <br/>
	/// | Element → group | `groupIds`		| grouping, no object with props  | <br/>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-03T11:15:42Z
	/// digest: 20970f1734f1138a24fae14a8a5d46479de0c31d4930f22a962f48fbbc1bd435
	/// updated: 2026-05-19
	/// </remarks>
	[Facets(Layer = "domain", Status = "active", Complexity = 2)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "7906218b504544b3aed851ec0827813c54ea8d612383d023c12a2341efb454a2", Stale = false, Path = "ExcaliDraw/Excalidraw.Document.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Root object for an `.excalidraw` scene file (schema version 2).")]
	[Concept("excalidraw_diagram_format")]
	public sealed class Document {

		/// <summary> Format discriminator. Always `"excalidraw"` for scene files. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Format discriminator.")]
		[Concept("excalidraw_diagram_format")]
		public string type { get; set; } = "excalidraw";

		/// <summary> Schema version number, currently always `2`. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Schema version number, currently always `2`.")]
		[Concept("excalidraw_diagram_format")]
		public int version { get; set; } = 2;

		/// <summary> Origin URL of the Excalidraw application that produced this file </summary>
		/// <remarks>
		/// e.g. `"https://excalidraw.com"`. JSON key: `"source"`.
		/// </remarks>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Origin URL of the Excalidraw application that produced this file")]
		[Concept("excalidraw_diagram_format")]
		public string source { get; set; } = "https://excalidraw.com";

		//public Document(AppState AppState) { appState = AppState; }

		/// <summary> All non-deleted canvas elements. </summary>
		/// <remarks>
		/// Deleted elements are stripped by `serializeAsJSON()` before writing to disk.
		/// </remarks>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("All non-deleted canvas elements.")]
		[Concept("excalidraw_diagram_format")]
		public List<Element> elements { get; set; } = new();

		/// <summary> Serializable subset of editor <see cref="AppState"/> </summary>
		/// <remarks>
		/// Ephemeral UI state is stripped before serialisation. JSON key: `"appState"`.
		/// </remarks>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Serializable subset of editor AppState")]
		[Concept("excalidraw_diagram_format")]
		public AppState appState { get; set; }

		/// <summary> Map of FileId → binary file data for all <see cref="ImageElement"/>s </summary>
		/// <remarks>
		/// Keyed by SHA-1 FileId strings. JSON key: `"files"`.
		/// </remarks>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Map of FileId → binary file data for all ImageElements")]
		[Concept("excalidraw_diagram_format")]
		public Dictionary<string, BinaryFileData> files { get; set; } = new();
	}

	/// <summary> Clipboard-format variant produced when copying selected elements. </summary>
	/// <remarks>
	/// Type field is `"excalidraw/clipboard"` instead of `"excalidraw"`.
	/// Source: clipboard.ts in the Excalidraw codebase.
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-03T11:15:42Z
	/// digest: 20970f1734f1138a24fae14a8a5d46479de0c31d4930f22a962f48fbbc1bd435
	/// updated: 2026-05-19
	/// </remarks>
	[Facets(Layer = "domain", Status = "active", Complexity = 2)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "a6ccdd4824f49a12a5e5779b1929ceec8be10e27839735e165e1e743670ed7c9", Stale = false, Path = "ExcaliDraw/Excalidraw.Document.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Clipboard-format variant produced when copying selected elements.")]
	[Concept("excalidraw_diagram_format")]
	public sealed class Clipboard {

		/// <summary> Format discriminator. Always `"excalidraw/clipboard"`. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Format discriminator.")]
		[Concept("excalidraw_diagram_format")]
		public string type { get; set; } = "excalidraw/clipboard";

		/// <summary>
		/// The copied canvas elements. `frameId` is stripped from elements
		/// that were copied without their containing frame.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("The copied canvas elements.")]
		[Concept("excalidraw_diagram_format")]
		public List<Element> elements { get; set; } = new();

		/// <summary> Binary file data for any <see cref="ImageElement"/>s in <see cref="elements"/>. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Binary file data for any ImageElements in elements.")]
		[Concept("excalidraw_diagram_format")]
		public Dictionary<string, BinaryFileData> files { get; set; } = new();
	}
}
