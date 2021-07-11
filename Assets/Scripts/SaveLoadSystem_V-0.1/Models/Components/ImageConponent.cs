using System;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;

namespace SaveLoadCore.Models.Components
{
    [Serializable]public class ImageComponent
    {
        private string _jsonSource;
        private ColorInfo _color;
        
        public bool enabled;
        public bool maskable;
        public bool raycastTarget;
        
        
        public Color color
        {
            get => new Color(_color.r, _color.g, _color.b, _color.a);
            set => _color = new ColorInfo(value.r, value.g, value.b, value.a);
        }
        public Sprite sprite 
        {
            get => JsonUtility.FromJson<Sprite>(_jsonSource);
            set => _jsonSource = JsonUtility.ToJson(value);
        }

        public Material material
        {
            get => null;
            set {} 
            //TODO Сделать сохранение материала
        }

        
        
        
        
        
        class ColorInfo
        {
            public float r;
            public float g;
            public float b;
            public float a;

            public ColorInfo(float r,float g,float b,float a)
            {
                this.r = r;
                this.g = g;
                this.b = b;
                this.a = a;
            }
            public ColorInfo(float r,float g,float b)
            {
                this.r = r;
                this.g = g;
                this.b = b;
                this.a = 1;
            }
        
        }
    }
}
