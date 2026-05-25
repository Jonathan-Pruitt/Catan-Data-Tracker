**IMPORTANT NOTE (5/24/2026)** - 
*This code is rough. This was the first major project that I created on my own very shortly after learning the absolute basics of coding.
I am presently working on creating an updated release which I am hoping to have rolled out by July 1, 2026 (tentatively).*

# **Catan Companion**

A data tracking app designed to be run in parallel with a game of Settlers of Catan or Seafarers. The app collects data about the players, settlements/cities, resources dispersed/blocked, dice rolls, and more. All data is collected and stored locally in your RAM during execution, with an end-game option to 'export' to .csv if permanent data is desired *(no data is transmitted over network or cloud in the current build).*

## Key Features

Here is a list of all of the data points tracked by this release:

 - Number of times each roll value rolled (e.g. "In this game, 8 was rolled 6 times")
 - The total amount of resources earned by each player
 - The total amount of resources blocked by the presence of the robber for each player
 - Number of knights each player played
 - Number of development cards were purchased by each player
 - Number of Settlements, Cities, and Roads built by each player
 - Number of rounds in the game
 - Duration of each player's turn, round, and game-time
    - *End-of-game screen displays the player with the shortest turn, longest turn, and average turn duration.*

## Installation

### Prerequisites

  - **Operating system**: Windows 10/11
  - **Runtime**: .Net10.0.0 Desktop Runtime *(if you don't have it installed, the Install Wizard should prompt it.)*

### How to install/run
  1) **Click on Releases**: Select the release you want to download.
  2) **Download the App**: Scroll down to the Assets section at the bottom of this release page and click on CatanCompanion*.zip to download it.
  3) **Extract the Files**: Locate the downloaded .zip file on your PC, right-click it, and select Extract All... to unzip it to a folder of your choice.
  4) **Run the Installer**: Open the extracted folder and double-click setup.exe.
  5) **Launch**: Open the folder the files were extracted to and run the `CatanCompanion.exe` executable file.
  6) **Enjoy!**: *(Launch the app after setting up the gameboard, but before Player1 selects their first settlement location)*

## Build Info
 - **IDE**: Visual Studio v18.6.1
   - **Visual Studio Workload**: .NET Desktop Development
 - **Target Framework**: net10.0-windows

## Known Issues

At present, I am not aware of any runtime bugs in the app; however, I intend to revamp the app's UX/UI to improve flow and optimize resource usage.
**Please feel free to create an issue if you encounter a bug, a break, or any other desired change**
