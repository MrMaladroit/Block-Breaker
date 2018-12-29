using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private PaddleMovementController paddle1;
    [SerializeField] private Vector2 paddleLaunchVelocity;
    [SerializeField] private AudioClip[] ballSounds;
       
    private Vector2 paddleToBallVector;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool hasStarted = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
}
