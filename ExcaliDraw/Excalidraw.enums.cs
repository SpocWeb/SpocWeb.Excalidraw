using System.Runtime.Serialization;

namespace org.SpocWeb.PptxToJson.ExcaliDraw; 

/// <summary> Enums and static Helper Methods to parse Excalidraw JSON </summary>
/// <remarks>
/// ## Meta
/// pass: 2
/// mtime: 2026-05-10T16:16:18Z
/// digest: ee572f5132b448e06a93d1830b2416bd13a91650e13f869a966de317fc2c8348
/// updated: 2026-05-19
/// </remarks>
static partial class Excalidraw {

	/// <summary> AKA ShapeType; Discriminates the concrete element subtype stored in the elements array.
	/// Maps 1-to-1 with the JSON "type" string field.
	/// </summary>
	public enum ElementType {
		/// <summary>Axis-aligned rectangle shape.</summary>
		rectangle,

		/// <summary>Ellipse (or circle when width == height) shape.</summary>
		ellipse,

		/// <summary>Diamond (rotated square) shape.</summary>
		diamond,

		/// <summary>
		/// Directed arrow between two points or bound elements.
		/// Supports start/end arrowheads and optional endpoint bindings.
		/// </summary>
		arrow,

		/// <summary>
		/// Undirected polyline or curved line between two or more points.
		/// No arrowheads; no endpoint bindings.
		/// </summary>
		line,

		/// <summary>
		/// Freehand stroke captured from pointer input.
		/// Stores raw points and optional pressure values.
		/// </summary>
		freedraw,

		/// <summary>Standalone or container-bound text label.</summary>
		text,

		/// <summary> Raster image referenced by a FileId key in the document's files map. </summary>
		image,

		/// <summary> Named frame that visually groups and clips a set of child elements. </summary>
		/// <remarks>
		/// Children reference the frame via their <see cref="Element.frameId"/> property.
		/// </remarks>
		frame,

		/// <summary>
		/// AI-generated magic frame; behaves like Frame but is produced
		/// by Excalidraw's generative features.
		/// </summary>
		magicframe,

		/// <summary>
		/// Embeds an external web resource (URL) rendered inside the canvas
		/// via an interactive widget.
		/// </summary>
		embeddable,

		/// <summary> Inline iframe element for embedding arbitrary HTML content directly on the canvas. </summary>
		iframe
	}

	/// <summary> Filling of the interior of a closed shape </summary>
	/// <remarks>
	/// Rendered via RoughJS fill algorithms.
	/// </remarks>
	public enum FillStyle {
		/// <summary> Single Diagonal parallel lines drawn across the interior (hatching). </summary>
		/// <remarks>
		/// This is the default fill style; gives a hand-drawn, sketchy appearance.
		/// </remarks>
		Hachure,

		/// <summary> Two overlapping sets of diagonal lines at 90° to each other, forming a grid-like cross-hatched pattern. </summary>
		[EnumMember(Value = "cross-hatch")] CrossHatch,

		/// <summary> The interior is filled with a flat, opaque colour. </summary>
		/// <remarks>
		/// No line pattern — cleanest, most print-friendly option.
		/// </remarks>
		Solid,

		/// <summary> Interior is filled with a zigzag line pattern. </summary>
		/// <remarks>
		/// Produces a more irregular, energetic texture than Hachure.
		/// </remarks>
		Zigzag
	}

	/// <summary> dash pattern applied to an element's stroke (outline). </summary>
	public enum StrokeStyle {

		/// <summary>Continuous, unbroken line. The default stroke style.</summary>
		Solid,

		/// <summary> evenly spaced dashes, to indicate optional or secondary relationships. </summary>
		Dashed,

		/// <summary> closely spaced dots; for tentative or background elements. </summary>
		Dotted
	}

	/// <summary>
	/// Decoration rendered at the start or end point of an Arrow element.
	/// The JSON field stores these as lowercase strings (e.g. "arrow", "bar").
	/// </summary>
	public enum Arrowhead {
		///// <summary>No decoration; the line ends without any marker.</summary>
		//None,

		/// <summary> A classic filled triangular arrowhead pointing in the direction of travel. </summary>
		/// <remarks>
		/// The most common endpoint marker.
		/// </remarks>
		Arrow = 1,

