using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_stats : Character_stats
{
	public static GameObject player;
	
	protected override void Awake ()
	{
		base.Awake();
		player = gameObject;
	}
	public override void Die()
	{
		base.Die();

		// Add ragdoll effect / death animation

		//Destroy(gameObject);
	}
}
