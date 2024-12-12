using HarmonyLib;
using UnityEngine;
using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppTLD.Gear;
using Il2CppNodeCanvas.Tasks.Actions;
using UnityEngine.AddressableAssets;
using Unity.VisualScripting;


namespace ArrowMod
{
    internal static class Patches
    {

        [HarmonyPatch(typeof(Panel_Crafting), nameof(Panel_Crafting.Initialize))]
        public class Panel_Crafting_Initialize
        {
            private static void Postfix()
            {
                //ArrowMod.Log("Adding blueprints.");
                if (Settings.options.arrowUseLine)
                {
                    InterfaceManager.GetInstance().m_BlueprintManager.m_AllBlueprints.Add(new BlueprintData()
                    {
                        name = "BLUEPRINT_GEAR_Arrow_ArrowMod_A",

                        // Inputs
                        m_RequiredTool = null,
                        m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0),

                        // Outputs
                        m_CraftedResultGear = GetGearItemPrefab("GEAR_Arrow"),
                        m_CraftedResultCount = 1,

                        // Process
                        m_Locked = false,
                        m_IgnoreLockInSurvival = false,
                        m_AppearsInStoryOnly = false,
                        m_AppearsInSurvivalOnly = false,
                        m_RequiresLight = true,
                        m_RequiresLitFire = false,
                        m_RequiredCraftingLocation = CraftingLocation.Anywhere,
                        m_DurationMinutes = Settings.options.arrowCraftTime,
                        m_CraftingAudio = MakeAudioEvent("PLAY_CRAFTINGARROWS"),

                        m_AppliedSkill = SkillType.None,
                        m_ImprovedSkill = SkillType.None,
                        m_CanIncreaseRepairSkill = false,
                        m_RequiredLiquid = new Il2CppReferenceArray<BlueprintData.RequiredLiquid>(0) { },
                        m_RequiredPowder = new Il2CppReferenceArray<BlueprintData.RequiredPowder>(0) { },

                        m_RequiredGear = new Il2CppReferenceArray<BlueprintData.RequiredGearItem>(4)
                        {
                            [0] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_Line") },
                            [1] = new BlueprintData.RequiredGearItem() { m_Count = 3, m_Item = GetGearItemPrefab("GEAR_CrowFeather") },
                            [2] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_ArrowShaft") },
                            [3] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_ArrowHead") }
                        }
                    });
                    //ArrowMod.Log("Adding blueprint 1.");

                    if (Settings.options.craftFletchingFromBark)
                    {
                        InterfaceManager.GetInstance().m_BlueprintManager.m_AllBlueprints.Add(new BlueprintData() { 

                        name = "BLUEPRINT_GEAR_Arrow_ArrowMod_B",

                        // Inputs

                        m_RequiredTool = GetToolItemPrefab("GEAR_Knife"),
                        m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0),

                        // Outputs
                        m_CraftedResultGear = GetGearItemPrefab("GEAR_Arrow"),
                        m_CraftedResultCount = 1,

                        // Process
                        m_Locked = false,
                        m_IgnoreLockInSurvival = false,
                        m_AppearsInStoryOnly = false,
                        m_AppearsInSurvivalOnly = false,
                        m_RequiresLight = true,
                        m_RequiresLitFire = false,
                        m_RequiredCraftingLocation = CraftingLocation.Anywhere,
                        m_DurationMinutes = Settings.options.arrowCraftTime + Settings.options.craftFletchingFromBarkTime,
                        m_CraftingAudio = MakeAudioEvent("PLAY_CRAFTINGARROWS"),

                        m_AppliedSkill = SkillType.None,
                        m_ImprovedSkill = SkillType.None,
                        m_CanIncreaseRepairSkill = false,
                        m_RequiredLiquid = new Il2CppReferenceArray<BlueprintData.RequiredLiquid>(0) { },
                        m_RequiredPowder = new Il2CppReferenceArray<BlueprintData.RequiredPowder>(0) { },
                        m_RequiredGear = new Il2CppReferenceArray<BlueprintData.RequiredGearItem>(4)
                        {
                            [0] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_Line") },
                            [1] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_BarkTinder") },
                            [2] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_ArrowShaft") },
                            [3] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_ArrowHead") }
                        }
                    });
                        //ArrowMod.Log("Adding blueprint 2.");

                        if ((bool)GearItem.LoadGearItemPrefab("GEAR_BarkPrepared"))
                        {
                            InterfaceManager.GetInstance().m_BlueprintManager.m_AllBlueprints.Add(new BlueprintData()
                            {

                                name = "BLUEPRINT_GEAR_Arrow_ArrowMod_B2",

                                // Inputs

                                m_RequiredTool = GetToolItemPrefab("GEAR_Knife"),
                                m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0),

                                // Outputs
                                m_CraftedResultGear = GetGearItemPrefab("GEAR_Arrow"),
                                m_CraftedResultCount = 1,

                                // Process
                                m_Locked = false,
                                m_IgnoreLockInSurvival = false,
                                m_AppearsInStoryOnly = false,
                                m_AppearsInSurvivalOnly = false,
                                m_RequiresLight = true,
                                m_RequiresLitFire = false,
                                m_RequiredCraftingLocation = CraftingLocation.Anywhere,
                                m_DurationMinutes = Settings.options.arrowCraftTime + Settings.options.craftFletchingFromBarkTime,
                                m_CraftingAudio = MakeAudioEvent("PLAY_CRAFTINGARROWS"),

                                m_AppliedSkill = SkillType.None,
                                m_ImprovedSkill = SkillType.None,
                                m_CanIncreaseRepairSkill = false,
                                m_RequiredLiquid = new Il2CppReferenceArray<BlueprintData.RequiredLiquid>(0) { },
                                m_RequiredPowder = new Il2CppReferenceArray<BlueprintData.RequiredPowder>(0) { },
                                m_RequiredGear = new Il2CppReferenceArray<BlueprintData.RequiredGearItem>(4)
                                {
                                    [0] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_Line") },
                                    [1] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_BarkPrepared") },
                                    [2] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_ArrowShaft") },
                                    [3] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_ArrowHead") }
                                }
                            });
                            //ArrowMod.Log("Adding blueprint 2b.");
                        }
                    }

                }

