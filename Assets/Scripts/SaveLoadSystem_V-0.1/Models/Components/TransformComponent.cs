using System;
using UnityEngine;

namespace SaveLoadCore.Models.Components
{
    [Serializable]public class TransformComponent : CustomComponentBase
    {
        private vector3 _postion;
        private vector3 _localPosition;
        private vector3 _localScale;
        private quaternion _rotation;
        
        
        public override void SetInfo(GameObject go)
        {
            _postion = new vector3(go.transform.position);
            _localPosition = new vector3(go.transform.localPosition);
            _localScale = new vector3(go.transform.localScale);
            _rotation = new quaternion(go.transform.rotation);
        }

        public override void AttachComponentToGameObject(GameObject go)
        {
            var transform = go.GetComponent<Transform>();
            transform.position = _postion.value;
            transform.localScale = _localScale.value;
            transform.rotation = _rotation.value;
        }

        [Serializable]class vector3
        { 
            readonly float x;
            readonly float y;
            readonly float z;

            public Vector3 value => new Vector3(x, y, z);
            public vector3(Vector3 v)
            {
                this.x = v.x;
                this.y = v.y;
                this.z = v.z;
            }
            
        }

        [Serializable]class quaternion
        {
            readonly float w;
            readonly float x;
            readonly float y;
            readonly float z;

            public Quaternion value => new Quaternion(x, y, z, w);
            public quaternion(Quaternion qua)
            {
                w = qua.w;
                x = qua.x;
                y = qua.y;
                z = qua.z;
            }
        }
    }
}