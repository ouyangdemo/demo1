using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBump : MonoBehaviour {

    public RendererEnum currentType;
    public RendererEnum nextType;
    public ItemPickupEnum hidePickup;
    public int amount =1;

    public SpriteRenderer sRenderer;
    public OMedia oMeidia;
    public InstantiationTransformManager iManager;
    public PickupRise pRise;

    private bool animating = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        EnumRenderer currentRendererSprite = SceneMode.instance.getRendererByEnum(currentType);

        if (!ReferenceEquals(currentRendererSprite, null) && !animating) {
            sRenderer.sprite = currentRendererSprite.rSprite;
        }
    }

    void OnCollisionEnter(Collision collision) {
        ContactPoint contact = collision.contacts[0];
        //Debug.Log("ObjectAutoMove-->OnCollisionEnter" + contact.normal);
        //Debug.DrawRay(contact.point, contact.normal, Color.red, 500);
        if (collision.collider.tag == TagEnum.Head.ToString()) {
            if (!ReferenceEquals(collision.collider.transform.parent, null) && collision.collider.transform.parent.tag == TagEnum.Player.ToString()) {
                if (contact.normal.y > 0) {
                    if (currentType == RendererEnum.Solid) {
                        oMeidia.playAudio(AudioEnum.Bump);
                    }
                    else if (currentType == RendererEnum.Breakable) {
                        oMeidia.playAudio(AudioEnum.BlockBreak);

                    }
                    else if (currentType == RendererEnum.Bounce) {
                        oMeidia.playAudio(AudioEnum.Bump);
                        oMeidia.playAnimation(AnimationEnum.Bumped, true);
                        if (amount <= 1) {
                            currentType = nextType;
                        }
                        else {
                            amount--;
                        }
                    }
                    else if (currentType == RendererEnum.Question) {
                        Transform transform = iManager.instantiate(InstantiationEnum.Hp);
                        pRise.setTarget(transform);
                        pRise.defaultAutoMove();
                        oMeidia.playAudio(AudioEnum.Bump);
                        oMeidia.playAnimation(AnimationEnum.Bumped, true);
                        currentType = nextType;
                    }
                }
            }
        }
    }
 
    void bumpedAnimationStart() {
        animating = true;
        //Debug.Log("BlockBump-->bumpedAnimationStart " + animating);
    }

    void bumpedAnimationComplete() {
        oMeidia.playAnimation(AnimationEnum.Bumped, false);
        animating = false;
        //Debug.Log("BlockBump-->bumpedAnimationComplete " + animating);
    }
}
