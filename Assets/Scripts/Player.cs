using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 10f;
    float screenHalfWidthInWorldUnits;
    float halfPlayerWidth;

    Rigidbody2D rb;
    private float screenWidth;
    public event System.Action OnPlayerDeath;

    private void Start()
    {
        screenWidth = Screen.width;
        rb = GetComponent<Rigidbody2D>();
        halfPlayerWidth = transform.localScale.x / 2;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    private void Update()
    {
        //Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        //Vector2 direction = input.normalized;
        //Vector2 velocity = direction * speed;
        //transform.Translate(velocity * Time.deltaTime);

        int i = 0;

        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > screenWidth / 2)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            if (Input.GetTouch(i).position.x < screenWidth / 2)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            ++i;
        }

        //OnBecomeInVisible
        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Block")
        {
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }

}
