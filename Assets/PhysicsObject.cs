using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

    public float minGroundNormal = 0.65f;
    public float gravityModifier = 1f;

    protected Vector3 targetVelocity;
    protected bool isGrounded;
    protected Vector3 groundNormal;

    protected Rigidbody rb;
    protected Vector3 velocity;
    protected RaycastHit[] hitBuffer;

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    void OnEnable() {
        rb = GetComponent<Rigidbody>();

        hitBuffer = new RaycastHit[16];


    }

    void OnDisable() {
    }

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        targetVelocity = Vector3.zero;
        computeVelocity();
	}

    protected virtual void computeVelocity() {
    }

    void FixedUpdate() {
        //Debug.Log("PhysicsObject-->FixedUpdate");

        velocity += gravityModifier * Physics.gravity * Time.deltaTime;
        velocity.x = targetVelocity.x;

        isGrounded = false;
        
        Vector3 deltaPosition = velocity * Time.deltaTime;

        Vector3 moveAlongGrounded = new Vector3(groundNormal.y , - groundNormal.x , 0f);

        Vector3 move = moveAlongGrounded * deltaPosition.x;

        movement(move, false);

        move = Vector3.up * deltaPosition.y;

        movement(move , true);
    }

    void movement(Vector3 move , bool yMovement) {
        float distance = move.magnitude;

        Debug.DrawRay(transform.position, move.normalized, Color.green);
        if (distance > minMoveDistance) {
            hitBuffer = Physics.BoxCastAll(transform.position, GetComponent<BoxCollider>().size/4 , move,transform.rotation, distance + shellRadius);
            for (int i=0;i<hitBuffer.Length;i++) {
                Vector3 currentNormal = hitBuffer[i].normal;
                //Debug.Log("PhysicsObject-->movement" + currentNormal +"  i=" +i);                
                if (currentNormal.y > minGroundNormal && !hitBuffer[i].collider.Equals(GetComponent<BoxCollider>())) {
                    Debug.DrawRay(transform.position, currentNormal, Color.yellow);
                    isGrounded = true;
                    if (yMovement) {
                        groundNormal = currentNormal;
                        //currentNormal.x = 0f;
                    }
                    float projection = Vector3.Dot(velocity,currentNormal);
                    //Debug.Log("PhysicsObject-->movement" + projection);
                    if (projection<0) {
                        velocity -= projection * currentNormal;
                    }

                    float modifiedDistance = hitBuffer[i].distance - shellRadius;
                    distance = modifiedDistance < distance ? modifiedDistance : distance;             
                }
            }
        }

        rb.position += move.normalized * distance;
        //Debug.Log("PhysicsObject-->movement" + rb.position);
    }
}
