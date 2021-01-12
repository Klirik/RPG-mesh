using UnityEngine;
using UnityEngine.AI;

public class MapGenerator : MonoBehaviour
{
    public NavMeshSurface navMeshSurface;

    public float heightWall = 0.5f;
    public float heightPlayer = 1.3f;

    public GameObject wallPrefab;
    public GameObject playerPrefab;

    //размер ground
    public int width = 10;
    public int height = 10;

    [Range(0,1)]
    public float randomFactor = 0.7f;

    private bool playerSpawned = false;

    private void Start()
    {
        GenerateLevel();
        navMeshSurface.BuildNavMesh();
    }

    [ContextMenu("Generate")]
    public void GenerateLevel()
    {
        for(int x = 0; x <= width; x += 1)
        {
            for (int z = 0; z <= height; z += 1)
            {
                if (Random.value < randomFactor)
                {
                    Vector3 position = new Vector3(x - width/2f, heightWall, z - height/2f);
                    Instantiate(wallPrefab, position, Quaternion.identity, transform);
                }
                else if (!playerSpawned)
                {
                    Vector3 position = new Vector3(x - width / 2f, heightPlayer, z - height / 2f);
                    Instantiate(playerPrefab, position, Quaternion.identity);
                    playerSpawned = true;
                }
            }
        }
    }
}
