# GitHub Copilot Instructions for Preset Filtered Zones (Continued)

## Mod Overview and Purpose

Preset Filtered Zones (Continued) is a RimWorld mod that builds upon the functionality of the original `cuproPandas` mod. This update includes several improvements, such as:

- Japanese translation by Proxyer.
- Support for translating stockpile labels.
- The addition of presets to storage buildings and stockpiles.

The mod aims to simplify the process of creating storage zones by providing pre-filtered categories for meals, meat, vegetables, medicine, joy, animals, outdoor items, and indoor items.

## Key Features and Systems

### Zones Added

- **Meal**: A zone for rottable meals.
- **Medicine**: A zone for anything in the medicine category.
- **Meat**: A zone for meats other than human and insect.
- **Veg**: A zone for rottable fruits, vegetables, and edible seeds.
- **Joy**: A zone for ingestibles that give joy when consumed, including drugs.
- **Animal**: A zone for fresh animal corpses (excluding insect and rotting corpses).
- **Outdoor**: A zone for items and raw resources that will not deteriorate outside.
- **Indoor**: A zone for anything that deteriorates outside.

### Compatibility

- **Save Compatibility**: The mod can be added to existing saves. Always back up your saves before adding new mods.
- **Mod Compatibility**: The mod is known to have issues with Industrial Rollers, as these zones are not recognized. Zones remain usable for normal hauling.

## Coding Patterns and Conventions

### C# File Structure

The mod consists of several C# files, each serving a specific purpose:

- **Building_Storage_GetGizmos.cs**: Contains the `Building_Storage_GetGizmos` class with a `Postfix` method.
- **Designator_OutdoorZoneAdd.cs**: Contains the `Designator_OutdoorZoneAdd` class.
- **Designator_PresetZoneAdd.cs**: Contains the `Designator_PresetZoneAdd` class with methods `CanDesignateCell`, `MakeNewZone`, and `NewZoneLabel`.
- **Designator_VegZoneAdd.cs**: Contains the `Designator_VegZoneAdd` class.
- **Harmony_Patches.cs**: Contains the `Harmony_Patches` class.

### XML Integration

The mod uses XML files to define patches and integrate with the RimWorld game. The main XML file is `Patches_Core.xml`, which contains definitions for various patches.

## Harmony Patching

The mod uses Harmony for patching RimWorld methods. This allows the mod to modify existing game behavior without altering the original game files. The `Harmony_Patches.cs` file contains the necessary patches to implement the new zones and their functionalities.

## Suggestions for Copilot

To ensure Copilot provides relevant suggestions for this mod, consider the following:

- **Context**: When working on the mod, provide context by including relevant classes and methods.
- **Specificity**: Be specific about the functionality you want to implement, such as adding a new zone or modifying an existing one.
- **Documentation**: Use comments to document your code and explain the purpose of each method or class.
- **Examples**: Provide examples of similar code or patches from the mod to guide Copilot.

By following these guidelines, Copilot will be better equipped to assist you in developing and maintaining the Preset Filtered Zones (Continued) mod.



This `.github/copilot-instructions.md` file provides a comprehensive guide for using GitHub Copilot with the Preset Filtered Zones (Continued) mod, covering the mod's purpose, key features, coding patterns, XML integration, and Harmony patching.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

