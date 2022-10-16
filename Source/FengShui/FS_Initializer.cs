using Verse;

namespace FengShui;

[StaticConstructorOnStartup]
internal static class FS_Initializer
{
    static FS_Initializer()
    {
        LongEventHandler.QueueLongEvent(Setup, "LibraryStartup", false, null);
    }

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
                switch (RSD.defName)
                {
                    case "Impressiveness":
                        process = true;
                        factor = Settings.ImpFactor;
                        break;
                    case "Wealth":
                        process = true;
                        factor = Settings.WthFactor;
                        break;
                    case "Space":
                        process = true;
                        factor = Settings.SpcFactor;
                        break;
                    case "Beauty":
                        process = true;
                        factor = Settings.BtyFactor;
                        break;
                    case "Cleanliness":
                        process = true;
                        factor = Settings.ClnFactor;
                        break;
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

    public static float ConvertScore(float score, float factor)
    {
        return score / (factor / 100f);
    }
}