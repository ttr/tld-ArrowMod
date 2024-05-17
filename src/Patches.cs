using HarmonyLib;
using UnityEngine;
using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppTLD.Gear;
using Il2CppNodeCanvas.Tasks.Actions;
using UnityEngine.AddressableAssets;


namespace ArrowMod
{
    internal static class Patches
    {

        [HarmonyPatch(typeof(Panel_Crafting), nameof(Panel_Crafting.Initialize))]
        public class Panel_Crafting_Initialize
        {
            private static void Postfix()
            {
                ArrowMod.Log("Adding blueprints.");
                if (Settings.options.arrowUseLine)
                {
                    BlueprintData bpi = ScriptableObject.CreateInstance<BlueprintData>();

                    bpi.name = "BLUEPRINT_GEAR_Arrow_ArrowMod_A";

                    // Inputs
                    bpi.m_RequiredTool = null;
                    bpi.m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0);

                    // Outputs
                    bpi.m_CraftedResult = GetGearItemPrefab("GEAR_Arrow");
                    bpi.m_CraftedResultCount = 1;

                    // Process
                    bpi.m_Locked = false;
                    bpi.m_IgnoreLockInSurvival = false;
                    bpi.m_AppearsInStoryOnly = false;
                    bpi.m_AppearsInSurvivalOnly = false;
                    bpi.m_RequiresLight = true;
                    bpi.m_RequiresLitFire = false;
                    bpi.m_RequiredCraftingLocation = CraftingLocation.Anywhere;
                    bpi.m_DurationMinutes = Settings.options.arrowCraftTime;
                    bpi.m_CraftingAudio = MakeAudioEvent("PLAY_CRAFTINGARROWS");

                    bpi.m_AppliedSkill = SkillType.None;
                    bpi.m_ImprovedSkill = SkillType.None;
                    bpi.m_CanIncreaseRepairSkill = false;
                    bpi.m_RequiredLiquid = new Il2CppReferenceArray<BlueprintData.RequiredLiquid>(0) { };
                    bpi.m_RequiredPowder = new Il2CppReferenceArray<BlueprintData.RequiredPowder>(0) { };

                    bpi.m_RequiredGear = new Il2CppReferenceArray<BlueprintData.RequiredGearItem>(4)
                    {
                        [0] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_Line") },
                        [1] = new BlueprintData.RequiredGearItem() { m_Count = 3, m_Item = GetGearItemPrefab("GEAR_CrowFeather") },
                        [2] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_ArrowShaft") },
                        [3] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_ArrowHead") }
                    };

                    ArrowMod.Log("Adding blueprint 1.");
                    InterfaceManager.GetInstance().m_BlueprintManager.m_AllBlueprints.Add(bpi);

                    if (Settings.options.craftFletchingFromBark)
                    {
                        BlueprintData bpi2 = ScriptableObject.CreateInstance<BlueprintData>();

                        bpi2.name = "BLUEPRINT_GEAR_Arrow_ArrowMod_B";

                        // Inputs

                        bpi2.m_RequiredTool = GetToolItemPrefab("GEAR_Knife");
                        bpi2.m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0);

                        // Outputs
                        bpi2.m_CraftedResult = GetGearItemPrefab("GEAR_Arrow");
                        bpi2.m_CraftedResultCount = 1;

                        // Process
                        bpi2.m_Locked = false;
                        bpi2.m_IgnoreLockInSurvival = false;
                        bpi2.m_AppearsInStoryOnly = false;
                        bpi2.m_AppearsInSurvivalOnly = false;
                        bpi2.m_RequiresLight = true;
                        bpi2.m_RequiresLitFire = false;
                        bpi2.m_RequiredCraftingLocation = CraftingLocation.Anywhere;
                        bpi2.m_DurationMinutes = Settings.options.arrowCraftTime + Settings.options.craftFletchingFromBarkTime;
                        bpi2.m_CraftingAudio = MakeAudioEvent("PLAY_CRAFTINGARROWS");

                        bpi2.m_AppliedSkill = SkillType.None;
                        bpi2.m_ImprovedSkill = SkillType.None;
                        bpi2.m_CanIncreaseRepairSkill = false;
                        bpi2.m_RequiredLiquid = new Il2CppReferenceArray<BlueprintData.RequiredLiquid>(0) { };
                        bpi2.m_RequiredPowder = new Il2CppReferenceArray<BlueprintData.RequiredPowder>(0) { };
                        bpi2.m_RequiredGear = new Il2CppReferenceArray<BlueprintData.RequiredGearItem>(4)
                        {
                            [0] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_Line") },
                            [1] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_BarkTinder") },
                            [2] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_ArrowShaft") },
                            [3] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_ArrowHead") }
                        };

                        InterfaceManager.GetInstance().m_BlueprintManager.m_AllBlueprints.Add(bpi2);
                        ArrowMod.Log("Adding blueprint 2.");
                    }

                }

