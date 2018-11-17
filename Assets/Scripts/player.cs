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

    public Vector2 jumpForce;

    private bool IsJumping;

    // Use this for initialization
    void Start()
    {
        normalVelocidad = 5;
        sprintVelocidad = 7;
        slowVelocidad = 3;
        IsJumping = false;

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
            
            if(!IsJumping)
            {
                GetComponent<Rigidbody2D>().AddForce(jumpForce, ForceMode2D.Impulse);
            }

        }
        if (agacharse)
        {
            gameObject.transform.localScale += new Vector3(0, -5, 0);
        }
    }


    void OnCollisionEnter2D(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            IsJumping = false;
        }
    }
}
