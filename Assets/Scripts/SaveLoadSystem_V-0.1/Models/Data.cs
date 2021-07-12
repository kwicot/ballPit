using System;
using SaveLoadCore.Models.Components;
using UnityEditor.SceneManagement;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

namespace SaveLoadCore.Models
{
    [Serializable]public class Data
    {
        public int prefabId;
        public int personalId;
        public bool activeSelf;
        public ImageComponent Image;
        public TransformComponent Transform;

    }
}