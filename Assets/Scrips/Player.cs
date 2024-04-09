using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using Unity.UI;
public class Player1 : MonoBehaviour
{
    [SerializeField] private Rigidbody myRBD2;
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] private float rayDistance = 10f;
    private Rigidbody _comRigiBody;
    private float horizontal;
    public float raycast;
    public bool Isground;
    public LayerMask Detectar;
    public bool Saltar;
    public float distancia;
    private int saltosRestantes;
    public int maxSaltos = 2;
    private Vector3 movementPlayer;
    public float SpeedX;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        _comRigiBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       //myRBD2.velocity = movementPlayer * velocityModifier;
        Isground = Physics.Raycast(transform.position, Vector3.down, raycast, Detectar);
        if (Isground)
        {
            saltosRestantes = maxSaltos;
        }

        if (saltosRestantes > 0)
        {
            Saltar = true;
            saltosRestantes--;
        }
    }
    public void Onmovement(InputAction.CallbackContext contex)
    {
        //movementPlayer = contex.ReadValue<Vector3>();
        horizontal = contex.ReadValue<Vector3>().x;
    }
    public void saltar(InputAction.CallbackContext contex)
    {

        _comRigiBody.velocity = new Vector3(horizontal * SpeedX, _comRigiBody.velocity.y);
        if (Saltar)
        {
            _comRigiBody.velocity = new Vector3(_comRigiBody.velocity.x, 0);
            _comRigiBody.AddForce(new Vector3(0, distancia), ForceMode.Impulse);
            Saltar = false;
        }
    }
    private void FixedUpdate()
    {
        _comRigiBody.velocity = new Vector3(horizontal * SpeedX, _comRigiBody.velocity.y);
    }
}
