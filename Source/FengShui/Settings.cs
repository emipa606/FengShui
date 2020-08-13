using System;
using UnityEngine;
using Verse;

namespace FengShui
{
	// Token: 0x02000004 RID: 4
	public class Settings : ModSettings
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000022B0 File Offset: 0x000004B0
		public void DoWindowContents(Rect canvas)
		{
			Listing_Standard listing_Standard = new Listing_Standard();
			listing_Standard.ColumnWidth = canvas.width;
			listing_Standard.Begin(canvas);
			float gap = 12f;
			listing_Standard.Gap(gap);
			float upperlimit = 200f;
			float lowerlimit = 50f;
			checked
			{
				listing_Standard.Label("FengShui.ImpFactor".Translate() + "  " + (int)Settings.ImpFactor, -1f, null);
				Settings.ImpFactor = (float)((int)listing_Standard.Slider((float)((int)Settings.ImpFactor), lowerlimit, upperlimit));
				listing_Standard.Gap(gap);
				listing_Standard.Label("FengShui.WthFactor".Translate() + "  " + (int)Settings.WthFactor, -1f, null);
				Settings.WthFactor = (float)((int)listing_Standard.Slider((float)((int)Settings.WthFactor), lowerlimit, upperlimit));
				listing_Standard.Gap(gap);
				listing_Standard.Label("FengShui.SpcFactor".Translate() + "  " + (int)Settings.SpcFactor, -1f, null);
				Settings.SpcFactor = (float)((int)listing_Standard.Slider((float)((int)Settings.SpcFactor), lowerlimit, upperlimit));
				listing_Standard.Gap(gap);
				listing_Standard.Label("FengShui.BtyFactor".Translate() + "  " + (int)Settings.BtyFactor, -1f, null);
				Settings.BtyFactor = (float)((int)listing_Standard.Slider((float)((int)Settings.BtyFactor), lowerlimit, upperlimit));
				listing_Standard.Gap(gap);
				listing_Standard.Label("FengShui.ClnFactor".Translate() + "  " + (int)Settings.ClnFactor, -1f, null);
				Settings.ClnFactor = (float)((int)listing_Standard.Slider((float)((int)Settings.ClnFactor), lowerlimit, upperlimit));
				listing_Standard.Gap(gap);
				Text.Font = GameFont.Tiny;
				listing_Standard.Label("          " + "FengShui.Tip".Translate(), -1f, null);
				Text.Font = GameFont.Small;
				listing_Standard.Gap(gap);
				if (listing_Standard.ButtonTextLabeled("FengShui.ResetDefaults".Translate(), "FengShui.Reset".Translate()))
				{
					Settings.doReset();
				}
				listing_Standard.End();
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000024F2 File Offset: 0x000006F2
		public static void doReset()
		{
			Settings.ImpFactor = 100f;
			Settings.WthFactor = 100f;
			Settings.SpcFactor = 100f;
			Settings.BtyFactor = 100f;
			Settings.ClnFactor = 100f;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002528 File Offset: 0x00000728
		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look<float>(ref Settings.ImpFactor, "ImpFactor", 100f, false);
			Scribe_Values.Look<float>(ref Settings.WthFactor, "WthFactor", 100f, false);
			Scribe_Values.Look<float>(ref Settings.SpcFactor, "SpcFactor", 100f, false);
			Scribe_Values.Look<float>(ref Settings.BtyFactor, "BtyFactor", 100f, false);
			Scribe_Values.Look<float>(ref Settings.ClnFactor, "ClnFactor", 100f, false);
		}

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
	}
}
