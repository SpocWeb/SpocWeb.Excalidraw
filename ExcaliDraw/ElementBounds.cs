using org.SpocWeb.root.Attributes;
using System.ComponentModel;
namespace org.SpocWeb.PptxToJson.ExcaliDraw;

/// <summary>Similar to <see cref="System.Drawing.Rectangle"/> but with <see cref="AngleRadians"/><br/>
/// Initializes an <see cref="ElementBounds"/> with position, size and <paramref name="angleRad"/>.</summary>
/// <remarks>
/// ## Meta
/// pass: 2
/// mtime: 2026-05-15T20:55:59Z
/// digest: bcae9ce00ceab71fbd3e569f2256e842c60f3f559f9d378303e20923f65942e4
/// updated: 2026-05-19
/// </remarks>
[DocState(Pass = 2, MTime = "2026-08-22T20:36:28Z", Digest = "071b8c55dca145d8bca4ac3eef758d87b7cfd6e8dd5b36d792209dcc0284bd0c", Stale = false, Path = "ExcaliDraw/ElementBounds.cs", Since = "2026-08-22")]
[System.ComponentModel.Description("Similar to Rectangle but with AngleRadians  Initializes an ElementBounds with position, size and angleRad.")]
public record struct ElementBounds {
	/// <summary>Initializes a new instance of <see cref="ElementBounds"/> with the specified <paramref name="x"/>, <paramref name="y"/>, <paramref name="width"/>, <paramref name="height"/> and <paramref name="angleRad"/>.</summary>
	[System.ComponentModel.Description("Initializes a new instance of ElementBounds with the specified x, y, width, height and angleRad.")]
	public ElementBounds(double x, double y, double width, double height, double angleRad) {
		X = x;
		Y = y;
		Width = width;
		Height = height;
		AngleRadians = angleRad;
	}

	/// <summary>Gets or sets the x.<br/>
	/// Gets or sets the y.</summary>
	[System.ComponentModel.Description("Gets or sets the x.")]
	public double X { get; set; }
	/// <summary>Gets or sets the y.</summary>
	[System.ComponentModel.Description("Gets or sets the y.")]
	public double Y { get; set; }
	/// <summary>Gets or sets the width.</summary>
	[System.ComponentModel.Description("Gets or sets the width.")]
	public double Width { get; set; }
	/// <summary>Gets or sets the height.</summary>
	[System.ComponentModel.Description("Gets or sets the height.")]
	public double Height { get; set; }

	/// <summary> Rotation Angle, also used to determine the Bounding Box </summary>
	/// <remarks>
	/// | TYPE		| HOW ANGLE IS APPLIED |
	/// |	---		| --- |
	/// | Rectangle	| All 4 corners are individually rotated around the element's centre (cx, cy) using rotate(x, y, cx, cy, element.angle). Min/Max of the rotated corners gives the AABB. |
	/// | Diamond	| The 4 axis-midpoint vertices(top, bottom, left, right) are each rotated around centre, then min/max is taken. |
	/// | Ellipse	| Uses analytical formulas: ww = √((w·cos θ)² + (h·sin θ)²), hh = √((h·cos θ)² + (w·sin θ)²), giving the AABB as [cx−ww, cy−hh, cx+ww, cy+hh]. Both cos(angle) and sin(angle) are called directly. |
	/// | FreeDraw	| Each raw point is rotated via rotate(x, y, cx−el.x, cy−el.y, element.angle) before min/max is computed. |
	/// | Linear	| Points are rotated via a transformXY callback (x, y) => rotate(el.x + x, el.y + y, cx, cy, element.angle) that is passed into the Bézier curve bounds calculator. |
	/// </remarks>
	[System.ComponentModel.Description("Rotation Angle, also used to determine the Bounding Box")]
	public double AngleRadians { get; set; }
}
