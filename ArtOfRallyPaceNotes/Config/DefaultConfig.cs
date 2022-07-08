namespace ArtOfRallyPaceNotes.Config
{
    public class DefaultConfig
    {
        public static PaceNoteGeneratorConfig[] PaceNoteGeneratorConfig =
        {
            new PaceNoteGeneratorConfig
            {
                Name = "SqR",
                Mode = PaceNoteMode.ANGLE,
                DistanceSumTolerance = 60,
                MinimumValue = 65,
                MaximumValue = 95,
                WarningDistance = 0,
            },
            new PaceNoteGeneratorConfig
            {
                Name = "3R",
                Mode = PaceNoteMode.ANGLE,
                DistanceSumTolerance = 25,
                MinimumValue = 35,
                MaximumValue = 45,
                WarningDistance = 0,
            }
        };
    }
}