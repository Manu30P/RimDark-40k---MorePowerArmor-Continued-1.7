# RimDark 40k - MorePowerArmor 1.2.0

- Added RimWorld 1.7 compatibility while retaining RimWorld 1.6 support.
- Updated the 1.7 build to .NET 10 and adapted the outfit-stand gorget patch to the 1.7 rendering API.
- Original mod by Portesel; RimWorld 1.7 compatibility update by Manu30 (Merk).

# RimDark 40k - MorePowerArmor 1.1.0

- Corrected the Visual Studio project target from .NET Framework 4.7.2 to 4.8, matching the current Core40k and Genes40k assemblies.
Compatibility update for RimWorld 1.6, RimDark 40k - Framework 1.2.32, and RimDark 40k - Mankind's Finest 1.1.13.

- Migrated backpack and shoulder rendering to `PawnRenderNode_FlagEdit`.
- Replaced the removed jump-pack and mask flag API with `DefModExtension_TextureFlags` and mask expansions.
- Migrated armor customization tabs to `DefModExtension_AvailableDrawerTabDefs`.
- Updated mask and decoration definitions for the current Core40k schema.
- Rebuilt the Gravis gorget renderer and outfit-stand patch against the current assemblies.
- Fixed the malformed Indomitus shoulder offset.
- Added complete direct dependencies and Workshop links to `About.xml`.
- Updated the Visual Studio project references and retained the `.sln` file.
