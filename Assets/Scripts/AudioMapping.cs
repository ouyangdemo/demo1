using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMapping : MonoBehaviour {

    //public EnumAudioClip[] enumAudioClip = new EnumAudioClip[Enum.GetValues(typeof(AudioEnum)).Length];
    public EnumAudioClip[] enumAudioClip = new EnumAudioClip[SceneMode.audioSize];
    private Dictionary<AudioEnum, EnumAudioClip> enumAudioMapping;

    //void Reset() {
    //    int len = enumAudioClip.Length;
    //    for (int i = 0; i < len; i++) {
    //        enumAudioClip[i].aEnum = (AudioEnum)Enum.GetValues(typeof(AudioEnum)).GetValue(i);
    //    }
    //}

    void Awake() {
        //Debug.Log("AudioMapping-->Awake " + System.Enum.GetValues(typeof(AudioEnum)));
        enumAudioMapping = new Dictionary<AudioEnum, EnumAudioClip>();
    }

    void OnEnable() {
        int len = enumAudioClip.Length;
        for (int i = 0; i < len; i++) {
            enumAudioMapping.Add(enumAudioClip[i].aEnum, enumAudioClip[i]);
        }
    }

    void OnDisable() {
        enumAudioMapping.Clear();
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public EnumAudioClip getAudioByEnum(AudioEnum aEnum) {
        //Debug.Log("AudioMapping-->getAudioByEnum " + aEnum + aEnum.ToString() + enumAudioClip.Length);
        if (!enumAudioMapping.ContainsKey(aEnum)) {
            return null;
        }
        //Debug.Log("AudioMapping-->getAudioByEnum " + enumAudioMapping[aEnum]);
        return enumAudioMapping[aEnum];
    }
}
