using Unity.VisualScripting;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float dropSpeed = -3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, dropSpeed * Time.deltaTime, 0);
        if(transform.position.y < -1 || GameManager.Instance.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
