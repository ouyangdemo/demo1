using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public static CameraManager instance;

    //public Transform[] targets;
    public Transform target;

    public bool follow = true;
    public float dampTime = 0.2f;

    public bool zoom = true;
    public float zoomDampTime = 0.2f;
    public float screenBuffer = 7.2f;
    public float zoomMin = 7.2f;

    public Vector3 freeArea = new Vector3(1f, 0.01f, 0.01f);
    public Vector3 offsetSize = new Vector3(2f,0f,0f);

    private Camera mzCamera;

    public Vector3 sceneBorder = new Vector3(58f, 20f, 2f);
    private Vector3 velocity;
    private float zoomSpeed;
    private Vector3 desiredPosition;
    private Vector3 desiredOffsetPosition;
    private Vector3 positionOffset;
    private float groundedYAxis;

    void Awake() {
        //Debug.Log("CameraManager-->Awake " + GameInstance.staticDelegate);
        instance = this;
        
        //Debug.Log("CameraManager-->Awake " + Screen.width +" "+ Screen.height);
        mzCamera = GetComponentInChildren<Camera>();
        //Debug.Log("CameraManager-->Awake " + mzCamera.WorldToScreenPoint(transform.position));
    }

    void OnEnable() {
        //Debug.Log("CameraManager-->OnEnable " + GameInstance.staticDelegate);
        //StartCoroutine(yieldForAddDelegate());
    }

    //IEnumerator yieldForAddDelegate() {
    //    yield return GameInstance.staticDelegate != null;
    //    GameInstance.staticDelegate.addDelegate(DelegateEnum.Camera, setGroundedYAxis);
    //}

    void OnDisable() {
        //GameInstance.staticDelegate.decreaseDelegate(DelegateEnum.Camera, setGroundedYAxis);
    }

    // Use this for initialization
    void Start () {
        //Debug.Log("CameraManager-->Start ");
    }

    // Update is called once per frame
    void Update () {
        cameraFollow();
        cameraZoomJump();
        //Debug.Log("CameraManager-->Update " + mzCamera.orthographicSize);
    }

    void cameraFollow() {
        if (!follow||target==null) {
            return;
        }
        desiredPosition = target.position;
        calculateFollow();

        //Debug.Log("CameraManager-->cameraFollow " + transform.position + desiredPosition);
    }

    void calculateFollow() {
        Vector3 movePos = desiredPosition - (transform.position - positionOffset);
        //Debug.Log("CameraManager-->calculateFollow movePos--->" + movePos + " " + freeArea);
        //Debug.Log("CameraManager-->calculateFollow movePos--->" + desiredOffsetPosition + " " + positionOffset + " " + transform.position);
        Vector3 deltaOffset = Vector3.zero;
        if (Mathf.Abs(movePos.x) <= freeArea.x && Mathf.Abs(movePos.y) <= freeArea.y && Mathf.Abs(movePos.z) <= freeArea.z) {            
            return;
        }

        //positionOffset = Vector3.zero;
        if (Mathf.Abs(movePos.x) > freeArea.x) {
            deltaOffset.x = movePos.x > 0 ? offsetSize.x : -offsetSize.x;
            desiredOffsetPosition.x = desiredPosition.x + deltaOffset.x;
            positionOffset.x = deltaOffset.x;
            //Debug.Log("CameraManager-->calculateFollow x");
        }
        if (Mathf.Abs(movePos.y) > freeArea.y) {
            deltaOffset.y = movePos.y > 0 ? offsetSize.y : -offsetSize.y;
            desiredOffsetPosition.y = desiredPosition.y + deltaOffset.y;
            positionOffset.y = deltaOffset.y;
            //Debug.Log("CameraManager-->calculateFollow y");
        }
        if (Mathf.Abs(movePos.z) > freeArea.z) {
            deltaOffset.z = movePos.z > 0 ? offsetSize.z : -offsetSize.z;
            desiredOffsetPosition.z = desiredPosition.z + deltaOffset.z;
            positionOffset.z = deltaOffset.z;
            //Debug.Log("CameraManager-->calculateFollow z");
        }

        //Vector3 desiredLocalPosition = transform.InverseTransformPoint(desiredPosition);
        //Vector3 transformLocalPos = transform.InverseTransformPoint(transform.position);
        //Vector3 desiredToTargetPos = desiredLocalPosition - transformLocalPos;

        Vector3 screenSize = new Vector3(mzCamera.orthographicSize * mzCamera.aspect, mzCamera.orthographicSize, 0);
        if (desiredOffsetPosition.x > sceneBorder.x - screenSize.x) {
            desiredOffsetPosition.x = sceneBorder.x - screenSize.x;
        }
        else if (desiredOffsetPosition.x < 0) {
            desiredOffsetPosition.x = 0;
        }
        if (desiredOffsetPosition.y > sceneBorder.y - screenSize.y) {
            desiredOffsetPosition.y = sceneBorder.y - screenSize.y;
        }
         else if (desiredOffsetPosition.x < 0) {
            desiredOffsetPosition.y = 0;
        }

        transform.position = Vector3.SmoothDamp(transform.position, desiredOffsetPosition, ref velocity, dampTime);
    }
    
    //void calculateAveragePosition() {
    //    Vector3 averagePos = new Vector3();
    //    int numTarget = 0;

    //    for (int i = 0; i < targets.Length; i++) {
    //        if (!targets[i].gameObject.activeSelf) {
    //            continue;
    //        }
    //        averagePos += targets[i].position;
    //        numTarget++;
    //    }

    //    if (numTarget > 0) {
    //        averagePos /= numTarget;
    //    }

    //    desiredPosition = averagePos;
    //}

    //void cameraZoom() {
    //    if (!zoom) {
    //        return;
    //    }
    //    float requiredSize = calculateRequiredSize();
    //    mzCamera.orthographicSize = Mathf.SmoothDamp(mzCamera.orthographicSize, requiredSize, ref zoomSpeed, zoomDampTime);
    //    //Debug.Log("CameraManager-->cameraZoom " + mzCamera.orthographicSize);
    //}

    //float calculateRequiredSize() {
    //    Vector3 desiredLocalPosition = transform.InverseTransformPoint(desiredPosition);

    //    float size = 0f;
    //    Vector3 targetLocalPos;
    //    Vector3 desiredToTargetPos;
    //    for (int i = 0; i < targets.Length; i++) {
    //        if (!targets[i].gameObject.activeSelf) {
    //            continue;
    //        }
    //        targetLocalPos = transform.InverseTransformPoint(targets[i].position);

    //        desiredToTargetPos = desiredLocalPosition - targetLocalPos;

    //        size = Mathf.Max(size, Mathf.Abs(desiredToTargetPos.x) / mzCamera.aspect);
    //        size = Mathf.Max(size, Mathf.Abs(desiredToTargetPos.y));
    //    }

    //    size += screenBuffer;
    //    size = Mathf.Max(size,zoomMin);

    //    //Debug.Log("CameraManager-->calculateRequiredSize " + size);

    //    return size;
    //}

    public void setGroundedYAxis(object[] rMsgData) {
        CameraEnum inputEnum;
        //Debug.Log("CameraManager-->setOriginalPosition");
        if (rMsgData.Length >= 1) {
            inputEnum = (CameraEnum)rMsgData[0];
        }
        else {
            return;
        }
        if (inputEnum == CameraEnum.GroundedYAxis) {
            if (rMsgData.Length >= 2) {
                groundedYAxis = ((Vector3)rMsgData[1]).y;
            }
        }

        //Debug.Log("CameraManager-->setOriginalPosition" + inputEnum + desiredPosition);
    }

    void cameraZoomJump() {
        if (!zoom) {
            return;
        }
        float size = desiredPosition.y - groundedYAxis;

        size += screenBuffer;
        
        Vector3 screenSize = new Vector3(size * mzCamera.aspect, size, 0);

        //Debug.Log("CameraManager-->cameraZoomJump " + desiredOffsetPosition.x + " " + screenSize.x + " "+ (desiredOffsetPosition.x - screenSize.x));

        if (desiredOffsetPosition.x >= sceneBorder.x - screenSize.x) {
            //Debug.Log("CameraManager-->cameraZoomJump 1 ");
            size = (sceneBorder.x - desiredOffsetPosition.x )/ mzCamera.aspect;
        }
        else if (desiredOffsetPosition.x - screenSize.x <= -zoomMin * mzCamera.aspect) {
            //Debug.Log("CameraManager-->cameraZoomJump 2 ");
            size = (desiredOffsetPosition.x + zoomMin * mzCamera.aspect) / mzCamera.aspect;
        }

        //if (desiredOffsetPosition.y > sceneBorder.y - screenSize.y) {
        //    //Debug.Log("CameraManager-->cameraZoomJump 3 ");
        //    size = sceneBorder.y - desiredOffsetPosition.y;
        //}
        //else if (desiredOffsetPosition.y - screenSize.y < -zoomMin) {
        //    //Debug.Log("CameraManager-->cameraZoomJump 4 ");
        //    size = desiredOffsetPosition.y + zoomMin;
        //}

        size = Mathf.Max(size, zoomMin);

        mzCamera.orthographicSize = Mathf.SmoothDamp(mzCamera.orthographicSize, size, ref zoomSpeed, zoomDampTime);
        //Debug.Log("CameraManager-->cameraZoomJump " + mzCamera.orthographicSize);
    }
}
