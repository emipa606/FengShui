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
            LongEventHandler.QueueLongEvent(Setup, "LibraryStartup", false, null);
        }

        // Token: 0x06000005 RID: 5 RVA: 0x000020A0 File Offset: 0x000002A0
        public static void Setup()
        {
            var allDefs = DefDatabase<RoomStatDef>.AllDefsListForReading;
            checked
            {
                if (allDefs.Count <= 0)
                {
                    return;
                }

                Log.Message("FengShui checking values:");
                foreach (var RSD in allDefs)
                {
                    var process = false;
                    var factor = 100f;
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

                    if (!process)
                    {
                        continue;
                    }

                    var count = 0;
                    var list = RSD.scoreStages;
                    if (list.Count > 0)
                    {
                        foreach (var RSSS in list)
                        {
                            if (!(RSSS.minScore > 0f) || factor == 100f)
                            {
                                continue;
                            }

                            RSSS.minScore = ConvertScore(RSSS.minScore, factor);
                            count++;
                        }
                    }

                    if (count > 0)
                    {
                        Log.Message(
                            string.Concat(RSD.defName, " processed ", count.ToString(),
                                " score values with a factor of ", (factor / 100f).ToStringPercent()));
                    }
                    else
                    {
                        Log.Message(RSD.defName + " remains unchanged.");
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