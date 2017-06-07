using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECollision : MonoBehaviour {

    public CMovement cMovement;
    public EnemyAI enemyAI;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter(Collision collision) {
        ContactPoint contact = collision.contacts[0];
        //Debug.Log("ECollision-->OnCollisionEnter" + contact.normal + collision.collider.tag.ToString());
        //Debug.DrawRay(contact.point, contact.normal, Color.red, 500);
        Vector3 pos = contact.point;
        if (collision.collider.tag == TagEnum.Block.ToString() || collision.collider.tag == transform.tag) {
            if (contact.normal.x != 0) {
                //Debug.Log("ECollision-->OnCollisionEnter Reverse");
                cMovement.movement(0,MotionEnum.ReverseXAxis); ;
            }
        }

        CharacterMode playerMode;
        if (!ReferenceEquals(collision.collider.transform.parent, null) && collision.collider.transform.parent.tag == TagEnum.Player.ToString()) {
            playerMode = collision.collider.GetComponentInParent<CharacterMode>();
            playerMode.Interact(InteractEnum.Enemy , enemyAI.eDamage);
        }
    }

    public void triggerEnter(Collider collider, ColliderEnum part) {
        //Debug.Log("ECollision-->partCollisionEnter");
        if (part == ColliderEnum.TrackingVision) {
            trackingTarget(collider);
        }
    }

    void trackingTarget(Collider collider) {
        if (collider.tag == TagEnum.Player.ToString()) {
            //Debug.Log("ECollision-->trackingTarget"+ collider+ collider.GetComponent<Transform>());
            enemyAI.trackingTarget(collider.GetComponent<Transform>());
        }
    }
}
