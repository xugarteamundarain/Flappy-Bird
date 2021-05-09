using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    // Movimiento arriba/abajo de las tuberias (0 = no movimiento)
    public float speed = 0;

    // Tiempo de cambio de movimiento para las tuberías
    public float switchTime = 2;

    private float distanceToDestroy = 64;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        
        // Invoaos el método cada x segundos
        InvokeRepeating("SwitchMovement", 0, switchTime);
    }

    void SwitchMovement()
    {
        GetComponent<Rigidbody2D>().velocity *= -1;
    }

    private void Update()
    {
        float cam_x = Camera.main.transform.position.x;
        float pipe_x = this.transform.position.x;
        if (cam_x > pipe_x + distanceToDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
