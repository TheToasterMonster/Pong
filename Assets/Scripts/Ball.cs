using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public Action leftScore;
    public Action rightScore;

    public float speed;
    private Vector2 direction;

    private float height;
    private float width;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize - transform.localScale.y / 2;
        width = Camera.main.orthographicSize * Camera.main.aspect - transform.localScale.x / 2;
        direction = new Vector2(1, UnityEngine.Random.Range(0, 2) == 1 ? 1 : -1).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = getNewPosition(Time.deltaTime);

        if (gameOver)
        {
            return;
        }

        if (transform.position.x < -width)
        {
            rightScore();
            gameOver = true;
            StartCoroutine(resetAfterDelay(1f));
        }
        else if (transform.position.x > width)
        {
            leftScore();
            gameOver = true;
            StartCoroutine(resetAfterDelay(1f));
        }
    }

    IEnumerator resetAfterDelay(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        transform.position = Vector3.zero;
        direction.x = UnityEngine.Random.Range(0, 2) == 1 ? direction.x : -direction.x;
        gameOver = false;
    }

    Vector3 getNewPosition(float dt)
    {
        float x = transform.position.x + speed * direction.x * dt;
        float y = Mathf.Clamp(transform.position.y + speed * direction.y * dt, -height, height);
        if (Mathf.Abs(y) == height)
        {
            direction.y = -direction.y;
        }
        return new Vector3(x, y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction.x = -direction.x;
    }
}
