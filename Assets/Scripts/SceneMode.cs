using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SceneMode : MonoBehaviour {

    public static SceneMode instance;

    public const int rendererSize = 4;
    public const int audioSize = 13;
    public const int particleSize = 1;
    public const int instantiationSize = 9;

    public PlayerInput playerController;
    public CameraManager cameraManager;
    public OMedia oMedia;

    public RendererMapping rendererMapping;
    public AudioMapping audioMapping;
    public ParticleMapping particleMapping;
    public InstantiationMapping instantiationMapping;

    public PlayerData playerData;
    public Transform spawnTransform;

    private Transform cPlayer;

    void Awake() {
        //Debug.Log("SceneMode-->Awake " + GameInstance.Instance());
        instance = this;
    }

    // Use this for initialization
    void Start () {
        reSpawnPlayerAt(spawnTransform,playerData.typeEnum);
        playBGM(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public EnumRenderer getRendererByEnum(RendererEnum rEnum) {
        return rendererMapping.getRendererByEnum(rEnum);
    }

    public EnumAudioClip getAudioByEnum(AudioEnum aEnum) {
        //Debug.Log("SceneMode-->getAudioByEnum " + audioMapping.getAudioByEnum(aEnum));
        return audioMapping.getAudioByEnum(aEnum);
    }
    
    public EnumParticle getParticleByEnum(ParticleEnum pEnum) {
        return particleMapping.getAudioByEnum(pEnum);
    }

    public EnumInstantiation getInstantiationByEnum(InstantiationEnum iEnum) {
        return instantiationMapping.getInstantiationByEnum(iEnum);
    }

    public void setSpawnPoint(Transform sTransform) {
        spawnTransform = sTransform;
    }

    public void playerDie() {
        Destroy(cPlayer.gameObject);
        if (playerData.life > 0) {
            playerData.life -= 1;
            reSpawnPlayerAt(spawnTransform, playerData.typeEnum);
        }
        else {
            Debug.Log("GameOver");
            reSpawnPlayerAt(spawnTransform, playerData.typeEnum);
        }
    }

    void reSpawnPlayerAt(Transform sTransform,InstantiationEnum type) {
        EnumInstantiation instantiationObject = SceneMode.instance.getInstantiationByEnum(type);
        Transform instantiation = instantiationObject.iTransform;

        cPlayer = Instantiate(instantiation, sTransform.position, sTransform.rotation);
        
        cameraManager.target = cPlayer;
        playerController.setTarget(cPlayer);
    }

    public void playBGM(bool play) {
        oMedia.playAudio(AudioEnum.BMG,play,true);
    }
}
