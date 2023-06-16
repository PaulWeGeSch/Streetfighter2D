using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour
{
    public int speed;

    void Update()
    {
        Vector2 pace = new Vector2(1, 0);
        transform.Translate(pace * speed * Time.deltaTime);
    }
}
