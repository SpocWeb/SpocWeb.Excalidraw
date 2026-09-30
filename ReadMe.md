---
facet-complexity: 1
facet-status: active
facet-layer: infrastructure
tags:
  - code/entry_point
concepts:
  - Technology\IT\Data\File_Format.md
description: "This folder contains `Program`: application entry point for the SpocWeb."
uid: SpocWeb.Excalidraw.md
tags: [arch, dev ]
digest:
  local-classes:
    Program:
      mtime: "2026-06-09T16:08:50Z"
      digest: "e1623107bf1d964a526b588adc259035fbc65d746201544be5e5926fddd0dbb9"
  folders: {}
related:
  - path: ../_Matthias/Code/NET/_org.structs/SpreadSheet/App.xaml.cs
    shared-tags: [code/entry_point]
  - path: ../_Matthias/Code/NET/_root/Testing/RegExp/Editor
    shared-tags: [code/entry_point]
  - path: ../_Matthias/Code/NET/_root/Testing/RegExp/RegulExer
    shared-tags: [code/entry_point]
dv_has_:
  sub_:
    folders: 1
    files: 18
    units: 45
    facet_:
      layer_:
        domain: 38
        infrastructure: 7
      status_:
        active: 45
      complexity_:
        "1": 31
        "2": 9
        "3": 4
        "4": 1
    tag_:
      code_:
        dto: 27
        json_serialization: 4
        id_generation: 1
        polymorphic_deserialization: 1
        enum: 9
        enum_parsing: 1
        parsing: 2
        enum_conversion: 1
        string_conversion: 1
        geometry: 1
    concept_:
      "Technology\\IT\\Data\\File_Format.md": 45
      diagram_element_model: 15
has_sub_folders: 1
has_sub_files: 18
has_sub_units: 45
has_sub_facet_layer_domain: 38
has_sub_facet_layer_infrastructure: 7
has_sub_facet_status_active: 45
has_sub_facet_complexity_1: 31
has_sub_facet_complexity_2: 9
has_sub_facet_complexity_3: 4
has_sub_facet_complexity_4: 1
has_sub_tag_code_dto: 27
has_sub_tag_code_json_serialization: 4
has_sub_tag_code_id_generation: 1
has_sub_tag_code_polymorphic_deserialization: 1
has_sub_tag_code_enum: 9
has_sub_tag_code_enum_parsing: 1
has_sub_tag_code_parsing: 2
has_sub_tag_code_enum_conversion: 1
has_sub_tag_code_string_conversion: 1
has_sub_tag_code_geometry: 1
has_sub_concept_technology_it_data_file_format_md: 45
has_sub_concept_diagram_element_model: 15
---
# SpocWeb.Excalidraw

This folder contains `Program`: application entry point for the SpocWeb.

## Classes

| Class | Responsibility |
|---|---|
| [Program](Program.cs) | Application entry point for the SpocWeb. |

## Subsystems

| Folder | Domain Role |
|---|---|
| [`ExcaliDraw/`](ExcaliDraw/ReadMe.md) | Excalidraw data model, parser, serializer, and JSON conversion utilities. |

## Architecture

```mermaid
flowchart TD
    Program["Program
    (entry point)"]
    ExcaliDraw["ExcaliDraw/
    (data model + serialization)"]

    Program -->|uses| ExcaliDraw
```
