using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiationTransformManager : MonoBehaviour {

    public InstantiationEnumTransform[] InstantiationEnumTransform;
    private Dictionary<InstantiationEnum, InstantiationEnumTransform> transformMapping;

    void Awake() {
        transformMapping = new Dictionary<InstantiationEnum, InstantiationEnumTransform>();
    }

    void OnEnable() {
        int len = InstantiationEnumTransform.Length;
        for (int i = 0; i < len; i++) {
            transformMapping.Add(InstantiationEnumTransform[i].iEnum, InstantiationEnumTransform[i]);
        }
    }

    void OnDisable() {
        //dManager.decreaseDelegate(DelegateEnum.Particle, playParticle);

        transformMapping.Clear();
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //Debug.Log("ParticleTransformManager-->Update " + transformMapping[ParticleEnum.Jump].position);
    }

    public Transform instantiate(InstantiationEnum inputEnum) {
        EnumInstantiation instantiationObject = SceneMode.instance.getInstantiationByEnum(inputEnum);
        Transform instantiation = instantiationObject.iTransform;
        Transform transform = transformMapping[inputEnum].iTransform;
        if (transformMapping.ContainsKey(inputEnum) && instantiation != null) {
            return Instantiate(instantiation, transform.position, transform.rotation);
        }

        return null;
    }
}
