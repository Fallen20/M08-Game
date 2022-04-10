using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScript : MonoBehaviour
{

	private SpriteRenderer sprite;
	public float speed=0.5f;
	private float offset=0f;

    void Start(){
         sprite=GetComponent<SpriteRenderer>();//pillas el sprite
    }

    void Update(){
        offset+=Time.deltaTime*speed;
        sprite.material.mainTextureOffset=new Vector2(offset, 0);
    }
}
