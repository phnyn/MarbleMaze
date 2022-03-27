using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField]
    private Button _startBtn;
    [SerializeField]
    private Slider _difficulty;

    public static float diffLevel;

    // Start is called before the first frame update
    void Start()
    {
        _startBtn.onClick.AddListener(start);
    }

    // Update is called once per frame
    void Update()
    {
        diffLevel = _difficulty.value;
        Debug.Log(diffLevel);
    }

    void start(){
        SceneManager.LoadScene(1);
    }
}
