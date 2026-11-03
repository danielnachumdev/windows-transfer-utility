# Windows Transfer Utility – Agent Context

Implementation guide for coding agents. Product pitch and user build steps: [`README.md`](README.md).

---

## Orientation

| Item | Detail |
| ---- | ------ |
| What is this? | WinForms desktop app — merge / transfer folder trees with newer-wins collisions |
| UI entry | `Windows Transfer Utility/MainForm.cs` (+ `MainForm.Designer.cs`, `MainForm.resx`) |
| Host | `Program.cs` → `Application.Run(new MainForm())` |
| Toolchain | .NET SDK + Windows Forms (`Microsoft.NET.Sdk.WindowsDesktop`) |
| Target | `netcoreapp3.1`, `UseWindowsForms` |
| Tests | None today |
| Platform | **Windows only** |
| Secrets | No API keys; do not commit personal absolute paths or private media |

```text
.
├── Windows Transfer Utility.sln
├── Windows Transfer Utility/
│   ├── Windows Transfer Utility.csproj
│   ├── Program.cs
│   ├── MainForm.cs              # smartTransfer, options, copy/cut, merge
│   ├── MainForm.Designer.cs     # WinForms layout
│   ├── MainForm.resx
│   └── Windows Transfer Utility.ico
├── Windows Transfer Utility.exe # prebuilt binary (tracked)
├── Windows Transfer Utility.png
├── README.md
└── AGENTS.md
```

Namespace / folder spelling: **`Windows_Transfer_Utility`** / **`Windows Transfer Utility`** (spaces in project path — keep as-is unless intentionally renaming everything).

---

## Develop

```bash
dotnet build "Windows Transfer Utility.sln"
dotnet run --project "Windows Transfer Utility"
```

Logic lives almost entirely in `MainForm.cs`:

- **`smartTransfer`** — recursive walk of source; creates missing target dirs, then files/subdirs
- **Collisions** — `File.GetLastWriteTime`; newer source wins; `backupCheckBox` → `.backup` + `replacedlog`, else delete older target
- **Mode** — `copyRadioButton` / `cutRadioButton` (move; may delete source after transfer)
- **`checkForMerge`** — when `mergeCheckBox` is on, strips Windows ` (N)` duplicate folder suffixes in relative paths
- **Empty dirs** — `deleteEmptyFoldersCheckBox`, `skipEmptyDirectoriesCheckBox`
- **Worker** — background `Thread` + UI timers for progress / status; stop writes error / replaced logs under target

Prefer small, focused edits in `MainForm.cs` / Designer; do not invent a separate library layer unless requested.

---

## PRs, CI, and releases

1. Branch off `main`; open a PR into `main`.
2. Attach **exactly one** semver label: `noBump` | `bumpPatch` | `bumpMinor` | `bumpMajor`.
3. Prefer required checks **`CI / CI`** and **`Semver / Semver`** when thin CI from [`danielnachumdev/actions`](https://github.com/danielnachumdev/actions) is on `main` (`allow-empty` is appropriate while there are no tests). Adoption may land via an open HOW-TO PR; until then, docs/chore PRs still use **`noBump`**.
4. Docs-only / chore PRs use **`noBump`**.
5. Do not invent NuGet / PyPI publish for this personal WinForms tool unless explicitly requested.

Shared how-to: [actions HOW-TO-USE](https://github.com/danielnachumdev/actions/blob/v1/HOW-TO-USE.md).

---

## Do not

- Rewrite the app to non-WinForms / cross-platform without an explicit request
- Delete or “fix” spaces in the project folder name in isolation (breaks `.sln` / `.csproj` paths)
- Commit generated `bin/` / `obj/`, secrets, or large personal media dumps
- Remove the tracked `.exe` without an explicit request (users download it from the repo)
