using System.Runtime.CompilerServices;
using UnityEngine;

public class StrafingEnemyBehaviour : MonoBehaviour, IRecieveDamage
{
    [SerializeField] private ScriptableEnemies EnemyData;

    private string EnemyName;
    private float CurrentHealth;
    private float MaxHealth;
    private float MovementSpeed;
    private float AttackDamage;
    private float AttackSpeed;


    private void Start()
    {
        EnemyName = EnemyData.GSEnemyName;
        CurrentHealth = EnemyData.GSMaxHealth;
        MaxHealth = EnemyData.GSMaxHealth;
        MovementSpeed = EnemyData.GSMovementSpeed;
        AttackDamage = EnemyData.GSAttackDamage;
        AttackSpeed = EnemyData.GSAttackSpeed;
    }

    public void GetDamaged(float DamageRecieved)
    {
        CurrentHealth -= DamageRecieved;

        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
