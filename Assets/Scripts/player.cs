using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float normalVelocidad;
    public float sprintVelocidad;
    public float slowVelocidad;

    public bool sprint;
    public bool slow;

    public fondo fondo;
    public float velocidadDespl;

    // Use this for initialization
    void Start()
    {
        normalVelocidad = 10;
        sprintVelocidad = 19;
        slowVelocidad = 5;

        
    }

    // Update is called once per frame
    void Update()
    {
        comprobarMovimiento();


        if (sprint)
            movimientoSprint();
        else if (slow)
            movimientoSlow();
        else
            movimientoNormal();
    }

    void movimientoNormal()
    {
        fondo.velocidadDesplazamiento = normalVelocidad;
    }

    void movimientoSprint()
    {
        fondo.velocidadDesplazamiento = sprintVelocidad;
    }
    void movimientoSlow()
    {
        //GetComponent<Rigidbody2D>().velocity = new Vector2(slowVelocidad, GetComponent<Rigidbody2D>().velocity.y);
        fondo.velocidadDesplazamiento = slowVelocidad;

    }

    void comprobarMovimiento()
    {
        if (gameObject.transform.position.x > 24)
            gameObject.transform.position = new Vector3(-7, -3, 0);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprint = true;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprint = false;
        }

        else if (Input.GetKey(KeyCode.LeftControl))
        {
            slow = true;
        }

        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            slow = false;
        }
    }
}
