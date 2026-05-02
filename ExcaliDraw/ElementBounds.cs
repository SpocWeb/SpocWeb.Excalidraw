namespace org.SpocWeb.PptxToJson.ExcaliDraw;

/// <summary> Alternative to <see cref="System.Drawing.Rectangle"/> </summary>
public record struct ElementBounds {
	public ElementBounds(double x, double y, double width, double height, double angleRad) {
		X = x;
		Y = y;
		Width = width;
		Height = height;
		AngleRadians = angleRad;
	}

	public double X { get; set; }
	public double Y { get; set; }
	public double Width { get; set; }
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
	public double AngleRadians { get; set; }
}
