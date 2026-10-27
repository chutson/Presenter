# Presenter

Presenter is a Windows desktop presentation tool built with .NET 8 and WPF for managing a song or sermon playlist, importing PowerPoint decks, and presenting content on a secondary display.

It is designed for churches and live worship settings where slides can be grouped into verses, toggled on/off, and displayed in order while keeping the presentation flow simple and flexible.

## Features

- Import PowerPoint presentations and convert them into slide data for the app
- Build and manage a playlist of songs or media items
- Expand/collapse playlist sections
- Drag and drop playlist organization
- Toggle individual slides or all slides in the same verse
- Preview the currently selected slide in the right-hand pane
- Start a presentation window on a secondary monitor
- Keep the presentation flow focused on enabled content only

## Screenshots

### Playlist management



### Presentation display



### Verse toggle workflow



## Project structure

- `Presenter.WPF` – WPF application and UI
- `Presenter.Models` – domain models such as songs and slide images
- `Presenter.Services` – service layer and messaging infrastructure
- `Presenter.Common` – shared utilities

## Requirements

### Run-time
- 
- Windows 10/11
- PowerPoint installed for import workflow
- 
- ### Development
- 
- .NET 8 SDK
- Visual Studio 2022 with .NET desktop development workload
- PowerPoint installed for import workflow

## Getting started

1. Clone the repository
   ```bash
   git clone https://github.com/chutson/Presenter.git
   cd Presenter
   ```

2. Open `presenter.sln` in Visual Studio

3. Restore NuGet packages

4. Set `Presenter.WPF` as the startup project

5. Build and run the application

## Usage

1. Import a PowerPoint file from the app UI
2. Add songs or prepared content to the playlist
3. Use the playlist context menu to enable/disable individual slides or full verses
4. Start the presentation from the main window
5. Use the secondary presentation display for audience playback

## Roadmap

- Improved slide editing and reordering
- Additional media format support
- Better presentation timing controls
- Export/import playlist data

## License

This project is provided as-is for personal and ministry use. Update the license text to match your preferred project license before public distribution.
