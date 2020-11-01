using Harmony;
using MelonLoader;
using UnhollowerBaseLib;
using UnityEngine;

namespace ArrowMod
{
    internal static class Patches
    {

        [HarmonyPatch(typeof(GameManager), "Awake")]
        public class GameManager_Awake
        {
            [HarmonyPatch(typeof(Panel_Crafting), "ItemPassesFilter")]
            private static class RecipesInToolsRecipes
            {
                internal static void Prefix(Panel_Crafting __instance, BlueprintItem bpi)
                {
                    if (bpi?.m_CraftedResult?.name == "GEAR_Arrow")
                    {
                        bpi.m_DurationMinutes = Settings.options.arrowCraftTime;
                        if (Settings.options.arrowUseLine)
                        {
                            MelonLogger.Log("use line");
                            bpi.m_RequiredGear = new Il2CppReferenceArray<GearItem>(4) { [0] = GetGearItemPrefab("GEAR_Line"), [1] = GetGearItemPrefab("GEAR_ArrowHead"), [2] = GetGearItemPrefab("GEAR_CrowFeather"), [3] = GetGearItemPrefab("GEAR_ArrowShaft") };
                            bpi.m_RequiredGearUnits = new Il2CppStructArray<int>(4) { [0] = 1, [1] = 1, [2] = 3, [3] = 1 };
                        }
                    } else if (bpi?.m_CraftedResult?.name == "GEAR_ArrowHead")
                    {
                        bpi.m_DurationMinutes = Settings.options.arrowHeadCraftTime;
                    }
                }
            }
            private static GearItem GetGearItemPrefab(string name) => Resources.Load(name).Cast<GameObject>().GetComponent<GearItem>();

        }
	}
}