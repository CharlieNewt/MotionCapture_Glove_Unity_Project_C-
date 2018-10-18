using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VectorMath
{
    public class VectorFunc : MonoBehaviour
    {
        /*
         * The Distance(...) function returns the length of the vector between two points.
        */ 
        public static float Distance(Vector3 startVec, Vector3 endVec)
        {
            Vector3 heading = endVec - startVec;
            float distance = heading.magnitude;
            return distance;
        }

        /*
         * The Direction(...) function returns the normalised direction vector from point startVec to point endVec
        */
        public static Vector3 Direction(Vector3 startVec, Vector3 endVec)
        {
            Vector3 heading = endVec - startVec;
            float distance = heading.magnitude;
            Vector3 direction = heading / distance;
            return direction;
        }
    }
}
