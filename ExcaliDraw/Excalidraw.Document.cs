namespace org.SpocWeb.PptxToJson.ExcaliDraw;

static partial class Excalidraw {

	/// <summary> Root object for a complete <c>.excalidraw</c> scene file (schema version 2).
	/// </summary>
	/// <remarks>
	/// Serialises to the top-level JSON structure defined at
	/// https://docs.excalidraw.com/docs/codebase/json-schema.
	/// </remarks>
	public sealed class Document {
		/// <summary>
		/// Format discriminator. Always <c>"excalidraw"</c> for scene files.
		/// JSON key: <c>"type"</c>.
		/// </summary>
		public string type { get; set; } = "excalidraw";

		/// <summary>
		/// Schema version number. Currently always <c>2</c>.
		/// Checked by <c>isValidExcalidrawData()</c> on load.
		/// JSON key: <c>"version"</c>.
		/// </summary>
		public int version { get; set; } = 2;

		/// <summary>
		/// Origin URL of the Excalidraw application that produced this file,
		/// e.g. <c>"https://excalidraw.com"</c>. JSON key: <c>"source"</c>.
		/// </summary>
		public string source { get; set; } = "https://excalidraw.com";

		/// <summary>
		/// All non-deleted canvas elements. Deleted elements are stripped
		/// by <c>serializeAsJSON()</c> before writing to disk.
		/// JSON key: <c>"elements"</c>.
		/// </summary>
		public List<Element> elements { get; set; } = new();

		/// <summary> Serializable subset of editor <see cref="AppState"/> </summary>
		/// <remarks>
		/// Ephemeral UI state is stripped before serialisation. JSON key: <c>"appState"</c>.
		/// </remarks>
		public AppState appState { get; set; }

		/// <summary>
		/// Map of FileId → binary file data for all <see cref="ImageElement"/>s
		/// in the scene. Keyed by SHA-1 FileId strings. JSON key: <c>"files"</c>.
		/// </summary>
		public Dictionary<string, BinaryFileData> files { get; set; } = new();
	}

	/// <summary>
	/// Clipboard-format variant produced when copying selected elements.
	/// Type field is <c>"excalidraw/clipboard"</c> instead of <c>"excalidraw"</c>.
	/// Source: clipboard.ts in the Excalidraw codebase.
	/// </summary>
	public sealed class Clipboard {
		/// <summary>
		/// Format discriminator. Always <c>"excalidraw/clipboard"</c>.
		/// JSON key: <c>"type"</c>.
		/// </summary>
		public string type { get; set; } = "excalidraw/clipboard";

		/// <summary>
		/// The copied canvas elements. <c>frameId</c> is stripped from elements
		/// that were copied without their containing frame.
		/// JSON key: <c>"elements"</c>.
		/// </summary>
		public List<Element> elements { get; set; } = new();

		/// <summary>
		/// Binary file data for any <see cref="ImageElement"/>s in <see cref="elements"/>.
		/// JSON key: <c>"files"</c>.
		/// </summary>
		public Dictionary<string, BinaryFileData> files { get; set; } = new();
	}
}
