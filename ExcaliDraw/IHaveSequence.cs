namespace org.SpocWeb.PptxToJson.ExcaliDraw;

public interface IHaveSequence<T> {
	public T Sequence { get; set; }

}

public static class IHaveSequence {
	/// <summary>Returns a deterministic-looking positive sequence id string.</summary> 
	public static string NextId(this IHaveSequence<int> context, string prefix) {
		context.Sequence++;
		return $"{prefix}-{context.Sequence:x8}";
	}

	/// <summary>Returns a positive pseudo-random integer suitable for Excalidraw metadata.</summary> 
	public static int NextPositiveInt(this IHaveSequence<int> context) {
		context.Sequence++;
		return unchecked((context.Sequence * 1103515245 + 12345) & int.MaxValue);
	}


}