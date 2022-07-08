using System.Collections.Generic;
using JetBrains.Annotations;
using ArtOfRallyPaceNotes.Settings;
using UnityEngine;
using UnityModManagerNet;
using Color = UnityEngine.Color;
using FontStyle = UnityEngine.FontStyle;

namespace ArtOfRallyPaceNotes
{
    public static class PaceNote
    {
        [CanBeNull] public static string[] PaceNoteConfig = null;

        [CanBeNull] public static Dictionary<string, Texture2D> Textures = null;

        public static void Draw(UnityModManager.ModEntry modEntry)
        {
            var paceNote = PaceNoteConfig?[PaceNoteManager.CurrentWaypointIndex];

            if (Main.Settings.ShowCurrentWaypoint)
            {
                GUI.Label(
                    new Rect(0, 0, 200, 200),
                    $"Waypoint {PaceNoteManager.CurrentWaypointIndex}\n"
                    + $"∠{PaceNoteManager.Angles?[PaceNoteManager.CurrentWaypointIndex]:F}° "
                    + $"∑{PaceNoteManager.MeanAngles?[PaceNoteManager.CurrentWaypointIndex]:F}° "
                    + $"@ {Main.Settings.DistanceTolerance:F}m\n"
                    + $"↕{PaceNoteManager.Elevations?[PaceNoteManager.CurrentWaypointIndex]:F}m "
                    + $"∑{PaceNoteManager.MeanElevations?[PaceNoteManager.CurrentWaypointIndex]:F}m "
                    + $"@ {Main.Settings.DistanceTolerance:F}m\n"
                    + $"↔{PaceNoteManager.Distances?[PaceNoteManager.CurrentWaypointIndex]:F}m\n"
                    + $"Pace Note: {paceNote}"
                );
            }

            if (paceNote == null || Textures?.ContainsKey(paceNote) != true) return;
            var texture = Textures![paceNote];

            var halfSize = Main.Settings.PaceNoteSize / 2;

            GUI.DrawTexture(
                new Rect(
                    Screen.width * Main.Settings.PositionX - halfSize,
                    Screen.height * Main.Settings.PositionY - halfSize,
                    Main.Settings.PaceNoteSize,
                    Main.Settings.PaceNoteSize
                ),
                texture,
                ScaleMode.ScaleToFit
            );
        }
    }
}