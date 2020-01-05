using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room_manager : MonoBehaviour
{
    public static Room_manager room_Manager;
    [SerializeField]
    private List<Room> rooms = null;
    [SerializeField]
    private GameObject Player = null;
    public static Room activeRoom;
    public GameObject upgradeShop;
    public string endScene = "EndScene";

    private int ctr = 0;

    public void openDoor(){
        OpenDoor.openDoor();
    }
    public void closeDoor(){
        OpenDoor.closeDoor();
    }
    public void restartRooms(){
        foreach(Room r in rooms){
            r.resetRoom();
            r.gameObject.SetActive(false);
        }

        Player.transform.position = rooms[0].startPos.transform.position;
        Camera.main.transform.position = Camera.main.transform.position + (rooms[0].startPos.transform.position-rooms[ctr].startPos.transform.position);
        rooms[ctr].gameObject.SetActive(false);
        rooms[0].gameObject.SetActive(true);
        activeRoom = rooms[0];
        openDoor();
        upgradeShop.SetActive(true);
        ctr = 0;

            
    }
    public void NextRoom(){
        ctr += 1;
        if(ctr<rooms.Count){
            Drop_system.instance.cleanDrops();
            Player.transform.position = rooms[ctr].startPos.transform.position;
            Camera.main.transform.position = Camera.main.transform.position + (rooms[ctr].startPos.transform.position-rooms[ctr-1].startPos.transform.position);
            rooms[ctr-1].gameObject.SetActive(false);
            rooms[ctr].gameObject.SetActive(true);
            activeRoom = rooms[ctr];
            if(ctr==1){
                upgradeShop.SetActive(false);
                Shop_system.shop.applyUpgrades();
            }
        }
        else{
            SceneManager.LoadScene(endScene);
        }
    }

    void Start()
    {
        room_Manager = this;
        foreach(Room r in rooms){
            r.GetComponentInChildren<LeaveThroghtDoor>().leaveRoom += NextRoom;
            r.RoomSolved += openDoor;
            r.gameObject.SetActive(false);
        }
        rooms[0].gameObject.SetActive(true);
        activeRoom = rooms[0];
        upgradeShop.SetActive(true);
    }
    void Update()
    {
        if(Player_stats.playerStats.enable_keys_for_testing && Input.GetKeyDown(KeyCode.B)){
            Drop_system.instance.cleanDrops();
            int ctr_end = 30;
            Player.transform.position = rooms[ctr_end].startPos.transform.position;
            Camera.main.transform.position = Camera.main.transform.position + (rooms[ctr_end].startPos.transform.position-rooms[ctr].startPos.transform.position);
            rooms[ctr].gameObject.SetActive(false);
            rooms[ctr_end].gameObject.SetActive(true);
            activeRoom = rooms[ctr_end];       
            ctr = ctr_end;     
        }
        if(Player_stats.playerStats.enable_keys_for_testing && Input.GetKeyDown(KeyCode.K)){// ugly to work for spliting enemies removed in the end
            /*List<GameObject> Enemies = new List<GameObject>(activeRoom.Enemies);
            foreach(GameObject e in Enemies){
                e.GetComponent<Enemy_stats>().Die();
            }
            Enemies = new List<GameObject>(activeRoom.Enemies);*/
            for(int i=0;i<activeRoom.Enemies.Count; i++){
                if(activeRoom.Enemies[i].activeSelf){
                    activeRoom.Enemies[i].GetComponent<Enemy_stats>().Die();
                }
            }
            Enemy_stats[] enemies = activeRoom.gameObject.GetComponentsInChildren<Enemy_stats>();
            for(int i=0;i<enemies.Length; i++){
                if(enemies[i].gameObject.activeSelf){
                    enemies[i].GetComponent<Enemy_stats>().Die();
                }
            }
        }
    }
}
