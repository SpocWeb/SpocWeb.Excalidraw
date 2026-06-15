namespace org.SpocWeb.PptxToJson.ExcaliDraw;

/// <summary>Contract for objects that carry a monotonically incrementing integer sequence counter.<br/>
/// Gets or sets the sequence.</summary>
/// <remarks>
/// ## Meta
/// pass: 2
/// mtime: 2026-05-02T09:43:19Z
/// digest: fc3f3f23b7d70d32067dd5a9256b2fc966270faeae3e1c775ff380e787da67b8
/// updated: 2026-05-19
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-06-14T11:57:41Z
/// digest: 35bd8afa8faaa7560a9dc1374fb54e9e6c6880a5bcd3bca5aeefdeff8380c614
/// </code>
/// </example>
public interface IHaveSequence<T> {
	/// <summary>Gets or sets the sequence.</summary>
	public T Sequence { get; set; }

}

/// <summary>Extension helpers for <see cref="IHaveSequence{T}"/> that generate Excalidraw-compatible ids and seeds.<br/>
/// Returns a deterministic-looking positive sequence id string.</summary>
/// <remarks>
/// ## Meta
/// pass: 2
/// mtime: 2026-05-02T09:43:19Z
/// digest: fc3f3f23b7d70d32067dd5a9256b2fc966270faeae3e1c775ff380e787da67b8
/// updated: 2026-05-19
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-22T17:44:36Z
/// digest: ea89c8837e5195c1cff18a4dd6f3d69cb4ab38de3dd19b3ee1ca1f2a277d3991
/// </code>
/// </example>
public static class IHaveSequence {
	/// <summary>Returns the next hex-formatted sequence ID for <paramref name="context"/><br/>
	/// by incrementing its counter and formatting it as <c>{prefix}-{sequence:x8}</c>.</summary>
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
