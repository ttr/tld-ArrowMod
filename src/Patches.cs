using HarmonyLib;
using UnityEngine;
using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppTLD.Gear;
using Il2CppNodeCanvas.Tasks.Actions;
using UnityEngine.AddressableAssets;
using Unity.VisualScripting;
using Il2CppSystem;
using MelonLoader.Preferences;
using Il2CppSteamworks;


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
                CraftingLocation arrowBench = CraftingLocation.Workbench;
                if (Settings.options.arrowsNoBench){
                  arrowBench = CraftingLocation.Anywhere;
                }

                InterfaceManager.GetInstance().m_BlueprintManager.m_AllBlueprints.Add(new BlueprintData()
                {
                    name = "BLUEPRINT_GEAR_Arrow_ArrowMod_A",

                    // Inputs
                    m_RequiredTool = null,
                    m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0),

                    // Outputs
                    m_CraftedResultGear = GetGearItemPrefab("GEAR_Arrow"),
                    m_CraftedResultCount = 1,
                    m_CraftingResultType = CraftingResult.StandardGear,
                    m_CraftedResultDecoration = null,
                    m_XPModesToDisable = new(),

                    // Process
                    m_UsesPhoto = false,
                    m_Locked = true,
                    m_IgnoreLockInSurvival = false,
                    m_AppearsInStoryOnly = false,
                    m_AppearsInSurvivalOnly = false,
                    m_RequiresLight = true,
                    m_RequiresLitFire = false,
                    m_RequiredCraftingLocation = arrowBench,
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
                ArrowMod.Log("Added: BLUEPRINT_GEAR_Arrow_ArrowMod_A, bench:" + arrowBench);
                InterfaceManager.GetInstance().m_BlueprintManager.m_AllBlueprints.Add(new BlueprintData() { 

                  name = "BLUEPRINT_GEAR_Arrow_ArrowMod_B1",

                  // Inputs

                  m_RequiredTool = GetToolItemPrefab("GEAR_Knife"),
                  m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0),

                  // Outputs
                  m_CraftedResultGear = GetGearItemPrefab("GEAR_Arrow"),
                  m_CraftedResultCount = 1,
                  m_CraftingResultType = CraftingResult.StandardGear,
                  m_CraftedResultDecoration = null,
                  m_XPModesToDisable = new(),

                  // Process
                  m_UsesPhoto = false,
                  m_Locked = true,
                  m_IgnoreLockInSurvival = false,
                  m_AppearsInStoryOnly = false,
                  m_AppearsInSurvivalOnly = false,
                  m_RequiresLight = true,
                  m_RequiresLitFire = false,
                  m_RequiredCraftingLocation = arrowBench,
                  m_DurationMinutes = Settings.options.arrowCraftTime *2 + Settings.options.craftFletchingFromBarkTime,
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
                ArrowMod.Log("Added: BLUEPRINT_GEAR_Arrow_ArrowMod_B1, bench:" + arrowBench);

                // Leather mod
                if ((bool)GearItem.LoadGearItemPrefab("GEAR_Bark"))
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
                        m_CraftingResultType = CraftingResult.StandardGear,
                        m_CraftedResultDecoration = null,
                        m_XPModesToDisable = new(),

                        // Process
                        m_UsesPhoto = false,
                        m_Locked = true,
                        m_IgnoreLockInSurvival = false,
                        m_AppearsInStoryOnly = false,
                        m_AppearsInSurvivalOnly = false,
                        m_RequiresLight = true,
                        m_RequiresLitFire = false,
                        m_RequiredCraftingLocation = arrowBench,
                        m_DurationMinutes = Settings.options.arrowCraftTime *2 + Settings.options.craftFletchingFromBarkTime,
                        m_CraftingAudio = MakeAudioEvent("PLAY_CRAFTINGARROWS"),

                        m_AppliedSkill = SkillType.None,
                        m_ImprovedSkill = SkillType.None,
                        m_CanIncreaseRepairSkill = false,
                        m_RequiredLiquid = new Il2CppReferenceArray<BlueprintData.RequiredLiquid>(0) { },
                        m_RequiredPowder = new Il2CppReferenceArray<BlueprintData.RequiredPowder>(0) { },
                        m_RequiredGear = new Il2CppReferenceArray<BlueprintData.RequiredGearItem>(4)
                        {
                            [0] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_Line") },
                            [1] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_Bark") },
                            [2] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_ArrowShaft") },
                            [3] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = GetGearItemPrefab("GEAR_ArrowHead") }
                        }
                    });
                    ArrowMod.Log("Added: BLUEPRINT_GEAR_Arrow_ArrowMod_B2, bench:" + arrowBench);
                }
                InterfaceManager.GetInstance().m_BlueprintManager.m_AllBlueprints.Add(new BlueprintData() { 
                  name = "BLUEPRINT_GEAR_ArrowShaft_ArrowMod_A",

                  // Inputs
                  m_RequiredTool = GetToolItemPrefab("GEAR_Knife"),
                  m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0),

                  // Outputs
                  m_CraftedResultGear = GetGearItemPrefab("GEAR_ArrowShaft"),
                  m_CraftedResultCount = 5,
                  m_CraftingResultType = CraftingResult.StandardGear,
                  m_CraftedResultDecoration = null,
                  m_XPModesToDisable = new(),

                  // Process
                  m_UsesPhoto = false,
                  m_Locked = true,
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
                ArrowMod.Log("Added: BLUEPRINT_GEAR_ArrowShaft_ArrowMod_A");
            }
        }

        [HarmonyPatch(typeof(BlueprintManager), "GetAllBlueprints")]
        public static class BlueprintManager_GetAllBlueprints {
            public static void Postfix(BlueprintManager __instance) {
                foreach (BlueprintData val in __instance.m_AllBlueprints)
                {
                    //ArrowMod.Log(" * " + val.name);
                    if (val.name == "BLUEPRINT_GEAR_Arrow_A")
                    {
                      val.Locked = Settings.options.arrowUseLine;
                      val.m_IgnoreLockInSurvival = false; // vanilla BP, needs to be set
                      ArrowMod.Log("Lock: " + val.name + " " + val.Locked);
                    } 
                    
                    else if (val.name.StartsWith("BLUEPRINT_GEAR_Arrow_ArrowMod_A"))
                    {
                      val.Locked = val.m_IgnoreLockInSurvival = !Settings.options.arrowUseLine;
                      ArrowMod.Log("Lock: " + val.name + " " + val.Locked);
                      val.m_DurationMinutes = Settings.options.arrowCraftTime * val.m_CraftedResultCount;
                      ArrowMod.Log("arrow time: " + val.m_DurationMinutes + " for " + val.name);

                    }
                    
                    else if (val.name.StartsWith("BLUEPRINT_GEAR_Arrow_ArrowMod_B"))
                    {

                      val.Locked = !(Settings.options.arrowUseLine && Settings.options.craftFletchingFromBark && GameManager.GetSkillArchery().GetCurrentTierNumber() + 1 >= Settings.options.craftFletchingFromBarkLevel);
                      ArrowMod.Log("Lock: " + val.name + " " + val.Locked);
                      val.m_DurationMinutes = Settings.options.arrowCraftTime *2 + Settings.options.craftFletchingFromBarkTime;
                      ArrowMod.Log("arrow time: " + val.m_DurationMinutes + " for " + val.name);

                    }
                    else if (val.name == "BLUEPRINT_GEAR_ArrowShaft_ArrowMod_A")
                    {
                      val.Locked = !(Settings.options.craftArrowFromWood && GameManager.GetSkillArchery().GetCurrentTierNumber() + 1 >= Settings.options.craftArrowFromWoodLevel);
                      ArrowMod.Log("Lock: " + val.name + " " + val.Locked);
                    }
                    
                    // arrowhead time
                    else if (val.m_CraftedResultGear.name == "GEAR_ArrowHead")
                    {
                      val.m_DurationMinutes = Settings.options.arrowHeadCraftTime * (int)Mathf.Floor(val.m_CraftedResultCount/2);
                      ArrowMod.Log("arrowhead time: " + val.m_DurationMinutes + " for " + val.name);
                    }
                    // arrows crafting time (override all others BP)
                    // arrows bench
                    else if (val.m_CraftedResultGear.name == "GEAR_Arrow")
                    {
                      val.m_DurationMinutes = Settings.options.arrowCraftTime * val.m_CraftedResultCount;
                      ArrowMod.Log("arrow time: " + val.m_DurationMinutes + " for " + val.name);
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