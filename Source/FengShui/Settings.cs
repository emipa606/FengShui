using UnityEngine;
using Verse;

namespace FengShui;

public class Settings : ModSettings
{
    public static float ImpFactor = 100f;

    public static float WthFactor = 100f;

    public static float SpcFactor = 100f;

    public static float BtyFactor = 100f;

    public static float ClnFactor = 100f;

    public static void DoWindowContents(Rect canvas)
    {
        var listingStandard = new Listing_Standard { ColumnWidth = canvas.width };
        listingStandard.Begin(canvas);
        var gap = 12f;
        listingStandard.Gap(gap);
        var upperlimit = 200f;
        var lowerlimit = 50f;
        checked
        {
            listingStandard.Label("FengShui.ImpFactor".Translate() + "  " + (int)ImpFactor);
            ImpFactor = (int)listingStandard.Slider((int)ImpFactor, lowerlimit, upperlimit);
            listingStandard.Gap(gap);
            listingStandard.Label("FengShui.WthFactor".Translate() + "  " + (int)WthFactor);
            WthFactor = (int)listingStandard.Slider((int)WthFactor, lowerlimit, upperlimit);
            listingStandard.Gap(gap);
            listingStandard.Label("FengShui.SpcFactor".Translate() + "  " + (int)SpcFactor);
            SpcFactor = (int)listingStandard.Slider((int)SpcFactor, lowerlimit, upperlimit);
            listingStandard.Gap(gap);
            listingStandard.Label("FengShui.BtyFactor".Translate() + "  " + (int)BtyFactor);
            BtyFactor = (int)listingStandard.Slider((int)BtyFactor, lowerlimit, upperlimit);
            listingStandard.Gap(gap);
            listingStandard.Label("FengShui.ClnFactor".Translate() + "  " + (int)ClnFactor);
            ClnFactor = (int)listingStandard.Slider((int)ClnFactor, lowerlimit, upperlimit);
            listingStandard.Gap(gap);
            Text.Font = GameFont.Tiny;
            listingStandard.Label("          " + "FengShui.Tip".Translate());
            Text.Font = GameFont.Small;
            listingStandard.Gap(gap);
            if (listingStandard.ButtonTextLabeled("FengShui.ResetDefaults".Translate(),
                    "FengShui.Reset".Translate()))
            {
                doReset();
            }

            if (Controller.CurrentVersion != null)
            {
                listingStandard.Gap();
                GUI.contentColor = Color.gray;
                listingStandard.Label("FengShui.CurrentModVersion".Translate(Controller.CurrentVersion));
                GUI.contentColor = Color.white;
            }

            listingStandard.End();
        }
    }

    private static void doReset()
    {
        ImpFactor = 100f;
        WthFactor = 100f;
        SpcFactor = 100f;
        BtyFactor = 100f;
        ClnFactor = 100f;
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref ImpFactor, "ImpFactor", 100f);
        Scribe_Values.Look(ref WthFactor, "WthFactor", 100f);
        Scribe_Values.Look(ref SpcFactor, "SpcFactor", 100f);
        Scribe_Values.Look(ref BtyFactor, "BtyFactor", 100f);
        Scribe_Values.Look(ref ClnFactor, "ClnFactor", 100f);
    }
}