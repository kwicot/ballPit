using System;
using Kwicot.Controllers;
using UnityEngine;
using Utils;
using Object = UnityEngine.Object;

public static class GameObjectExtension
{
    public static void Activate(this GameObject obj)
    {
        obj.SetActive(true);
    }

    public static void Deactivate(this GameObject obj)
    {
        obj.SetActive(false);
    }
/*
    public static GameObject Create(this GameObject obj, GameObject prefab, Transform parrent)
    {
        var GO = Object.Instantiate(prefab, parrent);
        GO.AddComponent<SaveDataInfo>().ID = prefab.GetInstanceID();
        return GO;
    }
    public static GameObject Create(this GameObject obj, GameObject prefab, Vector3 pos)
    {
        var GO = Object.Instantiate(prefab, pos,Quaternion.identity);
        GO.AddComponent<SaveDataInfo>().ID = prefab.GetInstanceID();
        return GO;
    }
    */
    }