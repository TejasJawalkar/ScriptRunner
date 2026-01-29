# Architecture Overview

ScriptRunner is structured using a layered desktop application architecture to promote separation of concerns, maintainability, and testability.

## Layers

### UI Layer (WinForms)
Handles all UI interactions.

### Core Layer
Contains batching, execution logic, providers, and models.

### Infrastructure Layer
Handles persistence via EF Core.

## Execution Flow

User selects SQL file → ScriptBatcher splits → Provider executes → Results logged → History saved
