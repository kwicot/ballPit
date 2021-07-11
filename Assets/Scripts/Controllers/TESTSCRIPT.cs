using System;
using System.Collections;
using System.Reflection;
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

        private void Start()
        {
            var obj = gameObject.Create(prefab);
           // Debug.Log($"Prefab id - {prefab.GetInstanceID()} \n new object id - {obj.GetComponent<SaveDataInfo>().ID}");
        }
        


    }
}