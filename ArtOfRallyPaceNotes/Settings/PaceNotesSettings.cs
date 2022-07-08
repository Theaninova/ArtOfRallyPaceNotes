using ArtOfRallyPaceNotes.Loader;
using ArtOfRallyPaceNotes.Patches.OutOfBoundsManager;
using UnityEngine;
using UnityModManagerNet;

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable ConvertToConstant.Global

namespace ArtOfRallyPaceNotes.Settings
{
    public enum PaceNotesMode
    {
        Off,
        Auto,
        ManualOnly,
        GeneratedOnly
    }

    public class PaceNotesSettings : UnityModManager.ModSettings, IDrawable
    {
        [Header("Modes")] [Draw(DrawType.ToggleGroup)]
        public PaceNotesMode PaceNotesMode = PaceNotesMode.Auto;

        [Draw(DrawType.Toggle)] public bool ShowCurrentWaypoint = false;

        [Draw(DrawType.Field)] public string AssetSet = "default";

        [Draw(DrawType.Field)] public string ConfigSet = "default";

        [Header("Positioning")] [Draw(DrawType.Slider, Min = 1, Max = 1000)]
        public int PaceNoteSize = 200;

        [Draw(DrawType.Slider, Min = 0.0f, Max = 1.0f)]
        public float PositionY = 0.25f;

        [Draw(DrawType.Slider, Min = 0.0f, Max = 1.0f)]
        public float PositionX = 0.5f;

        [Header("Auto Generation")] [Draw(DrawType.Field)]
        public float DistanceTolerance = 10;


        public void OnChange()
        {
        }

        public override void Save(UnityModManager.ModEntry modEntry)
        {
            Save(this, modEntry);
            PaceNote.Textures = PaceNoteAssetLoader.LoadAssets();
            if (PaceNoteManager.Waypoints != null)
            {
                OutOfBoundsManagerStartPatch.Postfix(PaceNoteManager.Waypoints);
            }
        }
    }
}