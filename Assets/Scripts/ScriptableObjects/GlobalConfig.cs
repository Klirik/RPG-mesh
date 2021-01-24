using UnityEngine;

[CreateAssetMenu(fileName = "Personage", menuName = "ScriptableObjects/GlobalConfig", order = 1)]
public class GlobalConfig : ScriptableObject
{
    [Header("Влияние характеристик")]
    public float CharacteristicContribution = 0.5f;
}
