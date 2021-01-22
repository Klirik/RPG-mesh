using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using Random = UnityEngine.Random;
public enum MapElements
{
    EmptyPlace,
    Wall,
    Rampant,

    EnemySpawner,
    PlayerSpawner,

    EdgeElement
}

public abstract class AbstractMapGenerator : MonoBehaviour
{
    public event Action OnEndGenerate = delegate { };

    protected MapElements[,] map;

    public NavMeshSurface NavMeshSurface;

    public float HeightWall = 0.5f;
    public float HeightPlayer = 1.3f;

    [Header("Элементы карты")]
    public GameObject WallPrefab;
    public GameObject RampantPrefab;
    
    public GameObject PlayerSpawner;
    public GameObject EnemySpawner;

    public int CountEnemySpawner = 4;

    [Header("Размеры карты")]
    public int Width = 10;
    public int Height = 10;
    
    [Range(0, 1)]
    public float RandomFactor = 0.7f;

    protected bool playerSpawned = false;
    
    protected int edgeOffset = 2;

    protected Dictionary<MapElements, Action<Vector3>> converter;

    protected void Awake()
    {
        converter = new Dictionary<MapElements, Action<Vector3>>
        {
            { MapElements.PlayerSpawner, (pos) => { Instantiate(PlayerSpawner, pos, Quaternion.identity, transform); } },
            { MapElements.EnemySpawner, (pos) => { Instantiate(EnemySpawner, pos, Quaternion.identity, transform); } },

            { MapElements.Rampant, (pos) => { Instantiate(RampantPrefab, pos, Quaternion.identity, transform); } },

            { MapElements.Wall, (pos) => { Instantiate(WallPrefab, pos, Quaternion.identity, transform); } },
            { MapElements.EdgeElement, (pos) => { Instantiate(WallPrefab, pos, Quaternion.identity, transform); } },
        };
    }

    protected void Start()
    {
        GenerateLevel();
        NavMeshSurface.BuildNavMesh();
    }

    protected Vector3 CalcPositionElement(int x, int z)
    {
        return new Vector3(x - Width / 2f, HeightWall, z - Height / 2f);
    }

    [ContextMenu("Generate")]
    public void GenerateLevel()
    {
        map = new MapElements[Width, Height];

        CreateMapBoard();
        FillInnerMap();
        AddRampant();

        ShowMap();

        OnEndGenerate?.Invoke();
    }

    protected abstract void CreateMapBoard();
    protected abstract void FillInnerMap();    
    protected abstract void AddRampant();
    public abstract void ShowMap();
}


