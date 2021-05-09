using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    // Velocidad del movimiento
    public float speed = 2f;
    // Fuerza del salto
    public float force = 300f;

    // Start is called before the first frame update
    void Start()
    {
        // Velocidad a la derecha del pájaro
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) ||
            (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) ||
            Input.GetMouseButton(0)) 
        {
            // Salto del pájaro
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        UIManager manager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        manager.ShowAds();
    }
}