                if (Settings.options.craftArrowFromWood)
                {
                    InterfaceManager.GetInstance().m_BlueprintManager.m_AllBlueprints.Add(new BlueprintData() { 
                    name = "BLUEPRINT_GEAR_ArrowShaft_ArrowMod_A",

                    // Inputs
                    m_RequiredTool = GetToolItemPrefab("GEAR_Knife"),
                    m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0),

                    // Outputs
                    m_CraftedResultGear = GetGearItemPrefab("GEAR_ArrowShaft"),
                    m_CraftedResultCount = 5,

                    // Process
                    m_Locked = false,
                    m_IgnoreLockInSurvival = false,
                    m_AppearsInStoryOnly = false,
                    m_AppearsInSurvivalOnly = false,
                    m_RequiresLight = true,
                    m_RequiresLitFire = false,
                    m_RequiredCraftingLocation = CraftingLocation.Workbench,
                    m_DurationMinutes = 180,
                    m_CraftingAudio = MakeAudioEvent("PLAY_CRAFTINGARROWS"),

                    m_AppliedSkill = SkillType.None,
                    m_ImprovedSkill = SkillType.None,
                    m_CanIncreaseRepairSkill = false,
                    m_RequiredLiquid = new Il2CppReferenceArray<BlueprintData.RequiredLiquid>(0) { },
                    m_RequiredPowder = new Il2CppReferenceArray<BlueprintData.RequiredPowder>(0) { },
                    m_RequiredGear = new Il2CppReferenceArray<BlueprintData.RequiredGearItem>(1)
                    {
                        [0] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_Hardwood") }
                    },
                });
                //ArrowMod.Log("Adding blueprint 3.");
                }

            }

        }
        [HarmonyPatch(typeof(BlueprintManager), "GetAllBlueprints")]
        public static class BlueprintManager_GetAllBlueprints {
            public static void Postfix(BlueprintManager __instance) {
                foreach (BlueprintData val in __instance.m_AllBlueprints)
                {
                    //ArrowMod.Log(" * " + val.name);
                    if (Settings.options.arrowUseLine && val.name == "BLUEPRINT_GEAR_Arrow_A")
                    {
                        //ArrowMod.Log("Locked: " + val.name);
                        val.Locked = true;
                        val.m_IgnoreLockInSurvival = false;
                    }
                    if (Settings.options.craftFletchingFromBark && val.name.StartsWith("BLUEPRINT_GEAR_Arrow_ArrowMod_B"))
                    {
                        if (!val.Locked && GameManager.GetSkillArchery().GetCurrentTierNumber() + 1 < Settings.options.craftFletchingFromBarkLevel)
                        {
                            //ArrowMod.Log("Locked: " + val.name);
                            val.Locked = true;
                        }
                        if (val.Locked && GameManager.GetSkillArchery().GetCurrentTierNumber() + 1 >= Settings.options.craftFletchingFromBarkLevel)
                        {
                            //ArrowMod.Log("Un-locked: " + val.name);
                            val.Locked = false;
                        }
                    }
                    if (Settings.options.craftArrowFromWood && val.name == "BLUEPRINT_GEAR_ArrowShaft_ArrowMod_A")
                    {
                        if (!val.Locked && GameManager.GetSkillArchery().GetCurrentTierNumber() + 1 < Settings.options.craftArrowFromWoodLevel)
                        {
                            //ArrowMod.Log("Locked: " + val.name);
                            val.Locked = true;
                        }
                        if (val.Locked && GameManager.GetSkillArchery().GetCurrentTierNumber() + 1 >= Settings.options.craftArrowFromWoodLevel)
                        {
                            //ArrowMod.Log("Un-locked: " + val.name);
                            val.Locked = false;
                        }
                    }
                    // arrowhead time
                    if (val.m_CraftedResultGear.name == "GEAR_ArrowHead")
                    {
                        val.m_DurationMinutes = Settings.options.arrowHeadCraftTime * (int)Mathf.Floor(val.m_CraftedResultCount/2);
                        //ArrowMod.Log("arrowhead time: " + val.m_DurationMinutes + " for " + val.name);
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