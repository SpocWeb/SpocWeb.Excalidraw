using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace org.SpocWeb.PptxToJson.ExcaliDraw; 

/// <summary>Partial class hosting all Excalidraw element types and their base class.</summary>
/// <remarks>
/// ## Meta
/// pass: 2
/// mtime: 2026-05-15T20:57:01Z
/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
/// updated: 2026-05-19
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-06-09T16:07:57Z
/// digest: aae77790dca39822d58425f311debad3aa038613e851567102d04737ebb581df
/// </code>
/// </example>
public static partial class Excalidraw{

	/// <summary>Rounds a floating-point value for JSON output.</summary>
	public static double Round(double value, int digits = 2)
		=> Math.Round(value, digits, MidpointRounding.AwayFromZero);

	/// <summary> Graphic Element Base-Class of <see cref="type"/> </summary>
	/// <summary>
	/// Properties shared by every Excalidraw element regardless of type.
	/// Corresponds to `_ExcalidrawElementBase` in types.ts.
	/// Property names match JSON camelCase keys exactly via <see cref="CamelCasePropertyNamesContractResolver"/>
	/// (first char lowercased).
	/// </summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:57:01Z
	/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-09T16:07:57Z
	/// digest: 00dd43a41bb2f6dc3a49516a6087b402fc7d1bf4ac21534f92776bf278557879
	/// </code>
	/// </example>
	public class Element {

		/// <summary> Debuggable String Representation </summary>
		public override string ToString() => JsonConvert.SerializeObject(this, Formatting.None, ExcalidrawParser.ExcalidrawSettings());

		/// <summary>Unique element identifier (random string). JSON key: `"id"`.</summary>
		public string id { get; set; }

		/// <summary> Element type discriminator matching the JSON `"type"` string. </summary>
		/// <remarks>
		/// Used by <see cref="ExcalidrawElementConverter"/> for polymorphic deserialisation.
		/// </remarks>
		public ElementType type { get; set; }

		/// <summary>Left edge of the element's bounding box in canvas coordinates (px). JSON key: `"x"`.</summary>
		public double x { get; set; }

		/// <summary>Top edge of the element's bounding box in canvas coordinates (px). JSON key: `"y"`.</summary>
		public double y { get; set; }

		/// <summary>Width of the element's bounding box (px). JSON key: `"width"`.</summary>
		public double width { get; set; }

		/// <summary>Height of the element's bounding box (px). JSON key: `"height"`.</summary>
		public double height { get; set; }

		/// <summary>
		/// Rotation angle in radians (clockwise from 12 o'clock).
		/// JSON key: `"angle"`.
		/// </summary>
		public double angle { get; set; }

		/// <summary>CSS colour string for the element's stroke/outline. JSON key: `"strokeColor"`.</summary>
		public string strokeColor { get; set; }

		/// <summary>CSS colour string for the element's fill. JSON key: `"backgroundColor"`.</summary>
		public string backgroundColor { get; set; }

		/// <summary>
		/// Fill pattern for the element's interior.
		/// One of `"hachure"`, `"cross-hatch"`, `"solid"`, `"zigzag"`.
		/// JSON key: `"fillStyle"`.
		/// </summary>
		public FillStyle fillStyle { get; set; }

		/// <summary>Stroke width in pixels. JSON key: `"strokeWidth"`.</summary>
		public double strokeWidth { get; set; }

		/// <summary>
		/// Dash pattern for the stroke: `"solid"`, `"dashed"`, or `"dotted"`.
		/// JSON key: `"strokeStyle"`.
		/// </summary>
		public StrokeStyle strokeStyle { get; set; }

		/// <summary>
		/// RoughJS roughness level: 0 = architect (clean), 1 = artist, 2 = cartoonist (very rough).
		/// JSON key: `"roughness"`.
		/// </summary>
		public int roughness { get; set; }

		/// <summary>
		/// Element opacity as an integer percentage (0–100).
		/// JSON key: `"opacity"`.
		/// </summary>
		public int opacity { get; set; }

