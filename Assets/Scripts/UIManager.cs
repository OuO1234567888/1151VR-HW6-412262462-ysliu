using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject chooseLevelUI;
    public GameObject playingUI;
    public Button easyBTN;
    public Button normalBTN;
    public Button hardBTN;
    public TextMeshProUGUI time;
    public TextMeshProUGUI score;
    public TextMeshProUGUI lastScore;
    public TextMeshProUGUI highScore;
    

    
    private void Awake()
    {
        // 確保場景中只有一個實例
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        easyBTN.onClick.AddListener(PressEasyBTN);
        normalBTN.onClick.AddListener(PressNormalBTN);
        hardBTN.onClick.AddListener(PressHardBTN);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPlayingUI()
    {
        playingUI.SetActive(true);
        chooseLevelUI.SetActive(false);
    } 

    public void ShowChooseLevelUI()
    {
        playingUI.SetActive(false);
        chooseLevelUI.SetActive(true);
    }

    public void PressEasyBTN()
    {
        GameManager.Instance.SetEasy();
        GameManager.Instance.StartGame();
    }

    public void PressNormalBTN()
    {
        GameManager.Instance.SetNormal();
        GameManager.Instance.StartGame();
    }

    public void PressHardBTN()
    {
        GameManager.Instance.SetHard();
        GameManager.Instance.StartGame();
    }
}
