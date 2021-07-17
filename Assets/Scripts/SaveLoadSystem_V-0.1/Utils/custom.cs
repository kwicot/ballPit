
#if UNITY_EDITOR

using System;
using Kwicot.Controllers;
using SaveLoadCore.Controllers;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SaveLoadCore.Utils
{
    public class custom : CustomEditor
    {
        public custom(Type inspectedType) : base(inspectedType)
        {
        }

        public custom(Type inspectedType, bool editorForChildClasses) : base(inspectedType, editorForChildClasses)
        {
            
        }
        
        [MenuItem("Kwicot/Add/SaveLoadController")]
        static void DoSom()
        {
            var control = Object.FindObjectOfType<SaveLoadController>();
            if (control)
            {
                Debug.LogWarning("Controller allready added");
                return;
            }
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.name = "SaveLoadController";
            Object.DestroyImmediate(go.GetComponent<MeshRenderer>());
            Object.DestroyImmediate(go.GetComponent<MeshFilter>());
            Object.DestroyImmediate(go.GetComponent<BoxCollider>());
            var controller = go.AddComponent<SaveLoadController>();
        }
    }
}

#endif