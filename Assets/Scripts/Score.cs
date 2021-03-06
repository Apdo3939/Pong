using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        score++;
        Ball ball = coll.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            coll.transform.position = Vector3.zero;
            ball.direction.x *= -1;
            ball.currentSpeed = ball.speed;
            scoreText.text = "" + score;
            audioSource.Play();
        }
    }
}
