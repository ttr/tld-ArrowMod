using MelonLoader;
using System.Reflection;

[assembly: AssemblyTitle(ArrowMod.BuildInfo.ModName)]
[assembly: AssemblyCopyright($"Created by {ArrowMod.BuildInfo.ModAuthor}")]

[assembly: AssemblyVersion(ArrowMod.BuildInfo.ModVersion)]
[assembly: AssemblyFileVersion(ArrowMod.BuildInfo.ModVersion)]
[assembly: MelonInfo(typeof(ArrowMod.ArrowMod), ArrowMod.BuildInfo.ModName, ArrowMod.BuildInfo.ModVersion, ArrowMod.BuildInfo.ModAuthor)]

//This tells MelonLoader that the mod is only for The Long Dark.
[assembly: MelonGame("Hinterland", "TheLongDark")]