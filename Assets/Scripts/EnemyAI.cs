using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public Vector3 speed = Vector3.one;
    public CMovement cMovement;
    public int eDamage;

    private Transform target;
    private bool tracking = false;

    void Awake() {
    }

    void OnEnable() {
    }

    void OnDisable() {
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (tracking) {
            trackingTo();
        }
    }

    void moveInput(float inputData, MotionEnum inputEnum) {
        //Debug.Log("EnemyAI-->inputMove" + velocity + inputData);
        cMovement.movement(inputData,inputEnum);
    }  

    public void startAI() {
        moveInput(speed.x,MotionEnum.XAxis);
    }

    public void trackingTarget(Transform tTarget) {
        target = tTarget;
        tracking = true;
    }

    void trackingTo() {
        if (target==null) {
            tracking = false;
            return;
        }
        Vector3 distance = target.transform.position - transform.position;
        moveInput(speed.x * distance.normalized.x, MotionEnum.XAxis);
        //Debug.Log("EnemyAI-->trackingTo" + direction + target.transform.position.x);
    }
}

