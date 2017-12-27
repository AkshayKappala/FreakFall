///===============================
/// AUTHOR       : nvnjls
/// PURPOSE      : Single script to pool all types of objects in the game (must have a Monobehaviour attached to it)
/// SPECIAL NOTES: I used gameobject Instance ID as a key for this process. No need to understand the code, 
///                just call GetClone method for cloning and Recycle method for recycling.
///
///===============================
///Change History: Mention changes here 
///
///==================================
using UnityEngine;
using System.Collections.Generic;

public static class ObjectPool
{
    // Available pools of type N
    private static Dictionary<int, List<MonoBehaviour>> AvailablePools = new Dictionary<int, List<MonoBehaviour>>();

    // Assigned pools of type N
    private static Dictionary<int, List<MonoBehaviour>> AssignedPools = new Dictionary<int, List<MonoBehaviour>>();


    public static N GetClone<N>(N originalObj) where N : MonoBehaviour
    {
        if (originalObj == null)
        {
            UnityEngine.Debug.LogError("object passed to ObjectPool.GetClone is null");
            return null;
        }
        int key = originalObj.GetInstanceID();
        if (AvailablePools.ContainsKey(key) && AvailablePools[key].Count > 0)
        {
            var clone = Move<N>(key, obj: (N)AvailablePools[key][0], from: AvailablePools, to: AssignedPools);
            clone.gameObject.SetActive(true);
            return clone;
        }
        else
        {
            var clone = GameObject.Instantiate<N>(originalObj);
            AddObjectToPool(AssignedPools, clone, key);
            clone.gameObject.SetActive(true);
            return clone;
        }
    }

    public static void Recycle<N>(N clone, N originalType) where N : MonoBehaviour
    {
        if (clone == null || originalType == null)
        {
            UnityEngine.Debug.LogError("object passed to ObjectPool.Recycle is null");
            return;
        }
        int key = originalType.GetInstanceID();
        Move<N>(key, clone, AssignedPools, AvailablePools);
        clone.gameObject.SetActive(false);
        clone.transform.SetParent(originalType.transform.parent, false);
    }

    private static void CreatePool(Dictionary<int, List<MonoBehaviour>> to, int withKey, MonoBehaviour obj)
    {
        List<MonoBehaviour> pool = new List<MonoBehaviour>();
        pool.Add(obj);
        to.Add(withKey, pool);
    }

    private static N Move<N>(int key, N obj, Dictionary<int, List<MonoBehaviour>> from,
    Dictionary<int, List<MonoBehaviour>> to) where N : MonoBehaviour
    {
        from[key].Remove(obj);
        AddObjectToPool(to, obj, key);
        return obj;

    }

    private static void AddObjectToPool(Dictionary<int, List<MonoBehaviour>> dic, MonoBehaviour obj, int key)
    {
        if (dic.ContainsKey(key))
        {
            dic[key].Add(obj);
        }
        else
        {
            CreatePool(to: dic, withKey: key, obj: obj);
        }
    }


}
