using NUnit.Framework;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public const float TOTAL_TIME = 30;
    public float remainingTime = 30;
    public int score = 0;
    public int highScore = 0;
    public bool isPlaying = false;
    AudioSource audioSource;
    public AudioClip getAppleSE;
    public AudioClip getBombSE;

    
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
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameOver();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying == true)
        {
            remainingTime -= Time.deltaTime;
            UIManager.Instance.time.text = remainingTime.ToString("f1") + "s";

            if(remainingTime <= 0)
            {
                GameOver();
            }
        }
    }

    public void GetApple()
    {
        score += 100;
        UIManager.Instance.score.text = "Score:" + score;
        audioSource.PlayOneShot(getAppleSE);
    }

    public void GetBomb()
    {
        score -= 200;
        if(score < 0)
        {
            score = 0;
        }
        UIManager.Instance.score.text = "Score:" + score;
        audioSource.PlayOneShot(getBombSE);
    }

    public void StartGame()
    {
        Reset();
        isPlaying = true;
        UIManager.Instance.ShowPlayingUI();
    }

    public void GameOver()
    {
        isPlaying = false;
        UIManager.Instance.lastScore.text = "Last Score:" + score;
        if(score > highScore)
        {
            highScore = score;
            UIManager.Instance.highScore.text = "Highest Score:" + score;
        }
        UIManager.Instance.ShowChooseLevelUI();
    }

    public void Reset()
    {
        ItemGenerater.Instance.delta = 0;
        score = 0;
        remainingTime = TOTAL_TIME;
    }

    public void SetEasy()
    {
        ItemGenerater.Instance.SetParameter(1.5f, 3, -3);
    }

    public void SetNormal()
    {
        ItemGenerater.Instance.SetParameter(1f, 4, -5);
    }

    public void SetHard()
    {
        ItemGenerater.Instance.SetParameter(0.5f, 5, -7);
        
    }
}
