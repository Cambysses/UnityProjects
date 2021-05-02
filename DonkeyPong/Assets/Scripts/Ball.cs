using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] AudioClip[] sounds;
    float xPush = 0.5f;
    float yPush = 10f;
    float randomSeed = 0.5f;
    bool launched = false;
    Vector2 paddleToBallVector;

    Rigidbody2D rigidBody2D;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        paddleToBallVector = (transform.position - paddle.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!launched)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (launched)
        {
            // Add slight randomness to velocity to prevent getting stuck.
            Vector2 nudge = new Vector2(UnityEngine.Random.Range(-randomSeed, randomSeed), UnityEngine.Random.Range(-randomSeed, randomSeed));
            rigidBody2D.velocity += nudge;

            // Play random sound within "sounds" folder.
            GetComponent<AudioSource>().PlayOneShot(sounds[UnityEngine.Random.Range(0, sounds.Length)]);
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            rigidBody2D.velocity = new Vector2(xPush, yPush);
            launched = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }
}
