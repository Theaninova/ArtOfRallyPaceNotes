using System;
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

        private static float LastTimestamp;

        private const float DisplayTime = 2;

        private const float FadeTime = 0.5f;

        private static string PaceNoteKey;

        public static void Draw(UnityModManager.ModEntry modEntry)
        {
            var newKey = PaceNoteConfig?[PaceNoteManager.CurrentWaypointIndex];
            if (newKey != null && newKey != PaceNoteKey)
            {
                PaceNoteKey = newKey;
                LastTimestamp = Time.time;
            }

            var time = Time.time - LastTimestamp;
            var fade = Mathf.Clamp(time > FadeTime
                ? 1f - (time + FadeTime - DisplayTime) / FadeTime
                : time / FadeTime , 0, 1
            );
            if (time > FadeTime && fade <= 0)
            {
                PaceNoteKey = null;
            }

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
                    + $"Pace Note: {PaceNoteKey}\n"
                    + $"Fade: {fade}"
                );
            }

            if (PaceNoteKey == null || Textures?.ContainsKey(PaceNoteKey) != true) return;

            var texture = Textures![PaceNoteKey];
            var halfSize = Main.Settings.PaceNoteSize / 2;

            GUI.color = new Color(1, 1, 1, fade);
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