using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJump : MonoBehaviour {
    public float normalJump = 6f;
    public bool doubleJumpEnable = true;
    public float doubleJump = 6f;

    public bool useGravity = true;
    public float gravity = 9.81f;

    private bool isDoubleJump;
    [HideInInspector]
    public JumpStatus jStatus;
    //private DelegateManager dManager;
    public CharacterController controller;
    public CMovement cMovement;
    public OMedia oMeidia;
    public ParticleTransformManager cParticle;
    

    void Awake() {
        //dManager = GetComponent<DelegateManager>();
        //controller = GetComponent<CharacterController>();
        //cMotion = GetComponent<CharacterMotion>();
        //cMeidia = GetComponent<ObjectMedia>();
        //cParticle = GetComponent<ParticleTransformManager>();
    }

    void OnEnable() {
        //dManager.addDelegate(DelegateEnum.Input,calculateJump);
        //dManager.addDelegate(DelegateEnum.Update, updateJumpStatus);
        isDoubleJump = true;
        jStatus = JumpStatus.Jump;
    }

    void OnDisable() {
        //dManager.decreaseDelegate(DelegateEnum.Input, calculateJump);
        //dManager.decreaseDelegate(DelegateEnum.Update, updateJumpStatus);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {        
    }

    void FixedUpdate() {
        //Debug.Log("CJump-->FixedUpdate"+ moveInput);
        calculateGravity();
        updateJumpStatus();
    }

    void calculateGravity() {
        //Debug.Log("CJump-->calculateGravity ");
        if (!useGravity) {
            return;
        }
        cMovement.movement(-gravity * Time.deltaTime, MotionEnum.AddYAxis);
        //Debug.Log("CJump-->calculateGravity " + velocity);
    }

    public void inputJump(InputEnum inputEnum, object inputData) {
        if (inputEnum != InputEnum.Jump) {
            return;
        }

        if ((bool)inputData == false) {
            return;
        }

        float velocity = 0f;
        checkJumpEnableAndJump(velocity, normalJump, doubleJump);
    }

    void checkJumpEnableAndJump(float velocity, float oneJump, float doubleJump) {
         if (jStatus == JumpStatus.Grounded) {
            velocity = oneJump;
            jStatus = JumpStatus.Jump;
        }
        else if (doubleJumpEnable && isDoubleJump == false) {
            velocity = doubleJump;
            isDoubleJump = true;
        }
        else {
            return;
        }

        cMovement.movement(velocity, MotionEnum.YAxis);
        oMeidia.playAudio(AudioEnum.Jump);
        cParticle.playParticle(ParticleEnum.Jump);
    }

    void updateJumpStatus() {
        JumpStatus status = controller.isGrounded ? JumpStatus.Grounded : JumpStatus.Jump;

        if (status == jStatus) {
            return;
        }

        jStatus = status;
        if (jStatus == JumpStatus.Grounded) {
            isDoubleJump = false;

            object[] sMsgData = new object[2];
            sMsgData[0] = CameraEnum.GroundedYAxis;
            sMsgData[1] = transform.position;
            GameInstance.staticDelegate.delegateInvoke(DelegateEnum.Camera, sMsgData);
        }

        oMeidia.playAnimation(AnimationEnum.Grounded,controller.isGrounded);
    }

    public void headBumped() {
        isDoubleJump = true;
    }

    //void calculateJump(object[] rMsgData) {
    //    InputEnum inputEnum;
    //    if (rMsgData.Length >= 1) {
    //        inputEnum = (InputEnum)rMsgData[0];
    //    }
    //    else {
    //        return;
    //    }
    //    if (inputEnum != InputEnum.Jump) {
    //        return;
    //    }

    //    //Debug.Log("CharacterJump-->calculateJump" + inputEnum);
    //    float velocity = jumpVelocity(inputEnum);
    //    if (velocity == 0) {
    //        return;
    //    }

    //    object[] sMsgData = new object[2];
    //    sMsgData[0] = MotionEnum.YAxis;
    //    sMsgData[1] = velocity;
    //    dManager.delegateInvoke(DelegateEnum.Motion, sMsgData);
    //}

    //float jumpVelocity(InputEnum inputEnum) {
    //    //Debug.Log("CharacterJump-->jumpVelocity " + inputEnum + jStatus);
    //    float velocity = 0f;

    //    if (inputEnum == InputEnum.None) {
    //        return velocity;
    //    }

    //    if (inputEnum == InputEnum.Jump) {
    //        velocity = checkJumpEnableAndJump(normalJump, doubleJump);
    //    }
    //    else {
    //        return velocity;
    //    };

    //    return velocity;
    //}    

    //float checkJumpEnableAndJump(float oneJump, float doubleJump) {
    //    float velocity = 0f;
    //    if (jStatus == JumpStatus.Grounded) {
    //        velocity = oneJump;
    //        jStatus = JumpStatus.Jump;

    //        audioPlay(AudioEnum.Jump);
    //        playParticle(ParticleEnum.Jump);            
    //    }
    //    else if (doubleJumpEnable && isDoubleJump == false) {
    //        velocity = doubleJump;
    //        isDoubleJump = true;

    //        audioPlay(AudioEnum.Jump);
    //        playParticle(ParticleEnum.Jump);
    //    }
    //    else {
    //    }
    //    return velocity;
    //}

    //void updateJumpStatus(object[] rMsgData) {
    //    UpdateEnum inputEnum;
    //    JumpStatus rStatus;

    //    if (rMsgData.Length >= 2) {
    //        inputEnum = (UpdateEnum)rMsgData[0];
    //        if (inputEnum == UpdateEnum.JumpStatus) {
    //            rStatus = (JumpStatus)rMsgData[1];
    //            if (jStatus == rStatus) {
    //                return;
    //            }

    //            jStatus = rStatus;
    //            if (jStatus == JumpStatus.Grounded) {
    //                isDoubleJump = false;

    //                object[] sMsgData = new object[2];
    //                sMsgData[0] = CameraEnum.GroundedYAxis;
    //                sMsgData[1] = transform.position;
    //                CameraManager.instance.setGroundedYAxis(sMsgData);
    //            }
    //        }      
    //    }
    //    //Debug.Log("CharacterJump-->updateJumpStatus " + jStatus);
    //}

    //void calculateGravity() {
    //    //Debug.Log("CharacterJump-->calculateGravity " + inputEnum + inputData);
    //    if (!useGravity) {
    //        return;
    //    }
    //    float velocity = -gravity * Time.deltaTime;

    //    object[] sMsgData = new object[2];
    //    sMsgData[0] = MotionEnum.AddYAxis;
    //    sMsgData[1] = velocity;
    //    dManager.delegateInvoke(DelegateEnum.Motion, sMsgData);
    //    //Debug.Log("CharacterJump-->calculateGravity " + velocity);
    //}

    //void audioPlay(AudioEnum aEnum) {
    //    object[] sMsgData = new object[2];
    //    sMsgData[0] = aEnum;

    //    dManager.delegateInvoke(DelegateEnum.Audio, sMsgData);
    //}

    //void playParticle(ParticleEnum aEnum) {
    //    object[] sMsgData = new object[2];
    //    sMsgData[0] = aEnum;

    //    dManager.delegateInvoke(DelegateEnum.Particle, sMsgData);

    //    //Debug.Log("CharacterMotion-->playParticle " + test.ToString());
    //}
}
