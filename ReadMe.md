---
concepts: []
facets: {}
description: "This folder contains `Program`: application entry point for the SpocWeb."
uid: SpocWeb.Excalidraw.md
tags: [arch, dev ]
digest:
  local-classes:
    Program:
      mtime: "2026-06-09T16:08:50Z"
      digest: "e1623107bf1d964a526b588adc259035fbc65d746201544be5e5926fddd0dbb9"
  folders: {}
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
