namespace org.SpocWeb.PptxToJson.ExcaliDraw; 

/// <summary> Enums and static Helper Methods to parse Excalidraw JSON </summary>
static partial class Excalidraw {

	/// <summary>
	/// Discriminates the concrete element subtype stored in the elements array.
	/// Maps 1-to-1 with the JSON "type" string field.
	/// </summary>
	public enum ElementType {
		/// <summary>Axis-aligned rectangle shape.</summary>
		Rectangle,

		/// <summary>Ellipse (or circle when width == height) shape.</summary>
		Ellipse,

		/// <summary>Diamond (rotated square) shape.</summary>
		Diamond,

		/// <summary>
		/// Directed arrow between two points or bound elements.
		/// Supports start/end arrowheads and optional endpoint bindings.
		/// </summary>
		Arrow,

		/// <summary>
		/// Undirected polyline or curved line between two or more points.
		/// No arrowheads; no endpoint bindings.
		/// </summary>
		Line,

		/// <summary>
		/// Freehand stroke captured from pointer input.
		/// Stores raw points and optional pressure values.
		/// </summary>
		Freedraw,

		/// <summary>Standalone or container-bound text label.</summary>
		Text,

		/// <summary>
		/// Raster image referenced by a FileId key in the document's files map.
		/// </summary>
		Image,

		/// <summary>
		/// Named frame that visually groups and clips a set of child elements.
		/// Children reference the frame via their frameId property.
		/// </summary>
		Frame,

		/// <summary>
		/// AI-generated magic frame; behaves like Frame but is produced
		/// by Excalidraw's generative features.
		/// </summary>
		MagicFrame,

		/// <summary>
		/// Embeds an external web resource (URL) rendered inside the canvas
		/// via an interactive widget.
		/// </summary>
		Embeddable,

		/// <summary>
		/// Inline iframe element for embedding arbitrary HTML content
		/// directly on the canvas.
		/// </summary>
		IFrame
	}

	/// <summary>
	/// Controls how the interior of a closed shape is filled.
	/// Rendered via RoughJS fill algorithms.
	/// </summary>
	public enum FillStyle {
		/// <summary>
		/// Diagonal parallel lines drawn across the interior (hatching).
		/// The default fill style; gives a hand-drawn, sketchy appearance.
		/// </summary>
		Hachure,

		/// <summary>
		/// Two overlapping sets of diagonal lines at 90° to each other,
		/// forming a grid-like cross-hatched pattern.
		/// </summary>
		CrossHatch,

		/// <summary>
		/// The interior is filled with a flat, opaque colour.
		/// No line pattern — cleanest, most print-friendly option.
		/// </summary>
		Solid,

		/// <summary>
		/// Interior is filled with a zigzag line pattern.
		/// Produces a more irregular, energetic texture than Hachure.
		/// </summary>
		ZigZag
	}

	/// <summary>
	/// Controls the dash pattern applied to an element's stroke (outline).
	/// </summary>
	public enum StrokeStyle {
		/// <summary>Continuous, unbroken line. The default stroke style.</summary>
		Solid,

		/// <summary>
		/// Stroke is broken into evenly spaced dashes.
		/// Useful for indicating optional or secondary relationships.
		/// </summary>
		Dashed,

		/// <summary>
		/// Stroke is broken into closely spaced dots.
		/// Typically used for tentative or background elements.
		/// </summary>
		Dotted
	}

	/// <summary>
	/// Decoration rendered at the start or end point of an Arrow element.
	/// The JSON field stores these as lowercase strings (e.g. "arrow", "bar").
	/// </summary>
	public enum Arrowhead {
		/// <summary>No decoration; the line ends without any marker.</summary>
		None,

		/// <summary>
		/// A classic filled triangular arrowhead pointing in the direction
		/// of travel. The most common endpoint marker.
		/// </summary>
		Arrow,

