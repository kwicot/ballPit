using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class PrefabsData
{
    public List<GameObject> prefabs = new List<GameObject>();
    private Dictionary<int, GameObject> prefabsMap = new Dictionary<int, GameObject>();
    public void Init(GameObject[] objs)
    {
        //TODO загрузка префабов из проекта
        


        foreach (var gameObject in objs)
        {
            prefabsMap.Add(gameObject.GetInstanceID(),gameObject);
        }
        Debug.Log($"Prefabs loaded {prefabsMap.Count}");
        
        
    }

    public PrefabsData()
    {
        foreach (var gameObject in prefabs)
        {
            prefabsMap.Add(gameObject.GetInstanceID(),gameObject);
        }
        Debug.Log($"Prefabs loaded {prefabsMap.Count}");
    }
    public GameObject this[int key]
    {
        get
        {
            try
            {
                var go = prefabsMap[key];
                return go;
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                return null;
            }
        }
    }
    
    
}