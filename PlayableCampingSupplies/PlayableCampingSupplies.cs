using HarmonyLib;
using PlayableCampingSupplies.Configurations;

namespace PlayableCampingSupplies
{
	class PlayableCampingSupplies
	{

		[HarmonyPatch(typeof(CampingSupplies))]
		[HarmonyPatch("StackMaximum", MethodType.Getter)]
		internal class CampingSupplies_StackMaximum_Getter__Patch
		{
			[HarmonyPrefix]
			public static bool Prefix(CampingSupplies __instance, ref int __result)
			{
				if (Configuration.getInstance().useOriginalCampingSupplies.Value)
					return true; //run the orignal code

				__result = Configuration.getInstance().maxCampingSupplies.Value;
				return false; //Tell Harmony to not run the original method
			}
		}

		[HarmonyPatch(typeof(RestZone))]
		[HarmonyPatch(nameof(RestZone.Camp))]
		internal class RestZone_Camp_Patch
		{
			[HarmonyPrefix]
			public static bool Prefix(RestZone __instance)
			{
				if (Configuration.getInstance().useOriginalCampingSupplies.Value || Configuration.getInstance().isCampDecreaseCSamount.Value)
					return true; //run the orignal code

				RestZone.Rest(RestZone.Mode.Camp);
				return false; //Tell Harmony to not run the original method
			}
		}

		[HarmonyPatch(typeof(RestZone))]
		[HarmonyPatch(nameof(RestZone.WhyCannotCamp))]
		internal class RestZone_WhyCannotCamp_Patch
		{
			[HarmonyPostfix]
			public static void Postfix(RestZone __instance, ref RestZone.CannotCampReason __result)
			{
				if (!Configuration.getInstance().useOriginalCampingSupplies.Value && !Configuration.getInstance().isCampDecreaseCSamount.Value)
					__result &= ~(RestZone.CannotCampReason.NoSupplies);
			}
		}

	}

}
