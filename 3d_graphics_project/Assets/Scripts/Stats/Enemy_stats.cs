using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy_stats : Character_stats {
	private Drop_client drop_Client;
	private Room room;
	private Vector3 startPos;
	private Quaternion startRot;
	private Vector3 startScale;
	
    //public event Action doAttack = delegate{};
	protected override void Awake ()
	{
		base.Awake();
		drop_Client = GetComponentInChildren<Drop_client>();
		room = gameObject.GetComponentInParent<Room>();
		room.addEnemie(gameObject);
		startPos = transform.position;
		startRot = transform.rotation;
		startScale = transform.localScale;
	}
	/*void Update(){
		if(attackReady){
			doAttack();
		}

	}*/
	void OnDisable(){
		transform.rotation = startRot;
		transform.position = startPos;
		transform.localScale = startScale;
		if(!attackReady){
			attackTimer = 0.0f;
		}
		status_effects.removeAllEffekts();
	}
	public override void Die()
	{
		base.Die();
		drop_Client.DropStuff();
		room.removeEnemie(gameObject);
		// Add ragdoll effect / death animation
		gameObject.SetActive(false);
		//Destroy(gameObject);
	}
}
