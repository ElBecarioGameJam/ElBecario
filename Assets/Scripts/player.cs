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

    public bool agacharse;
    public bool saltar;


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

        //el jugador corre
        if (Input.GetKey(KeyCode.D))
        {
            sprint = true;
        }

        //el jugador deja de correr
        else if (Input.GetKeyUp(KeyCode.D))
        {
            sprint = false;
        }

        //el jugador frena
        else if (Input.GetKey(KeyCode.A))
        {
            slow = true;
        }

        //el jugador deja de frenar
        else if (Input.GetKeyUp(KeyCode.A))
        {
            slow = false;
        }

        //el jugador salta
        if (Input.GetKeyDown(KeyCode.W))
        {
            saltar = true;
        }
        //el jugador se agacha
        else if (Input.GetKeyDown(KeyCode.S))
        {
            agacharse = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            agacharse = false;
        }
    }

    private void FixedUpdate()
    {
        if (saltar) //TODO
        {
            this.rigidbody2D.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            saltar = false;
        }
        if (agacharse)
        {
            gameObject.transform.localScale += new Vector3(0, -5, 0);
        }
    }
}
