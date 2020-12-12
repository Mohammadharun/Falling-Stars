using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public Vector2 speedMinMax;
    float speed;
    float destroyWhenInvisible;

    private void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetMaxDifficulty());
        destroyWhenInvisible = -Camera.main.orthographicSize - transform.localScale.y;
    }


    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if(transform.position.y < destroyWhenInvisible)
        {
            Destroy(gameObject);
        }
    }
}
