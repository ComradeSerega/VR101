﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public int first = -20;
    public int last = 20;
    public int speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (transform.position.x > last || transform.position.x < first)
        {
            speed = -speed;
        }

        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
