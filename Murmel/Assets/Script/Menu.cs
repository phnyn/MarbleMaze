using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    /* screens */
    [SerializeField]
    private GameObject _pause, _gameover, _ui, _win;

    [SerializeField]
    private Text _winStats;

    /* game is paused */
    bool paused;

    /* game is lost */
    bool lost;

    /* won game */
    bool won;

    [SerializeField]
    private Button _restart, _return;

    private SpawnMarbles spawner;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        lost = false;
        won = false;
        paused = false;
        _ui.SetActive(true);
        _pause.SetActive(false);
        _gameover.SetActive(false);
        _win.SetActive(false);

        _restart.onClick.AddListener(restartLevel);
        _return.onClick.AddListener(returnToStartMenu);

        spawner = GameObject.FindGameObjectWithTag("Respawn").GetComponent<SpawnMarbles>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            if(paused == false){
                _ui.SetActive(false);
                pause();
            } else {
                _ui.SetActive(true);
                unpause();
            }
        }
        
        if(lost == true | won == true){
            if(Input.GetKey(KeyCode.Space)){
                returnToStartMenu();
            }
        }
    }

    /* game is paused and the pause menu pops up */
    void pause(){
        Debug.Log("paused");
        paused = true;
        _pause.SetActive(true);
        Time.timeScale = 0;
    }

    /* game is unpaused and the pause menu disappears */
    void unpause(){
        paused = false;
        Debug.Log("unpaused");
        _pause.SetActive(false);
        Time.timeScale = 1;
    }

    /* current Scene gets restarted */
    void restartLevel(){
        Debug.Log("Restart Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /* returns to start menu */
    void returnToStartMenu(){
        Debug.Log("Back to Start Menu");
        SceneManager.LoadScene(0);
    }

    public void gameover(){
        lost = true;
        Debug.Log("gameover");
        Time.timeScale = 0;
        _ui.SetActive(false);
        _gameover.SetActive(true);
    }
    
    public void winGame(){
        won = true;
        Debug.Log("won");
        int spawns = spawner.getSpawnCounter();
        _winStats.text = "You won with " + spawns + " Respawn(s)!";
        Time.timeScale = 0;
        _ui.SetActive(false);
        _win.SetActive(true);
    }
}