		/// <summary>
		/// A short perpendicular bar ("|") drawn across the endpoint.
		/// Commonly used in entity-relationship or UML diagrams to denote
		/// "one" in cardinality notation.
		/// </summary>
		Bar,

		/// <summary>
		/// A filled circle drawn at the endpoint.
		/// Used in UML aggregation and ERD "zero or one" notations.
		/// </summary>
		Circle,

		/// <summary>
		/// A filled triangle larger than Arrow, pointing in the direction
		/// of travel. Used in UML class diagrams for inheritance.
		/// </summary>
		Triangle,

		/// <summary>
		/// An outlined (hollow) circle at the endpoint.
		/// Used in ERD "zero or many" / "zero or one" notations.
		/// </summary>
		CircleOutline,

		/// <summary>
		/// An outlined (hollow) triangle at the endpoint.
		/// Used in UML for interface realization / dependency arrows.
		/// </summary>
		TriangleOutline
	}

	/// <summary>Horizontal alignment of text within its bounding box.</summary>
	public enum TextAlign {
		/// <summary>Text is aligned to the left edge of the bounding box.</summary>
		left,

		/// <summary>Text is horizontally centred within the bounding box.</summary>
		center,

		/// <summary>Text is aligned to the right edge of the bounding box.</summary>
		right
	}

	/// <summary>Vertical alignment of text within its bounding box or container shape.</summary>
	public enum VerticalAlign {
		/// <summary>Text is pinned to the top edge of the bounding box.</summary>
		Top,

		/// <summary>Text is vertically centred within the bounding box.</summary>
		Middle,

		/// <summary>Text is pinned to the bottom edge of the bounding box.</summary>
		Bottom
	}

	/// <summary>
	/// Built-in font families available in Excalidraw.
	/// The integer values match the fontFamily field in the JSON.
	/// </summary>
	public enum FontFamily {
		/// <summary>
		/// Virgil — Excalidraw's default hand-drawn / sketch font.
		/// Gives diagrams their characteristic informal appearance.
		/// JSON value: 1.
		/// </summary>
		Virgil = 1,

		/// <summary>
		/// Helvetica (system sans-serif fallback).
		/// Produces clean, professional-looking text labels.
		/// JSON value: 2.
		/// </summary>
		Helvetica = 2,

		/// <summary>
		/// Cascadia Code — a monospace / code font.
		/// Ideal for labelling technical or code-related diagrams.
		/// JSON value: 3.
		/// </summary>
		Cascadia = 3
	}

	/// <summary>Load/persistence state of an Image element's binary data.</summary>
	public enum ImageStatus {
		/// <summary>
		/// The image has been referenced but its binary data has not yet
		/// been fetched or confirmed as available.
		/// </summary>
		Pending,

		/// <summary>
		/// The binary data has been successfully stored in the document's
		/// files map and is ready for rendering.
		/// </summary>
		Saved,

		/// <summary>
		/// The image could not be loaded or saved; it may display a
		/// placeholder or broken-image indicator on the canvas.
		/// </summary>
		Error
	}

	/// <summary>
	/// Determines how corner rounding is computed for a shape.
	/// Maps to the "type" field of the Roundness object on each element.
	/// </summary>
	public enum RoundnessType {
		/// <summary>
		/// Legacy fixed-radius rounding used by older Excalidraw versions.
		/// A constant pixel radius is applied regardless of element size.
		/// JSON value: 1.
		/// </summary>
		Legacy = 1,

		/// <summary>
		/// Corner radius is computed as a fixed proportion of the shorter
		/// side of the element's bounding box.
		/// JSON value: 2.
		/// </summary>
		ProportionalRadius = 2,

		/// <summary>
		/// Corner radius adapts to both element size and the value stored
		/// in Roundness.Value, giving the most natural-looking corners.
		/// Used by rectangles and diamonds in current Excalidraw versions.
		/// JSON value: 3.
		/// </summary>
		AdaptiveRadius = 3
	}
}
