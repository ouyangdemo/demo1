using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererMapping : MonoBehaviour {

    public EnumRenderer[] enumRenderer = new EnumRenderer[SceneMode.rendererSize];
    private Dictionary<RendererEnum, EnumRenderer> enumRendererMapping;

    void Awake() {
        enumRendererMapping = new Dictionary<RendererEnum, EnumRenderer>();
    }

    void OnEnable() {
        int len = enumRenderer.Length;
        for (int i = 0; i < len; i++) {
            enumRendererMapping.Add(enumRenderer[i].rEnum, enumRenderer[i]);
        }
    }

    void OnDisable() {
        enumRendererMapping.Clear();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public EnumRenderer getRendererByEnum(RendererEnum rEnum) {
        if (!enumRendererMapping.ContainsKey(rEnum)) {
            return null;
        }
        return enumRendererMapping[rEnum];
    }
}
