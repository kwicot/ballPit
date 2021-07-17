using System;
using SaveLoadCore.Models.Components;

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