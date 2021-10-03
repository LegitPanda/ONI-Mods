﻿using HarmonyLib;
using STRINGS;

namespace TeleStorage
{
    public class TeleStorageFlowControl : KMonoBehaviour, IIntSliderControl
    {
        public const string FlowTitle = "Flow rate";
        public const string FlowTooltip = "Flow rate";
        public const int GramsPerKilogram = 1000;

        public string SliderTitleKey => "STRINGS.UI.UISIDESCREENS.TELESTORAGE.FLOW.TITLE";

        public string SliderUnits => UI.UNITSUFFIXES.MASS.GRAM + "/" + UI.UNITSUFFIXES.SECOND;

        public float GetSliderMax(int index)
        {
            var flowManager = Conduit.GetFlowManager(GetComponent<TeleStorage>().Type);
            return Traverse.Create(flowManager).Field("MaxMass").GetValue<float>() * GramsPerKilogram;
        }

        public float GetSliderMin(int index)
        {
            return 0;
        }

        public string GetSliderTooltipKey(int index)
        {
            return "STRINGS.UI.UISIDESCREENS.TELESTORAGE.FLOW.TOOLTIP";
        }

        public string GetSliderTooltip()
        {
            return FlowTooltip;
        }

        public float GetSliderValue(int index)
        {
            return GetComponent<TeleStorage>().Flow;
        }

        public void SetSliderValue(float percent, int index)
        {
            GetComponent<TeleStorage>().Flow = percent;
        }

        public int SliderDecimalPlaces(int index)
        {
            return 0;
        }
    }
}
