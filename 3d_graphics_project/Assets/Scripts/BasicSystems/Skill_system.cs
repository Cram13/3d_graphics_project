using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;


enum Skills
{
    ProjectileFront, ProjectileDiagonal, ProjectileBack,
    SpecialSplashDamage, SpecialBigProjectiles,
    EffectPoison, EffectFire, EffectIce,
    StatAttack, StatAttackSpeed, StatHP, StatMovementspeed
}

public class Skill_system : MonoBehaviour
{
    public static Skill_system skill_system = null;
    public float incStatHP = 10;
    public float incStatAttack = 10;
    public float incStatAttackSpeed = 10;
    public float incStatMovementspeed = 10;

    private List<Skills> skills_remaining;
    private Player_stats player_stats;
    private Player_attack player_attack;
    public GameObject skill_select_canvas;
    private List<Button> buttons;

    void SelectSkill(){
        // setup ui change names, later images and callbacks
        //delegate void MyDelegateType();
        var random = new System.Random();
        foreach (Button button in buttons){
            Skills cur_skill = skills_remaining[random.Next(skills_remaining.Count)];
            button.GetComponentInChildren<Text>().text = ""+cur_skill;
            button.onClick = new Button.ButtonClickedEvent();
            button.onClick.AddListener(delegate{activateSkill(cur_skill);});
        }
        skill_select_canvas.SetActive(true);
    }
    void activateSkill(Skills skill){
        skill_select_canvas.SetActive(false);
        switch(skill){
            case Skills.ProjectileFront:
                player_attack.shootDoubleFront = true;
                skills_remaining.Remove(Skills.ProjectileFront);
                break;
            case Skills.ProjectileDiagonal:
                player_attack.shootDiagonal = true;
                skills_remaining.Remove(Skills.ProjectileDiagonal);
                break;
            case Skills.ProjectileBack:
                player_attack.shootBack = true;
                skills_remaining.Remove(Skills.ProjectileBack);
                break;
            case Skills.SpecialSplashDamage:
                player_attack.splashDamage = true;
                skills_remaining.Remove(Skills.SpecialSplashDamage);
                break;
            case Skills.SpecialBigProjectiles:
                player_attack.bigBullet = true;
                skills_remaining.Remove(Skills.SpecialBigProjectiles);
                break;
            case Skills.EffectPoison:
                skills_remaining.Remove(Skills.EffectPoison);
                player_attack.statusEffekt[(int)Status_effects.EffectName.Poison] = true;
                player_attack.effectDamage[(int)Status_effects.EffectName.Poison] = player_stats.attack.GetValue();
                break;
            case Skills.EffectFire:
                player_attack.statusEffekt[(int)Status_effects.EffectName.Fire] = true;
                player_attack.effectDamage[(int)Status_effects.EffectName.Fire] = player_stats.attack.GetValue();
                skills_remaining.Remove(Skills.EffectFire);
                break;
            case Skills.EffectIce:
                player_attack.statusEffekt[(int)Status_effects.EffectName.Ice] = true;
                player_attack.effectDamage[(int)Status_effects.EffectName.Ice] = 0;
                skills_remaining.Remove(Skills.EffectIce);
                break;
            case Skills.StatAttack:
                player_stats.attack.AddModifier(incStatAttack);
                break;
            case Skills.StatAttackSpeed:
                player_stats.attackSpeed.AddModifier(incStatAttackSpeed);
                player_stats.updateAttackSpeed();
                break;
            case Skills.StatHP:
                player_stats.healtPoints.AddModifier(incStatHP);
                player_stats.updateHealth();
                player_stats.GainHealth((int)incStatHP);
                break;
            case Skills.StatMovementspeed:
                player_stats.movementSpeed.AddModifier(incStatMovementspeed);
                player_stats.updateMovementSpeed();
                break;
            default:
                Debug.Log("skill not found: " + skill);
                break;
        }
    }
    void Awake ()
	{
        if(skill_system == null){
            skill_system = this;
        }
        else{
            Debug.Log("multiple skills systems");
        }
    }
    public void resetSkills(){
        // enable all skills to be chosen next time
        skills_remaining = Enum.GetValues(typeof(Skills)).Cast<Skills>().ToList();

        player_attack.shootDoubleFront = false;
        player_attack.shootDiagonal = false;
        player_attack.shootBack = false;
        player_attack.splashDamage = false;
        player_attack.bigBullet = false;
        player_attack.statusEffekt[(int)Status_effects.EffectName.Poison] = false;
        player_attack.effectDamage[(int)Status_effects.EffectName.Poison] = 0;
        player_attack.statusEffekt[(int)Status_effects.EffectName.Fire] = false;
        player_attack.effectDamage[(int)Status_effects.EffectName.Fire] = 0;
        player_attack.statusEffekt[(int)Status_effects.EffectName.Ice] = false;
        player_attack.effectDamage[(int)Status_effects.EffectName.Ice] = 0;
        player_stats.attack.Reset();
        player_stats.attackSpeed.Reset();
        player_stats.updateAttackSpeed();
        player_stats.healtPoints.Reset();
        player_stats.updateHealth();
        player_stats.movementSpeed.Reset();
        player_stats.updateMovementSpeed();

    }
    void Start()
    {
        skills_remaining = Enum.GetValues(typeof(Skills)).Cast<Skills>().ToList();
        player_attack = gameObject.GetComponent<Player_attack>();
        player_stats = gameObject.GetComponent<Player_stats>();
        player_stats.LevelUpCallback += SelectSkill;
        buttons = skill_select_canvas.GetComponentsInChildren<Button>().ToList();
        skill_select_canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
