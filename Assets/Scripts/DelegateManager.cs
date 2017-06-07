using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateManager : MonoBehaviour {

    private Dictionary<DelegateEnum, CommonDelegate> delegateMapping = new Dictionary<DelegateEnum, CommonDelegate>();

    void Awake() {
        //Debug.Log("DelegateManager-->Awake ");
    }

    void OnEnable() {
        //Debug.Log("DelegateManager-->OnEnable ");
    }
    void OnDisable() {
        delegateMapping.Clear();
    }

    public void registerDelegate(DelegateEnum dEnum, CommonDelegate tDelegate) {
        if(!delegateMapping.ContainsKey(dEnum)){
            delegateMapping.Add(dEnum, tDelegate);
        }
        //Debug.Log("DelegateManager-->registerDelegate " + delegateMapping[(int)dEnum].GetInvocationList().Length);
    }

    public void removeDelegate(DelegateEnum dEnum) {
        if (delegateMapping.ContainsKey(dEnum)) {
            delegateMapping.Remove(dEnum);
        }
        //Debug.Log("DelegateManager-->removeDelegate " + delegateMapping[(int)dEnum].GetInvocationList().Length);
    }    

    public void addDelegate(DelegateEnum dEnum, CommonDelegate tDelegate) {
        //Debug.Log("DelegateManager-->addDelegate " + dEnum.ToString() +" " + delegateMapping);
        if (!delegateMapping.ContainsKey(dEnum)) {
            registerDelegate(dEnum,null);
        }
        delegateMapping[dEnum] += tDelegate;
        //Debug.Log("DelegateManager-->addDelegate " + delegateMapping[(int)dEnum].GetInvocationList().Length);
    }

    public void decreaseDelegate(DelegateEnum dEnum, CommonDelegate tDelegate) {
        if (!delegateMapping.ContainsKey(dEnum)) {
            registerDelegate(dEnum, null);
        }
        delegateMapping[dEnum] -= tDelegate;
        //Debug.Log("DelegateManager-->decreaseDelegate " + delegateMapping[(int)dEnum].GetInvocationList().Length);
    }

    public void delegateInvoke(DelegateEnum dEnum, object[] msgData) {
        if (!delegateMapping.ContainsKey(dEnum)) {
            //Debug.Log("DelegateManager-->delegateInvoke NULL" + dEnum.ToString());
            return;
        }
        CommonDelegate delegates = delegateMapping[dEnum];
        if (delegates != null) {
            delegates.Invoke(msgData);
        }
    }    
}
