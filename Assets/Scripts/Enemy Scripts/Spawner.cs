using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    private static Spawner instance;
    public static Spawner Instance { get { return instance; } }

    private BoundsInt area;
    private Transform[] pointsInScene;
    private Transform ending;
    [SerializeField] private GameObject endPoint;
    [SerializeField] private Tilemap ground;
    [SerializeField] private Tile groundTile;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private GameObject[] patrolPoints;

    private void Awake()
    {
        if (Instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (ground != null)
        {
            area = ground.cellBounds;
        }

        pointsInScene = new Transform[2];

        Spawn();
    }

    private void Spawn()
    {
        List<Vector3Int> availablePositions = new List<Vector3Int>();

        GetSpawnPositions(availablePositions);

        SpawnEnemyPatrolPoints(availablePositions);

        SpawnPrefabs(availablePositions);

        SpawnEndPoistion(availablePositions);
    }

    private void SpawnEndPoistion(List<Vector3Int> availablePositions)
    {
        Vector3Int endPosition = GetDistinctPosition(availablePositions);
        Vector3 endCell = ground.GetCellCenterWorld(endPosition);

        ending = Instantiate(endPoint, endCell, Quaternion.identity).transform;
    }

    private void SpawnPrefabs(List<Vector3Int> availablePositions)
    {
        if (availablePositions.Count >= prefabs.Length)
        {
            for (int i = 0; i < prefabs.Length; i++)
            {
                Vector3Int randomPosition = GetDistinctPosition(availablePositions);
                Vector3 cellPosition = ground.GetCellCenterWorld(randomPosition);
                GameObject spawnedObject = Instantiate(prefabs[i], cellPosition, Quaternion.identity);
            }
        }
    }

    private void SpawnEnemyPatrolPoints(List<Vector3Int> availablePositions)
    {
        Vector3Int pos1 = availablePositions[0];
        Vector3Int pos2 = availablePositions[availablePositions.Count - 1];

        Vector3 patrolCell1 = ground.GetCellCenterWorld(pos1);
        Vector3 patrolCell2 = ground.GetCellCenterWorld(pos2);

        pointsInScene[0] = Instantiate(patrolPoints[0], patrolCell1, Quaternion.identity).transform;
        pointsInScene[1] = Instantiate(patrolPoints[1], patrolCell2, Quaternion.identity).transform;
    }

    private void GetSpawnPositions(List<Vector3Int> availablePositions)
    {
        foreach (Vector3Int position in area.allPositionsWithin)
        {
            if (ground.GetTile(position) == groundTile)
            {
                Vector3Int offsetPosition = new Vector3Int(position.x, position.y + 1, position.z);
                availablePositions.Add(offsetPosition);
            }
        }
    }

    private Vector3Int GetDistinctPosition(List<Vector3Int> positions)
    {
        int randomIndex = Random.Range(0, positions.Count);
        Vector3Int randomPosition = positions[randomIndex];
        positions.RemoveAt(randomIndex);
        return randomPosition;       
    }

    public Transform[] getPatrolPoints()
    {
        return pointsInScene;
    }

    public Transform getEnding()
    {
        return ending;
    }

    public void Burn()
    {
        Destroy(gameObject);
    }
}
