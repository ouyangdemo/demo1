using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMapping : MonoBehaviour {

    public EnumParticle[] enumParticle = new EnumParticle[SceneMode.particleSize];
    private Dictionary<ParticleEnum, EnumParticle> enumParticleMapping;

    void Awake() {
        enumParticleMapping = new Dictionary<ParticleEnum, EnumParticle>();
    }

    void OnEnable() {
        int len = enumParticle.Length;
        for (int i = 0; i < len; i++) {
            if (enumParticle[i] != null) {
                enumParticleMapping.Add(enumParticle[i].pEnum, enumParticle[i]);
            }
        }
    }

    void OnDisable() {
        enumParticleMapping.Clear();
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public EnumParticle getAudioByEnum(ParticleEnum pEnum) {
        if (!enumParticleMapping.ContainsKey(pEnum)) {
            return null;
        }
        return enumParticleMapping[pEnum];
    }
}
