using System;
using System.Collections.Generic;
using SimpleInputCore.Controllers;
using UnityEngine;

namespace SimpleInputCore
{
    public static class SimpleInput
    {
        private static bool initialized = false;

        private static Dictionary<string, InputControllerBase> ControllersMap =
            new Dictionary<string, InputControllerBase>();
        static void init()
        {
            var controllers = GameObject.FindObjectsOfType<InputControllerBase>();
            foreach (var controller in controllers)
            {
                ControllersMap.Add(controller.AxisName,controller);
            }
            initialized = true;
        }

        public static float GetAxis(string AxisName)
        {
            if (!initialized) init();
            try
            {
                var data = ControllersMap[AxisName].GetData();
                return data;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return 0;
            }
        }
    }
}