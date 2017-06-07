using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

[System.Serializable]
public class MyEventHandler : UnityEvent<object[]> {
}

[System.Serializable]
public class ParticleEnumTransform {
    public ParticleEnum pEnum;
    public Transform pTransform;
}

[System.Serializable]
public class InstantiationEnumTransform {
    public InstantiationEnum iEnum;
    public Transform iTransform;
}

[System.Serializable]
public class EnumParticle {
    public ParticleEnum pEnum;
    public Transform pTransform;
}

[System.Serializable]
public class EnumAudioClip {
    public AudioEnum aEnum;
    public AudioClip aAudioClip;
    public AudioMixerGroup outputAudioMixerGroup;
}

[System.Serializable]
public class EnumAudioSource {
    public AudioEnum aEnum;
    public AudioSource aAudioSource;
}

[System.Serializable]
public class EnumRenderer {
    public RendererEnum rEnum;
    public Sprite rSprite;
}

[System.Serializable]
public class EnumInstantiation {
    public InstantiationEnum iEnum;
    public Transform iTransform;
}

public delegate void CommonDelegate(object[] msgData);
//public MyDelegate inputDelegate;
//pInput.inputDelegate += cMotion.test;
//if (inputDelegate!=null) {
//    inputDelegate(msgData);
//}

public class StaticDelegateManager {
    private static StaticDelegateManager instance;

    private CommonDelegate[] delegateMapping;

    private StaticDelegateManager() {
        delegateMapping = new CommonDelegate[System.Enum.GetNames(typeof(DelegateEnum)).Length];
    }

    public static StaticDelegateManager Instance() {
        if (instance == null)
            instance = new StaticDelegateManager();
        return instance;
    }

    //private static CommonDelegate[] delegateMapping = new CommonDelegate[System.Enum.GetNames(typeof(DelegateEnum)).Length];

    public static void addDelegate(DelegateEnum dEnum, CommonDelegate tDelegate) {
        StaticDelegateManager.Instance().delegateMapping[(int)dEnum] += tDelegate;
        //Debug.Log("StaticDelegateManager-->addDelegate " + delegateMapping[(int)dEnum].GetInvocationList().Length);
    }
    public static void decreaseDelegate(DelegateEnum dEnum, CommonDelegate tDelegate) {
        StaticDelegateManager.Instance().delegateMapping[(int)dEnum] -= tDelegate;
        //Debug.Log("StaticDelegateManager-->decreaseDelegate " + delegateMapping[(int)dEnum].GetInvocationList().Length);
    }

    public static void delegateInvoke(DelegateEnum dEnum, object[] msgData) {
        CommonDelegate delegates = StaticDelegateManager.Instance().delegateMapping[(int)dEnum];
        if (delegates != null) {
            delegates.Invoke(msgData);
        }
    }
}




