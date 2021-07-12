using System;
using System.Collections;
using System.Reflection;
using SaveLoadCore.Controllers;
using SaveLoadCore.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UI;
using Utils;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Kwicot.Controllers
{
    public class TESTSCRIPT : MonoBehaviour
    {
        public GameObject prefab;
        public bool Load = false;

        private void Start()
        {
            if(Load) SaveLoadController.instance.LoadData();
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    var pos = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0);
                    gameObject.Create(prefab, pos);
                }
            }
        }


        private void OnDisable()
        {
            SaveLoadController.instance.SaveData();
        }
    }
}