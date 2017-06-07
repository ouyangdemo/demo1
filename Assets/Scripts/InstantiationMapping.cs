using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiationMapping : MonoBehaviour {

    public EnumInstantiation[] enumInstantiation = new EnumInstantiation[SceneMode.instantiationSize];
    private Dictionary<InstantiationEnum, EnumInstantiation> enumInstantiationMapping;

    void Awake() {
        enumInstantiationMapping = new Dictionary<InstantiationEnum, EnumInstantiation>();
    }

    void OnEnable() {
        int len = enumInstantiation.Length;
        for (int i = 0; i < len; i++) {
            if (enumInstantiation[i] != null) {
                enumInstantiationMapping.Add(enumInstantiation[i].iEnum,enumInstantiation[i]);
            }
        }
    }

    void OnDisable() {
        enumInstantiationMapping.Clear();
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public EnumInstantiation getInstantiationByEnum(InstantiationEnum iEnum) {
        if (!enumInstantiationMapping.ContainsKey(iEnum)) {
            return null;
        }
        return enumInstantiationMapping[iEnum];
    }
}