		/// <summary>
		/// Corner-rounding configuration, or `null` for sharp corners.
		/// JSON key: `"roundness"`.
		/// </summary>
		public Roundness? roundness { get; set; }

		/// <summary>
		/// Random seed integer used by RoughJS to produce a stable hand-drawn shape
		/// that doesn't change across re-renders. JSON key: `"seed"`.
		/// </summary>
		public int seed { get; set; }

		/// <summary>
		/// Soft-delete flag. Deleted elements remain in the array so that
		/// collaborative peers can reconcile removals. JSON key: `"isDeleted"`.
		/// </summary>
		public bool isDeleted { get; set; }

		/// <summary> ID of the frame element that contains this element, or `null`. </summary>
		public string? frameId { get; set; }

		/// <summary> Ordered list of group IDs this element belongs to,
		/// from deepest (innermost) to shallowest (outermost). </summary>
		public List<string> groupIds { get; set; } = new();

		/// <summary> References to arrows or text elements bound to this element. </summary>
		public List<BoundElement>? boundElements { get; set; }

		/// <summary> Hyperlink URL attached to the element, or `null`. </summary>
		public string? link { get; set; }

		/// <summary> When `true`, the element cannot be selected or moved interactively. </summary>
		public bool locked { get; set; }

		/// <summary> Sequential integer incremented on every change.
		/// Used for collaborative reconciliation. JSON key: `"version"`.
		/// </summary>
		public int version { get; set; }

		/// <summary>
		/// Random integer regenerated on every change, used for deterministic
		/// reconciliation when two peers have the same version counter.
		/// </summary>
		public int versionNonce { get; set; }

		/// <summary> Unix epoch timestamp (ms) of the last element mutation. </summary>
		public long updated { get; set; }

		/// <summary> Fractional index string (rocicorp/fractional-indexing) used for
		/// stable ordering in multiplayer scenarios. JSON key: `"index"`.
		/// </summary>
		public string index { get; set; }

		/// <summary> Arbitrary host-app or plugin data attached to this element. </summary>
		public Dictionary<string, object> customData { get; set; }

		/// <summary>
		/// Catch-all bucket that preserves any unrecognised JSON fields during
		/// round-trips, ensuring forward compatibility.
		/// </summary>
		[JsonExtensionData]
		public IDictionary<string, object> AdditionalData { get; set; }

		public static string DefaultStrokeColor = "#1e1e1e";
		public static string DefaultTextColor = "#1e1e1e";
		public static string Transparent = "transparent";

		/// <summary> Minimum Constructor </summary>
		protected Element(ElementType elementType) { type = elementType; }

		/// <summary>Initializes a new instance of <see cref="Element"/> with the specified <paramref name="Id"/>, <paramref name="Type"/>, <paramref name="FrameId"/>, <paramref name="X"/>, <paramref name="Y"/>, <paramref name="StrokeWidth"/>, <paramref name="StrokeStyle"/>, <paramref name="StrokeColor"/>, <paramref name="BackgroundColor"/> and <paramref name="Opacity"/>.</summary>
		public Element(
			string Id
			, ElementType Type
			, string? FrameId
			, double X
			, double Y
			, double StrokeWidth
			, StrokeStyle StrokeStyle
			, string? StrokeColor
			, string? BackgroundColor
			, double Opacity
		) {
			id=Id;
			type= Type;
			frameId= FrameId;
			x=X;
			y=Y;
			strokeWidth=StrokeWidth;
			strokeStyle=StrokeStyle;
			strokeColor= StrokeColor;
			backgroundColor= BackgroundColor;
			opacity = (int)Opacity;
		}

