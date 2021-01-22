using UnityEngine;

public class SimplerMapGenerator : AbstractMapGenerator
{
    protected override void CreateMapBoard()
    {
        for (int x = 0; x < Width; x++)
        {
            map[x, 0] = MapElements.EdgeElement;
            map[x, Height-1] = MapElements.EdgeElement;
        }
        for (int z = 0; z < Height; z++)
        {
            map[0, z] = MapElements.EdgeElement;
            map[Width-1, z] = MapElements.EdgeElement;
        }
    }

    protected override void FillInnerMap()
    {
        for (int x = edgeOffset; x <= Width - edgeOffset; x++)
        {
            for (int z = edgeOffset; z <= Height - edgeOffset; z++)
            {
                if (Random.value < RandomFactor)
                {
                    map[x, z] = MapElements.EdgeElement;
                }
                else if (!playerSpawned)
                {
                    map[x, z] = MapElements.PlayerSpawner;
                    playerSpawned = true;
                }
                else if ((Random.value < RandomFactor) && (CountEnemySpawner > 0))
                {
                    map[x, z] = MapElements.EnemySpawner;
                    CountEnemySpawner--;
                }
            }
        }
    }

    protected override void AddRampant()
    {
    }

    public override void ShowMap()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int z = 0; z < Height; z++)
            {
                Vector3 position = CalcPositionElement(x, z);

                if (converter.ContainsKey(map[x, z]))
                {
                    converter[map[x, z]].Invoke(position);
                }
            }
        }
    }
}
