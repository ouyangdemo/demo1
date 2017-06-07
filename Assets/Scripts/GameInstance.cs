using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour {

    public static GameInstance instance;

    public static DelegateManager staticDelegate;
    //StartCoroutine(yieldForAddDelegate());
    //IEnumerator yieldForAddDelegate() {
    //    yield return GameInstance.staticDelegate != null;
    //    GameInstance.staticDelegate.addDelegate(DelegateEnum.Camera, setGroundedYAxis);
    //}

    void Awake() {
        //Debug.Log("GameInstance-->Awake ");
        instance = this;

        staticDelegate = GetComponent<DelegateManager>();

        DontDestroyOnLoad(gameObject);
    }

    void OnEnable() {
        //Debug.Log("GameInstance-->OnEnable ");       
    }

    void OnDisable() {
    }    

    // Use this for initialization
    void Start() {
        //Debug.Log("GameInstance-->Start ");
    }
}