		/// <summary>Initializes a new instance of <see cref="Element"/> with the specified <paramref name="type"/>, <paramref name="bounds"/>, <paramref name="context"/> and <paramref name="GroupIds"/>.</summary>
		public Element(ElementType type, ElementBounds bounds
			, IHaveSequence<int> context, List<string> GroupIds) : this(
			context.NextId(type.ToString()), type, null, Round(bounds.X), Round(bounds.Y)
			, 1d, StrokeStyle.Solid
			, DefaultStrokeColor
			, Transparent, 100) {
			roughness = 0;
			width = Round(bounds.Width);
			height = Round(bounds.Height);
			angle = Round(bounds.AngleRadians, 6);
			fillStyle = FillStyle.Solid;
			groupIds = GroupIds;
			frameId = null;
			roundness = null;
			seed = context.NextPositiveInt();
			version = 1;
			versionNonce = context.NextPositiveInt();
			isDeleted = false;
			boundElements = null;
			updated = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
			link = null;
			locked = false;
		}


		/// <summary>Deconstructs this instance into its component parts.</summary>
		public void Deconstruct(out string Id
			, out ElementType Type
			, out string? FrameId
			, out double X
			, out double Y
			, out double StrokeWidth
			, out StrokeStyle StrokeStyle
			, out string? StrokeColor
			, out string? BackgroundColor
			, out double Opacity) {
			Id = id;
			Type = type;
			FrameId = frameId;
			X = x;
			Y = y;
			StrokeWidth = strokeWidth;
			StrokeStyle = strokeStyle;
			StrokeColor = strokeColor;
			BackgroundColor = backgroundColor;
			Opacity = opacity;
		}
	}


	/// <summary>
	/// Axis-aligned rectangle shape element.
	/// No additional properties beyond the base element.
	/// JSON type: `"rectangle"`.
	/// </summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:57:01Z
	/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-09T16:07:57Z
	/// digest: dbf553a66b7a0528d1c5170ff9c4d7babdb69942e9510ce21f860c22f29736d5
	/// </code>
	/// </example>
	public sealed class RectangleElement : Element {
		/// <summary> Initializes an empty <see cref="RectangleElement"/> for JSON deserialization. </summary>
		public RectangleElement() : base(ElementType.rectangle) { }

		/// <summary> Initializes a <see cref="RectangleElement"/> from <paramref name="bounds"/> using <paramref name="context"/> for id/seed. </summary>
		public RectangleElement(ElementBounds bounds, IHaveSequence<int> context, List<string> groupIds)
			: base(ElementType.ellipse, bounds, context, groupIds) {
		}


	}

	/// <summary>
	/// Ellipse (or circle when width == height) shape element.
	/// No additional properties beyond the base element.
	/// JSON type: `"ellipse"`.
	/// </summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:57:01Z
	/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-09T16:07:57Z
	/// digest: 88ca0892e541e80785eb95b8fdc5e33df1e6841cf47beee13611a5b8c2994edf
	/// </code>
	/// </example>
	public sealed class EllipseElement : Element {
		/// <summary> Initializes an empty <see cref="EllipseElement"/> for JSON deserialization. </summary>
		public EllipseElement() : base(ElementType.ellipse) { }

		/// <summary> Initializes an <see cref="EllipseElement"/> from <paramref name="bounds"/> using <paramref name="context"/> for id/seed. </summary>
		public EllipseElement(ElementBounds bounds, IHaveSequence<int> context, List<string> groupIds)
			: base(ElementType.ellipse, bounds, context, groupIds) {
		}

	}

	/// <summary>
	/// Diamond (rotated square) shape element.
	/// No additional properties beyond the base element.
	/// JSON type: `"diamond"`.
	/// </summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:57:01Z
	/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-09T16:07:57Z
	/// digest: 938dea4088d89746c8db83fed844daa24fb2b369983d90865ab797e7acfdbf35
	/// </code>
	/// </example>
	public sealed class DiamondElement : Element {
		/// <summary> Initializes an empty <see cref="DiamondElement"/> for JSON deserialization. </summary>
		public DiamondElement() : base(ElementType.diamond) { }

