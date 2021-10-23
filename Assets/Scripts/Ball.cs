using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 direction;
    public float speed;
    public float currentSpeed;
    public AudioClip onHitWall;
    public AudioClip onHiPlayer;
    AudioSource audioSource;
    void Awake()
    {
        currentSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        do
        {
            direction = new Vector2(1, Random.Range(-1.5f, 1.5f));
        } while (Mathf.Abs(direction.y) <= 0.1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + currentSpeed * direction * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent<Player>())
        {
            direction.x = direction.x * -1;
            currentSpeed *= 1.3f;
            audioSource.clip = onHiPlayer;
            audioSource.Play();
        }
        else
        {
            direction.y *= -1;
            audioSource.clip = onHitWall;
            audioSource.Play();
        }

    }
}
