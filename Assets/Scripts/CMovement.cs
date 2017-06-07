using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMovement : MonoBehaviour {

    public CharacterController controller;
    public OMedia oMeidia;
    //private DelegateManager dManager;
    //[SerializeField]
    private Vector3 velocity;
    private MoveStatus mStatus;
    private bool facingRight;
    //private JumpStatus jStatus;

    void Awake() {
        //controller = GetComponent<CharacterController>();
        //cMeidia = GetComponent<ObjectMedia>();
        //dManager = GetComponent<DelegateManager>();
    }

    void OnEnable() {
        //dManager.addDelegate(DelegateEnum.Motion, updateVelocity);

        velocity = Vector3.zero;
        mStatus = MoveStatus.Stay;
        facingRight = true;
        //jStatus = JumpStatus.Jump;
    }

    void OnDisable() {
        //dManager.decreaseDelegate(DelegateEnum.Motion, updateVelocity);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate() {
        //Debug.Log("CMovement-->FixedUpdate"+ moveInput);
        updateMovement();
    }

    public void movement(float inputData, MotionEnum inputEnum) {
        if (inputEnum == MotionEnum.XAxis) {
            velocity.x = inputData;
        }
        else if (inputEnum == MotionEnum.YAxis) {
            velocity.y = inputData;
        }
        else if (inputEnum == MotionEnum.AddXAxis) {
            velocity.x += inputData;
        }
        else if (inputEnum == MotionEnum.AddYAxis) {
            velocity.y += inputData;
        }
        else if (inputEnum == MotionEnum.ReverseXAxis) {
            velocity.x *= -1;
        }
        else if (inputEnum == MotionEnum.ReverseYAxis) {
            //Debug.Log("CMovement-->updateVelocity" + velocity.y);
            velocity.y *= -1;
            //Debug.Log("CMovement-->updateVelocity" + velocity.y);
        }
    }

    void updateMovement() {
        //calculateGravity();
        controller.Move(velocity * Time.deltaTime);
        updateMoveStatus();
        updateJumpStatus();
    }

    void updateMoveStatus() {
        float velocity = controller.velocity.x;

        mStatus = Mathf.Abs(velocity) > 0 ? MoveStatus.Run : MoveStatus.Stay;
        if (mStatus == MoveStatus.Run) {
            //bool sFacingRight = velocity > 0 ? true : false;
            if (facingRight ^ (velocity > 0)) {
                facingRight = !facingRight;
                oMeidia.playAnimation(AnimationEnum.FacingRight,facingRight);
            }
        }
        oMeidia.playAnimation(AnimationEnum.VelocityX, Mathf.Abs(velocity));
    }

    void updateJumpStatus() {
        if (controller.isGrounded) {
            if (velocity.y == 0f) {
                return;
            }
            velocity.y = 0f;
        }

        oMeidia.playAnimation(AnimationEnum.VelocityY,velocity.y);
    }

        //void updateVelocity(object[] rMsgData) {
        //    MotionEnum inputEnum;
        //    float inputData=0f;

        //    if (rMsgData.Length >= 2) {
        //        inputEnum = (MotionEnum)rMsgData[0];
        //        inputData = (float)rMsgData[1];
        //    }
        //    else {
        //        return;
        //    }

        //    if (inputEnum == MotionEnum.XAxis) {
        //        velocity.x = inputData;
        //    }
        //    else if (inputEnum == MotionEnum.YAxis) {
        //        velocity.y = inputData;
        //    }
        //    else if (inputEnum == MotionEnum.ZAxis) {
        //        velocity.z = inputData;
        //    }
        //    else if (inputEnum == MotionEnum.AddXAxis) {
        //        velocity.x += inputData;
        //    }
        //    else if (inputEnum == MotionEnum.AddYAxis) {
        //        velocity.y += inputData;
        //    }
        //    else if (inputEnum == MotionEnum.AddZAxis) {
        //        velocity.z += inputData;
        //    }
        //    else if (inputEnum == MotionEnum.ReverseXAxis) {
        //        velocity.x *= -1;
        //    }
        //    else if (inputEnum == MotionEnum.ReverseYAxis) {
        //        //Debug.Log("CharacterMotion-->updateVelocity" + velocity.y);
        //        velocity.y *= -1;
        //        //Debug.Log("CharacterMotion-->updateVelocity" + velocity.y);
        //    }
        //    else if (inputEnum == MotionEnum.ReverseZAxis) {
        //        velocity.z *= -1;
        //    }

        //}

        //void updateMotion() {
        //    //calculateGravity();

        //    controller.Move(velocity * Time.deltaTime);

        //    updateMoveStatus();
        //    updateJumpStatus();                
        //}

        //void updateMoveStatus() {
        //    float velocity = controller.velocity.x;

        //    mStatus = Mathf.Abs(velocity) > 0 ? MoveStatus.Run : MoveStatus.Stay;
        //    if (mStatus == MoveStatus.Run) {
        //        //bool sFacingRight = velocity > 0 ? true : false;
        //        if (facingRight ^ (velocity > 0)) {
        //            facingRight = !facingRight;
        //            animationFacing(facingRight);
        //        }           
        //    }

        //    animationMove(Mathf.Abs(velocity));
        //}

        //void updateJumpStatus() {
        //    if (jStatus == JumpStatus.Grounded && velocity.y == 0f) {
        //        return;
        //    }

        //    object[] sMsgData = new object[2];
        //    sMsgData[0] = UpdateEnum.JumpStatus;
        //    if (controller.isGrounded) {
        //        jStatus = JumpStatus.Grounded;

        //        sMsgData[1] = jStatus;
        //        //DelegateManager.delegateInvoke(DelegateEnum.Update, sMsgData);

        //        velocity.y = 0f;

        //    }
        //    else {

        //        jStatus = JumpStatus.Jump;

        //        sMsgData[1] = jStatus;
        //        //DelegateManager.delegateInvoke(DelegateEnum.Update, sMsgData);            


        //    }

        //    dManager.delegateInvoke(DelegateEnum.Update, sMsgData);

        //    animationJump(velocity.y);
        //    animationGrounded(controller.isGrounded);

        //    //Debug.Log("CharacterMotion-->updateGround " + jStatus + controller.velocity.y);
        //}

        //void animationMove(float velocity) {
        //    object[] sMsgData = new object[2];
        //    sMsgData[0] = AnimationEnum.VelocityX;
        //    sMsgData[1] = velocity;

        //    dManager.delegateInvoke(DelegateEnum.Animation, sMsgData);
        //}

        //void animationFacing(bool facingRight) {
        //    object[] sMsgData = new object[2];
        //    sMsgData[0] = AnimationEnum.FacingRight;
        //    sMsgData[1] = facingRight;

        //    dManager.delegateInvoke(DelegateEnum.Animation, sMsgData);
        //}

        //void animationJump(float velocity) {
        //    object[] sMsgData = new object[2];
        //    sMsgData[0] = AnimationEnum.VelocityY;
        //    sMsgData[1] = velocity;

        //    dManager.delegateInvoke(DelegateEnum.Animation, sMsgData);
        //}

        //void animationGrounded(bool grounded) {
        //    object[] sMsgData = new object[2];
        //    sMsgData[0] = AnimationEnum.Grounded;
        //    sMsgData[1] = grounded;

        //    dManager.delegateInvoke(DelegateEnum.Animation, sMsgData);
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
