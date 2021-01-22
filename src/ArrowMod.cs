using MelonLoader;
using Harmony;
using UnityEngine;

namespace ArrowMod {
    internal class ArrowMod : MelonMod
    {
        public override void OnApplicationStart()
        {
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
            Settings.OnLoad();
        }
    }
}