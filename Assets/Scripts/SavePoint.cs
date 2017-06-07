using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour {
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider) {
        //Debug.Log("TrackingVision-->OnTriggerEnter" + collider.tag.ToString());
        if (collider.tag == TagEnum.Player.ToString()) {
            SceneMode.instance.setSpawnPoint(transform);
        }
    }
}
