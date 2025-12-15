# Old Phone Keypad Simulator

A simple C# solution that simulates typing text using an old mobile phone keypad, where each number key is pressed multiple times to select a character.

## Problem Overview

Older mobile phones required pressing number buttons repeatedly to type letters.
This project converts a sequence of keypad presses into the corresponding text output.

## Keypad Layout

```
1       2       3
&'(     ABC     DEF

4       5       6
GHI     JKL     MNO

7       8       9
PQRS    TUV     WXYZ

        0
```

## Special Characters

- `*` — Backspace (removes the last character)
- `#` — Send (ends input processing)
- `(space)` — Pause (required when typing consecutive letters from the same button)

## Examples

```
OldPhonePad("33#") => "E"
OldPhonePad("227*#") => "B"
OldPhonePad("4433555 555666#") => "HELLO"
OldPhonePad("8 88777444666*664#") => "TURING"
```

## Implementation Notes

The solution processes the input in a single pass while keeping track of the current button and how many times it has been pressed.

Key behaviors handled:

- Grouping repeated presses of the same button
- Processing input when a space or a different button is encountered
- Wrapping around when presses exceed the number of available letters
- Supporting backspace (\*) and send (#) operations

## Design Choices

### Separated button processing logic

The logic for converting button presses into a character occurs in multiple places, so it is handled by a dedicated helper method to avoid duplication.

### Modulo wrapping

Allows cycling back to the first character if a button is pressed more times than it has letters (e.g. 2222 → A).

### StringBuilder usage

Since characters are appended incrementally, StringBuilder is used to avoid unnecessary string allocations.

## Running the Project

```bash
dotnet build
dotnet run
```

## Test Coverage

The project includes manual test cases covering:

- Basic single and repeated button presses
- Character wrapping behavior
- Handling spaces between same-button presses
- Backspace functionality
- Common edge cases (empty input, invalid buttons, buttons 0 and 1)

## Complexity

- **Time Complexity**: O(n), where n is the length of the input
- **Space Complexity**: O(m), where m is the length of the output

## Project Structure

```
OldPhonePad/
├── OldPhonePad.cs         # Core implementation
├── Program.cs             # Test runner
├── OldPhonePad.csproj     # Project configuration
└── README.md              # Documentation
```

## Notes

This solution was implemented as part of a C# coding challenge and focuses on clarity, correctness, and maintainability.
