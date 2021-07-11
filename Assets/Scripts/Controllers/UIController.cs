using System;
using SimpleInputCore.Controllers;
using UnityEngine;

namespace Kwicot.Controllers
{
    public class UIController : MonoBehaviour
    {
        public GameObject VerticalSlider;
        public GameObject HorizontalSlider;


        private void Start()
        {
            GameController.onStateChanged += OnStateChanged;
        }

        void OnStateChanged(GameState state)
        {
            switch (state)
            {
                case GameState.Throw:
                {
                    VerticalSlider.Deactivate();
                    break;
                }
                case GameState.Wait:
                {
                    VerticalSlider.Activate();
                    break;
                }
            }
        }
    }
}