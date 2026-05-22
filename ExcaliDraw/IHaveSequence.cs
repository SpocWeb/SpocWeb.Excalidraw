namespace org.SpocWeb.PptxToJson.ExcaliDraw;

/// <summary>Contract for objects that carry a monotonically incrementing integer sequence counter.</summary>
/// <remarks>
/// ## Meta
/// pass: 2
/// mtime: 2026-05-02T09:43:19Z
/// digest: fc3f3f23b7d70d32067dd5a9256b2fc966270faeae3e1c775ff380e787da67b8
/// updated: 2026-05-19
/// </remarks>
public interface IHaveSequence<T> {
	/// <summary>Gets or sets the sequence.</summary>
	public T Sequence { get; set; }

}

/// <summary>Extension helpers for <see cref="IHaveSequence{T}"/> that generate Excalidraw-compatible ids and seeds.</summary>
/// <remarks>
/// ## Meta
/// pass: 2
/// mtime: 2026-05-02T09:43:19Z
/// digest: fc3f3f23b7d70d32067dd5a9256b2fc966270faeae3e1c775ff380e787da67b8
/// updated: 2026-05-19
/// </remarks>
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
