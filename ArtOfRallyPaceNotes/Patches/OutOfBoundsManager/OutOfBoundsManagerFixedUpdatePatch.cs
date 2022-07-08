using ArtOfRallyPaceNotes.Config;
using ArtOfRallyPaceNotes.Loader;
using HarmonyLib;
using UnityEngine;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace ArtOfRallyPaceNotes.Patches.OutOfBoundsManager
{
    [HarmonyPatch(typeof(global::OutOfBoundsManager), "FixedUpdate")]
    public class OutOfBoundsManagerFixedUpdatePatch
    {
        // ReSharper disable twice InconsistentNaming
        public static void Postfix(int ___CurrentWaypointIndex)
        {
            PaceNoteManager.CurrentWaypointIndex = ___CurrentWaypointIndex;
        }
    }

    [HarmonyPatch(typeof(global::OutOfBoundsManager), nameof(global::OutOfBoundsManager.Start))]
    public class OutOfBoundsManagerStartPatch
    {
        public static void Postfix(Vector3[] ____cachedWaypoints)
        {
            var stage = GameModeManager.RallyManager.RallyData.GetCurrentStage();
            var stageKey = $"{AreaManager.GetAreaStringNotLocalized(stage.Area)}_{stage.Name}";

            Main.Logger.Log($"Stage key: {stageKey}, WaypointCount: {____cachedWaypoints.Length}");

            PaceNoteManager.Waypoints = ____cachedWaypoints;
            PaceNoteManager.Distances = PaceNoteGenerator.GetDistances(____cachedWaypoints);
            PaceNoteManager.Angles = PaceNoteGenerator.GetAngles(____cachedWaypoints);
            PaceNoteManager.MeanAngles = PaceNoteGenerator.GetMeanValues(
                PaceNoteManager.Angles,
                PaceNoteManager.Distances,
                Main.Settings.DistanceTolerance
            );
            PaceNoteManager.Elevations = PaceNoteGenerator.GetElevations(____cachedWaypoints);
            PaceNoteManager.MeanElevations = PaceNoteGenerator.GetMeanValues(
                PaceNoteManager.Elevations,
                PaceNoteManager.Distances,
                Main.Settings.DistanceTolerance
            );
            Main.Logger.Log($"Angles: {PaceNoteManager.Angles.Length}");

            PaceNote.PaceNoteConfig =
                PaceNoteConfigLoader.LoadPaceNoteConfig(stageKey, ____cachedWaypoints.Length);
            if (PaceNote.PaceNoteConfig == null)
            {
                PaceNote.PaceNoteConfig = PaceNoteGenerator.GeneratePaceNotes(
                    PaceNoteManager.Waypoints,
                    PaceNoteManager.Distances,
                    PaceNoteManager.Angles,
                    PaceNoteManager.Elevations,
                    DefaultConfig.PaceNoteGeneratorConfig
                )[0];
                Main.Logger.Log("Auto-generated PaceNotes");
                Main.Logger.Log($"[{string.Join(", ", PaceNote.PaceNoteConfig)}]");
            }
        }
    }
}