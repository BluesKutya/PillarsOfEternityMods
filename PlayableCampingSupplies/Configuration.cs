using BepInEx.Configuration;

namespace PlayableCampingSupplies.Configurations
{
    public sealed class Configuration
    {

        private Configuration() {}

        public static volatile Configuration instance;

        public static Configuration getInstance() {
            return instance;
        }

        private ConfigFile config { get; set; }


        public ConfigEntry<bool> useOriginalCampingSupplies { get; private set; }
        public ConfigEntry<bool> isCampDecreaseCSamount { get; private set; }
        public ConfigEntry<byte> maxCampingSupplies { get; private set; }


        public Configuration(ConfigFile _config)
        {
            config = _config;

            useOriginalCampingSupplies = config.Bind("General", "UseOriginalCampingSupplies", false, "Use the original method of max. CampingSupplies calculations and check");

            isCampDecreaseCSamount = config.Bind("General", "IsCampDecreaseCSamount", false, "If enabled, Camping will reduce the amount of CampingSupplies.");

            maxCampingSupplies = config.Bind("General", "MaxCampingSupplies", (byte)32, "Maximum number of Camping Supplies");
        }

    }

}
