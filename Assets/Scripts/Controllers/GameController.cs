using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.WSA;

namespace Kwicot.Controllers
{
    public class GameController : MonoBehaviour
    {
        public static GameState State { get; private set; }

        public static Action<GameState> onStateChanged;

        private void Start()
        {
            State = GameState.Wait;
            onStateChanged?.Invoke(State);
        }

        public static void SetState(object sender, GameState state)
        {
            Debug.Log($"StateChanged, sender is {sender}");
            State = state;
            onStateChanged?.Invoke(State);
        }



    }
}

public enum GameState
{
    Throw,
    Wait
}