		/// <summary> Initializes a <see cref="DiamondElement"/> from <paramref name="bounds"/> using <paramref name="context"/> for id/seed. </summary>
		public DiamondElement(ElementBounds bounds, IHaveSequence<int> context, List<string> groupIds)
			: base(ElementType.diamond, bounds, context, groupIds) {
		}

	}

	/// <summary> Base class for elements composed of an ordered array of points: lines and arrows. </summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:57:01Z
	/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-09T16:07:57Z
	/// digest: 14d176b2956813fd19adb4f4bebaeccb963a622777e739e9b5449a5d4daa57c7
	/// </code>
	/// </example>
	public class LinearElement : Element {

		/// <summary> Initializes an empty <see cref="LinearElement"/> for JSON deserialization. </summary>
		protected LinearElement(ElementType type) : base(type) { }

		/// <summary> Initializes a <see cref="LinearElement"/> with full styling and optional endpoint bindings. </summary>
		protected LinearElement(string id
			, ElementType elementType
			, string? frameId
			, double x
			, double y
			, double strokeWidth
			, StrokeStyle strokeStyle
			, string? strokeColor
			, double opacity
			, Arrowhead? StartArrowhead
			, Arrowhead? EndArrowhead
			, string? StartElementId
			, string? EndElementId
			//, string? label
			) : base(id, elementType, frameId, x, y, strokeWidth, strokeStyle, strokeColor, null, opacity) {
			startBinding = new PointBinding(StartElementId);
			endBinding = new PointBinding(EndElementId);
			startArrowhead = StartArrowhead;
			endArrowhead = EndArrowhead;
			//this.label = label;
		}


		/// <summary> Initializes a <see cref="LinearElement"/> from <paramref name="bounds"/> using <paramref name="context"/> for id/seed. </summary>
		public LinearElement(ElementType ElementType
			, ElementBounds bounds
			, IHaveSequence<int> context, List<string> groupIds
			, Arrowhead? StartArrowhead
			, Arrowhead? EndArrowhead
			, string? StartElementId
			, string? EndElementId
			//, string? Label
		) : base(ElementType, bounds, context, groupIds) {
			startBinding = new PointBinding(StartElementId);
			endBinding = new PointBinding(EndElementId);
			startArrowhead = StartArrowhead;
			endArrowhead = EndArrowhead;
			//label = Label;
		}

		/// <summary> Type of <see cref="Arrowhead"/> at the Line Start </summary>
		public Arrowhead? startArrowhead { get; set; }

		/// <summary> Type of <see cref="Arrowhead"/> at the Line End </summary>
		public Arrowhead? endArrowhead { get; set; }

		/// <summary>Gets or sets the label.</summary>
		[Obsolete("In earlier Versions, excalidraw stored the Label here use " + nameof(boundElements), true)]
		public string? label { get; set; }

		/// <summary> Ordered array of [x, y] point pairs in element-local coordinates. </summary>
		/// <remarks>
		/// The first point is always [0, 0]; subsequent points are relative offsets.
		/// JSON key: `"points"`.
		/// </remarks>
		public List<double[]> points { get; set; } = new();

		///// <summary> The last point that was committed to the <see cref="points"/> array during interactive creation. </summary>
		///// <remarks>
		///// Used internally; may be `null`.
		///// JSON key: `"lastCommittedPoint"`.
		///// </summary>
		//public double[]? lastCommittedPoint { get; set; }

		/// <summary> Arrow endpoint binding to the element at the start of the line.
		/// `null` when the start is unbound. JSON key: `"startBinding"`.
		/// </summary>
		public PointBinding? startBinding { get; set; }

		/// <summary> Arrow endpoint binding to the element at the end of the line.
		/// `null` when the end is unbound. JSON key: `"endBinding"`.
		/// </summary>
		public PointBinding? endBinding { get; set; }

	}

