using UnityEngine;

namespace SimpleInputCore.Controllers
{
    public abstract class InputControllerBase : MonoBehaviour
    {
        public string AxisName;
        public abstract float GetData();
    }
}