using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollider : MonoBehaviour {

    public ColliderEnum part;
    public CCollision handler;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter(Collision collision) {
        handler.partCollisionEnter(collision, part);
    }
}
