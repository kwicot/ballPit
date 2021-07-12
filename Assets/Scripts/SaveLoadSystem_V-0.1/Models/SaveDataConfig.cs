using System;

namespace SaveLoadCore.Models
{
    [Serializable]public class SaveDataConfig
    {
        public bool Images;
        public bool Transforms;
        public bool Buttons;
        public bool RigidBodys;
        public bool BoxColliders;
        public bool BoxColliders2D;
        public bool CircleColliders2D;
        public bool CapsuleColliders;
        public bool MeshColliders;
        public bool SphereColliders;
        public bool PolygonColliders;
        public bool Texts;
    }
}