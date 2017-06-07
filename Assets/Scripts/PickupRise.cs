using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRise : MonoBehaviour {

    public Vector3 speed = Vector3.one;
    public Vector3 moveDirection = Vector3.up;
    private Rigidbody rb;
    private Vector3 velocity;
    private Transform target;

    void Awake() {
    }

    void OnEnable() {

    }

    void OnDisable() {

    }

    // Update is called once per frame
    void Update() {
        if (velocity == Vector3.zero || target==null) {
            return;
        }

        target.transform.Translate(velocity * Time.deltaTime);
    }

    public void setTarget(Transform tTarget) {
        target = tTarget;
        useGravity(target, false);
        //Debug.Log("PickupRise-->setTarget" + target);
    }

    public void defaultAutoMove() {
        autoMove(speed, moveDirection);
    }

    public void autoMove(Vector3 aSpeed, Vector3 aDirection) {
        velocity = new Vector3(aDirection.x * aSpeed.x, aDirection.y * aSpeed.y, aDirection.z * aSpeed.z);
    }

    public void stopAutoMove() {
        velocity = Vector3.zero;
        useGravity(target, true);
    }

    public void useGravity(Transform tTarget,bool use) {
        rb = target.GetComponent<Rigidbody>();
        if (rb != null) {
            rb.useGravity = use;
        }
    }

    void OnCollisionExit(Collision collision) {
        //Debug.Log("PickupRise-->OnCollisionExit" + collision.transform.Equals(target));
        if (collision.transform.Equals(target)) {
            stopAutoMove();
        }
    }
}
