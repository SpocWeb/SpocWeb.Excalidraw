using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using org.SpocWeb.root.Attributes;
using System.ComponentModel;
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
[DocState(Pass = 2, MTime = "2026-08-22T20:36:28Z", Digest = "aae77790dca39822d58425f311debad3aa038613e851567102d04737ebb581df", Stale = false, Path = "ExcaliDraw/Excalidraw.elements.cs", Since = "2026-08-22")]
public static partial class Excalidraw{

	/// <summary>Rounds a floating-point value for JSON output.</summary>
	[Facets(Layer = "infrastructure", Status = "active", Complexity = 1)]
	[Tags("code/json_serialization", "code/numeric_formatting")]
	[System.ComponentModel.Description("Rounds a floating-point value for JSON output.")]
	[Concept("excalidraw_diagram_format")]
	public static double Round(double value, int digits = 2)
		=> Math.Round(value, digits, MidpointRounding.AwayFromZero);

	/// <summary>Graphic Element Base-Class of <see cref="type"/><br/>
	/// Properties shared by every Excalidraw element regardless of type.
	/// Corresponds to `_ExcalidrawElementBase` in types.ts.
	/// Property names match JSON camelCase keys exactly via <see cref="CamelCasePropertyNamesContractResolver"/>
	/// (first char lowercased).</summary>
	/// <remarks>
	/// ## Meta
	/// pass: 2
	/// mtime: 2026-05-15T20:57:01Z
	/// digest: b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
	/// updated: 2026-05-19
	/// </remarks>
	[Facets(Layer = "domain", Status = "active", Complexity = 2)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "00dd43a41bb2f6dc3a49516a6087b402fc7d1bf4ac21534f92776bf278557879", Stale = false, Path = "ExcaliDraw/Excalidraw.elements.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Graphic Element Base-Class of type  Properties shared by every Excalidraw element regardless of type.")]
	[Concept("excalidraw_diagram_format")]
	[Concept("diagram_element_model")]
	public class Element {

		/// <summary> Debuggable String Representation </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Debuggable String Representation")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public override string ToString() => JsonConvert.SerializeObject(this, Formatting.None, ExcalidrawParser.ExcalidrawSettings());

		/// <summary>Unique element identifier (random string). JSON key: `"id"`.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Unique element identifier (random string).")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public string id { get; set; }

		/// <summary> Element type discriminator matching the JSON `"type"` string. </summary>
		/// <remarks>
		/// Used by <see cref="ExcalidrawElementConverter"/> for polymorphic deserialisation.
		/// </remarks>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Element type discriminator matching the JSON `\"type\"` string.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public ElementType type { get; set; }

		/// <summary>Left edge of the element's bounding box in canvas coordinates (px). JSON key: `"x"`.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Left edge of the element's bounding box in canvas coordinates (px).")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public double x { get; set; }

		/// <summary>Top edge of the element's bounding box in canvas coordinates (px). JSON key: `"y"`.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Top edge of the element's bounding box in canvas coordinates (px).")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public double y { get; set; }

		/// <summary>Width of the element's bounding box (px). JSON key: `"width"`.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Width of the element's bounding box (px).")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public double width { get; set; }

		/// <summary>Height of the element's bounding box (px). JSON key: `"height"`.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Height of the element's bounding box (px).")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public double height { get; set; }

		/// <summary>
		/// Rotation angle in radians (clockwise from 12 o'clock).
		/// JSON key: `"angle"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Rotation angle in radians (clockwise from 12 o'clock).")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public double angle { get; set; }

		/// <summary>CSS colour string for the element's stroke/outline. JSON key: `"strokeColor"`.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("CSS colour string for the element's stroke/outline.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public string strokeColor { get; set; }

		/// <summary>CSS colour string for the element's fill. JSON key: `"backgroundColor"`.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("CSS colour string for the element's fill.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public string backgroundColor { get; set; }

		/// <summary>
		/// Fill pattern for the element's interior.
		/// One of `"hachure"`, `"cross-hatch"`, `"solid"`, `"zigzag"`.
		/// JSON key: `"fillStyle"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Fill pattern for the element's interior.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public FillStyle fillStyle { get; set; }

		/// <summary>Stroke width in pixels. JSON key: `"strokeWidth"`.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Stroke width in pixels.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public double strokeWidth { get; set; }

		/// <summary>
		/// Dash pattern for the stroke: `"solid"`, `"dashed"`, or `"dotted"`.
		/// JSON key: `"strokeStyle"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Dash pattern for the stroke: `\"solid\"`, `\"dashed\"`, or `\"dotted\"`.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public StrokeStyle strokeStyle { get; set; }

		/// <summary>
		/// RoughJS roughness level: 0 = architect (clean), 1 = artist, 2 = cartoonist (very rough).
		/// JSON key: `"roughness"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("RoughJS roughness level: 0 = architect (clean), 1 = artist, 2 = cartoonist (very rough).")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public int roughness { get; set; }

		/// <summary>
		/// Element opacity as an integer percentage (0–100).
		/// JSON key: `"opacity"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Element opacity as an integer percentage (0–100).")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public int opacity { get; set; }

		/// <summary>
		/// Corner-rounding configuration, or `null` for sharp corners.
		/// JSON key: `"roundness"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Corner-rounding configuration, or `null` for sharp corners.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public Roundness? roundness { get; set; }

		/// <summary>
		/// Random seed integer used by RoughJS to produce a stable hand-drawn shape
		/// that doesn't change across re-renders. JSON key: `"seed"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Random seed integer used by RoughJS to produce a stable hand-drawn shape that doesn't change across re-renders.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public int seed { get; set; }

		/// <summary>
		/// Soft-delete flag. Deleted elements remain in the array so that
		/// collaborative peers can reconcile removals. JSON key: `"isDeleted"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Soft-delete flag.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public bool isDeleted { get; set; }

		/// <summary> ID of the frame element that contains this element, or `null`. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("ID of the frame element that contains this element, or `null`.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public string? frameId { get; set; }

		/// <summary> Ordered list of group IDs this element belongs to,
		/// from deepest (innermost) to shallowest (outermost). </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Ordered list of group IDs this element belongs to, from deepest (innermost) to shallowest (outermost).")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public List<string> groupIds { get; set; } = new();

		/// <summary> References to arrows or text elements bound to this element. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("References to arrows or text elements bound to this element.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public List<BoundElement>? boundElements { get; set; }

		/// <summary> Hyperlink URL attached to the element, or `null`. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Hyperlink URL attached to the element, or `null`.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public string? link { get; set; }

		/// <summary> When `true`, the element cannot be selected or moved interactively. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("When `true`, the element cannot be selected or moved interactively.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public bool locked { get; set; }

		/// <summary> Sequential integer incremented on every change.
		/// Used for collaborative reconciliation. JSON key: `"version"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Sequential integer incremented on every change.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public int version { get; set; }

		/// <summary>
		/// Random integer regenerated on every change, used for deterministic
		/// reconciliation when two peers have the same version counter.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Random integer regenerated on every change, used for deterministic reconciliation when two peers have the same version counter.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public int versionNonce { get; set; }

		/// <summary> Unix epoch timestamp (ms) of the last element mutation. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Unix epoch timestamp (ms) of the last element mutation.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public long updated { get; set; }

		/// <summary> Fractional index string (rocicorp/fractional-indexing) used for
		/// stable ordering in multiplayer scenarios. JSON key: `"index"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Fractional index string (rocicorp/fractional-indexing) used for stable ordering in multiplayer scenarios.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public string index { get; set; }

		/// <summary> Arbitrary host-app or plugin data attached to this element. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Arbitrary host-app or plugin data attached to this element.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public Dictionary<string, object> customData { get; set; }

		/// <summary>
		/// Catch-all bucket that preserves any unrecognised JSON fields during
		/// round-trips, ensuring forward compatibility.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Catch-all bucket that preserves any unrecognised JSON fields during round-trips, ensuring forward compatibility.")]
		[JsonExtensionData]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public IDictionary<string, object> AdditionalData { get; set; }

		public static string DefaultStrokeColor = "#1e1e1e";
		public static string DefaultTextColor = "#1e1e1e";
		public static string Transparent = "transparent";

		/// <summary> Minimum Constructor </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Minimum Constructor")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		protected Element(ElementType elementType) { type = elementType; }

		/// <summary>Initializes a new instance of <see cref="Element"/> with the specified <paramref name="Id"/>, <paramref name="Type"/>, <paramref name="FrameId"/>, <paramref name="X"/>, <paramref name="Y"/>, <paramref name="StrokeWidth"/>, <paramref name="StrokeStyle"/>, <paramref name="StrokeColor"/>, <paramref name="BackgroundColor"/> and <paramref name="Opacity"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of Element with the specified Id, Type, FrameId, X, Y, StrokeWidth, StrokeStyle, StrokeColor, BackgroundColor and Opacity.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of Element with the specified type, bounds, context and GroupIds.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Deconstructs this instance into its component parts.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
	[Facets(Layer = "domain", Status = "active", Complexity = 1)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "dbf553a66b7a0528d1c5170ff9c4d7babdb69942e9510ce21f860c22f29736d5", Stale = false, Path = "ExcaliDraw/Excalidraw.elements.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Axis-aligned rectangle shape element.")]
	[Concept("excalidraw_diagram_format")]
	[Concept("diagram_element_model")]
	public sealed class RectangleElement : Element {
		/// <summary> Initializes an empty <see cref="RectangleElement"/> for JSON deserialization. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes an empty RectangleElement for JSON deserialization.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public RectangleElement() : base(ElementType.rectangle) { }

		/// <summary> Initializes a <see cref="RectangleElement"/> from <paramref name="bounds"/> using <paramref name="context"/> for id/seed. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a RectangleElement from bounds using context for id/seed.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
	[Facets(Layer = "domain", Status = "active", Complexity = 1)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "88ca0892e541e80785eb95b8fdc5e33df1e6841cf47beee13611a5b8c2994edf", Stale = false, Path = "ExcaliDraw/Excalidraw.elements.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Ellipse (or circle when width == height) shape element.")]
	[Concept("excalidraw_diagram_format")]
	[Concept("diagram_element_model")]
	public sealed class EllipseElement : Element {
		/// <summary> Initializes an empty <see cref="EllipseElement"/> for JSON deserialization. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes an empty EllipseElement for JSON deserialization.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public EllipseElement() : base(ElementType.ellipse) { }

		/// <summary> Initializes an <see cref="EllipseElement"/> from <paramref name="bounds"/> using <paramref name="context"/> for id/seed. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes an EllipseElement from bounds using context for id/seed.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
	[Facets(Layer = "domain", Status = "active", Complexity = 1)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "938dea4088d89746c8db83fed844daa24fb2b369983d90865ab797e7acfdbf35", Stale = false, Path = "ExcaliDraw/Excalidraw.elements.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Diamond (rotated square) shape element.")]
	[Concept("excalidraw_diagram_format")]
	[Concept("diagram_element_model")]
	public sealed class DiamondElement : Element {
		/// <summary> Initializes an empty <see cref="DiamondElement"/> for JSON deserialization. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes an empty DiamondElement for JSON deserialization.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public DiamondElement() : base(ElementType.diamond) { }

		/// <summary> Initializes a <see cref="DiamondElement"/> from <paramref name="bounds"/> using <paramref name="context"/> for id/seed. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a DiamondElement from bounds using context for id/seed.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
	[Facets(Layer = "domain", Status = "active", Complexity = 2)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "14d176b2956813fd19adb4f4bebaeccb963a622777e739e9b5449a5d4daa57c7", Stale = false, Path = "ExcaliDraw/Excalidraw.elements.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Base class for elements composed of an ordered array of points: lines and arrows.")]
	[Concept("excalidraw_diagram_format")]
	[Concept("diagram_element_model")]
	public class LinearElement : Element {

		/// <summary> Initializes an empty <see cref="LinearElement"/> for JSON deserialization. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes an empty LinearElement for JSON deserialization.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		protected LinearElement(ElementType type) : base(type) { }

		/// <summary> Initializes a <see cref="LinearElement"/> with full styling and optional endpoint bindings. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a LinearElement with full styling and optional endpoint bindings.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a LinearElement from bounds using context for id/seed.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Type of Arrowhead at the Line Start")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public Arrowhead? startArrowhead { get; set; }

		/// <summary> Type of <see cref="Arrowhead"/> at the Line End </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Type of Arrowhead at the Line End")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public Arrowhead? endArrowhead { get; set; }

		/// <summary>Gets or sets the label.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Gets or sets the label.")]
		[Obsolete("In earlier Versions, excalidraw stored the Label here use " + nameof(boundElements), true)]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public string? label { get; set; }

		/// <summary> Ordered array of [x, y] point pairs in element-local coordinates. </summary>
		/// <remarks>
		/// The first point is always [0, 0]; subsequent points are relative offsets.
		/// JSON key: `"points"`.
		/// </remarks>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Ordered array of [x, y] point pairs in element-local coordinates.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Arrow endpoint binding to the element at the start of the line.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public PointBinding? startBinding { get; set; }

		/// <summary> Arrow endpoint binding to the element at the end of the line.
		/// `null` when the end is unbound. JSON key: `"endBinding"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Arrow endpoint binding to the element at the end of the line.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
	[Facets(Layer = "domain", Status = "active", Complexity = 1)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "6156d6936db61eab6bdb9dca528e237dee22cff4153682c2ea1e16775886813f", Stale = false, Path = "ExcaliDraw/Excalidraw.elements.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Undirected straight or curved line through two or more points.")]
	[Concept("excalidraw_diagram_format")]
	[Concept("diagram_element_model")]
	public sealed class LineElement : LinearElement {

		/// <summary>
		/// When `true`, the last point is connected back to the first
		/// to close the polyline into a polygon. JSON key: `"polygon"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("When `true`, the last point is connected back to the first to close the polyline into a polygon.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public bool polygon { get; set; }

		/// <summary> Initializes an empty <see cref="LineElement"/> for JSON deserialization. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes an empty LineElement for JSON deserialization.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public LineElement() : base(ElementType.line) { }

		/// <summary> Initializes a <see cref="LineElement"/> with full styling parameters. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a LineElement with full styling parameters.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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


		/// <summary>Initializes a new instance of <see cref="LineElement"/> with the specified <paramref name="bounds"/>, <paramref name="context"/> and <paramref name="groupIds"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of LineElement with the specified bounds, context and groupIds.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
	[Facets(Layer = "domain", Status = "active", Complexity = 2)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "0505b14edc4bc1c1311dcf294b40ab6c8fdaa9ba194687a4c150edb0ea6dd091", Stale = false, Path = "ExcaliDraw/Excalidraw.elements.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Directed arrow with optional endpoint bindings and arrowhead decorations.")]
	[Concept("excalidraw_diagram_format")]
	[Concept("diagram_element_model")]
	public sealed class Arrow : LinearElement {

		/// <summary>Initializes a new instance of <see cref="Arrow"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of Arrow.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public Arrow() : base(ElementType.arrow) { }

		/// <summary>Initializes a new instance of <see cref="Arrow"/> with the specified <paramref name="Id"/>, <paramref name="FrameId"/>, <paramref name="X"/>, <paramref name="Y"/>, <paramref name="StrokeWidth"/>, <paramref name="StrokeStyle"/>, <paramref name="StrokeColor"/>, <paramref name="Opacity"/>, <paramref name="StartArrowhead"/>, <paramref name="EndArrowhead"/>, <paramref name="StartElementId"/> and <paramref name="EndElementId"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of Arrow with the specified Id, FrameId, X, Y, StrokeWidth, StrokeStyle, StrokeColor, Opacity, StartArrowhead, EndArrowhead, StartElementId and EndElementId.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of Arrow with the specified bounds, context, groupIds, StartArrowhead, EndArrowhead, StartElementId and EndElementId.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("When `true`, the arrow uses 90-degree elbow routing instead of straight or curved segments.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
	[Facets(Layer = "domain", Status = "active", Complexity = 1)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "d2b2929eba28461799f197b2bdbbeac7fefc7de99d62c69a696d6c476e4f8c88", Stale = false, Path = "ExcaliDraw/Excalidraw.elements.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Freehand stroke captured from pointer input.")]
	[Concept("excalidraw_diagram_format")]
	[Concept("diagram_element_model")]
	public sealed class FreedrawElement : Element {
		/// <summary>Initializes a new instance of <see cref="FreedrawElement"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of FreedrawElement.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public FreedrawElement() : base(ElementType.freedraw) { }

		/// <summary>Initializes a new instance of <see cref="FreedrawElement"/> with the specified <paramref name="bounds"/>, <paramref name="context"/> and <paramref name="groupIds"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of FreedrawElement with the specified bounds, context and groupIds.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public FreedrawElement(ElementBounds bounds, IHaveSequence<int> context, List<string> groupIds)
			: base(ElementType.freedraw, bounds, context, groupIds) {
		}

		/// <summary>
		/// Ordered array of [x, y] points in canvas coordinates tracing the stroke.
		/// JSON key: `"points"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Ordered array of [x, y] points in canvas coordinates tracing the stroke.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public List<double[]> points { get; set; } = new();

		/// <summary>
		/// Per-point stylus pressure values (0.0–1.0) corresponding to each entry
		/// in <see cref="points"/>. Empty when <see cref="simulatePressure"/> is `true`.
		/// JSON key: `"pressures"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Per-point stylus pressure values (0.0–1.0) corresponding to each entry in points.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public List<double> pressures { get; set; } = new();

		/// <summary>
		/// When `true`, pressure is algorithmically simulated rather than
		/// read from the pointer device. JSON key: `"simulatePressure"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("When `true`, pressure is algorithmically simulated rather than read from the pointer device.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
	[Facets(Layer = "domain", Status = "active", Complexity = 1)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "9d258720f987f3053db79b3fd54f36d42dddb115cc01097b07d1197e76076842", Stale = false, Path = "ExcaliDraw/Excalidraw.elements.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Text label element, either standalone or bound to a container shape.")]
	[Concept("excalidraw_diagram_format")]
	[Concept("diagram_element_model")]
	public sealed class TextElement : Element {

		/// <summary>Initializes a new instance of <see cref="TextElement"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of TextElement.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public TextElement() : base(ElementType.text) { }

		/// <summary>Initializes a new instance of <see cref="TextElement"/> with the specified <paramref name="bounds"/>, <paramref name="context"/> and <paramref name="groupIds"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of TextElement with the specified bounds, context and groupIds.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public TextElement(ElementBounds bounds, IHaveSequence<int> context, List<string> groupIds)
			: base(ElementType.text, bounds, context, groupIds) {
		}

		/// <summary> Display text content (may be wrapped). JSON key: `"text"`. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Display text content (may be wrapped).")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public string text { get; set; }

		/// <summary> The full, unwrapped text before container-width wrapping is applied. </summary>
		/// <remarks>
		/// JSON key: `"originalText"`.
		/// </remarks>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("The full, unwrapped text before container-width wrapping is applied.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public string originalText { get; set; }

		/// <summary>Font size in pixels. JSON key: `"fontSize"`.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Font size in pixels.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public double fontSize { get; set; }

		/// <summary> Numeric font family ID matching the `FONT_FAMILY` constant. </summary>
		/// <remarks>
		/// See <see cref="FontFamily"/> enum for named values. JSON key: `"fontFamily"`.
		/// </remarks>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Numeric font family ID matching the `FONT_FAMILY` constant.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public FontFamily fontFamily { get; set; }

		/// <summary> Horizontal text alignment: `"left"`, `"center"`, or `"right"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Horizontal text alignment: `\"left\"`, `\"center\"`, or `\"right\"`.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public TextAlign textAlign { get; set; }

		/// <summary> Vertical text alignment within the bounding box or container:
		/// `"top"`, `"middle"`, or `"bottom"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Vertical text alignment within the bounding box or container: `\"top\"`, `\"middle\"`, or `\"bottom\"`.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public VerticalAlign verticalAlign { get; set; }

		/// <summary> ID of the container shape this text is bound to,
		/// or `null` for standalone text. JSON key: `"containerId"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("ID of the container shape this text is bound to, or `null` for standalone text.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public string? containerId { get; set; }

		/// <summary>
		/// When `true`, the container shape resizes to fit the text.
		/// When `false`, text wraps to fit the container width.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("When `true`, the container shape resizes to fit the text.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public bool autoResize { get; set; }

		/// <summary>
		/// Unitless line-height multiplier (W3C convention).
		/// Multiply by <see cref="fontSize"/> to obtain the line height in pixels.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Unitless line-height multiplier (W3C convention).")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public double lineHeight { get; set; }

		/// <summary> Position of the first Text Line; typ: FontSize </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Position of the first Text Line; typ: FontSize")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
	[Facets(Layer = "domain", Status = "active", Complexity = 2)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "82c53954ef1b74088f6c78273b3757ae25c986679cc0ab47354eda9a5714c712", Stale = false, Path = "ExcaliDraw/Excalidraw.elements.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Raster image whose binary content is stored in the document-level `files` map keyed by fileId.")]
	[Concept("excalidraw_diagram_format")]
	[Concept("diagram_element_model")]
	public sealed class ImageElement : Element {

		/// <summary>Initializes a new instance of <see cref="ImageElement"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of ImageElement.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public ImageElement() : base(ElementType.image) { }

		/// <summary>Initializes a new instance of <see cref="ImageElement"/> with the specified <paramref name="bounds"/>, <paramref name="context"/> and <paramref name="groupIds"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of ImageElement with the specified bounds, context and groupIds.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public ImageElement(ElementBounds bounds, IHaveSequence<int> context, List<string> groupIds)
			: base(ElementType.image, bounds, context, groupIds) {
		}

		/// <summary> SHA-1 FileId referencing the binary data in `ExcalidrawDocument.files`.
		/// `null` when the image has not yet been assigned a file. JSON key: `"fileId"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("SHA-1 FileId referencing the binary data in `ExcalidrawDocument.files`.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public string? fileId { get; set; }

		/// <summary>
		/// Load/persistence state of the image binary data.
		/// One of `"pending"`, `"saved"`, `"error"`. JSON key: `"status"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Load/persistence state of the image binary data.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public string status { get; set; }

		/// <summary>
		/// Two-element array [scaleX, scaleY] in the range [-1, 1].
		/// A value of -1 on either axis flips the image on that axis.
		/// JSON key: `"scale"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Two-element array [scaleX, scaleY] in the range [-1, 1].")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public double[] scale { get; set; }

		/// <summary>
		/// Active crop rectangle applied to the image, or `null` if uncropped.
		/// JSON key: `"crop"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 2)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Active crop rectangle applied to the image, or `null` if uncropped.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
	[Facets(Layer = "domain", Status = "active", Complexity = 1)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "cae8b3242cc04c5e5d7f8bfa4302b37a40adff0836b5c7c5fc5720bf5ac7edfe", Stale = false, Path = "ExcaliDraw/Excalidraw.elements.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Crop rectangle applied to an image element")]
	[Concept("excalidraw_diagram_format")]
	[Concept("diagram_element_model")]
	public sealed class ImageCrop {
		/// <summary>Left offset of the crop rectangle in natural image pixels. JSON key: `"x"`.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Left offset of the crop rectangle in natural image pixels.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public double x { get; set; }

		/// <summary>Top offset of the crop rectangle in natural image pixels. JSON key: `"y"`.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Top offset of the crop rectangle in natural image pixels.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public double y { get; set; }

		/// <summary>Width of the crop rectangle in natural image pixels. JSON key: `"width"`.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Width of the crop rectangle in natural image pixels.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public double width { get; set; }

		/// <summary>Height of the crop rectangle in natural image pixels. JSON key: `"height"`.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Height of the crop rectangle in natural image pixels.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public double height { get; set; }

		/// <summary>
		/// Full intrinsic width of the source image in pixels (before any scaling).
		/// JSON key: `"naturalWidth"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Full intrinsic width of the source image in pixels (before any scaling).")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public double naturalWidth { get; set; }

		/// <summary>
		/// Full intrinsic height of the source image in pixels (before any scaling).
		/// JSON key: `"naturalHeight"`.
		/// </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Full intrinsic height of the source image in pixels (before any scaling).")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
	[Facets(Layer = "domain", Status = "active", Complexity = 1)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "d5ca03d313d97389d4947ac505e8a4c4f45f9c7a96be236d4fa4617fcfae4841", Stale = false, Path = "ExcaliDraw/Excalidraw.elements.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Named frame that visually groups and clips its child elements.")]
	[Concept("excalidraw_diagram_format")]
	[Concept("diagram_element_model")]
	public sealed class FrameElement : Element {
		/// <summary>Initializes a new instance of <see cref="FrameElement"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of FrameElement.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public FrameElement() : base(ElementType.frame) { }

		/// <summary>Initializes a new instance of <see cref="FrameElement"/> with the specified <paramref name="id"/>, <paramref name="x"/>, <paramref name="y"/> and <paramref name="Name"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of FrameElement with the specified id, x, y and Name.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public FrameElement(string id
			, double x
			, double y
			, string? Name
		) : base(id, ElementType.frame, null, x, y, 0, StrokeStyle.Solid, null, null, 0) {
			name = Name;
		}

		/// <summary>Initializes a new instance of <see cref="FrameElement"/> with the specified <paramref name="bounds"/>, <paramref name="context"/> and <paramref name="groupIds"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of FrameElement with the specified bounds, context and groupIds.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public FrameElement(ElementBounds bounds, IHaveSequence<int> context, List<string> groupIds)
			: base(ElementType.frame, bounds, context, groupIds) {
		}

		/// <summary> Human-readable label displayed in the frame's header, or `null`. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Human-readable label displayed in the frame's header, or `null`.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
	[Facets(Layer = "domain", Status = "active", Complexity = 1)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "10c4a0f483a16d480a9390e11a8f784a4480a7c3634a8510d6f87a75d327ece4", Stale = false, Path = "ExcaliDraw/Excalidraw.elements.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("AI-generated magic frame.")]
	[Concept("excalidraw_diagram_format")]
	[Concept("diagram_element_model")]
	public sealed class MagicFrameElement : Element {
		/// <summary>Initializes a new instance of <see cref="MagicFrameElement"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of MagicFrameElement.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public MagicFrameElement() : base(ElementType.magicframe) { }

		/// <summary>Initializes a new instance of <see cref="MagicFrameElement"/> with the specified <paramref name="bounds"/>, <paramref name="context"/> and <paramref name="groupIds"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of MagicFrameElement with the specified bounds, context and groupIds.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public MagicFrameElement(ElementBounds bounds, IHaveSequence<int> context, List<string> groupIds)
			: base(ElementType.magicframe, bounds, context, groupIds) {
		}

		/// <summary> Human-readable label displayed in the frame's header, or `null`. </summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Human-readable label displayed in the frame's header, or `null`.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
	[Facets(Layer = "domain", Status = "active", Complexity = 1)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "2e2a47aad35618e502f2cda987731c182412386040f86a8c122ab61ef55595b2", Stale = false, Path = "ExcaliDraw/Excalidraw.elements.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Embeds an external web resource (URL) rendered as an interactive widget.")]
	[Concept("excalidraw_diagram_format")]
	[Concept("diagram_element_model")]
	public sealed class EmbeddableElement : Element {

		/// <summary>Initializes a new instance of <see cref="EmbeddableElement"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of EmbeddableElement.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public EmbeddableElement() : base(ElementType.embeddable) { }

		/// <summary>Initializes a new instance of <see cref="EmbeddableElement"/> with the specified <paramref name="bounds"/>, <paramref name="context"/> and <paramref name="groupIds"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of EmbeddableElement with the specified bounds, context and groupIds.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
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
	[Facets(Layer = "domain", Status = "active", Complexity = 1)]
	[Tags("code/dto")]
	[DocState(Pass = 2, MTime = "2026-08-30T21:01:40Z", Digest = "50ec4d2b1ff0046f8f2a9885aaa32409bce0655928bba636fa1923386a389d0c", Stale = false, Path = "ExcaliDraw/Excalidraw.elements.cs", Since = "2026-08-22")]
	[System.ComponentModel.Description("Inline iframe for arbitrary HTML content directly on the canvas.")]
	[Concept("excalidraw_diagram_format")]
	[Concept("diagram_element_model")]
	public sealed class IFrameElement : Element {
		/// <summary>Initializes a new instance of <see cref="IFrameElement"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of IFrameElement.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public IFrameElement() : base(ElementType.iframe) { }

		/// <summary>Initializes a new instance of <see cref="IFrameElement"/> with the specified <paramref name="bounds"/>, <paramref name="context"/> and <paramref name="groupIds"/>.</summary>
		[Facets(Layer = "domain", Status = "active", Complexity = 1)]
		[Tags("code/dto")]
		[System.ComponentModel.Description("Initializes a new instance of IFrameElement with the specified bounds, context and groupIds.")]
		[Concept("excalidraw_diagram_format")]
		[Concept("diagram_element_model")]
		public IFrameElement(ElementBounds bounds, IHaveSequence<int> context, List<string> groupIds)
			: base(ElementType.iframe, bounds, context, groupIds) {
		}


	}
}
