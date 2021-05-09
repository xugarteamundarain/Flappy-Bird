using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bird"){
            UIManager manager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
            manager.AddPoint();
        }
    }
}
