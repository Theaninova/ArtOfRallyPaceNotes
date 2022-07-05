# Art Of Rally Pace Notes

[![](https://img.shields.io/github/v/release/Theaninova/Art-Of-Rally-Pacenotes?label=Download)](https://github.com/Theaninova/Art-Of-Rally-Reset-Visualizer/releases/latest)
![](https://img.shields.io/badge/Game%20Version-v1.3.3a-blue)
[![Art Or Rally Discord](https://badgen.net/discord/members/Sx3e7qGTh9)](https://discord.gg/Sx3e7qGTh9)

A mod for Art Of Rally that adds automatic & configurable pace notes.

#### Launcher Support
![](https://img.shields.io/badge/GOG-Supprted-green)
![](https://img.shields.io/badge/Steam-Supprted-green)
![](https://img.shields.io/badge/Epic-Untested-yellow)

#### Platform Support
![](https://img.shields.io/badge/Windows-Supprted-green)
![](https://img.shields.io/badge/Linux-Untested-yellow)
![](https://img.shields.io/badge/OS%2FX-Untested-yellow)
![](https://img.shields.io/badge/PlayStation-Not%20Supprted-red)
![](https://img.shields.io/badge/XBox-Not%20Supprted-red)
![](https://img.shields.io/badge/Switch-Not%20Supprted-red)


## Usage

Press `CTRL + F10` to bring up the mod menu. Click on the Pace Notes mod,
and enable or disable the desired features.

### Features

TODO

### Folder Structure

```
mod root/
├─ PaceNoteAssets/
│  ├─ default/
│  │  ├─ 1R.png
│  │  └─ ...
│  └─ yourCustomAssets/
│     ├─ 1R.png
│     └─ ...
├─ PaceNoteConfigs/
│  ├─ default/
│  │  ├─ finland_noormarkku.csv
│  │  └─ ...
│  └─ yourCustomPaceNotes/
│     ├─ finland_noormarkku.csv
│     └─ ...
├─ ArtOfRallyPaceNotes.dll
└─ info.json

```

### Writing Pace Notes

In principle, you could use any names for your pace notes, but
for the sake of consistency, we are going to use the Patterson "Numbers" system
for naming.

[![](https://www.rallynews.net/pattersonpacenotes/images/2011Notesymbols.gif)](https://www.rallynews.net/pattersonpacenotes/systemtypes.asp)

This does *not* mean that they will be displayed like this, that will be up to
the asset set you use.

Pace Notes are written as a [CSV](https://en.wikipedia.org/wiki/Comma-separated_values) file,
with the following columns:

| Start Waypoint | End Waypoint | Pace Note |
|----------------|--------------|-----------|
| 0              | 10           | 1R        |
| 20             | 30           | AcR       |
| ...            | ...          | ...       |

This means from waypoint 0..10, you will see the pace note for 1R.

## Installation

Follow the [installation guide](https://www.nexusmods.com/site/mods/21/) of
the Unity Mod Manager.

Then simply download the [latest release](https://github.com/Theaninova/Art-Of-Rally-Reset-Pacenotes/releases/latest)
and drop it into the mod manager's mods page.

## Showcase

[**Demo Video:**](TODO)
