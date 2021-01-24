using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    [SerializeField] private Personage player;
    public Personage Player { get => player; }

    [SerializeField] private Personage enemy;
    public Personage Enemy { get => enemy; }

    [SerializeField] private GlobalConfig global;
    public GlobalConfig Global { get => global; }

}
