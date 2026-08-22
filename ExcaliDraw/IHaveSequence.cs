using org.SpocWeb.root.Attributes;
using System.ComponentModel;
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
[DocState(Pass = 2, MTime = "2026-08-22T17:32:47Z", Digest = "35bd8afa8faaa7560a9dc1374fb54e9e6c6880a5bcd3bca5aeefdeff8380c614", Stale = false, Path = "ExcaliDraw/IHaveSequence.cs", Since = "2026-08-22")]
[System.ComponentModel.Description("Contract for objects that carry a monotonically incrementing integer sequence counter.")]
public interface IHaveSequence<T> {
	/// <summary>Gets or sets the sequence.</summary>
	[System.ComponentModel.Description("Gets or sets the sequence.")]
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
[DocState(Pass = 2, MTime = "2026-08-22T17:32:47Z", Digest = "ea89c8837e5195c1cff18a4dd6f3d69cb4ab38de3dd19b3ee1ca1f2a277d3991", Stale = false, Path = "ExcaliDraw/IHaveSequence.cs", Since = "2026-08-22")]
[System.ComponentModel.Description("Extension helpers for IHaveSequence that generate Excalidraw-compatible ids and seeds.")]
public static class IHaveSequence {
	/// <summary>Returns the next hex-formatted sequence ID for <paramref name="context"/><br/>
	/// by incrementing its counter and formatting it as <c>{prefix}-{sequence:x8}</c>.</summary>
	[System.ComponentModel.Description("Returns the next hex-formatted sequence ID for context  by incrementing its counter and formatting it as  {prefix}-{sequence:x8} .")]
	public static string NextId(this IHaveSequence<int> context, string prefix) {
		context.Sequence++;
		return $"{prefix}-{context.Sequence:x8}";
	}

	/// <summary>Returns a positive pseudo-random integer suitable for Excalidraw metadata.</summary> 
	[System.ComponentModel.Description("Returns a positive pseudo-random integer suitable for Excalidraw metadata.")]
	public static int NextPositiveInt(this IHaveSequence<int> context) {
		context.Sequence++;
		return unchecked((context.Sequence * 1103515245 + 12345) & int.MaxValue);
	}


}
