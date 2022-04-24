using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RightPlayer : MonoBehaviour
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
        ball.rightScore += onRightScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = getNewPosition(Time.deltaTime, Vector3.up);
        } else if (Input.GetKey(KeyCode.DownArrow))
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

    void onRightScore()
    {
        score++;
        scoreText.GetComponent<TextMeshPro>().text = score.ToString();
    }
}
