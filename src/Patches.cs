using MelonLoader;
using Harmony;
using UnhollowerBaseLib;
using UnityEngine;


namespace ArrowMod
{
    internal static class Patches
    {
        [HarmonyPatch(typeof(GameManager), "Awake")]
        public class GameManager_Awake
        {
            private static void Postfix()
            {

                if (Settings.options.arrowUseLine)
                {
                    BlueprintItem bpi = GameManager.GetBlueprints().AddComponent<BlueprintItem>();
                    // Inputs
                    bpi.m_KeroseneLitersRequired = 0f;
                    bpi.m_GunpowderKGRequired = 0f;
                    bpi.m_RequiredTool = null;
                    bpi.m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0);

                    // Outputs
                    bpi.m_CraftedResult = GetGearItemPrefab("GEAR_Arrow");
                    bpi.m_CraftedResultCount = 1;

                    // Process
                    bpi.m_Locked = false;
                    bpi.m_AppearsInStoryOnly = false;
                    bpi.m_RequiresLight = true;
                    bpi.m_RequiresLitFire = false;
                    bpi.m_RequiredCraftingLocation = CraftingLocation.Workbench;
                    bpi.m_DurationMinutes = Settings.options.arrowCraftTime;
                    bpi.m_CraftingAudio = "PLAY_CRAFTINGARROWS";
                    bpi.m_AppliedSkill = SkillType.None;
                    bpi.m_ImprovedSkill = SkillType.None;
                    bpi.m_RequiredGear = new Il2CppReferenceArray<GearItem>(4)
                    {
                        [0] = GetGearItemPrefab("GEAR_Line"),
                        [1] = GetGearItemPrefab("GEAR_CrowFeather"),
                        [2] = GetGearItemPrefab("GEAR_ArrowShaft"),
                        [3] = GetGearItemPrefab("GEAR_ArrowHead")
                    };
                    bpi.m_RequiredGearUnits = new Il2CppStructArray<int>(4)
                    {
                        [0] = 1,
                        [1] = 3,
                        [2] = 1,
                        [3] = 1
                    };
                }
                if (Settings.options.craftArrowFromWood)
                {
                    BlueprintItem bpi = GameManager.GetBlueprints().AddComponent<BlueprintItem>();
                    // Inputs
                    bpi.m_KeroseneLitersRequired = 0f;
                    bpi.m_GunpowderKGRequired = 0f;
                    bpi.m_RequiredTool = GetToolItemPrefab("GEAR_Knife"); ;
                    bpi.m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0);

                    // Outputs
                    bpi.m_CraftedResult = GetGearItemPrefab("GEAR_ArrowShaft");
                    bpi.m_CraftedResultCount = 3;

                    // Process
                    bpi.m_Locked = false;
                    bpi.m_AppearsInStoryOnly = false;
                    bpi.m_RequiresLight = true;
                    bpi.m_RequiresLitFire = false;
                    bpi.m_RequiredCraftingLocation = CraftingLocation.Workbench;
                    bpi.m_DurationMinutes = 180; // with knife it will be 1/2 of this time; it will be much longer than from branch but it takes time to cut arrow from plank
                    bpi.m_CraftingAudio = "PLAY_CRAFTINGARROWS";
                    bpi.m_AppliedSkill = SkillType.None;
                    bpi.m_ImprovedSkill = SkillType.None;
                    bpi.m_RequiredGear = new Il2CppReferenceArray<GearItem>(1)
                    {
                        [0] = GetGearItemPrefab("GEAR_Hardwood")
                    };
                    bpi.m_RequiredGearUnits = new Il2CppStructArray<int>(1)
                    {
                        [0] = 1
                    };
                }
            }
        }

        [HarmonyPatch(typeof(Panel_Crafting), "ItemPassesFilter")]
        private static class Panel_Crafting_ItemPassesFilter
        {
            private static void Postfix(Panel_Crafting __instance, ref bool __result, BlueprintItem bpi)
            {
                if (bpi?.m_CraftedResult?.name == "GEAR_Arrow")
                {
                    if (Settings.options.arrowUseLine && bpi.m_RequiredGear.Count == 3)
                    {
                        __result = false;
                    }
                    bpi.m_DurationMinutes = Settings.options.arrowCraftTime;
                }
                else if (bpi?.m_CraftedResult?.name == "GEAR_ArrowHead")
                {
                    // for mods that override result count, like ForgeBlueprintsMod
                    int resMulti = bpi.m_CraftedResultCount / 2;
                    bpi.m_DurationMinutes = Settings.options.arrowHeadCraftTime * resMulti;

                }

            }
        }

        // based on better mending mod
        [HarmonyPatch(typeof(Panel_Crafting), "RefreshSelectedBlueprint")]
        public class Panel_Crafting_RefreshSelectedBlueprint
        {
            private static void Postfix(Panel_Crafting __instance)
            {
                //__instance.m_SelectedDescription.color = whiteColor;
                BlueprintItem bpi = __instance.m_SelectedBPI;
                if (bpi)
                {
                    if (bpi.m_CraftedResult == GetGearItemPrefab("GEAR_ArrowShaft") && bpi.m_RequiredGear[0] == GetGearItemPrefab("GEAR_Hardwood"))
                    {
                        int currentArcherySkill = GameManager.GetSkillArchery().GetCurrentTierNumber() + 1;
                        int requiredArcherySkill = Settings.options.craftArrowFromWoodLevel;
                        MelonLogger.Log(currentArcherySkill + "<" + requiredArcherySkill);
                        if (currentArcherySkill < requiredArcherySkill)
                        {
                            __instance.m_SelectedDescription.text = "Required Archery skill " + requiredArcherySkill.ToString();
                            __instance.m_SelectedDescription.color = redColor;
                        }
                    }
                }
            }
        }

        // based on better mending mod
        [HarmonyPatch(typeof(BlueprintItem), "CanCraftBlueprint")]
        private class BlueprintItem_CanCraftBlueprint
        {

            private static void Postfix(ref bool __result, BlueprintItem __instance)
            {
                if (__instance.m_CraftedResult == GetGearItemPrefab("GEAR_ArrowShaft") && __instance.m_RequiredGear[0] == GetGearItemPrefab("GEAR_Hardwood") && __result)
                {
                    int currentArcherySkill = GameManager.GetSkillArchery().GetCurrentTierNumber() + 1;
                    int requiredArcherySkill = Settings.options.craftArrowFromWoodLevel;
                    MelonLogger.Log("BPI-test: " + currentArcherySkill + "<" + requiredArcherySkill);
                    if (currentArcherySkill < requiredArcherySkill)
                    {
                        __result = false;
                    }
                }
            }
        }

        private static GearItem GetGearItemPrefab(string name) => Resources.Load(name).Cast<GameObject>().GetComponent<GearItem>();
        private static ToolsItem GetToolItemPrefab(string name) => Resources.Load(name).Cast<GameObject>().GetComponent<ToolsItem>();

        private static readonly Color whiteColor = new Color(0.7f, 0.7f, 0.7f);
        private static readonly Color redColor = new Color(0.7f, 0f, 0f);

    }
}