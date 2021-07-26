using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DistanceHelper
{
    public static float Distance(GameObject object1, GameObject object2)
    {
        return Vector3.Distance(GetClosestPoint(object1, object2), object1.transform.position);
    }

    public static float SqrMagnitude(GameObject object1, GameObject object2)
    {
        return Vector3.SqrMagnitude(GetClosestPoint(object1, object2) - object1.transform.position);
    }
    private static Vector3 GetClosestPoint(GameObject object1, GameObject object2)
    {
        MeshCollider meshCollider = object2.gameObject.GetComponentInChildren<MeshCollider>();
        if (meshCollider != null)
        {
            return meshCollider.ClosestPointOnBounds(object1.transform.position);
        }

        SkinnedMeshRenderer skinnedMeshRenderer1 = object2.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();

        if (skinnedMeshRenderer1 != null)
        {
            return skinnedMeshRenderer1.bounds.ClosestPoint(object1.transform.position);
        }
        return object2.transform.position;
    }

}