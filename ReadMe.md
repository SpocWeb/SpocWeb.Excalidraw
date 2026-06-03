---
uid: SpocWeb.Excalidraw.md
tags: [arch, dev ]
---

<details><summary><span style="font-size:24px;font-weight:bold">Content</span></summary>
[[_TOC_]]

</details>

# SpocWeb.Excalidraw

<!-- digest-map
local-classes:
  AppState: mtime=2026-05-15T20:56:12Z digest=8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
  Arrow: mtime=2026-05-15T20:57:01Z digest=b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
  BinaryFileData: mtime=2026-05-15T20:56:12Z digest=8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
  BoundElement: mtime=2026-05-15T20:56:12Z digest=8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
  Clipboard: mtime=2026-05-03T11:15:42Z digest=20970f1734f1138a24fae14a8a5d46479de0c31d4930f22a962f48fbbc1bd435
  DiamondElement: mtime=2026-05-15T20:57:01Z digest=b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
  Document: mtime=2026-05-03T11:15:42Z digest=20970f1734f1138a24fae14a8a5d46479de0c31d4930f22a962f48fbbc1bd435
  Element: mtime=2026-05-15T20:57:01Z digest=b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
  ElementBounds: mtime=2026-05-15T20:55:59Z digest=bcae9ce00ceab71fbd3e569f2256e842c60f3f559f9d378303e20923f65942e4
  EllipseElement: mtime=2026-05-15T20:57:01Z digest=b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
  EmbeddableElement: mtime=2026-05-15T20:57:01Z digest=b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
  Excalidraw: mtime=2026-05-10T16:16:18Z digest=ee572f5132b448e06a93d1830b2416bd13a91650e13f869a966de317fc2c8348
  ExcalidrawElementConverter: mtime=2026-05-04T06:50:08Z digest=6bd1a4123c70999cdb57f1abbdadef8453fec2e9a8482179d72178918f415bcd
  ExcalidrawParser: mtime=2026-05-15T20:56:05Z digest=beb3737587544cb4f2871cfd7db7397dbf510d7d76ef91e74d4561c5a2c315bf
  FrameElement: mtime=2026-05-15T20:57:01Z digest=b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
  FreedrawElement: mtime=2026-05-15T20:57:01Z digest=b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
  IFrameElement: mtime=2026-05-15T20:57:01Z digest=b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
  IHaveSequence: mtime=2026-05-02T09:43:19Z digest=fc3f3f23b7d70d32067dd5a9256b2fc966270faeae3e1c775ff380e787da67b8
  ImageCrop: mtime=2026-05-15T20:57:01Z digest=b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
  ImageElement: mtime=2026-05-15T20:57:01Z digest=b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
  LinearElement: mtime=2026-05-15T20:57:01Z digest=b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
  LineElement: mtime=2026-05-15T20:57:01Z digest=b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
  MagicFrameElement: mtime=2026-05-15T20:57:01Z digest=b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
  PascalToSnakeConversion: mtime=2026-05-03T17:35:31Z digest=d4f126731646bc73bcfb4d9d181bb63fa8e639c8fc2319eb96508113d82ce6d5
  PointBinding: mtime=2026-05-15T20:56:12Z digest=8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
  Program: mtime=2026-05-02T09:48:43Z digest=e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855
  RectangleElement: mtime=2026-05-15T20:57:01Z digest=b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
  Roundness: mtime=2026-05-15T20:56:12Z digest=8e3bd7e1288d4ca0bed69587ec0867c4a44255f665cc45018a066de5bebed3c6
  SnakeCaseEnumConverter: mtime=2026-05-03T17:27:38Z digest=a0b69328b4d8d1e16b2115a6ad606198be0bbe56a838aa8f570d82f6958174a0
  TextElement: mtime=2026-05-15T20:57:01Z digest=b390d9e832cad8a4119eca03b771d6044717604550b67134271e51d20afa58d6