	/// <summary> Undirected straight or curved line through two or more points. </summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:57:01Z
	/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-09T16:07:57Z
	/// digest: c41e97c1cfe2e234ee1d322147ec96516e6d0ad6ed2b6faf7f2178a7b8a32522
	/// </code>
	/// </example>
	public sealed class LineElement : LinearElement {

		/// <summary>
		/// When `true`, the last point is connected back to the first
		/// to close the polyline into a polygon. JSON key: `"polygon"`.
		/// </summary>
		public bool polygon { get; set; }

		/// <summary> Initializes an empty <see cref="LineElement"/> for JSON deserialization. </summary>
		public LineElement() : base(ElementType.line) { }

		/// <summary> Initializes a <see cref="LineElement"/> with full styling parameters. </summary>
		public LineElement(string Id
			, string? FrameId
			, double X
			, double Y
			, double StrokeWidth
			, StrokeStyle StrokeStyle
			, string? StrokeColor
			, double Opacity
			//, string? Label
			)
			: base(Id, ElementType.line, FrameId, X, Y, StrokeWidth, StrokeStyle, StrokeColor, Opacity
				  , null, null, null, null//, Label
				  ) {
		}


		public LineElement(ElementBounds bounds
			, IHaveSequence<int> context, List<string> groupIds
			//, string? Label
		) : base(ElementType.line, bounds, context, groupIds
			, null, null, null, null//, Label
			) {
		}

	}

	/// <summary> Directed arrow with optional endpoint bindings and arrowhead decorations. </summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:57:01Z
	/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-09T16:07:57Z
	/// digest: 0505b14edc4bc1c1311dcf294b40ab6c8fdaa9ba194687a4c150edb0ea6dd091
	/// </code>
	/// </example>
	public sealed class Arrow : LinearElement {

		/// <summary>Initializes a new instance of <see cref="Arrow"/>.</summary>
		public Arrow() : base(ElementType.arrow) { }

		/// <summary>Initializes a new instance of <see cref="Arrow"/> with the specified <paramref name="Id"/>, <paramref name="FrameId"/>, <paramref name="X"/>, <paramref name="Y"/>, <paramref name="StrokeWidth"/>, <paramref name="StrokeStyle"/>, <paramref name="StrokeColor"/>, <paramref name="Opacity"/>, <paramref name="StartArrowhead"/>, <paramref name="EndArrowhead"/>, <paramref name="StartElementId"/> and <paramref name="EndElementId"/>.</summary>
		public Arrow(string Id
			, string? FrameId
			, double X
			, double Y
			, double StrokeWidth
			, StrokeStyle StrokeStyle
			, string? StrokeColor
			, double Opacity
			, Arrowhead? StartArrowhead
			, Arrowhead? EndArrowhead
			//, string? Label = null
			, string? StartElementId = null
			, string? EndElementId = null
		) : base(Id, ElementType.arrow, FrameId, X, Y, StrokeWidth, StrokeStyle, StrokeColor, Opacity
			, StartArrowhead, EndArrowhead, StartElementId, EndElementId//, Label
			) {
		}


		/// <summary>Initializes a new instance of <see cref="Arrow"/> with the specified <paramref name="bounds"/>, <paramref name="context"/>, <paramref name="groupIds"/>, <paramref name="StartArrowhead"/>, <paramref name="EndArrowhead"/>, <paramref name="StartElementId"/> and <paramref name="EndElementId"/>.</summary>
		public Arrow(ElementBounds bounds
			, IHaveSequence<int> context, List<string> groupIds
			, Arrowhead? StartArrowhead
			, Arrowhead? EndArrowhead
			//, string? Label
			, string? StartElementId = null
			, string? EndElementId = null
		) : base(ElementType.arrow, bounds, context, groupIds
			, StartArrowhead, EndArrowhead, StartElementId, EndElementId//, Label
			) {
		}

		/// <summary> When `true`, the arrow uses 90-degree elbow routing
		/// instead of straight or curved segments. </summary>
		public bool elbowed { get; set; }

	}

