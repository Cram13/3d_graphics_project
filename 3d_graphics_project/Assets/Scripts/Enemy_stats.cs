using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_stats : Character_stats {
	private Drop_client drop_Client;
	protected override void Awake ()
	{
		base.Awake();
		drop_Client = GetComponentInChildren<Drop_client>();
	}
	public override void Die()
	{
		base.Die();
		drop_Client.DropStuff();
		// Add ragdoll effect / death animation

		Destroy(gameObject);
	}
}
