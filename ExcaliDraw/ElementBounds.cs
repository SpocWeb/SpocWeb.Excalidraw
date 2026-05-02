namespace org.SpocWeb.PptxToJson.ExcaliDraw;

public record struct ElementBounds {
	public double X { get; set; }
	public double Y { get; set; }
	public double Width { get; set; }
	public double Height { get; set; }
	public double AngleRadians { get; set; }
}
