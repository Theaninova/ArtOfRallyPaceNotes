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
        public static void Postfix(
            global::OutOfBoundsManager __instance,
            int ___CurrentWaypointIndex,
            Vector3[] ____cachedWaypoints)
        {
            PaceNoteManager.Waypoints = ____cachedWaypoints;
            PaceNoteManager.CurrentWaypoint = ___CurrentWaypointIndex;
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

            PaceNote.PaceNoteConfig =
                PaceNoteConfigLoader.LoadPaceNoteConfig(stageKey, ____cachedWaypoints.Length);
        }
    }
}