using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTransformManager : MonoBehaviour {

    public ParticleEnumTransform[] particleEnumTransform;
    private Dictionary<ParticleEnum, ParticleEnumTransform> transformMapping;

    //private DelegateManager dManager;

    void Awake() {
        //dManager = GetComponent<DelegateManager>();
        transformMapping = new Dictionary<ParticleEnum, ParticleEnumTransform>();
    }

    void OnEnable() {
        //dManager.addDelegate(DelegateEnum.Particle, playParticle);

        int len = particleEnumTransform.Length;
        for (int i = 0; i < len; i++) {
            transformMapping.Add(particleEnumTransform[i].pEnum, particleEnumTransform[i]);
        }
    }

    void OnDisable() {
        //dManager.decreaseDelegate(DelegateEnum.Particle, playParticle);

        transformMapping.Clear();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("ParticleTransformManager-->Update " + transformMapping[ParticleEnum.Jump].position);
    }

    public void playParticle(ParticleEnum inputEnum) {
        EnumParticle particleObject = SceneMode.instance.getParticleByEnum(inputEnum);
        Transform particle = particleObject.pTransform;
        Transform transform = transformMapping[inputEnum].pTransform;
        if (transformMapping.ContainsKey(inputEnum) && particle != null) {
            Instantiate(particle, transform.position, transform.rotation);
        }
    }

    //void playParticle(object[] rMsgData) {
    //    ParticleEnum inputEnum;
    //    Transform particle;

    //    if (rMsgData.Length >= 2) {
    //        inputEnum = (ParticleEnum)rMsgData[0];
    //        particle = SceneMode.instance.getParticleByEnum(inputEnum);
    //        if (transformMapping.ContainsKey(inputEnum) && particle!=null) {
    //            Instantiate(particle, transformMapping[inputEnum].position,transform.rotation);
    //        }            
    //    }
    //}
}
