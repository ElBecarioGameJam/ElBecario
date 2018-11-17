using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Based on Penny Pixel 2D Tutorial
https://unity3d.com/es/learn/tutorials/topics/2d-game-creation/intro-2d-world-building-w-tilemap?playlist=17093
 */
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 10;
    public float jumpTakeOffSpeed = 10;

    private Animator animator;

    // Use this for initialization
    void Start () 
    {
        animator = GetComponent<Animator> ();
        if (animator == null) {
            animator = transform.GetComponentInChildren<Animator>();
        }
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("Horizontal");

        if (Input.GetButtonDown ("Jump") && grounded) {
            velocity.y = jumpTakeOffSpeed;
        } else if (Input.GetButtonUp ("Jump")) 
        {
            if (velocity.y > 0) {
                velocity.y = velocity.y * 0.5f;
            }
        }
        if(move.x > 0.01f)
        {   
            if (transform.localScale.x < 0) {
                transform.localScale = transform.localScale * new Vector2(-1,1);
                BroadcastMessage("facingRight",SendMessageOptions.DontRequireReceiver);
            } 
        } 
        else if (move.x < -0.01f)
        {
            if (transform.localScale.x > 0) {
                transform.localScale = transform.localScale * new Vector2(-1,1);
                BroadcastMessage("facingLeft",SendMessageOptions.DontRequireReceiver);
            } 
        }
        if (animator != null) {
            animator.SetBool ("Grounded", grounded);
            animator.SetFloat ("VelocityX", Mathf.Abs (velocity.x) / maxSpeed);
        }

        targetVelocity = move * maxSpeed;
    }
}