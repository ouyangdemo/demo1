using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCollision : MonoBehaviour {

    public RMove rbMove;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision) {
        ContactPoint contact = collision.contacts[0];
        //Debug.Log("PCollision-->OnCollisionEnter" + contact.normal);
        //Debug.DrawRay(contact.point, contact.normal, Color.red, 500);
        Vector3 pos = contact.point;
        if (collision.collider.tag == TagEnum.Block.ToString() || collision.collider.tag == transform.tag) {
            if (contact.normal.x != 0) {
                //Debug.Log("PCollision-->OnCollisionEnter Reverse");
                rbMove.directionReverse();
            }
            if (contact.normal.y > 0) {
                if (rbMove.velocity == Vector3.zero) {
                    //Debug.Log("PCollision-->OnCollisionEnter Default");
                    rbMove.defaultAutoMove();
                }
            }
        }
    }
}
