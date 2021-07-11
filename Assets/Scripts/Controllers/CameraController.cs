using System;
using Kwicot.Controllers;
using UnityEngine;
using SimpleInputCore;

public class CameraController : MonoBehaviour
{
    private GameObject Pivot;
    public PlayerController Player;

    public delegate void ThrowDelegate(float strange, float max);

    public static ThrowDelegate OnStrangeChangedDelegate;


    private void Start()
    {
        Pivot = transform.parent.gameObject;
    }

    private float horizontal;
    private void Update()
    {

        var h = SimpleInput.GetAxis("Horizontal");
        if (h != 0)
        {
            //Debug.Log(h);
            horizontal += h * (2f * Math.Abs(h));
            Pivot.transform.rotation = Quaternion.Euler(0, horizontal, 0);
        }

        var v = SimpleInput.GetAxis("Vertical");
        if (v > 0.05f)
            OnStrangeChangedDelegate?.Invoke(v,2f);

        if (Input.touchCount > 0 && GameController.State == GameState.Throw)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                var ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.CompareTag("Ball"))
                    {
                        Player.TargetBall = hit.collider.gameObject;
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Ball"))
                {
                    Player.TargetBall = hit.collider.gameObject;
                }
            }
        }

    }

    private void FixedUpdate()
    {
        if (Player.TargetBall)
        {
            Pivot.transform.position =
                Vector3.Lerp(Pivot.transform.position, Player.TargetBall.transform.position, 0.3f);
        }
    }
}
