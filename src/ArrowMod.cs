using MelonLoader;
using Harmony;
using UnityEngine;

namespace ArrowMod {
    internal class ArrowMod : MelonMod
    {

        public override void OnApplicationStart()
        {
            Debug.Log($"[{InfoAttribute.Name}] Version {InfoAttribute.Version} loaded!");
            Settings.OnLoad();
        }



    }
}