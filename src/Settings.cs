using ModSettings;

namespace ArrowMod
{
	internal class ArrowModSettings : JsonModSettings
	{
		[Name("Arrowhead craft time")]
		[Description("Minutes to craft 2 arrowheads. Default is 60, recommended is 20-40")]
		[Slider(1, 120)]
		public int arrowHeadCraftTime = 60;

		[Name("Arrow craft time")]
		[Description("Minutes to craft 1 arrow. Default is 90, recommended is 15-30")]
		[Slider(1, 180)]
		public int arrowCraftTime = 90;

		[Name("Use line")]
		[Description("Require 1 line to craft an arrow. Will not display as a requirement in the crafting menu.")]
		public bool arrowUseLine = false;

		[Name("Craft Arrowshaft from Hardwood")]
		[Description("Allow to use hardwood to craft arrow shafts.")]
		public bool craftArrowFromWood = false;

		[Name("... skill level")]
		[Description("Archery skill required to craft arrow shaft from wood - designed to be late game - recommended is 4-5.")]
		[Slider(0, 5)]
		public int craftArrowFromWoodLevel = 5;

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