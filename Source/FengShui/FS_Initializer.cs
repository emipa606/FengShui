using Verse;

namespace FengShui;

[StaticConstructorOnStartup]
internal static class FS_Initializer
{
    static FS_Initializer()
    {
        LongEventHandler.QueueLongEvent(setup, "LibraryStartup", false, null);
    }

    private static void setup()
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
                    foreach (var rsss in list)
                    {
                        if (!(rsss.minScore > 0f) || factor == 100f)
                        {
                            continue;
                        }

                        rsss.minScore = convertScore(rsss.minScore, factor);
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

    private static float convertScore(float score, float factor)
    {
        return score / (factor / 100f);
    }
}