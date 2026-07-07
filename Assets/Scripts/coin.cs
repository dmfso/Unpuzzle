using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.RegisterCoin();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectCoin();
            gameObject.SetActive(false);
        }
    }
}   