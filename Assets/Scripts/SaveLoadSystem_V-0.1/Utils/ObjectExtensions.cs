using Kwicot.Controllers;
using SaveLoadCore.Controllers;
using SaveLoadCore.Models;
using UnityEngine;
using Utils;

namespace SaveLoadCore.Utils
{
    public static class ObjectExtensions
    {
        private static bool initialized = false;
            private static bool firstEnter;
            private static SaveLoadController controller;
            static void Init()
            {
                controller = Object.FindObjectOfType<SaveLoadController>();
                initialized = true;
            }
            public static GameObject Create<T>(this T obj, GameObject prefab, Data loadData = null)
            {
                if(!initialized) Init();
        
                var GO = Object.Instantiate(prefab);
                if (controller)
                {
                    var dataController = GO.AddComponent<GameObjectDataController>();
                    
                    
                    if (loadData == null)
                    {
                        loadData = new Data()
                        {
                            personalId = GO.GetInstanceID(),
                            prefabId = prefab.GetInstanceID()
                        };
                        dataController.Init(loadData);
                    }
                    else
                    {
                        loadData.personalId = GO.GetInstanceID();
                        loadData.prefabId = prefab.GetInstanceID();
                        dataController.LoadData(loadData);
                    }
                    
                    controller.AddData(dataController);
                }
                if(firstEnter)
                {
                    firstEnter = false;
                    Debug.LogWarning("SaveLoadController not initialized. Created object will not be save");
                }
        
                return GO;
        
            }
            public static GameObject Create<T>(this T obj, GameObject prefab,Transform parrent, Data loadData = null)
            {
                if(!initialized) Init();
        
                var GO = Object.Instantiate(prefab,parrent);
                if (controller)
                {
                    if (loadData == null)
                        loadData = new Data()
                        {
                            personalId = GO.GetInstanceID(),
                            prefabId = prefab.GetInstanceID()
                        };
                    var data = GO.AddComponent<GameObjectDataController>();
                    data.Init(loadData);
                    controller.AddData(data);
                }
                if(firstEnter)
                {
                    firstEnter = false;
                    Debug.LogWarning("SaveLoadController not initialized. Created object will not be save");
                }
        
                return GO;
            }
            public static GameObject Create<T>(this T obj, GameObject prefab,Vector3 pos, Data loadData = null)
            {
                if(!initialized) Init();
        
                var GO = Object.Instantiate(prefab,pos, Quaternion.identity);
                if (controller)
                {
                    if (loadData == null)
                        loadData = new Data()
                        {
                            personalId = GO.GetInstanceID(),
                            prefabId = prefab.GetInstanceID()
                        };
                    var data = GO.AddComponent<GameObjectDataController>();
                    data.Init(loadData);
                    controller.AddData(data);
                }
                if(firstEnter)
                {
                    firstEnter = false;
                    Debug.LogWarning("SaveLoadController not initialized. Created object will not be save");
                }
        
                return GO;
            }
            public static GameObject Create<T>(this T obj, GameObject prefab,Vector3 pos,Quaternion qua, Data loadData = null)
            {
                if(!initialized) Init();
        
                var GO = Object.Instantiate(prefab,pos,qua);
                if (controller)
                {
                    if (loadData == null)
                        loadData = new Data()
                        {
                            personalId = GO.GetInstanceID(),
                            prefabId = prefab.GetInstanceID()
                        };
                    var data = GO.AddComponent<GameObjectDataController>();
                    data.Init(loadData);
                    controller.AddData(data);
                }
                if(firstEnter)
                {
                    firstEnter = false;
                    Debug.LogWarning("SaveLoadController not initialized. Created object will not be save");
                }
        
                return GO;
            }

    }
}