	/// <summary> Freehand stroke captured from pointer input. </summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:57:01Z
	/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-09T16:07:57Z
	/// digest: acbef79f8bd8d16fd9ddcb351f31d79eccf5d00c896cc2abb1ed1bb05fe92ce6
	/// </code>
	/// </example>
	public sealed class FreedrawElement : Element {
		/// <summary>Initializes a new instance of <see cref="FreedrawElement"/>.</summary>
		public FreedrawElement() : base(ElementType.freedraw) { }

		/// <summary>Initializes a new instance of <see cref="FreedrawElement"/> with the specified <paramref name="bounds"/>, <paramref name="context"/> and <paramref name="groupIds"/>.</summary>
		public FreedrawElement(ElementBounds bounds, IHaveSequence<int> context, List<string> groupIds)
			: base(ElementType.freedraw, bounds, context, groupIds) {
		}

		/// <summary>
		/// Ordered array of [x, y] points in canvas coordinates tracing the stroke.
		/// JSON key: `"points"`.
		/// </summary>
		public List<double[]> points { get; set; } = new();

		/// <summary>
		/// Per-point stylus pressure values (0.0–1.0) corresponding to each entry
		/// in <see cref="points"/>. Empty when <see cref="simulatePressure"/> is `true`.
		/// JSON key: `"pressures"`.
		/// </summary>
		public List<double> pressures { get; set; } = new();

		/// <summary>
		/// When `true`, pressure is algorithmically simulated rather than
		/// read from the pointer device. JSON key: `"simulatePressure"`.
		/// </summary>
		public bool simulatePressure { get; set; }
	}

	/// <summary> Text label element, either standalone or bound to a container shape. </summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:57:01Z
	/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-09T16:07:57Z
	/// digest: 9d258720f987f3053db79b3fd54f36d42dddb115cc01097b07d1197e76076842
	/// </code>
	/// </example>
	public sealed class TextElement : Element {

		/// <summary>Initializes a new instance of <see cref="TextElement"/>.</summary>
		public TextElement() : base(ElementType.text) { }

		/// <summary>Initializes a new instance of <see cref="TextElement"/> with the specified <paramref name="bounds"/>, <paramref name="context"/> and <paramref name="groupIds"/>.</summary>
		public TextElement(ElementBounds bounds, IHaveSequence<int> context, List<string> groupIds)
			: base(ElementType.text, bounds, context, groupIds) {
		}

		/// <summary> Display text content (may be wrapped). JSON key: `"text"`. </summary>
		public string text { get; set; }

		/// <summary> The full, unwrapped text before container-width wrapping is applied. </summary>
		/// <remarks>
		/// JSON key: `"originalText"`.
		/// </remarks>
		public string originalText { get; set; }

		/// <summary>Font size in pixels. JSON key: `"fontSize"`.</summary>
		public double fontSize { get; set; }

		/// <summary> Numeric font family ID matching the `FONT_FAMILY` constant. </summary>
		/// <remarks>
		/// See <see cref="FontFamily"/> enum for named values. JSON key: `"fontFamily"`.
		/// </remarks>
		public FontFamily fontFamily { get; set; }

		/// <summary> Horizontal text alignment: `"left"`, `"center"`, or `"right"`.
		/// </summary>
		public TextAlign textAlign { get; set; }

		/// <summary> Vertical text alignment within the bounding box or container:
		/// `"top"`, `"middle"`, or `"bottom"`.
		/// </summary>
		public VerticalAlign verticalAlign { get; set; }

		/// <summary> ID of the container shape this text is bound to,
		/// or `null` for standalone text. JSON key: `"containerId"`.
		/// </summary>
		public string? containerId { get; set; }

		/// <summary>
		/// When `true`, the container shape resizes to fit the text.
		/// When `false`, text wraps to fit the container width.
		/// </summary>
		public bool autoResize { get; set; }

