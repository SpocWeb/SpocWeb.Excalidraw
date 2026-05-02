using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace org.SpocWeb.PptxToJson.ExcaliDraw; 

public static partial class Excalidraw{

	/// <summary>Rounds a floating-point value for JSON output.</summary> 
	public static double Round(double value, int digits = 2)
		=> Math.Round(value, digits, MidpointRounding.AwayFromZero);

	/// <summary> Graphic Element Base-Class of <paramref name="Type"/> </summary>
	/// <summary>
	/// Properties shared by every Excalidraw element regardless of type.
	/// Corresponds to <c>_ExcalidrawElementBase</c> in types.ts.
	/// Property names match JSON camelCase keys exactly via <see cref="CamelCasePropertyNamesContractResolver"/>
	/// (first char lowercased).
	/// </summary>
	public abstract class Element {

		/// <summary>Unique element identifier (random string). JSON key: <c>"id"</c>.</summary>
		public string id { get; set; }

		/// <summary> Element type discriminator matching the JSON <c>"type"</c> string. </summary>
		/// <remarks>
		/// Used by <see cref="ExcalidrawElementConverter"/> for polymorphic deserialisation.
		/// </remarks>
		public ElementType type { get; set; }

		/// <summary>Left edge of the element's bounding box in canvas coordinates (px). JSON key: <c>"x"</c>.</summary>
		public double x { get; set; }

		/// <summary>Top edge of the element's bounding box in canvas coordinates (px). JSON key: <c>"y"</c>.</summary>
		public double y { get; set; }

		/// <summary>Width of the element's bounding box (px). JSON key: <c>"width"</c>.</summary>
		public double width { get; set; }

		/// <summary>Height of the element's bounding box (px). JSON key: <c>"height"</c>.</summary>
		public double height { get; set; }

		/// <summary>
		/// Rotation angle in radians (clockwise from 12 o'clock).
		/// JSON key: <c>"angle"</c>.
		/// </summary>
		public double angle { get; set; }

		/// <summary>CSS colour string for the element's stroke/outline. JSON key: <c>"strokeColor"</c>.</summary>
		public string strokeColor { get; set; }

		/// <summary>CSS colour string for the element's fill. JSON key: <c>"backgroundColor"</c>.</summary>
		public string backgroundColor { get; set; }

		/// <summary>
		/// Fill pattern for the element's interior.
		/// One of <c>"hachure"</c>, <c>"cross-hatch"</c>, <c>"solid"</c>, <c>"zigzag"</c>.
		/// JSON key: <c>"fillStyle"</c>.
		/// </summary>
		public FillStyle fillStyle { get; set; }

		/// <summary>Stroke width in pixels. JSON key: <c>"strokeWidth"</c>.</summary>
		public double strokeWidth { get; set; }

		/// <summary>
		/// Dash pattern for the stroke: <c>"solid"</c>, <c>"dashed"</c>, or <c>"dotted"</c>.
		/// JSON key: <c>"strokeStyle"</c>.
		/// </summary>
		public StrokeStyle strokeStyle { get; set; }

		/// <summary>
		/// RoughJS roughness level: 0 = architect (clean), 1 = artist, 2 = cartoonist (very rough).
		/// JSON key: <c>"roughness"</c>.
		/// </summary>
		public int roughness { get; set; }

		/// <summary>
		/// Element opacity as an integer percentage (0–100).
		/// JSON key: <c>"opacity"</c>.
		/// </summary>
		public int opacity { get; set; }

		/// <summary>
		/// Corner-rounding configuration, or <c>null</c> for sharp corners.
		/// JSON key: <c>"roundness"</c>.
		/// </summary>
		public Roundness roundness { get; set; }

		/// <summary>
		/// Random seed integer used by RoughJS to produce a stable hand-drawn shape
		/// that doesn't change across re-renders. JSON key: <c>"seed"</c>.
		/// </summary>
		public int seed { get; set; }

		/// <summary>
		/// Soft-delete flag. Deleted elements remain in the array so that
		/// collaborative peers can reconcile removals. JSON key: <c>"isDeleted"</c>.
		/// </summary>
		public bool isDeleted { get; set; }

