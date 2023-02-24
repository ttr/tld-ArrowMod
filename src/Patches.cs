using MelonLoader;
using HarmonyLib;
using UnityEngine;
using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppTLD.Gear;
using UnityEngine.Playables;
using Il2CppSystem.Linq.Expressions;

namespace ArrowMod
{
    internal static class Patches
    {

        //[HarmonyPatch(typeof(GameManager), "Awake")]
        [HarmonyPatch(typeof(Panel_Crafting), nameof(Panel_Crafting.Initialize))]
        public class InterfaceManager_Awake
        {
            private static void Postfix()
            {
                
                ArrowMod.Log("Adding blueprints.");
                if (Settings.options.arrowUseLine)
                {
                    BlueprintData bpi = new();

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
                    bpi.m_DurationMinutes = Settings.options.arrowCraftTime; // whaever, we need to set this in ItemPassFilter
                    bpi.m_CraftingAudio = MakeAudioEvent("PLAY_CRAFTINGARROWS");

                    bpi.m_AppliedSkill = SkillType.None;
                    bpi.m_ImprovedSkill = SkillType.None;
                    bpi.m_RequiredGear = new Il2CppReferenceArray<BlueprintData.RequiredGearItem>(0) { };

                    bpi.m_RequiredGear = new Il2CppReferenceArray<BlueprintData.RequiredGearItem>(4)
                    {
                        [0] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_Line") },
                        [1] = new BlueprintData.RequiredGearItem() { m_Count = 3, m_Item = GetGearItemPrefab("GEAR_CrowFeather") },
                        [2] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_ArrowShaft") },
                        [3] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_ArrowHead") }
                    };
                    InterfaceManager.GetInstance().m_BlueprintManager.m_AllBlueprints.Add(bpi);

                    if (Settings.options.craftFletchingFromBark)
                    {
                        BlueprintData bpi2 = new();
                        // Inputs
                        bpi2.m_KeroseneLitersRequired = 0f;
                        bpi2.m_GunpowderKGRequired = 0f;
                        bpi2.m_RequiredTool = GetToolItemPrefab("GEAR_Knife");
                        bpi2.m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0);

                        // Outputs
                        bpi2.m_CraftedResult = GetGearItemPrefab("GEAR_Arrow");
                        bpi2.m_CraftedResultCount = 1;

                        // Process
                        bpi2.m_Locked = false;
                        bpi2.m_AppearsInStoryOnly = false;
                        bpi2.m_RequiresLight = true;
                        bpi2.m_RequiresLitFire = false;
                        bpi2.m_RequiredCraftingLocation = CraftingLocation.Workbench;
                        bpi2.m_DurationMinutes = 2 * (Settings.options.arrowCraftTime + Settings.options.craftFletchingFromBarkTime); // whaever, we need to set this in ItemPassFilter
                        bpi2.m_CraftingAudio = MakeAudioEvent("PLAY_CRAFTINGARROWS");
                        bpi2.m_AppliedSkill = SkillType.None;
                        bpi2.m_ImprovedSkill = SkillType.None;
                        bpi2.m_RequiredGear = new Il2CppReferenceArray<BlueprintData.RequiredGearItem>(4)
                        {
                            [0] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_Line") },
                            [1] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_BarkTinder") },
                            [2] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_ArrowShaft") },
                            [3] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_ArrowHead") }
                        };
                        InterfaceManager.GetInstance().m_BlueprintManager.m_AllBlueprints.Add(bpi2);
                    }
                }
                if (Settings.options.craftArrowFromWood)
                {
                    BlueprintData bpi3 = new();
                    // Inputs
                    bpi3.m_KeroseneLitersRequired = 0f;
                    bpi3.m_GunpowderKGRequired = 0f;
                    bpi3.m_RequiredTool = GetToolItemPrefab("GEAR_Knife");
                    bpi3.m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0);

                    // Outputs
                    bpi3.m_CraftedResult = GetGearItemPrefab("GEAR_ArrowShaft");
                    bpi3.m_CraftedResultCount = 3;

