using UnityEngine;
using Verse;

namespace FengShui
{
    // Token: 0x02000004 RID: 4
    public class Settings : ModSettings
    {
        // Token: 0x04000002 RID: 2
        public static float ImpFactor = 100f;

        // Token: 0x04000003 RID: 3
        public static float WthFactor = 100f;

        // Token: 0x04000004 RID: 4
        public static float SpcFactor = 100f;

        // Token: 0x04000005 RID: 5
        public static float BtyFactor = 100f;

        // Token: 0x04000006 RID: 6
        public static float ClnFactor = 100f;

        // Token: 0x06000007 RID: 7 RVA: 0x000022B0 File Offset: 0x000004B0
        public void DoWindowContents(Rect canvas)
        {
            var listing_Standard = new Listing_Standard {ColumnWidth = canvas.width};
            listing_Standard.Begin(canvas);
            var gap = 12f;
            listing_Standard.Gap(gap);
            var upperlimit = 200f;
            var lowerlimit = 50f;
            checked
            {
                listing_Standard.Label("FengShui.ImpFactor".Translate() + "  " + (int) ImpFactor);
                ImpFactor = (int) listing_Standard.Slider((int) ImpFactor, lowerlimit, upperlimit);
                listing_Standard.Gap(gap);
                listing_Standard.Label("FengShui.WthFactor".Translate() + "  " + (int) WthFactor);
                WthFactor = (int) listing_Standard.Slider((int) WthFactor, lowerlimit, upperlimit);
                listing_Standard.Gap(gap);
                listing_Standard.Label("FengShui.SpcFactor".Translate() + "  " + (int) SpcFactor);
                SpcFactor = (int) listing_Standard.Slider((int) SpcFactor, lowerlimit, upperlimit);
                listing_Standard.Gap(gap);
                listing_Standard.Label("FengShui.BtyFactor".Translate() + "  " + (int) BtyFactor);
                BtyFactor = (int) listing_Standard.Slider((int) BtyFactor, lowerlimit, upperlimit);
                listing_Standard.Gap(gap);
                listing_Standard.Label("FengShui.ClnFactor".Translate() + "  " + (int) ClnFactor);
                ClnFactor = (int) listing_Standard.Slider((int) ClnFactor, lowerlimit, upperlimit);
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

                listing_Standard.End();
            }
        }

        // Token: 0x06000008 RID: 8 RVA: 0x000024F2 File Offset: 0x000006F2
        public static void doReset()
        {
            ImpFactor = 100f;
            WthFactor = 100f;
            SpcFactor = 100f;
            BtyFactor = 100f;
            ClnFactor = 100f;
        }

        // Token: 0x06000009 RID: 9 RVA: 0x00002528 File Offset: 0x00000728
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
}