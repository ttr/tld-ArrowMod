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
                internal static void Postfix(Panel_Crafting __instance, BlueprintItem bpi)
                {
                    if (bpi?.m_CraftedResult?.name == "GEAR_Arrow")
                    {
                        bpi.m_DurationMinutes = Settings.options.arrowCraftTime;
                        if (Settings.options.arrowUseLine)
                        {
                            bpi.m_RequiredGear[0] = GetGearItemPrefab("GEAR_Line");
                            bpi.m_RequiredGear[1] = GetGearItemPrefab("GEAR_CrowFeather");
                            bpi.m_RequiredGear[2] = GetGearItemPrefab("GEAR_ArrowShaft");
                            bpi.m_RequiredGearUnits[0] = 1;
                            bpi.m_RequiredGearUnits[1] = 3;
                            bpi.m_RequiredGearUnits[2] = 1;
                        }
                    } else if (bpi?.m_CraftedResult?.name == "GEAR_ArrowHead")
                    {
                        bpi.m_DurationMinutes = Settings.options.arrowHeadCraftTime;
                    } else if (bpi?.m_CraftedResult?.name == "GEAR_ArrowShaft" && Settings.options.arrowUseLine)
                    {
                        if (bpi.m_RequiredGear.Count != 2)
                        {
                            MelonLogger.Log(bpi.m_RequiredGear.Count);
                            bpi.m_RequiredGear = new Il2CppReferenceArray<GearItem>(2) { [0] = GetGearItemPrefab("GEAR_BirchSaplingDried"), [1] = GetGearItemPrefab("GEAR_ArrowHead") };
                            bpi.m_RequiredGearUnits = new Il2CppStructArray<int>(2) { [0] = 1, [1] = 3 };
                        }
                        else
                        {
                            bpi.m_RequiredGear[0] = GetGearItemPrefab("GEAR_BirchSaplingDried");
                            bpi.m_RequiredGear[1] = GetGearItemPrefab("GEAR_ArrowHead");
                            bpi.m_RequiredGearUnits[0] = 1;
                            bpi.m_RequiredGearUnits[1] = 3;
                        }

                    }

                }
            }
            private static GearItem GetGearItemPrefab(string name) => Resources.Load(name).Cast<GameObject>().GetComponent<GearItem>();

        }
	}
}