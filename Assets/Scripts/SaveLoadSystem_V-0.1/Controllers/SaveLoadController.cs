using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Object = UnityEngine.Object;

namespace SaveLoadCore.Controllers
{
    public class SaveLoadController : MonoBehaviour
    {
        public static SaveLoadController instance;
        private Dictionary<int, GameObjectDataController> dataMap;

        private PrefabsData prefabsData;

        private void Start()
        {
            prefabsData = new PrefabsData();
        }
        void Init()
        {
            //TODO загрузка данных

            dataMap = new Dictionary<int, GameObjectDataController>();
        }

        void SaveData()
        {
            
        }

        void LoadData()
        {
            
        }

        public void AddData(GameObjectDataController data)
        {
            if(dataMap == null) Init();


            try
            {
                var d = dataMap[data.prefabId];
                //TODO перезапись данных
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                dataMap.Add(data.prefabId,data);
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
