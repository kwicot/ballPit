using System;
using Kwicot.Controllers;
using SaveLoadCore.Models;
using SaveLoadCore.Models.Components;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

namespace SaveLoadCore.Controllers
{
    public class GameObjectDataController : MonoBehaviour
    {
        private Data _data;
        public Data data { get; }

        public int prefabId => _data.prefabId;
        public int personalId => _data.personalId;

        void UpdateData()
        {
            _data.activeSelf = gameObject.activeSelf;
            _data.Transform?.SetInfo(gameObject);
            _data.Image?.SetInfo(gameObject);
        }

        public void Init(Data data)
        {
            this._data = data;
            var controller = SaveLoadController.instance;

            if (controller.config.Transforms)
                _data.Transform = new TransformComponent();
            
            if (controller.config.Images && gameObject.TryGetComponent(out Image img))
                _data.Image = new ImageComponent();
            
            
            //if(controller.config.BoxColliders && gameObject.TryGetComponent(out BoxCollider col))
            
        }

        public void LoadData(Data data)
        {
            _data = data;
            
            gameObject.SetActive(_data.activeSelf);
            _data.Image?.AttachComponentToGameObject(gameObject);
            _data.Transform?.AttachComponentToGameObject(gameObject);
        }


        private void OnDestroy()
        {
            SaveLoadController.instance.RemoveData(personalId);
        }
    }
}