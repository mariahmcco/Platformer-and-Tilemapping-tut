using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnMove : MonoBehaviour
{
    private Vector2 startPosition;
    public float speed;

    void Start () 
    {
    startPosition = transform.position;
    }
    void Update()
    {
        transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);

        transform.position = new Vector2(startPosition.x + Mathf.Sin(Time.time * speed), transform.position.y);
    }
}
