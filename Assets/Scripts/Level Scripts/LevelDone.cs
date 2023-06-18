using UnityEngine;

public class LevelDone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            LevelManager.Instance.LevelComplete();
        }
    }
}
