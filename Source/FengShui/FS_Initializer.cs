using System;
using System.Collections.Generic;
using Verse;

namespace FengShui
{
	// Token: 0x02000003 RID: 3
	[StaticConstructorOnStartup]
	internal static class FS_Initializer
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002082 File Offset: 0x00000282
		static FS_Initializer()
		{
			LongEventHandler.QueueLongEvent(new Action(FS_Initializer.Setup), "LibraryStartup", false, null, true);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020A0 File Offset: 0x000002A0
		public static void Setup()
		{
			List<RoomStatDef> allDefs = DefDatabase<RoomStatDef>.AllDefsListForReading;
			checked
			{
				if (allDefs.Count > 0)
				{
					Log.Message("FengShui checking values:", false);
					foreach (RoomStatDef RSD in allDefs)
					{
						bool process = false;
						float factor = 100f;
						if (RSD.defName == "Impressiveness")
						{
							process = true;
							factor = Settings.ImpFactor;
						}
						else if (RSD.defName == "Wealth")
						{
							process = true;
							factor = Settings.WthFactor;
						}
						else if (RSD.defName == "Space")
						{
							process = true;
							factor = Settings.SpcFactor;
						}
						else if (RSD.defName == "Beauty")
						{
							process = true;
							factor = Settings.BtyFactor;
						}
						else if (RSD.defName == "Cleanliness")
						{
							process = true;
							factor = Settings.ClnFactor;
						}
						if (process)
						{
							int count = 0;
							List<RoomStatScoreStage> list = RSD.scoreStages;
							if (list.Count > 0)
							{
								foreach (RoomStatScoreStage RSSS in list)
								{
									if (RSSS.minScore > 0f && factor != 100f)
									{
										RSSS.minScore = FS_Initializer.ConvertScore(RSSS.minScore, factor);
										count++;
									}
								}
							}
							if (count > 0)
							{
								Log.Message(string.Concat(new string[]
								{
									RSD.defName,
									" processed ",
									count.ToString(),
									" score values with a factor of ",
									(factor / 100f).ToStringPercent()
								}), false);
							}
							else
							{
								Log.Message(RSD.defName + " remains unchanged.", false);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000022A4 File Offset: 0x000004A4
		public static float ConvertScore(float score, float factor)
		{
			return score / (factor / 100f);
		}
	}
}
