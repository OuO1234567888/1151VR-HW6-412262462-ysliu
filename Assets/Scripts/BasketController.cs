using UnityEngine;

public class BasketController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.isPlaying == true)
        {
            // 從攝影機發射一條射線到滑鼠點擊的位置
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 執行射線檢測（maxDistance 可以限制射線距離，layerMask 可以過濾圖層）
            if (Physics.Raycast(ray, out hit))
            {
                // 籃子位置等於被點到的物件的位置 y歸0讓點到蘋果或炸彈也能在正常的位置
                Vector3 pos = hit.transform.position;
                pos.y = 0;
                gameObject.transform.position = pos;
                
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            GameManager.Instance.GetApple();
        }
        else if (other.CompareTag("Bomb"))
        {
            GameManager.Instance.GetBomb();
        }
    }

}
