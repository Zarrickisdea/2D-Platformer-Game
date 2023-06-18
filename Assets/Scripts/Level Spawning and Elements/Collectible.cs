using UnityEngine;
public class Collectible : MonoBehaviour
{
    [SerializeField] private GameObject levelEnd;
    void Update()
    {
        transform.Rotate(0, 5f, 0, Space.World);
    }

	void OnTriggerEnter2D(Collider2D other)
    { 
        other.gameObject.GetComponent<PlayerController>().Pickup();
        ActivateEnd();
        Destroy(gameObject);
	}

    private void ActivateEnd()
    {
        if (levelEnd != null)
        {
            Vector3 spawnPosition = Spawner.Instance.getEnding().position;
            spawnPosition.y -= 1f;
            Instantiate(levelEnd, spawnPosition, Quaternion.identity);
        }
    }
}
