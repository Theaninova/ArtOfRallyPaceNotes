using JetBrains.Annotations;
using UnityEngine;

namespace ArtOfRallyPaceNotes
{
    public static class PaceNoteManager
    {
        [CanBeNull] public static Vector3[] Waypoints;
        
        public static int CurrentWaypoint;
    }
}