		/// <summary>
		/// Unitless line-height multiplier (W3C convention).
		/// Multiply by <see cref="fontSize"/> to obtain the line height in pixels.
		/// </summary>
		public double lineHeight { get; set; }

		/// <summary> Position of the first Text Line; typ: FontSize </summary>
		public double baseline { get ; set ; }
	}

	/// <summary> Raster image whose binary content is stored in the document-level `files` map keyed by <see cref="fileId"/>. </summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:57:01Z
	/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-09T16:07:57Z
	/// digest: 3a1be6f68af968b21632c4483879c2519fe1c1f69b07f79774f705bfda1ba1a4
	/// </code>
	/// </example>
	public sealed class ImageElement : Element {

		/// <summary>Initializes a new instance of <see cref="ImageElement"/>.</summary>
		public ImageElement() : base(ElementType.image) { }

		/// <summary>Initializes a new instance of <see cref="ImageElement"/> with the specified <paramref name="bounds"/>, <paramref name="context"/> and <paramref name="groupIds"/>.</summary>
		public ImageElement(ElementBounds bounds, IHaveSequence<int> context, List<string> groupIds)
			: base(ElementType.image, bounds, context, groupIds) {
		}

		/// <summary> SHA-1 FileId referencing the binary data in `ExcalidrawDocument.files`.
		/// `null` when the image has not yet been assigned a file. JSON key: `"fileId"`.
		/// </summary>
		public string? fileId { get; set; }

		/// <summary>
		/// Load/persistence state of the image binary data.
		/// One of `"pending"`, `"saved"`, `"error"`. JSON key: `"status"`.
		/// </summary>
		public string status { get; set; }

		/// <summary>
		/// Two-element array [scaleX, scaleY] in the range [-1, 1].
		/// A value of -1 on either axis flips the image on that axis.
		/// JSON key: `"scale"`.
		/// </summary>
		public double[] scale { get; set; }

		/// <summary>
		/// Active crop rectangle applied to the image, or `null` if uncropped.
		/// JSON key: `"crop"`.
		/// </summary>
		public ImageCrop? crop { get; set; }
	}

	/// <summary> Crop rectangle applied to an image element </summary>
	/// <remarks>
	/// expressed in the image's natural (pre-scale) pixel coordinate space.
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:57:01Z
	/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-09T16:07:57Z
	/// digest: cae8b3242cc04c5e5d7f8bfa4302b37a40adff0836b5c7c5fc5720bf5ac7edfe
	/// </code>
	/// </example>
	public sealed class ImageCrop {
		/// <summary>Left offset of the crop rectangle in natural image pixels. JSON key: `"x"`.</summary>
		public double x { get; set; }

		/// <summary>Top offset of the crop rectangle in natural image pixels. JSON key: `"y"`.</summary>
		public double y { get; set; }

		/// <summary>Width of the crop rectangle in natural image pixels. JSON key: `"width"`.</summary>
		public double width { get; set; }

		/// <summary>Height of the crop rectangle in natural image pixels. JSON key: `"height"`.</summary>
		public double height { get; set; }

		/// <summary>
		/// Full intrinsic width of the source image in pixels (before any scaling).
		/// JSON key: `"naturalWidth"`.
		/// </summary>
		public double naturalWidth { get; set; }

		/// <summary>
		/// Full intrinsic height of the source image in pixels (before any scaling).
		/// JSON key: `"naturalHeight"`.
		/// </summary>
		public double naturalHeight { get; set; }
	}

	/// <summary> Named frame that visually groups and clips its child elements. </summary>
	/// <remarks>
	/// Children reference this frame via their `frameId` property.
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:57:01Z
	/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-09T16:07:57Z
	/// digest: d5ca03d313d97389d4947ac505e8a4c4f45f9c7a96be236d4fa4617fcfae4841
	/// </code>
	/// </example>
	public sealed class FrameElement : Element {
		/// <summary>Initializes a new instance of <see cref="FrameElement"/>.</summary>
		public FrameElement() : base(ElementType.frame) { }