		/// <summary>
		/// ID of the frame element that contains this element, or <c>null</c>.
		/// JSON key: <c>"frameId"</c>.
		/// </summary>
		public string frameId { get; set; }

		/// <summary>
		/// Ordered list of group IDs this element belongs to,
		/// from deepest (innermost) to shallowest (outermost).
		/// JSON key: <c>"groupIds"</c>.
		/// </summary>
		public List<string> groupIds { get; set; } = new();

		/// <summary>
		/// References to arrows or text elements bound to this element.
		/// JSON key: <c>"boundElements"</c>.
		/// </summary>
		public List<BoundElement> boundElements { get; set; }

		/// <summary>
		/// Hyperlink URL attached to the element, or <c>null</c>.
		/// JSON key: <c>"link"</c>.
		/// </summary>
		public string link { get; set; }

		/// <summary>
		/// When <c>true</c>, the element cannot be selected or moved interactively.
		/// JSON key: <c>"locked"</c>.
		/// </summary>
		public bool locked { get; set; }

		/// <summary>
		/// Sequential integer incremented on every change.
		/// Used for collaborative reconciliation. JSON key: <c>"version"</c>.
		/// </summary>
		public int version { get; set; }

		/// <summary>
		/// Random integer regenerated on every change, used for deterministic
		/// reconciliation when two peers have the same version counter.
		/// JSON key: <c>"versionNonce"</c>.
		/// </summary>
		public int versionNonce { get; set; }

		/// <summary>
		/// Unix epoch timestamp (ms) of the last element mutation.
		/// JSON key: <c>"updated"</c>.
		/// </summary>
		public long updated { get; set; }

		/// <summary>
		/// Fractional index string (rocicorp/fractional-indexing) used for
		/// stable ordering in multiplayer scenarios. JSON key: <c>"index"</c>.
		/// </summary>
		public string index { get; set; }

		/// <summary>
		/// Arbitrary host-app or plugin data attached to this element.
		/// JSON key: <c>"customData"</c>.
		/// </summary>
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

		public Element() { }

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