		/// <summary> A short perpendicular bar ("|") drawn across the endpoint. </summary>
		/// <remarks>
		/// Commonly used in entity-relationship or UML diagrams to denote "one" in cardinality notation.
		/// </remarks>
		Bar,

		/// <summary> A filled circle drawn at the endpoint. </summary>
		/// <remarks>
		/// Used in UML aggregation and ERD "zero or one" notations.
		/// </remarks>
		Circle,

		/// <summary> An outlined (hollow) circle at the endpoint. </summary>
		/// <remarks>
		/// Used in ERD "zero or many" / "zero or one" notations.
		/// </remarks>
		CircleOutline,

		/// <summary> A filled triangle larger than Arrow, pointing in the direction of travel. </summary>
		/// <remarks>
		/// Used in UML class diagrams for references and dependencies.
		/// </remarks>
		Triangle,

		/// <summary> An outlined (hollow) triangle at the endpoint. </summary>
		/// <remarks>
		/// Used in UML for inheritance and interface realization arrows.
		/// </remarks>
		TriangleOutline,

		/// <summary>A filled diamond at the endpoint.</summary>
		/// <remarks>
		/// Used in UML for composition relationships.
		/// </remarks>
		Diamond,

		/// <summary>An outlined (hollow) diamond at the endpoint.</summary>
		/// <remarks>
		/// Used in UML for aggregation relationships.
		/// </remarks>
		DiamondOutline,

		// ── Cardinality markers (ERD) ─────────────────────────────────

		/// <summary>Exactly one — a single vertical bar.</summary>
		CardinalityOne,

		/// <summary>Many — a crow's-foot (three-pronged) marker.</summary>
		CardinalityMany,

		/// <summary>One or many — crow's-foot with a single bar.</summary>
		CardinalityOneOrMany,

		/// <summary>Exactly one (mandatory) — double bar.</summary>
		CardinalityExactlyOne,

		/// <summary>Zero or one (optional one) — bar with a circle.</summary>
		CardinalityZeroOrOne,

		/// <summary>Zero or many (optional many) — crow's-foot with a circle.</summary>
		CardinalityZeroOrMany,

		[Obsolete("Use " + nameof(Circle))]
		Dot = Circle,

		[Obsolete("Use " + nameof(CardinalityOne))]
		CrowfootOne = CardinalityOne,

		[Obsolete("Use " + nameof(CardinalityMany))]
		CrowfootMany = CardinalityMany,

		[Obsolete("Use " + nameof(CardinalityOneOrMany))]
		CrowfootOneOrMany = CardinalityOneOrMany,
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
		/// <summary> 1. Virgil — Excalidraw's default hand-drawn / sketch font. </summary>
		/// <remarks>
		/// Gives diagrams their characteristic informal appearance.
		/// </remarks>
		Virgil = 1,

		/// <summary> 2. Helvetica (system sans-serif fallback). </summary>
		/// <remarks>
		/// Produces clean, professional-looking text labels.
		/// </remarks>
		Helvetica = 2,

		/// <summary> Cascadia Code — a monospace / code font. </summary>
		/// <remarks>
		/// Ideal for labelling technical or code-related diagrams.
		/// </remarks>
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

	/// <summary> Determines how corner rounding is computed for a shape. </summary>
	/// <remarks>
	/// Maps to the "type" field of the Roundness object on each element.
	/// </remarks>
	public enum RoundnessType {

		/// <summary> 1. Legacy fixed-radius rounding used by older Excalidraw versions. </summary>
		/// <remarks>
		/// A constant pixel radius is applied regardless of element size.
		/// </remarks>
		Legacy = 1,

		/// <summary> 2. Corner radius is computed as a fixed proportion of the shorter side of the element's bounding box. </summary>
		ProportionalRadius = 2,

		/// <summary> Corner radius adapts to both element size and the value stored in Roundness.Value,
		/// giving the most natural-looking corners.
		/// </summary>
		/// <remarks>
		/// Used by rectangles and diamonds in current Excalidraw versions.
		/// </remarks>
		AdaptiveRadius = 3
	}
}
