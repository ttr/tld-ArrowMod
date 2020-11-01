using ModSettings;
using System.Reflection;

namespace ArrowMod
{
	internal class ArrowModSettings : JsonModSettings
	{

		[Name("Arrowhead craft time")]
		[Description("Minutes to craft arrowhead. Default is 60, recommended 20-40")]
		[Slider(1, 180)]
		public int arrowHeadCraftTime = 30;

		[Name("Arrow craft time")]
		[Description("Minutes to craft arrow. Default is 90, recommended 15-30")]
		[Slider(1, 180)]
		public int arrowCraftTime = 30;

		[Name("Use line")]
		[Description("Use lines to craft arrows")]
		public bool arrowUseLine = true;

	}
	internal static class Settings
	{
		public static ArrowModSettings options;
		public static void OnLoad()
		{
			options = new ArrowModSettings();
			options.AddToModSettings("Arrow Mod Settings");
		}
	}
}