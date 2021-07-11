using System.Collections.Generic;
using UnityEngine;

public class PrefabsData
{
    private Dictionary<int, GameObject> prefabsMap = new Dictionary<int, GameObject>();
    public void Init()
    {
        //TODO проверить на работоспособность
        var objs = Resources.LoadAll<GameObject>(@"../");


        foreach (var gameObject in objs)
        {
            prefabsMap.Add(gameObject.GetInstanceID(),gameObject);
        }
        Debug.Log($"Prefabs loaded {prefabsMap.Count}");
    }
    
    
}