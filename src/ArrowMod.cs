using MelonLoader;


namespace ArrowMod
{
    public static class BuildInfo
    {
        internal const string ModName = "ArrowMod";
        internal const string ModAuthor = "ttr";
        internal const string ModVersion = "1.8.1";
    }
    internal class ArrowMod : MelonMod
    {

        public override void OnInitializeMelon()
        {
            Settings.OnLoad();
            LoggerInstance.Msg($"[{BuildInfo.ModName}] Version {BuildInfo.ModVersion} loaded!");
        }
        public static void Log(string msg)
        {
            MelonLogger.Msg(msg);
        }
    }
}