		/// <summary>Initializes a new instance of <see cref="FrameElement"/> with the specified <paramref name="id"/>, <paramref name="x"/>, <paramref name="y"/> and <paramref name="Name"/>.</summary>
		public FrameElement(string id
			, double x
			, double y
			, string? Name
		) : base(id, ElementType.frame, null, x, y, 0, StrokeStyle.Solid, null, null, 0) {
			name = Name;
		}

		/// <summary>Initializes a new instance of <see cref="FrameElement"/> with the specified <paramref name="bounds"/>, <paramref name="context"/> and <paramref name="groupIds"/>.</summary>
		public FrameElement(ElementBounds bounds, IHaveSequence<int> context, List<string> groupIds)
			: base(ElementType.frame, bounds, context, groupIds) {
		}

		/// <summary> Human-readable label displayed in the frame's header, or `null`. </summary>
		public string? name { get; set; }
	}

	/// <summary> AI-generated magic frame. </summary>
	/// <remarks>
	/// Behaves like <see cref="FrameElement"/> but is produced by Excalidraw's text-to-diagram / generative features.
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:57:01Z
	/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-09T16:07:57Z
	/// digest: 10c4a0f483a16d480a9390e11a8f784a4480a7c3634a8510d6f87a75d327ece4
	/// </code>
	/// </example>
	public sealed class MagicFrameElement : Element {
		/// <summary>Initializes a new instance of <see cref="MagicFrameElement"/>.</summary>
		public MagicFrameElement() : base(ElementType.magicframe) { }

		/// <summary>Initializes a new instance of <see cref="MagicFrameElement"/> with the specified <paramref name="bounds"/>, <paramref name="context"/> and <paramref name="groupIds"/>.</summary>
		public MagicFrameElement(ElementBounds bounds, IHaveSequence<int> context, List<string> groupIds)
			: base(ElementType.magicframe, bounds, context, groupIds) {
		}

		/// <summary> Human-readable label displayed in the frame's header, or `null`. </summary>
		public string? name { get; set; }
	}

	/// <summary> Embeds an external web resource (URL) rendered as an interactive widget. </summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:57:01Z
	/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-09T16:07:57Z
	/// digest: 2e2a47aad35618e502f2cda987731c182412386040f86a8c122ab61ef55595b2
	/// </code>
	/// </example>
	public sealed class EmbeddableElement : Element {

		/// <summary>Initializes a new instance of <see cref="EmbeddableElement"/>.</summary>
		public EmbeddableElement() : base(ElementType.embeddable) { }

		/// <summary>Initializes a new instance of <see cref="EmbeddableElement"/> with the specified <paramref name="bounds"/>, <paramref name="context"/> and <paramref name="groupIds"/>.</summary>
		public EmbeddableElement(ElementBounds bounds, IHaveSequence<int> context, List<string> groupIds)
			: base(ElementType.embeddable, bounds, context, groupIds) {
		}

	}

	/// <summary> Inline iframe for arbitrary HTML content directly on the canvas. </summary>
	/// <remarks>
	/// May carry AI generation metadata in `customData.generationData`.
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:57:01Z
	/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
	/// updated: 2026-05-19
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-09T16:07:57Z
	/// digest: 50ec4d2b1ff0046f8f2a9885aaa32409bce0655928bba636fa1923386a389d0c
	/// </code>
	/// </example>
	public sealed class IFrameElement : Element {
		/// <summary>Initializes a new instance of <see cref="IFrameElement"/>.</summary>
		public IFrameElement() : base(ElementType.iframe) { }

		/// <summary>Initializes a new instance of <see cref="IFrameElement"/> with the specified <paramref name="bounds"/>, <paramref name="context"/> and <paramref name="groupIds"/>.</summary>
		public IFrameElement(ElementBounds bounds, IHaveSequence<int> context, List<string> groupIds)
			: base(ElementType.iframe, bounds, context, groupIds) {
		}


	}
}