                    // Process
                    bpi3.m_Locked = false;
                    bpi3.m_AppearsInStoryOnly = false;
                    bpi3.m_RequiresLight = true;
                    bpi3.m_RequiresLitFire = false;
                    bpi3.m_RequiredCraftingLocation = CraftingLocation.Workbench;
                    bpi3.m_DurationMinutes = 180; // with knife it will be 1/2 of this time; it will be much longer than from branch but it takes time to cut arrow from plank
                    bpi3.m_CraftingAudio = MakeAudioEvent("PLAY_CRAFTINGARROWS");
                    bpi3.m_AppliedSkill = SkillType.None;
                    bpi3.m_ImprovedSkill = SkillType.None;
                    bpi3.m_RequiredGear = new Il2CppReferenceArray<BlueprintData.RequiredGearItem>(1)
                    {
                        [0] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_Hardwood") }
                    };
                    InterfaceManager.GetInstance().m_BlueprintManager.m_AllBlueprints.Add(bpi3);
                }
            }
        }

        [HarmonyPatch(typeof(Panel_Crafting), "ItemPassesFilter")]
        private static class Panel_Crafting_ItemPassesFilter
        {
            private static void Postfix(Panel_Crafting __instance, ref bool __result, BlueprintData bpi)
            {
                if (bpi?.m_CraftedResult?.name == "GEAR_Arrow")
                {
                    if (Settings.options.arrowUseLine && bpi.m_RequiredGear.Count == 3)
                    {
                        __result = false;
                    }
                    if (bpi.m_RequiredGear[1].m_Item == GetGearItemPrefab("GEAR_BarkTinder"))
                    {
                        bpi.m_DurationMinutes = (Settings.options.arrowCraftTime + Settings.options.craftFletchingFromBarkTime) * 2;
                    }
                    else
                    {
                        bpi.m_DurationMinutes = Settings.options.arrowCraftTime;
                    }
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
                BlueprintData bpi = __instance.m_SelectedBPI;
                if (bpi)
                {
                    __instance.m_SelectedDescription.color = whiteColor;
                    if (bpi.m_CraftedResult == GetGearItemPrefab("GEAR_ArrowShaft") && bpi.m_RequiredGear[0].m_Item == GetGearItemPrefab("GEAR_Hardwood"))
                    {
                        int currentArcherySkill = GameManager.GetSkillArchery().GetCurrentTierNumber() + 1;
                        int requiredArcherySkill = Settings.options.craftArrowFromWoodLevel;
                        if (currentArcherySkill < requiredArcherySkill)
                        {
                            __instance.m_SelectedDescription.text = "Required Archery skill " + requiredArcherySkill.ToString();
                            __instance.m_SelectedDescription.color = redColor;
                        }
                    }
                    if (bpi.m_CraftedResult == GetGearItemPrefab("GEAR_Arrow") && bpi.m_RequiredGear[1].m_Item == GetGearItemPrefab("GEAR_BarkTinder"))
                    {
                        int currentArcherySkill = GameManager.GetSkillArchery().GetCurrentTierNumber() + 1;
                        int requiredArcherySkill = Settings.options.craftFletchingFromBarkLevel;
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
        [HarmonyPatch(typeof(BlueprintData), "CanCraftBlueprint")]
        private class BlueprintData_CanCraftBlueprint
        {

            private static void Postfix(ref bool __result, BlueprintData __instance)
            {
                if (__instance.m_CraftedResult == GetGearItemPrefab("GEAR_ArrowShaft") && __instance.m_RequiredGear[0].m_Item == GetGearItemPrefab("GEAR_Hardwood") && __result)
                {
                    int currentArcherySkill = GameManager.GetSkillArchery().GetCurrentTierNumber() + 1;
                    int requiredArcherySkill = Settings.options.craftArrowFromWoodLevel;
                    if (currentArcherySkill < requiredArcherySkill)
                    {
                        __result = false;
                    }
                }
                if (__instance.m_CraftedResult == GetGearItemPrefab("GEAR_Arrow") && __instance.m_RequiredGear[1].m_Item == GetGearItemPrefab("GEAR_BarkTinder") && __result)
                {
                    int currentArcherySkill = GameManager.GetSkillArchery().GetCurrentTierNumber() + 1;
                    int requiredArcherySkill = Settings.options.craftFletchingFromBarkLevel;
                    if (currentArcherySkill < requiredArcherySkill)
                    {
                        __result = false;
                    }
                }
            }
        }

        //private static GearItem GetGearItemPrefab(string name) => Resources.Load(name).Cast<GameObject>().GetComponent<GearItem>();
        private static GearItem GetGearItemPrefab(string name)
        {
            return GearItem.LoadGearItemPrefab(name);
        }
        //private static ToolsItem GetToolItemPrefab(string name) => Resources.Load(name).Cast<GameObject>().GetComponent<ToolsItem>();
        private static ToolsItem GetToolItemPrefab(string name)
        {
            return GearItem.LoadGearItemPrefab(name).m_ToolsItem;
        }
        // from CraftingRevisions by ds5678 and STBlade
        public static Il2CppAK.Wwise.Event? MakeAudioEvent(string eventName)
        {
            if (eventName == null)
            {
                return null;
            }
            uint eventId = AkSoundEngine.GetIDFromString(eventName);
            if (eventId <= 0 || eventId >= 4294967295)
            {
                return null;
            }

            Il2CppAK.Wwise.Event newEvent = new();
            newEvent.WwiseObjectReference = new WwiseEventReference();
            newEvent.WwiseObjectReference.objectName = eventName;
            newEvent.WwiseObjectReference.id = eventId;
            return newEvent;
        }

        private static readonly Color whiteColor = new Color(0.7f, 0.7f, 0.7f);
        private static readonly Color redColor = new Color(0.7f, 0f, 0f);

    }
}