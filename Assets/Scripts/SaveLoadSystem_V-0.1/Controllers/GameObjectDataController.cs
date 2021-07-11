using System;
using Kwicot.Controllers;
using SaveLoadCore.Models;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

namespace SaveLoadCore.Controllers
{
    public class GameObjectDataController : MonoBehaviour
    {
        private Data _data;
        private int _prefabId;
        private int _personalId;
        
        

        
        
        public Data data => _data;
        public int prefabId => _prefabId;
        public int personalId => _personalId;
        public void Init(Data data)
        {
            _data = data;
        }

        public void Init(int prefabId)
        {
            _prefabId = _prefabId;
            _personalId = _personalId;
        }
        
        private void OnDestroy()
        {
            SaveLoadController.instance.RemoveData(_prefabId);
        }
    }
}