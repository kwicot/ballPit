using System;
using System.Collections.Generic;
using SaveLoadCore.Models;
using SaveLoadCore.Utils;
using UnityEngine;

namespace SaveLoadCore.Controllers
{
    public class SaveLoadController : MonoBehaviour
    {
        public static SaveLoadController instance;
        private Dictionary<int, GameObjectDataController> dataMap;

        [SerializeField]private PrefabsData prefabsData = new PrefabsData();

        public SaveDataConfig config = new SaveDataConfig();

        private void Awake()
        {
            if (!instance) instance = this;
            else Destroy(this);
        }

        private void Start()
        {
            //prefabsData.Init(Resources.LoadAll<GameObject>(""));
        }
        void Init()
        {
            dataMap = new Dictionary<int, GameObjectDataController>();
        }

        public void SaveData()
        {
            var map = new Dictionary<int, Data>();
            foreach (var dataController in dataMap)
            {
                map.Add(dataController.Key,dataController.Value.data);
            }

            PersistentCache.Save(map);
        }

        public void LoadData()
        {
            var map = PersistentCache.TryLoad<Dictionary<int, Data>>();
            if (map != null)
            {
                Debug.LogWarning("Success load data");
                dataMap = new Dictionary<int, GameObjectDataController>();
                foreach (var obj in map)
                {
                    var data = obj.Value;
                    var id = data.prefabId;
                    GameObject prefab = prefabsData[id];
                    gameObject.Create(prefab, obj.Value);
                }
            }
            else
            {
                Debug.LogWarning("Fail load data");
            }
        }

        public void AddData(GameObjectDataController data)
        {
            if(dataMap == null) Init();


            try
            {
                dataMap[data.personalId] = data;
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                dataMap.Add(data.personalId,data);
            }
        }

        public bool RemoveData(int id)
        {
            try
            {
                return dataMap.Remove(id);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                return false;
            }
        }
    }
}
