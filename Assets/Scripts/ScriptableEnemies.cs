using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableEnemies", menuName = "Scriptable Objects/ScriptableEnemies")]
public class ScriptableEnemies : ScriptableObject
{
    [SerializeField] private string EnemyName;
    [SerializeField] private float MaxHealth;
    [SerializeField] private float CurrentHealth;
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float AttackSpeed;
    [SerializeField] private float AttackDamage;


    public string GSEnemyName
        { get { return EnemyName; } }
    public float GSMaxHealth
        { get { return MaxHealth; } }
    public float GSCurrentHealth
        { get { return CurrentHealth; } }
    public float GSMovementSpeed
        { get { return MovementSpeed; } }
    public float GSAttackSpeed
        { get { return AttackSpeed; } }
    public float GSAttackDamage
        { get { return AttackDamage; } }
}
