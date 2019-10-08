using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Character_stats : MonoBehaviour
{
    public Stat attack;
    public Stat healtPoints;
    public Stat attackSpeed;
    public Stat movementSpeed;

	public event Action<float, float> onHealthChanged = delegate{};
	public float maxHealth = 100;
	public float currentHealth { get; private set; }

	private bool _attackReady = true;
	public bool attackReady { get{if(_attackReady){attackTimer = 0.0f; _attackReady=false; return true;} return false;}}
	private float attackTimer = 0, attackReadyValue;

    	// Set current health to max health
	// when starting the game.
	virtual protected void Awake ()
	{
		currentHealth = maxHealth;
	}
	
	void Start (){
		attackReadyValue = 1/attackSpeed.GetValue();
	}

	void Update(){
		if(!_attackReady)
			attackTimer += Time.deltaTime;
			//Debug.Log(attackTimer+ " "+attackReadyValue);
			if(attackTimer>attackReadyValue){
				_attackReady = true;
			}

	}


	// Damage the character
	public void TakeDamage (float damage)
	{
		// Damage the character
		currentHealth -= damage;
		onHealthChanged(currentHealth, maxHealth);
		//Debug.Log(transform.name + " takes " + damage + " damage.");

		// If health reaches zero
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	public virtual void Die ()
	{
		// Die in some way
		// This method is meant to be overwritten
		Debug.Log(transform.name + " died.");
	}
}
