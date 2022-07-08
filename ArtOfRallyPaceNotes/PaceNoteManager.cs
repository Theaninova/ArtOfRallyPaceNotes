using JetBrains.Annotations;
using UnityEngine;

namespace ArtOfRallyPaceNotes
{
    public static class PaceNoteManager
    {
        [CanBeNull] public static Vector3[] Waypoints;

        [CanBeNull] public static float[] Elevations;
        
        [CanBeNull] public static float[] MeanElevations;

        [CanBeNull] public static float[] Angles;

        [CanBeNull] public static float[] MeanAngles;

        [CanBeNull] public static float[] Distances;
        
        public static int CurrentWaypointIndex;
    }
}