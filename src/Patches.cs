using Harmony;
using MelonLoader;
using UnhollowerBaseLib;
using UnityEngine;

namespace ArrowMod
{
    internal static class Patches
    {
        //item gear names
        private const string ARROWHEAD_NAME = "GEAR_ArrowHead";
        private const string ARROW_NAME = "GEAR_Arrow";
        private const string ARROW_SHAFT_NAME = "GEAR_ArrowShaft";
        private const string LINE_NAME = "GEAR_Line";
        private const string CROW_FEATHER_NAME = "GEAR_CrowFeather";


        [HarmonyPatch(typeof(Panel_Crafting), "ItemPassesFilter")] //runs everytime the crafting menu is opened or scrolled
        private static class RecipesInToolsRecipes
        {
            internal static void Postfix(Panel_Crafting __instance, BlueprintItem bpi)
            {
                if (bpi?.m_CraftedResult?.name == ARROW_NAME && bpi?.m_CraftedResultCount == 1)
                {
                    bpi.m_DurationMinutes = Settings.options.arrowCraftTime;
                    //If using lines for crafting, add them to the crafting requirements
                    if (Settings.options.arrowUseLine && bpi.m_RequiredGear.Length != 4)
                    {
                        bpi.m_RequiredGear = new Il2CppReferenceArray<GearItem>(4)
                        {
                            [0] = GetGearItemPrefab(ARROWHEAD_NAME),
                            [1] = GetGearItemPrefab(ARROW_SHAFT_NAME),
                            [2] = GetGearItemPrefab(CROW_FEATHER_NAME),
                            [3] = GetGearItemPrefab(LINE_NAME)
                        };
                        bpi.m_RequiredGearUnits = new Il2CppStructArray<int>(4) { [0] = 1, [1] = 1, [2] = 3, [3] = 1 };
                    }
                    //If not using lines for crafting, revert blueprint to the original
                    else if(!Settings.options.arrowUseLine && bpi.m_RequiredGear.Length != 3)
                    {
                        bpi.m_RequiredGear = new Il2CppReferenceArray<GearItem>(3)
                        {
                            [0] = GetGearItemPrefab(ARROWHEAD_NAME),
                            [1] = GetGearItemPrefab(ARROW_SHAFT_NAME),
                            [2] = GetGearItemPrefab(CROW_FEATHER_NAME)
                        };
                        bpi.m_RequiredGearUnits = new Il2CppStructArray<int>(3) { [0] = 1, [1] = 1, [2] = 3 };
                    }
                }
                //Change Arrowhead crafting time
                else if (bpi?.m_CraftedResult?.name == ARROWHEAD_NAME)
                {
                    if(bpi?.m_CraftedResultCount == 2)
                    {
                        bpi.m_DurationMinutes = Settings.options.arrowHeadCraftTime;
                    }
                    else if(bpi?.m_CraftedResultCount == 7)
                    {
                        bpi.m_DurationMinutes = Settings.options.arrowHeadCraftTime * 3;
                    }
                }

            }
        }
        private static GearItem GetGearItemPrefab(string name) => Resources.Load(name).Cast<GameObject>().GetComponent<GearItem>();


    }
}