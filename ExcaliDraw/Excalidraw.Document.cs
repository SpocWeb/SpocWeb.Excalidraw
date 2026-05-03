namespace org.SpocWeb.PptxToJson.ExcaliDraw;

static partial class Excalidraw {

	/// <summary> Root object for an <c>.excalidraw</c> scene file (schema version 2). </summary>
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
	/// </remarks>
	public sealed class Document {

		/// <summary> Format discriminator. Always <c>"excalidraw"</c> for scene files. </summary>
		public string type { get; set; } = "excalidraw";

		/// <summary> Schema version number, currently always <c>2</c>. </summary>
		public int version { get; set; } = 2;

		/// <summary> Origin URL of the Excalidraw application that produced this file </summary>
		/// <remarks>
		/// e.g. <c>"https://excalidraw.com"</c>. JSON key: <c>"source"</c>.
		/// </remarks>
		public string source { get; set; } = "https://excalidraw.com";

		//public Document(AppState AppState) { appState = AppState; }

		/// <summary> All non-deleted canvas elements. </summary>
		/// <remarks>
		/// Deleted elements are stripped by <c>serializeAsJSON()</c> before writing to disk.
		/// </remarks>
		public List<Element> elements { get; set; } = new();

		/// <summary> Serializable subset of editor <see cref="AppState"/> </summary>
		/// <remarks>
		/// Ephemeral UI state is stripped before serialisation. JSON key: <c>"appState"</c>.
		/// </remarks>
		public AppState appState { get; set; }

		/// <summary> Map of FileId → binary file data for all <see cref="ImageElement"/>s </summary>
		/// <remarks>
		/// Keyed by SHA-1 FileId strings. JSON key: <c>"files"</c>.
		/// </remarks>
		public Dictionary<string, BinaryFileData> files { get; set; } = new();
	}

	/// <summary> Clipboard-format variant produced when copying selected elements. </summary>
	/// <remarks>
	/// Type field is <c>"excalidraw/clipboard"</c> instead of <c>"excalidraw"</c>.
	/// Source: clipboard.ts in the Excalidraw codebase.
	/// </remarks>
	public sealed class Clipboard {

		/// <summary> Format discriminator. Always <c>"excalidraw/clipboard"</c>. </summary>
		public string type { get; set; } = "excalidraw/clipboard";

		/// <summary>
		/// The copied canvas elements. <c>frameId</c> is stripped from elements
		/// that were copied without their containing frame.
		/// </summary>
		public List<Element> elements { get; set; } = new();

		/// <summary> Binary file data for any <see cref="ImageElement"/>s in <see cref="elements"/>. </summary>
		public Dictionary<string, BinaryFileData> files { get; set; } = new();
	}
}
