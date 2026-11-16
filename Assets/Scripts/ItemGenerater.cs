using Unity.Collections;
using UnityEngine;

public class ItemGenerater : MonoBehaviour
{
    public static ItemGenerater Instance;
    public GameObject applePrefab;
    public GameObject bombPrefab;
    float span = 1;
    int bombRatio = 2;
    float dropSpeed = -3;
    public float delta = 0;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isPlaying == true){
            delta += Time.deltaTime;
            if(delta >= span)
            {
                delta = 0;
                GameObject item;
                int dice = Random.Range(0, 10);
                if(dice < bombRatio)
                {
                    item = Instantiate(bombPrefab);
                }
                else
                {
                    item = Instantiate(applePrefab);
                }
                item.GetComponent<ItemController>().dropSpeed = this.dropSpeed;
                int x = Random.Range(-1, 2);
                int z = Random.Range(-1, 2);
                item.transform.position = new Vector3(3*x, 5, 3*z);
            }
        }
    }

    public void SetParameter(float span, int bombRatio, float dropSpeed)
    {
        this.span = span;
        this.bombRatio = bombRatio;
        this.dropSpeed = dropSpeed;
    }
}
