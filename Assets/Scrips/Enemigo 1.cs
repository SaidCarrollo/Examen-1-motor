using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public float LimiteI;
    public float LimiteD;
    public int direccion;
    public float speed = 1;
    private Rigidbody rigi;


    private void Awake()
    {
        rigi = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (transform.position.x <= LimiteI)
        {
            direccion = 1;
        }
        else if (transform.position.x >= LimiteD)
        {
            direccion = -1;
        }
        rigi.velocity = new Vector3(direccion * speed, rigi.velocity.y, 0);
    }
}
