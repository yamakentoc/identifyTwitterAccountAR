using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserIcon : MonoBehaviour {
    public User user;
    private Material material;

    void Start() {
        this.material = GetComponent<Renderer>().material;
    }

    public void SetTexture(Texture texture) {
        this.material.mainTexture = texture;
    }
}
