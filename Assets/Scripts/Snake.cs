using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 200f;

    public Joystick joystick;

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
        transform.Rotate(Vector3.forward * -joystick.Vertical * rotationSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "killsPlayer")
        {
            if (GameManager.Instance.hasEnded == false)
            {
                if (transform.parent.name == "Player1")
                {
                    PlayerPrefs.SetInt("Player2", PlayerPrefs.GetInt("Player2") + 1);
                }
                else if (transform.parent.name == "Player2")
                {
                    PlayerPrefs.SetInt("Player1", PlayerPrefs.GetInt("Player1") + 1);
                }
            }

            speed = 0;
            rotationSpeed = 0;

            GameObject.FindObjectOfType<GameManager>().EndGame();  
        }
    }
}
