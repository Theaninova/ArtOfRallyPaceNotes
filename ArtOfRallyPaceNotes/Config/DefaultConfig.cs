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
                DistanceSumTolerance = 10,
                MinimumValue = 85,
                MaximumValue = 95,
                WarningDistance = 50,
            },
            new PaceNoteGeneratorConfig
            {
                Name = "3R",
                Mode = PaceNoteMode.ANGLE,
                DistanceSumTolerance = 10,
                MinimumValue = 35,
                MaximumValue = 45,
                WarningDistance = 50,
            }
        };
    }
}