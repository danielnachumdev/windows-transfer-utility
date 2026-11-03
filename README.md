# Windows Transfer Utility

WinForms app for **merging duplicated Windows folders** back together. Pick a source and a target; when two files share the same relative path and name, the utility keeps the **newer** one (by last-write time) and optionally backs up or deletes the older copy.

> **Disclaimer:** You are fully responsible for the outcome of any merge or delete this program performs. Back up important data first.

Prebuilt binary (tracked in-repo): [`Windows Transfer Utility.exe`](https://github.com/danielnachumdev/windows-transfer-utility/blob/main/Windows%20Transfer%20Utility.exe)

## What it does

- Browse **source** and **target** folders in the UI
- **Copy** or **Cut** (move) files into the target tree
- On name collisions: keep the newer file; optionally rename the older target file to `.backup` and write a replaced-file log
- Optional cleanup: delete empty source folders, skip empty directories on transfer
- Optional **Merge Similar Directories** for Windows-style copies (`folder`, `folder (1)`, `folder (2)`)

Core transfer logic lives in [`MainForm.cs`](https://github.com/danielnachumdev/windows-transfer-utility/blob/main/Windows%20Transfer%20Utility/MainForm.cs).

## Requirements

- **Windows** (WinForms)
- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet/3.1) (or a newer SDK that can target `netcoreapp3.1`) — only needed to build from source

## Build & run

```bash
dotnet build "Windows Transfer Utility.sln"
dotnet run --project "Windows Transfer Utility"
```

Or open `Windows Transfer Utility.sln` in Visual Studio and press F5. You can also run the checked-in `.exe` on Windows without building.

## Usage

1. Select the **source** folder and the **target** folder.
2. Choose **Copy** or **Cut**.
3. Toggle options as needed (backup on replace, empty-folder behavior, merge similar directories).
4. Click **Start** and wait for the progress bar / status to finish.
5. If replacements or errors occurred, check logs written under the **target** folder (`REPLACED FILE LOG.txt`, `… - ERROR LOG.txt`).

### Options

![options UI](https://user-images.githubusercontent.com/34595741/132944495-57298977-6b1c-40a8-b81c-b87d9064c617.png)

| Option | Behavior |
| ------ | -------- |
| **when replacing, create backup?** | On collision where source is newer: rename the existing target file to `.backup` (and log it). Off → delete the older target file. |
| **Delete Empty Folders?** | After copying a missing subtree, delete empty folders under **source**. |
| **Skip Empty Directories?** | Do not create empty directories under **target**. |
| **Merge Similar Directories?** | Treat `name`, `name (1)`, `name (2)`, … as the same folder and merge contents (Windows duplicate-folder naming). |

### Merge similar directories — before / after

**Before**

<img width="941" alt="before merge" src="https://user-images.githubusercontent.com/34595741/132944417-2e53ceaf-db17-40d6-83e1-f5613a81a615.png">

**After**

<img width="1242" alt="after merge" src="https://user-images.githubusercontent.com/34595741/132944421-c88cad48-dd19-470e-a31b-0f0ca42271a9.png">

## Contributing

Agent / maintainer notes (layout, toolchain, PR labels): [`AGENTS.md`](./AGENTS.md).
