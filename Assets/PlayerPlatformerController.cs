using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7f;
    public float jumpSpeed = 7f;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    protected override void computeVelocity() {
        base.computeVelocity();
        Vector3 move = Vector3.zero;

        move.x = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = jumpSpeed;
        }
        else if(Input.GetButtonUp("Jump")){
            if (velocity.y>0) {
                velocity.y *= .5f;
            }
        }

        targetVelocity = move;
    }
    
}
