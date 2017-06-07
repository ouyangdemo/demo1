using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    //public MyEventHandler moveHanlder;
    //public MyEventHandler jumpHanlder;
    //public MyEventHandler actionHanlder;
    //private DelegateManager dManager;

    public CMove cMove;
    public CJump cJump;

    void Awake() {
        //dManager = GetComponent<DelegateManager>();
        //cMove = GetComponent<CharacterMove>();
        //cJump = GetComponent<CharacterJump>();
    }

    void OnEnable() {
        //dManager.registerDelegate(DelegateEnum.Input,null);
        //cMove = GetComponent<CharacterMove>();
        //cJump = GetComponent<CharacterJump>();
    }

    void OnDisable() {
        //dManager.removeDelegate(DelegateEnum.Input);
    }

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        horizontalInput();
        verticalInput();
        jumpInput();
        actionInput();
    }

    void FixedUpdate() {
        //Debug.Log("PlayerInput-->FixedUpdate");
    }

    void horizontalInput() {
        InputEnum inputEnum;

        float hInput = Input.GetAxis("Horizontal");

        //inputEnum = Input.GetButton("Fire1") ? InputEnum.Run : InputEnum.Walk;
        inputEnum = InputEnum.HorizontalMove;

        cMove.inputMove(inputEnum, hInput);
    }

    void verticalInput() {
        InputEnum inputEnum;
        float vInput = Input.GetAxis("Vertical");

        inputEnum = InputEnum.VerticalMove;

        cMove.inputMove(inputEnum, vInput);
    }

    void jumpInput() {
        InputEnum inputEnum = InputEnum.Jump;

        if (Input.GetButtonDown("Jump")) {
            cJump.inputJump(inputEnum, true);
        }
        else if (Input.GetButtonUp("Jump")) {
            cJump.inputJump(inputEnum, false);
        }
        else {
            return;
        }
    }

    void actionInput() {
        //InputEnum inputEnum;

        if (!Input.GetButton("Fire1")) {
            return;
        }
        //inputEnum = InputEnum.Action;
    }

    public void setTarget(Transform target) {
        cMove = target.GetComponent<CMove>();
        cJump = target.GetComponent<CJump>();
    }

    //void horizontalInput() {
    //    InputEnum inputEnum;

    //    float hInput = Input.GetAxis("Horizontal");
    //    //if (hInput == 0) {
    //    //    return;
    //    //}

    //    //inputEnum = Input.GetButton("Fire1") ? InputEnum.Run : InputEnum.Walk;
    //    inputEnum = InputEnum.HorizontalMove;
    //    object[] sMsgData = new object[2];
    //    sMsgData[0] = inputEnum;
    //    sMsgData[1] = hInput;

    //    dManager.delegateInvoke(DelegateEnum.Input, sMsgData);
    //    //moveHanlder.Invoke(msgData);
    //    //GameInstance.staticDelegate.delegateInvoke(DelegateEnum.Input, sMsgData);
    //}

    //void verticalInput() {
    //    InputEnum inputEnum;
    //    float vInput = Input.GetAxis("Vertical");
    //    if (vInput == 0) {
    //        return;
    //    }
    //    inputEnum = InputEnum.HorizontalMove;

    //    object[] sMsgData = new object[2];
    //    sMsgData[0] = inputEnum;
    //    sMsgData[1] = vInput;

    //    dManager.delegateInvoke(DelegateEnum.Input, sMsgData);
    //}

    //void jumpInput() {
    //    InputEnum inputEnum;

    //    if (Input.GetButtonDown("Jump")) {
    //        inputEnum = InputEnum.Jump;
    //    }
    //    else {
    //        return;
    //    }

    //    object[] sMsgData = new object[1];
    //    sMsgData[0] = inputEnum;

    //    dManager.delegateInvoke(DelegateEnum.Input,sMsgData);
    //}

    //void actionInput() {
    //    InputEnum inputEnum;

    //    if (Input.GetButton("Fire1")) {
    //        inputEnum = InputEnum.Action;
    //    }
    //    else {
    //        return;
    //    }

    //    object[] sMsgData = new object[1];
    //    sMsgData[0] = inputEnum;

    //    dManager.delegateInvoke(DelegateEnum.Input, sMsgData);
    //}    
}