folders:
folder_digest: 698a023f6bc7aa6c1967e44ecd12de387a9d497bab697a9ec440ce22fd0a7dd8
folder_mtime: 2026-05-15T20:57:01Z
-->
This Project provides for [Excalidraw](https://excalidraw.com/) Graphics:
- Data Model 
- Parser and Serializer using Newtonsoft JSON

## Classes

| Class | Responsibility | Key Collaborators |
|---|---|---|
| [Excalidraw](ExcaliDraw/Excalidraw.public.cs) | Partial root class; grouping namespace for all Excalidraw types. | All element and model types |
| [Excalidraw.Document](ExcaliDraw/Excalidraw.Document.cs) | Root scene document (schema version 2) containing elements, appState and files. | `Element`, `AppState`, `BinaryFileData` |
| [Excalidraw.Clipboard](ExcaliDraw/Excalidraw.Document.cs) | Clipboard-format variant (`"excalidraw/clipboard"`) used when copying selected elements. | `Element`, `BinaryFileData` |
| [Element](ExcaliDraw/Excalidraw.elements.cs) | Base class for all canvas elements; holds id, geometry, stroke, fill, opacity, grouping and collaboration metadata. | All concrete element types |
| [LinearElement](ExcaliDraw/Excalidraw.elements.cs) | Intermediate base for line and arrow elements; adds `points`, `startBinding`, `endBinding` and arrowheads. | `Arrow`, `LineElement`, `PointBinding` |
| [Arrow](ExcaliDraw/Excalidraw.elements.cs) | Directed arrow with optional 90° elbow routing and endpoint bindings. | `LinearElement`, `PointBinding`, `Arrowhead` |
| [LineElement](ExcaliDraw/Excalidraw.elements.cs) | Undirected polyline or polygon (`polygon=true` to close the path). | `LinearElement` |
| [RectangleElement](ExcaliDraw/Excalidraw.elements.cs) | Axis-aligned rectangle shape. | `Element` |
| [EllipseElement](ExcaliDraw/Excalidraw.elements.cs) | Ellipse or circle shape. | `Element` |
| [DiamondElement](ExcaliDraw/Excalidraw.elements.cs) | Diamond (rotated square) shape. | `Element` |
| [FreedrawElement](ExcaliDraw/Excalidraw.elements.cs) | Freehand stroke with optional per-point pressure data. | `Element` |
| [TextElement](ExcaliDraw/Excalidraw.elements.cs) | Standalone or container-bound text label. | `Element`, `FontFamily`, `TextAlign`, `VerticalAlign` |
| [ImageElement](ExcaliDraw/Excalidraw.elements.cs) | Raster image referenced by `fileId` from the document's `files` map. | `Element`, `BinaryFileData`, `ImageCrop` |
| [FrameElement](ExcaliDraw/Excalidraw.elements.cs) | Named frame that visually groups and clips child elements. | `Element` |
| [MagicFrameElement](ExcaliDraw/Excalidraw.elements.cs) | AI-generated frame produced by Excalidraw's generative features. | `Element` |
| [EmbeddableElement](ExcaliDraw/Excalidraw.elements.cs) | Embedded external URL rendered as an interactive widget. | `Element` |
| [IFrameElement](ExcaliDraw/Excalidraw.elements.cs) | Inline iframe for arbitrary HTML content. | `Element` |
| [ElementBounds](ExcaliDraw/ElementBounds.cs) | Value record for an element's position, size and rotation angle. | All element constructors |
| [Roundness](ExcaliDraw/Excalidraw.model.cs) | Corner-rounding config (`type` + optional `value`). | `Element` |
| [BoundElement](ExcaliDraw/Excalidraw.model.cs) | Reference from a container to a bound arrow or text element. | `Element` |
| [PointBinding](ExcaliDraw/Excalidraw.model.cs) | Arrow-tip attachment descriptor (elementId, focus, gap, fixedPoint). | `LinearElement` |
| [BinaryFileData](ExcaliDraw/Excalidraw.model.cs) | Binary file entry (MIME type, base-64 dataURL, timestamps). | `Document`, `ImageElement` |
| [AppState](ExcaliDraw/Excalidraw.model.cs) | Serializable subset of editor state (background, grid, theme, tool defaults, scroll, zoom). | `Document` |
| [ExcalidrawParser](ExcaliDraw/ExcalidrawParser.cs) | Parses and serializes `Document` and `Clipboard` using configured `JsonSerializerSettings`. | `Document`, `Clipboard`, `ExcalidrawElementConverter`, `SnakeCaseEnumConverter` |
| [ExcalidrawElementConverter](ExcaliDraw/ExcalidrawElementConverter.cs) | Polymorphic `JsonConverter` that reads the `"type"` discriminator and creates the matching element subclass. | `Element` and all subtypes |
| [SnakeCaseEnumConverter](ExcaliDraw/SnakeCaseEnumConverter.cs) | `JsonConverter` that serializes enums as `snake_case` strings. | `PascalToSnakeConversion`, all enum types |
| [PascalToSnakeConversion](ExcaliDraw/PascalToSnakeConversion.cs) | Thread-safe cached PascalCase→snake_case utility used by `SnakeCaseEnumConverter`. | `SnakeCaseEnumConverter` |
| [IHaveSequence&lt;T&gt;](ExcaliDraw/IHaveSequence.cs) | Contract for objects that carry a monotonically incrementing integer counter; helpers generate deterministic ids and seeds. | Element constructors |

## Relationships

```mermaid
flowchart TD
    Document["Document"]
    Clipboard["Clipboard"]
    Element["Element (base)"]
    LinearElement["LinearElement"]
    Arrow["Arrow"]
    LineElement["LineElement"]
    TextElement["TextElement"]
    ImageElement["ImageElement"]
    FrameElement["FrameElement"]
    ExcalidrawParser["ExcalidrawParser"]
    ExcalidrawElementConverter["ExcalidrawElementConverter"]
    SnakeCaseEnumConverter["SnakeCaseEnumConverter"]
    PascalToSnakeConversion["PascalToSnakeConversion"]
    AppState["AppState"]
    BinaryFileData["BinaryFileData"]
    PointBinding["PointBinding"]

    Document -->|"elements"| Element
    Document -->|"appState"| AppState
    Document -->|"files"| BinaryFileData

    linkStyle 0 opacity:1
    linkStyle 1 opacity:1
    linkStyle 2 opacity:1

    Clipboard -->|"elements"| Element
    Clipboard -->|"files"| BinaryFileData

    linkStyle 3 opacity:1
    linkStyle 4 opacity:1

    Element -->|"subtype"| LinearElement
    LinearElement -->|"subtype"| Arrow
    LinearElement -->|"subtype"| LineElement
    Element -->|"subtype"| TextElement
    Element -->|"subtype"| ImageElement
    Element -->|"subtype"| FrameElement

    linkStyle 5 opacity:1
    linkStyle 6 opacity:1
    linkStyle 7 opacity:1
    linkStyle 8 opacity:1
    linkStyle 9 opacity:1
    linkStyle 10 opacity:1

    LinearElement -->|"startBinding/endBinding"| PointBinding
    ImageElement -->|"fileId →"| BinaryFileData

    linkStyle 11 opacity:1
    linkStyle 12 opacity:1

    ExcalidrawParser -->|"uses"| ExcalidrawElementConverter
    ExcalidrawParser -->|"uses"| SnakeCaseEnumConverter
    SnakeCaseEnumConverter -->|"uses"| PascalToSnakeConversion
    ExcalidrawElementConverter -->|"creates"| Element

    linkStyle 13 opacity:1
    linkStyle 14 opacity:1
    linkStyle 15 opacity:1
    linkStyle 16 opacity:1
```

## Quick Start

```csharp
// Parse a .excalidraw scene file.
var document = ExcalidrawParser.ParseExcalidraw(
    File.ReadAllText("diagram.excalidraw"));

// Enumerate all arrow elements.
var arrows = document.elements.OfType<Excalidraw.Arrow>();

// Build a new document and add a rectangle.
var ctx = new MySequenceContext();   // implements IHaveSequence<int>
var bounds = new ElementBounds(x: 100, y: 80, width: 200, height: 120, angleRad: 0);
var rect = new Excalidraw.RectangleElement(bounds, ctx, groupIds: new());

var doc = new Excalidraw.Document();
doc.elements.Add(rect);

// Serialize back to JSON.
string json = doc.ToJson();
```

## Key Concepts

### Polymorphic element model
All canvas elements inherit from [Element](ExcaliDraw/Excalidraw.elements.cs).
[ExcalidrawElementConverter](ExcaliDraw/ExcalidrawElementConverter.cs) reads the
`"type"` discriminator from the JSON token and instantiates the correct subclass
before populating it via `JsonSerializer.Populate`.
Write is delegated to the default Newtonsoft serializer.

### Snake-case enum serialization
Excalidraw's JSON uses `snake_case` strings for enum fields
(e.g. `"cross-hatch"`, `"solid"`, `"arrow"`).
[SnakeCaseEnumConverter](ExcaliDraw/SnakeCaseEnumConverter.cs) delegates
to [PascalToSnakeConversion](ExcaliDraw/PascalToSnakeConversion.cs),
which caches the forward and reverse mappings per enum type in a
`ConcurrentDictionary` for lock-free thread safety.
Values that require a hyphen (e.g. `"cross-hatch"`) are handled by
`[EnumMember]` attributes that bypass the automatic conversion.

### Deterministic ids and seeds
[IHaveSequence&lt;T&gt;](ExcaliDraw/IHaveSequence.cs) provides `NextId` and `NextPositiveInt`
so that element constructors can produce stable, collision-free ids and
`versionNonce` seeds without a global counter.
The id format is `"{type}-{counter:x8}"` (e.g. `"rectangle-00000001"`).

### ElementBounds
[ElementBounds](ExcaliDraw/ElementBounds.cs) is a `record struct` that
captures `x`, `y`, `width`, `height`, and `AngleRadians`.
Element constructors accept it as a single positional parameter,
delegating rounding (`Math.Round` with `AwayFromZero`) to `Excalidraw.Round`.

## Further Reading

- [Excalidraw JSON schema](https://docs.excalidraw.com/docs/codebase/json-schema) — official schema documentation.
- [Excalidraw types.ts](https://github.com/excalidraw/excalidraw/blob/master/packages/excalidraw/types.ts) — TypeScript source from which the C# model was derived.
- [Newtonsoft.Json JsonConverter](https://www.newtonsoft.com/json/help/html/CustomJsonConverter.htm) — basis for `ExcalidrawElementConverter` and `SnakeCaseEnumConverter`.
- [RoughJS](https://roughjs.com/) — the sketchy rendering library referenced by `roughness`, `fillStyle`, and `strokeStyle` fields.

# License
[![Hippocratic License HL3-BDS-BOD-ECO-MEDIA-MIL-MY-SOC-SUP-SV-TAL-XUAR](https://img.shields.io/static/v1?label=Hippocratic%20License&message=HL3-BDS-BOD-ECO-MEDIA-MIL-MY-SOC-SUP-SV-TAL-XUAR&labelColor=5e2751&color=bc8c3d)](https://firstdonoharm.dev/version/3/0/bds-bod-eco-media-mil-my-soc-sup-sv-tal-xuar.html)
This Software is licensed by the [Hippocratic License](https://firstdonoharm.dev),
because we know that technology is not neutral, but can be abused.

Although we apply a permissive License for derivative Work,
we hope that other developers follow our example
and choose [similar ethical licenses](https://ethicalsource.dev/licenses/) for derivative works.

