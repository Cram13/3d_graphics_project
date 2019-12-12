using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Shop_system : MonoBehaviour
{
    public enum ShopUpgrades
    {
        attack, attackSpeed, healtPoints, movementSpeed
    }
    public static Shop_system shop=null;
    public List<TextMeshProUGUI> buttonTexts = new List<TextMeshProUGUI>(4);
    public TextMeshProUGUI currentCoins = null;
    public int[] upgradeLevel = {1,1,1,1};
    public string[] buttonBaseText = {"attack: ", "attackSpeed: ", "healtPoints: ", "movementSpeed: "};
    
    public float[] upgradePerLevel = {1,1,1,1};
    public int[] price = {100,100,100,100};

    public void upgrade(ShopUpgrades shopUpgrades){
        if(price[(int)shopUpgrades]<Player_stats.playerStats.currency){
            bool succes = Player_stats.playerStats.SpendCurrency(price[(int)shopUpgrades]);
            if(succes){
                upgradeLevel[(int)shopUpgrades] +=1;
                buttonTexts[(int)shopUpgrades].text = "Price: "+price[(int)shopUpgrades]+"\nLevel: "+upgradeLevel[(int)shopUpgrades];
                price[(int)shopUpgrades] = (int)(price[(int)shopUpgrades]*1.5f);
                updateCurrentCoins();
            }
        }
    }
    public void OnEnable(){
        updateCurrentCoins();
        for(int i=0;i<4;i++){
            buttonTexts[i].text = "Price: "+price[i]+"\nLevel: "+upgradeLevel[i];
        }
    }
    public void updateCurrentCoins(){
        if(Player_stats.playerStats!=null){
            currentCoins.text = "Current Coins: " + Player_stats.playerStats.currency;
        }
    }
    public void upgradeAttack(){
        upgrade(ShopUpgrades.attack);
    }
    public void upgradeAttackSpeed(){
        upgrade(ShopUpgrades.attackSpeed);
        Player_stats.playerStats.updateAttackSpeed();
    }
    public void upgradeHealtPoints(){
        upgrade(ShopUpgrades.healtPoints);
        Player_stats.playerStats.updateHealth();
    }
    public void upgradeMovementSpeed(){
        upgrade(ShopUpgrades.movementSpeed);
        Player_stats.playerStats.updateMovementSpeed();
    }
    public void applyUpgrades(){
        for(int i=1; i<upgradeLevel[(int)ShopUpgrades.attack];i++){
            Player_stats.playerStats.attack.AddModifier(upgradePerLevel[(int)ShopUpgrades.attack]);
        }
        for(int i=1; i<upgradeLevel[(int)ShopUpgrades.attackSpeed];i++){
            Player_stats.playerStats.attackSpeed.AddModifier(upgradePerLevel[(int)ShopUpgrades.attackSpeed]);
        }
        Player_stats.playerStats.updateAttackSpeed();
        for(int i=1; i<upgradeLevel[(int)ShopUpgrades.healtPoints];i++){
            Player_stats.playerStats.healtPoints.AddModifier(upgradePerLevel[(int)ShopUpgrades.healtPoints]);
            Player_stats.playerStats.GainHealth((int)upgradePerLevel[(int)ShopUpgrades.healtPoints]);
        }
        Player_stats.playerStats.updateHealth();
        for(int i=1; i<upgradeLevel[(int)ShopUpgrades.movementSpeed];i++){
            Player_stats.playerStats.movementSpeed.AddModifier(upgradePerLevel[(int)ShopUpgrades.movementSpeed]);
        }
        Player_stats.playerStats.updateMovementSpeed();
    }
    void Awake (){
        if(shop == null){
            shop = this;
        }
        else{
            Debug.Log("multiple shop systems");
        }
    }
        void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)){
            Player_stats.playerStats.GainCurrency(1000);
        }
    }
}
