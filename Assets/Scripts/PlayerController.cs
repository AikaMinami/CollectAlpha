using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private enum State{idle, walk, jump}
    private State state = State.idle;
    private Collider2D coll;
    [SerializeField]private LayerMask ground;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }  

    private void Update(){
        float hDirection = Input.GetAxis("Horizontal");
        if(hDirection < 0){
            rb.velocity = new Vector2(-5,0);
            transform.localScale = new Vector2(-1,1);
        } else if(hDirection > 0){
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2(1,1); 
        } else {
        }
        if(Input.GetKeyDown("Jump") && coll.IsTouchingLayers(ground)){
            rb.velocity = new Vector2(rb.velocity.x,10f);
            state = State.jump;
        }
        VelocityState();
        anim.SetInteger("state", (int)state);
    }

    private void VelocityState(){
        if(state == State.jump){

        }
        else if(Mathf.Abs(rb.velocity.x) > 1.9f){
            state = State.walk;
        } else {
            state = State.idle;     
        }
    }
}
