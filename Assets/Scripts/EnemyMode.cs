using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMode : MonoBehaviour {

    public EnemyAI eMoveAI;
    public OMedia oMeidia;
    public ParticleTransformManager cParticle;

    // Use this for initialization
    void Start () {
        eMoveAI.startAI();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
