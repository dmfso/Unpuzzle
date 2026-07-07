using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.Instance.Die(gameObject);
        }
        else if (other.CompareTag("Finish"))
        {
            GameManager.Instance.CheckFinish();
        }
        else if (other.CompareTag("Checkpoint"))
        {
            GameManager.Instance.SetCheckpoint(other.transform.position);
        }
    }
}