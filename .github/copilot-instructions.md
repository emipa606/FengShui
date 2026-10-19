# GitHub Copilot Instructions for Feng Shui (Continued)

## Mod Overview and Purpose

**Feng Shui (Continued)** is a RimWorld mod originally developed by pelador and updated for continued use. The mod's primary purpose is to allow players to modify various room characteristics in the game, providing a more personalized and customizable experience regarding how rooms are scored. Specifically, the mod affects impressiveness, wealth, space, beauty, and cleanliness of rooms. Players can tweak these parameters through mod settings to affect room scoring on a percentage basis, allowing for a more dynamic interpretation of room attributes in the game.

## Key Features and Systems

- **Room Characteristic Customization**: Modify room impressiveness, wealth, space, beauty, and cleanliness by adjusting a percentage multiplier between 50% and 200%.
- **Dynamic Room Scoring**: Changes how room attributes are calculated and compared, offering a varied perspective on room impressiveness and other characteristics.
- **Mod Compatibility**: Can be safely added or removed from existing games. Note that interacting with other mods that manipulate the same values may result in compounded effects.
- **User-Friendly Settings**: Mod options can be adjusted in-game, though changes require reloading RimWorld to take effect.

## Coding Patterns and Conventions

- **C# Coding Style**: The project employs typical C# object-oriented programming principles with clearly defined types and methods. Each C# file represents specific functional elements of the mod.
- **Namespace Convention**: All C# classes are encapsulated within an appropriate namespace related to the mod's purpose and functionality.
- **XML Defs**: The project currently does not include XML files but integrates with RimWorld’s settings system through C# scripting.

## XML Integration

While this mod primarily relies on C# for its functionality, any future XML integration should adhere to RimWorld’s XML schema conventions. XML is typically used to define additional game content such as items, recipes, or game settings.

## Harmony Patching

Harmony is used for patching the game's existing methods to inject custom behavior without altering the original code. Although Harmony details are not in the current setup, when utilizing Harmony for potential future enhancements:

- **Prefix/Postfix Methods**: Use these to add logic before or after existing game functions.
- **Transpilers**: For complex modifications, allow for more extensive changes to method bodies.
- **Safety and Compatibility**: Always ensure Harmony patches are specific to avoid conflicts with other mods and maintain game stability.

## Suggestions for Copilot

- **Commenting and Documentation**: Ensure every method and significant code block is well-commented to enhance understanding and collaboration.
- **Code Reusability**: Identify patterns that can be abstracted into reusable functions or classes, improving maintainability.
- **Modular Code Design**: Encourage the separation of concerns within code, keeping logic isolated to make future updates or additions easier.
- **Testing and Validation**: Implement thorough testing routines in the game environment to validate changes and performance impacts.
- **Community Engagement**: Leverage community feedback through platforms like Discord and GitHub to continually improve and curate a more robust mod.

By following these instructions, developers can utilize GitHub Copilot effectively to develop and maintain the Feng Shui (Continued) mod, ensuring stability, compatibility, and future adaptability.

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

