using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeftPlayer : MonoBehaviour
{
    public float speed;
    private float height;

    private int score;
    public GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize - transform.localScale.y / 2;
        score = 0;

        Ball ball = FindObjectOfType<Ball>();
        ball.leftScore += onLeftScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = getNewPosition(Time.deltaTime, Vector3.up);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position = getNewPosition(Time.deltaTime, Vector3.down);
        }
    }

    Vector3 getNewPosition(float dt, Vector3 direction)
    {
        Vector3 position = transform.position + speed * direction * dt;
        position.y = Mathf.Clamp(position.y, -height, height);
        return position;
    }

    void onLeftScore()
    {
        score++;
        scoreText.GetComponent<TextMeshPro>().text = score.ToString();
    }
}
