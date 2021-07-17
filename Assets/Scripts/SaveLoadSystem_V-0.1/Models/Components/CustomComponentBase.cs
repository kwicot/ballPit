using UnityEngine;

namespace SaveLoadCore.Models.Components
{
    public abstract class CustomComponentBase
    {
        public abstract void SetInfo(GameObject go);
        public abstract void AttachComponentToGameObject(GameObject go);
    }
}