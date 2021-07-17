using System;
using UnityEngine;
using UnityEngine.UI;

namespace SaveLoadCore.Models.Components
{
    [Serializable]public class ImageComponent : CustomComponentBase
    {
        private string _spriteSource;
        private ColorInfo _color;
        
        public bool enabled;
        public bool maskable;
        public bool raycastTarget;


        public override void SetInfo(GameObject go)
        {
            var img = go.GetComponent<Image>();
            _spriteSource = JsonUtility.ToJson(img.sprite);
            _color = new ColorInfo(img.color);
            enabled = img.enabled;
            maskable = img.maskable;
            raycastTarget = img.raycastTarget;
            
            
        }

        public override void AttachComponentToGameObject(GameObject go)
        {
            var img = go.AddComponent<Image>();
            img.sprite = JsonUtility.FromJson<Sprite>(_spriteSource);
            img.color = _color.value;
            img.enabled = enabled;
            img.maskable = maskable;
            img.raycastTarget = raycastTarget;
        }
        [Serializable]class ColorInfo
        {
            readonly float r;
            readonly float g;
            readonly float b;
            readonly float a;
            public Color value => new Color(r, g, b, a);

            public ColorInfo(Color color)
            {
                r = color.r;
                g = color.g;
                b = color.b;
                a = color.a;
            }
        
        }
    }
}
