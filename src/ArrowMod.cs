using MelonLoader;

using UnityEngine;

namespace ArrowMod
{
	public static class BuildInfo
	{
		public const string Name = "ArrowMod"; // Name of the Mod.  (MUST BE SET)
		public const string Description = "A mod to make arrow crafting more realistic."; // Description for the Mod.  (Set as null if none)
		public const string Author = "ttr, ds5678"; // Author of the Mod.  (MUST BE SET)
		public const string Company = null; // Company that made the Mod.  (Set as null if none)
		public const string Version = "1.7.1"; // Version of the Mod.  (MUST BE SET)
		public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
	}
	internal class ArrowMod : MelonMod
	{
		public override void OnApplicationStart()
		{
			Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
			Settings.OnLoad();
		}
	}
}