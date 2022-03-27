using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnMarbles : MonoBehaviour
{
    /* prefab of a marble */
    [SerializeField]
    private GameObject _marblePrefab; 

    [SerializeField]
    private Image _health;

    private Menu menu;

    /* difficulty */
    private float diff;

    /* counts how many times respawned */
    private int spawnCounter = -1;
    // Start is called before the first frame update
    void Start()
    {  
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
        diff = setDifficulty();
        spawnMarble();
    }

    /* spawns a new marble */
    public void spawnMarble(){
        resetBox();
        // (8,1,6) for quick win
        // (2,1,9) start position
        GameObject marble = Instantiate(_marblePrefab, new Vector3(2, 1, 9), Quaternion.identity);
        marble.GetComponent<Rigidbody>().angularDrag = diff;
        Debug.Log(spawnCounter);
        if(spawnCounter == 4){
            menu.gameover();
        } else {
            spawnCounter ++;
            respawnBar();
        }
    }

    /* resets the rotatation of the box */
    void resetBox(){
        GameObject middle = GameObject.Find("MiddleBox");
        middle.transform.rotation = Quaternion.identity;
        GameObject inner = GameObject.Find("InnerBox");
        inner.transform.rotation = Quaternion.identity;
    }

    /* changes the spawnbar on top signaling how many respawns are left */
    void respawnBar(){
        float max = 5f;
        _health.fillAmount = spawnCounter / max;
    }

    public int getSpawnCounter(){
        return this.spawnCounter;
    }

    /* sets difficulty, how fast the marble halts */
    float setDifficulty(){
        if(StartScreen.diffLevel == 0){
            return 6;
        } else if(StartScreen.diffLevel == 1) {
            return 3;
        } else {
            return 0;
        }

    }
} 
