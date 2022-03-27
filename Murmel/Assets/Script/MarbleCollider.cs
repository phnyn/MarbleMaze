using UnityEngine;

public class MarbleCollider : MonoBehaviour
{   
    private SpawnMarbles spawner;
    private Menu menu;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Respawn").GetComponent<SpawnMarbles>();
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
    }

    //Destroys marble upon collision with a 'hole'
    void OnTriggerEnter(Collider col){
        if(col.tag =="Hole"){
            Debug.Log("Marble collided with Hole");
            Destroy(this.gameObject);
            spawner.spawnMarble();
        }

        if(col.tag == "Goal"){
            Debug.Log("Marble collided with Goal"); 
            menu.winGame(); 
        }
    }
}
