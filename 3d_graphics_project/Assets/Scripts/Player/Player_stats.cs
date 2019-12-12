using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_stats : Character_stats
{
	public static GameObject player;
	public GameObject deathScreen;
	public static Player_stats playerStats;
	public int currency{ get; protected set; } = 0;
	public int experience{ get; protected set; } = 0;
	public int level{ get; protected set; } = 1;
	private int experienceForLevelUp = 100;
	private float grothForLevelUp = 1.1f;
    public event Action LevelUpCallback = delegate{};
	public void ResetPlayer(){
		level = 1;
		experienceForLevelUp = 100;
        playerStats.attack.Reset();
        playerStats.attackSpeed.Reset();
        playerStats.updateAttackSpeed();
        playerStats.healtPoints.Reset();
        playerStats.updateHealth();
        playerStats.movementSpeed.Reset();
        playerStats.updateMovementSpeed();
		reborn();
	}
	public bool SpendCurrency(int amount){
		if(amount>currency){
			return false;
		}
		if(amount>0){
			currency -= amount;
		}
		return true;

	}

	public void GainCurrency(int amount){
		if(amount>0){
			currency += amount;
		}
	}
	public void GainExperience(int amount){
		if(amount>0){
			experience += amount;
			if(experience>experienceForLevelUp){
				experience -= experienceForLevelUp;
				experienceForLevelUp = (int)(experienceForLevelUp* grothForLevelUp);
				level = level + 1;
				//Debug.Log("Level Up need to improove stats "+level);
				LevelUpCallback();
			}
		}
	}

	protected override void Awake ()
	{
		base.Awake();
		player = gameObject;
		playerStats = this;
	}
	public override void Die()
	{	
		deathScreen.SetActive(true);
		base.Die();

		// Add ragdoll effect / death animation

		//Destroy(gameObject);
	}
}
