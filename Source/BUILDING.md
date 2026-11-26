# Building MorePowerArmor

## RimWorld 1.7 (.NET 10 / Waylith)

Build `Rimdark_MorePowerArmors/Rimdark_MorePowerArmors.1.7.csproj` with the .NET 10 SDK:

```powershell
dotnet build Rimdark_MorePowerArmors/Rimdark_MorePowerArmors.1.7.csproj -c Release
```

Both Debug and Release builds output directly to `1.7\Assemblies` inside the mod.

## RimWorld 1.6 (.NET Framework 4.8)

Open `Rimdark_MorePowerArmors/Rimdark_MorePowerArmors.sln` in Visual Studio 2022 with the .NET Framework 4.8 targeting pack installed.

The project defaults to these paths:

- RimWorld: `C:\Logiciels\Steam\steamapps\common\RimWorld` (the 1.7 project also auto-detects `C:\Program Files (x86)\Steam\steamapps\common\RimWorld`)
- Workshop: `C:\Logiciels\Steam\steamapps\workshop\content\294100` (the 1.7 project also auto-detects `C:\Program Files (x86)\Steam\steamapps\workshop\content\294100`)

The project references the live assemblies for RimWorld, Harmony, RimDark 40k - Framework, and RimDark 40k - Mankind's Finest. Both Debug and Release builds output directly to `1.6\Assemblies` (for 1.6) or `1.7\Assemblies` (for 1.7) inside the mod.

For another installation location, override the `RimWorldDir` and `WorkshopDir` MSBuild properties or edit their defaults in the `.csproj` file. Do not copy dependency DLLs into this mod; they must remain supplied by their owning mods.
