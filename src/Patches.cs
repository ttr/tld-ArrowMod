using HarmonyLib;
using UnityEngine;
using Il2Cpp;
using Il2CppTLD.Gear;

namespace ArrowMod
{
    internal static class Patches
    {

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
                    if (Settings.options.arrowUseLine && val.name == "BLUEPRINT_GEAR_Arrow_ArrowMod_A")
                    {
                        val.m_DurationMinutes = Settings.options.arrowCraftTime;
                        val.m_CraftingAudio = MakeAudioEvent("PLAY_CRAFTINGARROWS");
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
                            val.m_DurationMinutes = Settings.options.arrowCraftTime + Settings.options.craftFletchingFromBarkTime;
                            val.m_CraftingAudio = MakeAudioEvent("PLAY_CRAFTINGARROWS");
                        }
                    }
                    if (Settings.options.arrowUseLine && val.name == "BLUEPRINT_GEAR_Arrow_ArrowMod_B2")
                    {
                        val.m_DurationMinutes = Settings.options.arrowCraftTime;
                        val.m_CraftingAudio = MakeAudioEvent("PLAY_CRAFTINGARROWS");
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
                            val.m_CraftingAudio = MakeAudioEvent("PLAY_CRAFTINGARROWS");
                        }
                    }
                    // arrowhead time
                    if (val.m_CraftedResultGear.name == "GEAR_ArrowHead")
                    {
                        //ArrowMod.Log("arrowhead time: " + val.m_DurationMinutes + " for " + val.name);
                        //ArrowMod.Log("arrowhead time: " + val.m_CraftedResultCount + " for " + val.name);
                        //val.m_DurationMinutes = Settings.options.arrowHeadCraftTime * (int)Mathf.Floor(val.m_CraftedResultCount/2);
                        val.m_DurationMinutes = Settings.options.arrowHeadCraftTime * (int)Mathf.Floor(val.m_CraftedResultCount / 2);
                    }
                }
            }
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