		public Element(ElementType type, ElementBounds bounds
			, IHaveSequence<int> context, params string[] groupIds) : this(
			context.NextId(type.ToString()), type, null, Round(bounds.X), Round(bounds.Y)
			, 1d, StrokeStyle.Solid
			, DefaultStrokeColor
			, Transparent, 100) {
			roughness = 0;
			width = Round(bounds.Width);
			height = Round(bounds.Height);
			angle = Round(bounds.AngleRadians, 6);
			fillStyle = FillStyle.Solid;
			GroupIds = groupIds;
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

		[JsonIgnore]
		public string[] GroupIds { get ; set ; }


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

	// ─── Generic shapes ───────────────────────────────────────────────────────────

	/// <summary>
	/// Axis-aligned rectangle shape element.
	/// No additional properties beyond the base element.
	/// JSON type: <c>"rectangle"</c>.
	/// </summary>
	public sealed class RectangleElement : Element { }

	/// <summary>
	/// Ellipse (or circle when width == height) shape element.
	/// No additional properties beyond the base element.
	/// JSON type: <c>"ellipse"</c>.
	/// </summary>
	public sealed class EllipseElement : Element { }

	/// <summary>
	/// Diamond (rotated square) shape element.
	/// No additional properties beyond the base element.
	/// JSON type: <c>"diamond"</c>.
	/// </summary>
	public sealed class DiamondElement : Element { }

	/// <summary> Base class for elements composed of an ordered array of points: lines and arrows. </summary>
	public abstract class LinearElement : Element {

		public LinearElement() { }

		protected LinearElement(string Id
			, ElementType ElementType
			, string? FrameId
			, double X
			, double Y
			, double StrokeWidth
			, StrokeStyle StrokeStyle
			, string? StrokeColor
			, double Opacity
			//, string? StartElementId
			//, string? EndElementId
			//, Excalidraw.Arrowhead StartArrowhead
			//, Excalidraw.Arrowhead EndArrowhead
			//, string? Label
			) : base(Id, ElementType, FrameId, X, Y, StrokeWidth, StrokeStyle, StrokeColor, null, Opacity) {
			//this.StartElementId = StartElementId;
			//this.EndElementId = EndElementId;
			//this.StartArrowhead = StartArrowhead;
			//this.EndArrowhead = EndArrowhead;
			//this.Label = Label;
		}


		public LinearElement(   ElementType ElementType
			, ElementBounds bounds
			, IHaveSequence<int> context, string[] groupIds
			//, string? StartElementId
			//, string? EndElementId
			//, Excalidraw.Arrowhead StartArrowhead
			//, Excalidraw.Arrowhead EndArrowhead
			//, string? Label
		) : base(ElementType, bounds, context, groupIds) {
			//this.StartElementId = StartElementId;
			//this.EndElementId = EndElementId;
			//this.StartArrowhead = StartArrowhead;
			//this.EndArrowhead = EndArrowhead;
			//this.Label = Label;
		}

		/// <summary>
		/// Ordered array of [x, y] point pairs in element-local coordinates.
		/// The first point is always [0, 0]; subsequent points are relative offsets.
		/// JSON key: <c>"points"</c>.
		/// </summary>
		public List<double[]> points { get; set; } = new();

		/// <summary>
		/// The last point that was committed to the <see cref="points"/> array
		/// during interactive creation. Used internally; may be <c>null</c>.
		/// JSON key: <c>"lastCommittedPoint"</c>.
		/// </summary>
		public double[] lastCommittedPoint { get; set; }

		/// <summary>
		/// Arrow endpoint binding to the element at the start of the line.
		/// <c>null</c> when the start is unbound. JSON key: <c>"startBinding"</c>.
		/// </summary>
		public PointBinding startBinding { get; set; }

		/// <summary>
		/// Arrow endpoint binding to the element at the end of the line.
		/// <c>null</c> when the end is unbound. JSON key: <c>"endBinding"</c>.
		/// </summary>
		public PointBinding endBinding { get; set; }

		/// <summary>
		/// Arrowhead decoration at the start point, or <c>null</c> for none.
		/// JSON key: <c>"startArrowhead"</c>.
		/// </summary>
		public string startArrowhead { get; set; }

		/// <summary>
		/// Arrowhead decoration at the end point, or <c>null</c> for none.
		/// JSON key: <c>"endArrowhead"</c>.
		/// </summary>
		public string endArrowhead { get; set; }
	}

	/// <summary> Undirected straight or curved line through two or more points. </summary>
	public sealed class LineElement : LinearElement {

		/// <summary>
		/// When <c>true</c>, the last point is connected back to the first
		/// to close the polyline into a polygon. JSON key: <c>"polygon"</c>.
		/// </summary>
		public bool polygon { get; set; }

		public LineElement() { }

		public LineElement(string Id
			, string? FrameId
			, double X
			, double Y
			, double StrokeWidth
			, StrokeStyle StrokeStyle
			, string? StrokeColor
			, double Opacity
			//, string? StartElementId
			//, string? EndElementId
			//, Excalidraw.Arrowhead StartArrowhead
			//, Excalidraw.Arrowhead EndArrowhead
			, string? Label)
			: base(Id, ElementType.Line, FrameId, X, Y, StrokeWidth, StrokeStyle, StrokeColor, Opacity//, Label
				  ) {
			//this.StartElementId = StartElementId;
			//this.EndElementId = EndElementId;
			//this.StartArrowhead = StartArrowhead;
			//this.EndArrowhead = EndArrowhead;
			//this.Label = Label;
		}


		public LineElement(ElementBounds bounds
			, IHaveSequence<int> context, string[] groupIds
			//, string? StartElementId
			//, string? EndElementId
			//, Excalidraw.Arrowhead StartArrowhead
			//, Excalidraw.Arrowhead EndArrowhead
			//, string? Label
		) : base( ElementType.Line, bounds, context, groupIds) {
			//this.StartElementId = StartElementId;
			//this.EndElementId = EndElementId;
			//this.StartArrowhead = StartArrowhead;
			//this.EndArrowhead = EndArrowhead;
			//this.Label = Label;
		}

	}

	/// <summary> Directed arrow with optional endpoint bindings and arrowhead decorations. </summary>
	public sealed class Arrow : LinearElement {

		public Arrow() { }
		public Arrow(string Id
			, string? FrameId
			, double X
			, double Y
			, double StrokeWidth
			, StrokeStyle StrokeStyle
			, string? StrokeColor
			, double Opacity

			//, string? StartElementId
			//, string? EndElementId
			//, Arrowhead StartArrowhead
			//, Arrowhead EndArrowhead
			//, string? Label
			) : base(Id, ElementType.Arrow, FrameId, X, Y, StrokeWidth, StrokeStyle, StrokeColor, Opacity//, Label
				) {
			//this.StartElementId = StartElementId;
			//this.EndElementId = EndElementId;
			//this.StartArrowhead = StartArrowhead;
			//this.EndArrowhead = EndArrowhead;
			//this.Label = Label;
		}


		public Arrow(ElementBounds bounds
			, IHaveSequence<int> context, string[] groupIds
			//, string? StartElementId
			//, string? EndElementId
			//, Excalidraw.Arrowhead StartArrowhead
			//, Excalidraw.Arrowhead EndArrowhead
			//, string? Label
			) : base(Excalidraw.ElementType.Arrow, bounds, context, groupIds) {
			//this.StartElementId = StartElementId;
			//this.EndElementId = EndElementId;
			//this.StartArrowhead = StartArrowhead;
			//this.EndArrowhead = EndArrowhead;
			//this.Label = Label;
		}

		/// <summary>
		/// When <c>true</c>, the arrow uses 90-degree elbow routing instead of
		/// straight or curved segments. JSON key: <c>"elbowed"</c>.
		/// </summary>
		public bool elbowed { get; set; }
	}

	/// <summary> Freehand stroke captured from pointer input. </summary>
	public sealed class FreedrawElement : Element {
		/// <summary>
		/// Ordered array of [x, y] points in canvas coordinates tracing the stroke.
		/// JSON key: <c>"points"</c>.
		/// </summary>
		public List<double[]> points { get; set; } = new();

		/// <summary>
		/// Per-point stylus pressure values (0.0–1.0) corresponding to each entry
		/// in <see cref="points"/>. Empty when <see cref="simulatePressure"/> is <c>true</c>.
		/// JSON key: <c>"pressures"</c>.
		/// </summary>
		public List<double> pressures { get; set; } = new();

		/// <summary>
		/// When <c>true</c>, pressure is algorithmically simulated rather than
		/// read from the pointer device. JSON key: <c>"simulatePressure"</c>.
		/// </summary>
		public bool simulatePressure { get; set; }
	}

	/// <summary> Text label element, either standalone or bound to a container shape. </summary>
	public sealed class TextElement : Element {
		/// <summary>
		/// Display text content (may be wrapped). JSON key: <c>"text"</c>.
		/// </summary>
		public string text { get; set; }

		/// <summary>
		/// The full, unwrapped text before container-width wrapping is applied.
		/// JSON key: <c>"originalText"</c>.
		/// </summary>
		public string originalText { get; set; }

		/// <summary>Font size in pixels. JSON key: <c>"fontSize"</c>.</summary>
		public double fontSize { get; set; }

		/// <summary>
		/// Numeric font family ID matching the <c>FONT_FAMILY</c> constant.
		/// See <see cref="FontFamily"/> enum for named values. JSON key: <c>"fontFamily"</c>.
		/// </summary>
		public int fontFamily { get; set; }

		/// <summary>
		/// Horizontal text alignment: <c>"left"</c>, <c>"center"</c>, or <c>"right"</c>.
		/// JSON key: <c>"textAlign"</c>.
		/// </summary>
		public string textAlign { get; set; }

		/// <summary>
		/// Vertical text alignment within the bounding box or container:
		/// <c>"top"</c>, <c>"middle"</c>, or <c>"bottom"</c>.
		/// JSON key: <c>"verticalAlign"</c>.
		/// </summary>
		public string verticalAlign { get; set; }

		/// <summary>
		/// ID of the container shape this text is bound to, or <c>null</c>
		/// for standalone text. JSON key: <c>"containerId"</c>.
		/// </summary>
		public string containerId { get; set; }

		/// <summary>
		/// When <c>true</c>, the container shape resizes to fit the text.
		/// When <c>false</c>, text wraps to fit the container width.
		/// JSON key: <c>"autoResize"</c>.
		/// </summary>
		public bool autoResize { get; set; }

		/// <summary>
		/// Unitless line-height multiplier (W3C convention).
		/// Multiply by <see cref="fontSize"/> to obtain the line height in pixels.
		/// JSON key: <c>"lineHeight"</c>.
		/// </summary>
		public double lineHeight { get; set; }
	}

	/// <summary> Raster image whose binary content is stored in the document-level <c>files</c> map keyed by <see cref="fileId"/>. </summary>
	public sealed class ImageElement : Element {
		/// <summary>
		/// SHA-1 FileId referencing the binary data in <c>ExcalidrawDocument.files</c>.
		/// <c>null</c> when the image has not yet been assigned a file. JSON key: <c>"fileId"</c>.
		/// </summary>
		public string fileId { get; set; }

		/// <summary>
		/// Load/persistence state of the image binary data.
		/// One of <c>"pending"</c>, <c>"saved"</c>, <c>"error"</c>. JSON key: <c>"status"</c>.
		/// </summary>
		public string status { get; set; }

		/// <summary>
		/// Two-element array [scaleX, scaleY] in the range [-1, 1].
		/// A value of -1 on either axis flips the image on that axis.
		/// JSON key: <c>"scale"</c>.
		/// </summary>
		public double[] scale { get; set; }

		/// <summary>
		/// Active crop rectangle applied to the image, or <c>null</c> if uncropped.
		/// JSON key: <c>"crop"</c>.
		/// </summary>
		public ImageCrop crop { get; set; }
	}

	/// <summary> Crop rectangle applied to an image element </summary>
	/// <remarks>
	/// expressed in the image's natural (pre-scale) pixel coordinate space.
	/// </remarks>
	public sealed class ImageCrop {
		/// <summary>Left offset of the crop rectangle in natural image pixels. JSON key: <c>"x"</c>.</summary>
		public double x { get; set; }

		/// <summary>Top offset of the crop rectangle in natural image pixels. JSON key: <c>"y"</c>.</summary>
		public double y { get; set; }

		/// <summary>Width of the crop rectangle in natural image pixels. JSON key: <c>"width"</c>.</summary>
		public double width { get; set; }

		/// <summary>Height of the crop rectangle in natural image pixels. JSON key: <c>"height"</c>.</summary>
		public double height { get; set; }

		/// <summary>
		/// Full intrinsic width of the source image in pixels (before any scaling).
		/// JSON key: <c>"naturalWidth"</c>.
		/// </summary>
		public double naturalWidth { get; set; }

		/// <summary>
		/// Full intrinsic height of the source image in pixels (before any scaling).
		/// JSON key: <c>"naturalHeight"</c>.
		/// </summary>
		public double naturalHeight { get; set; }
	}

	/// <summary> Named frame that visually groups and clips its child elements. </summary>
	/// <remarks>
	/// Children reference this frame via their <c>frameId</c> property.
	/// </remarks>
	public sealed class FrameElement : Element {
		/// <summary>
		/// Human-readable label displayed in the frame's header, or <c>null</c>.
		/// JSON key: <c>"name"</c>.
		/// </summary>
		public string name { get; set; }
	}

	/// <summary> AI-generated magic frame. </summary>
	/// <remarks>
	/// Behaves like <see cref="FrameElement"/> but is produced by Excalidraw's text-to-diagram / generative features.
	/// </remarks>
	public sealed class MagicFrameElement : Element {
		/// <summary>
		/// Human-readable label displayed in the frame's header, or <c>null</c>.
		/// JSON key: <c>"name"</c>.
		/// </summary>
		public string name { get; set; }
	}

	/// <summary> Embeds an external web resource (URL) rendered as an interactive widget. </summary>
	public sealed class EmbeddableElement : Element { }

	/// <summary> Inline iframe for arbitrary HTML content directly on the canvas. </summary>
	/// <remarks>
	/// May carry AI generation metadata in <c>customData.generationData</c>.
	/// </remarks>
	public sealed class IFrameElement : Element { }
}
