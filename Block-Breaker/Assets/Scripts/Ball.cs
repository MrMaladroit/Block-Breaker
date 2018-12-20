using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private PaddleMovementController paddle1;
    [SerializeField] private Vector2 paddleLaunchVelocity;


    private Vector2 paddleToBallVector;
    private Rigidbody2D rb;
    private bool hasStarted = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        paddleToBallVector = this.transform.position - paddle1.transform.position;
    }

    private void Update()
    {
        if(hasStarted == false)
        {
            LockBallPosToPaddle();
            LaunchOnMouseClick();
        }

    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rb.velocity = paddleLaunchVelocity;
        }
    }

    private void LockBallPosToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);

        transform.position = paddlePos + paddleToBallVector;
    }
}
