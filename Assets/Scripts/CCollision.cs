using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCollision : MonoBehaviour {

    public CharacterController controller;
    //private DelegateManager dManager;
    public CMovement cMovement;
    public CJump cJump;

    //private CollisionFlags curFlags;

    void Awake() {
        //controller = GetComponent<CharacterController>();
        //dManager = GetComponent<DelegateManager>();
        //cMotion = GetComponent<CharacterMotion>();
    }

    void OnEnable() {
        //curFlags = CollisionFlags.None;
    }

    void OnDisable() {
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    void FixedUpdate() {
        //Debug.Log("CCollision-->FixedUpdate" + controller.collisionFlags + curFlags);
    }

    public void partCollisionEnter(Collision collision, ColliderEnum part) {
        //Debug.Log("CCollision-->partCollisionEnter");
        if (part == ColliderEnum.Head) {
            headCollisionEnter(collision);
        }
    }

    void headCollisionEnter(Collision collision) {
        if (collision.collider.tag == TagEnum.Block.ToString()) {
            ContactPoint contact = collision.contacts[0];
            //Debug.Log("CCollision-->OnCollisionEnter" + contact.normal);
            //Debug.DrawRay(contact.point, contact.normal, Color.red, 500);
            if (contact.normal.y < 0) {
                cJump.headBumped();
                cMovement.movement(0, MotionEnum.ReverseYAxis);
            }
            //Debug.Log("CCollision-->headColliderEnter");
        }
    }
}
