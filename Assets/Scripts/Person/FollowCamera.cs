using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public AbstractMapGenerator MapGenerator;

    public Vector3 Offset = new Vector3(5,10,0);
    
    private Player person;

    private PlayerSpawner playerSpawner;
    private void Start()
    {
        if (MapGenerator) MapGenerator.OnEndGenerate += FindSpawner;
    }

    private void FindSpawner()
    {
        playerSpawner = FindObjectOfType<PlayerSpawner>();

        if (playerSpawner) playerSpawner.OnSpawn += FindPlayer;
    }

    private void FindPlayer()
    {
        person = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (person)
        {
            transform.position = person.transform.position + Offset;
        }
    }

    private void OnDestroy()
    {
        if (MapGenerator) MapGenerator.OnEndGenerate -= FindSpawner;
        if (playerSpawner) playerSpawner.OnSpawn -= FindPlayer;
    }
}
