using System.Reflection;
using HarmonyLib;
using BepInEx;
using PlayableCampingSupplies.Configurations;

namespace PlayableCampingSupplies
{

    [BepInPlugin(GUID, "PlayableCampingSupplies", "2.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private const string GUID = "blueskutya.poe.playablecampingsupplies";

        private void Awake()
        {
            //init the Configuration
            Configuration.instance = new Configuration(Config);

            var harmony = new Harmony(GUID);

            var assembly = Assembly.GetExecutingAssembly();
            harmony.PatchAll(assembly);

            // Plugin startup logic
            Logger.LogInfo("Plugin playable-campingsupplies is loaded!");
        }

    }

}
