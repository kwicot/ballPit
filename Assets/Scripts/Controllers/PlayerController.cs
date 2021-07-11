using System;
using UnityEngine;

namespace Kwicot.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        public GameObject TargetBall;
        public float StrangeImpulse;
        private float Strange;
        
        
        private Camera camera;
        private void Start()
        {
            camera = Camera.main;
            CameraController.OnStrangeChangedDelegate += OnStrangeChanged;
        }

        private void Update()
        {
            if (GameController.State == GameState.Throw)
            {
                if (TargetBall.GetComponent<Rigidbody>().velocity.magnitude < 0.1f)
                {
                    TargetBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    GameController.SetState(this,GameState.Wait);
                }
            }
        }
        

        void OnStrangeChanged(float strange, float max)
        {
            Strange = strange * StrangeImpulse;
        }

        public void Throw()
        {
            TargetBall.GetComponent<Rigidbody>().velocity = camera.transform.forward * Strange * StrangeImpulse;
            GameController.SetState(this,GameState.Throw);
        }
    }

}