using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMode : MonoBehaviour {

    //private CharacterController controller;
    public OMedia oMeidia;
    public ParticleTransformManager cParticle;

    public int Hp = 3;

    private CharacterState status;

    void Awake() {
        //controller = GetComponent<CharacterController>();
        //cMeidia = GetComponent<ObjectMedia>();
        //cParticle = GetComponent<ParticleTransformManager>();
    }

    void OnEnable() {
        status &= ~CharacterState.Crouch;
    }

    void OnDisable() {

    }

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    //void Update() {
    //    //Debug.Log("CharacterMode-->Update");
    //}

    //void FixedUpdate() {
    //    //Debug.Log("CharacterMode-->FixedUpdate");
    //}

    //void LateUpdate() {
    //}    

    public void PickupItem(ItemPickupEnum type,float value) {
        //Debug.Log("CharacterMode-->PickupItem");
        if (ItemPickupEnum.Hp == type) {
            Debug.Log("CharacterMode-->AddHp");
            oMeidia.playAudio(AudioEnum.Pickup);
        }
        else if (ItemPickupEnum.Coin == type) {
            oMeidia.playAudio(AudioEnum.Coin);
            //Debug.Log("CharacterMode-->AddCoins");
            //cParticle.playParticle(ParticleEnum.Jump);
        }
        else if (ItemPickupEnum.Life == type) {
            oMeidia.playAudio(AudioEnum.Life);
            //Debug.Log("CharacterMode-->AddLife");
        }
        else if (ItemPickupEnum.Key == type) {
            oMeidia.playAudio(AudioEnum.Key);
            //Debug.Log("CharacterMode-->AddKey");
        }
    }

    public void Interact(InteractEnum type, float value) {
        //Debug.Log("CharacterMode-->Interact");
        if (InteractEnum.Enemy == type) {
            Debug.Log("CharacterMode-->MinusHp");
            oMeidia.playAudio(AudioEnum.HpDown);
            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Player"),true);
        }
        else if (InteractEnum.Enemy == type) {
            
        }
    }
}






















