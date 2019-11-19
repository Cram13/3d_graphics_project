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
	public Status_effects status_effects;
	public event Action OnDeath = delegate{};

	public event Action<float, float> onHealthChanged = delegate{};
	//public float maxHealth = 100;
	public float currentHealth { get; protected set; }

	protected bool _attackReady = false;
	public bool attackReady { get{if(_attackReady){attackTimer = 0.0f; _attackReady=false; return true;} return false;}}
	protected float attackTimer = 0, attackReadyValue;

    	// Set current health to max health
	// when starting the game.
	virtual protected void Awake ()
	{
		currentHealth = healtPoints.GetValue();
		status_effects = gameObject.GetComponentInChildren<Status_effects>();
	}
	
	void Start (){
		attackReadyValue = 1/attackSpeed.GetValue();
	}
	public void reborn(){
		currentHealth = healtPoints.GetValue();
		updateHealth();
	}
	void Update(){
		if(!_attackReady)
			attackTimer += Time.deltaTime;
			if(attackTimer>attackReadyValue){
				_attackReady = true;
			}

	}
	
	public void updateHealth(){
			onHealthChanged(currentHealth, healtPoints.GetValue());
	}
	public void updateAttackSpeed(){
		attackReadyValue = 1/attackSpeed.GetValue();
	}
	public void updateMovementSpeed(){
		;
	}


	// Damage the character
	public void TakeDamage (float damage)
	{
		// Damage the character
		if(damage>0){
			currentHealth -= damage;
			onHealthChanged(currentHealth, healtPoints.GetValue());
			//Debug.Log(transform.name + " takes " + damage + " damage.");
		}
		// If health reaches zero
		if (currentHealth <= 0)
		{
			Die();
		}
	}
	public void GainHealth(int amount){
		if(amount>0){
			currentHealth += amount;
			if(currentHealth>healtPoints.GetValue()){
				currentHealth = healtPoints.GetValue();
			}
			onHealthChanged(currentHealth, healtPoints.GetValue());
		}

	}

	public virtual void Die ()
	{
		OnDeath();
		// Die in some way
		// This method is meant to be overwritten
		//Debug.Log(transform.name + " died.");
	}
}
