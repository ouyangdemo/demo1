using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMove : MonoBehaviour {
    public Vector3 speed = new Vector3(4f,0f,0f);

    private Vector3 velocity;

    //private DelegateManager dManager;

    public CMovement cMovement;

    void Awake() {
        //Debug.Log("CharacterMove-->Awake ");
        //dManager = GetComponent<DelegateManager>();

        //cMotion = GetComponent<CharacterMotion>();
    }

    void OnEnable() {
        //dManager.addDelegate(DelegateEnum.Input, calculateMove);
        velocity = Vector3.zero;
    }

    void OnDisable() {
        //dManager.decreaseDelegate(DelegateEnum.Input, calculateMove);
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        //Debug.Log("CMove-->FixedUpdate"+ moveInput);
    }

    public void inputMove(InputEnum inputEnum, object inputData) {
        //Debug.Log("CMove-->inputMove" + velocity + inputData);
        if (inputEnum == InputEnum.HorizontalMove) {
            if (velocity.x == 0 && (float)inputData == 0) {
                return;
            }
            velocity.x = speed.x * (float)inputData;
            cMovement.movement(velocity.x, MotionEnum.XAxis);
        }
    }

    //void checkInput(ref float rVelocity,float inputData, MotionEnum mEnum) {
    //    if (rVelocity == 0 && inputData == 0) {
    //        return;
    //    }
    //    cMovement.movement(rVelocity, MotionEnum.ZAxis);
    //}

    //void calculateMove(object[] rMsgData) {
    //    InputEnum inputEnum;
    //    float inputData;

    //    if (rMsgData.Length >= 2) {
    //        inputEnum = (InputEnum)rMsgData[0];
    //        inputData = (float)rMsgData[1];
    //    }
    //    else {
    //        return;
    //    }
    //    if (inputEnum != InputEnum.HorizontalMove) {
    //        return;
    //    }

    //    //Debug.Log("CharacterMove-->calculateMove" + inputEnum + inputData);        
    //    if (velocity == 0f && inputData == 0f) {
    //        return;
    //    }
    //    velocity = moveVelocity(inputEnum, inputData);

    //    object[] sMsgData = new object[2];
    //    sMsgData[0] = MotionEnum.XAxis;
    //    sMsgData[1] = velocity;
    //    dManager.delegateInvoke(DelegateEnum.Motion, sMsgData);
    //}


    //float moveVelocity(InputEnum inputEnum, float inputData) {        
    //    float velocity = 0f;
    //    if (inputEnum == InputEnum.HorizontalMove) {
    //        velocity = speed * inputData;
    //    }
    //    return velocity;
    //}
}