                if (Settings.options.craftArrowFromWood)
                {
                    BlueprintData bpi3 = ScriptableObject.CreateInstance<BlueprintData>();
                    bpi3.name = "BLUEPRINT_GEAR_ArrowShaft_ArrowMod_A";

                    // Inputs
                    bpi3.m_RequiredTool = GetToolItemPrefab("GEAR_Knife");
                    bpi3.m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0);

                    // Outputs
                    bpi3.m_CraftedResult = GetGearItemPrefab("GEAR_ArrowShaft");
                    bpi3.m_CraftedResultCount = 3;

                    // Process
                    bpi3.m_Locked = false;
                    bpi3.m_IgnoreLockInSurvival = false;
                    bpi3.m_AppearsInStoryOnly = false;
                    bpi3.m_AppearsInSurvivalOnly = false;
                    bpi3.m_RequiresLight = true;
                    bpi3.m_RequiresLitFire = false;
                    bpi3.m_RequiredCraftingLocation = CraftingLocation.Workbench;
                    bpi3.m_DurationMinutes = 180;
                    bpi3.m_CraftingAudio = MakeAudioEvent("PLAY_CRAFTINGARROWS");

                    bpi3.m_AppliedSkill = SkillType.None;
                    bpi3.m_ImprovedSkill = SkillType.None;
                    bpi3.m_CanIncreaseRepairSkill = false;
                    bpi3.m_RequiredLiquid = new Il2CppReferenceArray<BlueprintData.RequiredLiquid>(0) { };
                    bpi3.m_RequiredPowder = new Il2CppReferenceArray<BlueprintData.RequiredPowder>(0) { };
                    bpi3.m_RequiredGear = new Il2CppReferenceArray<BlueprintData.RequiredGearItem>(1)
                    {
                        [0] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_Hardwood") }
                    };
                    InterfaceManager.GetInstance().m_BlueprintManager.m_AllBlueprints.Add(bpi3);
                    ArrowMod.Log("Adding blueprint 3.");
                }

            }

        }
        [HarmonyPatch(typeof(BlueprintManager), "GetAllBlueprints")]
        public static class BlueprintManager_GetAllBlueprints {
            public static void Postfix(BlueprintManager __instance) {
                List<BlueprintData> remove = new List<BlueprintData>();
                foreach (BlueprintData val in __instance.m_AllBlueprints)
                {
                    //ArrowMod.Log(" * " + val.name);
                    if (Settings.options.arrowUseLine && val.name == "BLUEPRINT_GEAR_Arrow_A")
                    {
                        remove.Add(val);
                    }
                    if (Settings.options.craftFletchingFromBark && val.name == "BLUEPRINT_GEAR_Arrow_ArrowMod_B")
                    {
                        if (!val.Locked && GameManager.GetSkillArchery().GetCurrentTierNumber() + 1 < Settings.options.craftFletchingFromBarkLevel)
                        {
                            ArrowMod.Log("Locked: " + val.name);
                            val.Locked = true;
                        }
                        if (val.Locked && GameManager.GetSkillArchery().GetCurrentTierNumber() + 1 >= Settings.options.craftFletchingFromBarkLevel)
                        {
                            ArrowMod.Log("Un-locked: " + val.name);
                            val.Locked = false;
                        }
                    }
                    if (Settings.options.craftArrowFromWood && val.name == "BLUEPRINT_GEAR_ArrowShaft_ArrowMod_A")
                    {
                        if (!val.Locked && GameManager.GetSkillArchery().GetCurrentTierNumber() + 1 < Settings.options.craftArrowFromWoodLevel)
                        {
                            ArrowMod.Log("Locked: " + val.name);
                            val.Locked = true;
                        }
                        if (val.Locked && GameManager.GetSkillArchery().GetCurrentTierNumber() + 1 >= Settings.options.craftArrowFromWoodLevel)
                        {
                            ArrowMod.Log("Un-locked: " + val.name);
                            val.Locked = false;
                        }
                    }
                    // arrowhead time
                    if (val.m_CraftedResult.name == "GEAR_ArrowHead")
                    {
                        val.m_DurationMinutes = Settings.options.arrowHeadCraftTime * (int)Mathf.Floor(val.m_CraftedResultCount/2);
                        ArrowMod.Log("arrowhead time: " + val.m_DurationMinutes + " for " + val.name);
                    }
                }
                foreach (BlueprintData val in remove)
                {
                    if (__instance.m_AllBlueprints.Remove(val))
                    {
                        ArrowMod.Log("Removed: " + val.name);
                    }
                }
            }
        }

        private static GearItem GetGearItemPrefab(string name)
        {
            return GearItem.LoadGearItemPrefab(name);
        }
        
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

    }
}