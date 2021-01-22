using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public AbstractMapGenerator MapGenerator;

    public Vector3 Offset = new Vector3(5,10,0);
    
    private Player person;

    private void Start()
    {
        MapGenerator.OnEndGenerate += FindPlayer;
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
        MapGenerator.OnEndGenerate -= FindPlayer;
    }
}
