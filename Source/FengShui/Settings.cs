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

    public void DoWindowContents(Rect canvas)
    {
        var listing_Standard = new Listing_Standard { ColumnWidth = canvas.width };
        listing_Standard.Begin(canvas);
        var gap = 12f;
        listing_Standard.Gap(gap);
        var upperlimit = 200f;
        var lowerlimit = 50f;
        checked
        {
            listing_Standard.Label("FengShui.ImpFactor".Translate() + "  " + (int)ImpFactor);
            ImpFactor = (int)listing_Standard.Slider((int)ImpFactor, lowerlimit, upperlimit);
            listing_Standard.Gap(gap);
            listing_Standard.Label("FengShui.WthFactor".Translate() + "  " + (int)WthFactor);
            WthFactor = (int)listing_Standard.Slider((int)WthFactor, lowerlimit, upperlimit);
            listing_Standard.Gap(gap);
            listing_Standard.Label("FengShui.SpcFactor".Translate() + "  " + (int)SpcFactor);
            SpcFactor = (int)listing_Standard.Slider((int)SpcFactor, lowerlimit, upperlimit);
            listing_Standard.Gap(gap);
            listing_Standard.Label("FengShui.BtyFactor".Translate() + "  " + (int)BtyFactor);
            BtyFactor = (int)listing_Standard.Slider((int)BtyFactor, lowerlimit, upperlimit);
            listing_Standard.Gap(gap);
            listing_Standard.Label("FengShui.ClnFactor".Translate() + "  " + (int)ClnFactor);
            ClnFactor = (int)listing_Standard.Slider((int)ClnFactor, lowerlimit, upperlimit);
            listing_Standard.Gap(gap);
            Text.Font = GameFont.Tiny;
            listing_Standard.Label("          " + "FengShui.Tip".Translate());
            Text.Font = GameFont.Small;
            listing_Standard.Gap(gap);
            if (listing_Standard.ButtonTextLabeled("FengShui.ResetDefaults".Translate(),
                    "FengShui.Reset".Translate()))
            {
                doReset();
            }

            if (Controller.currentVersion != null)
            {
                listing_Standard.Gap();
                GUI.contentColor = Color.gray;
                listing_Standard.Label("FengShui.CurrentModVersion".Translate(Controller.currentVersion));
                GUI.contentColor = Color.white;
            }

            listing_Standard.End();
        }
    }

    public static void doReset()
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