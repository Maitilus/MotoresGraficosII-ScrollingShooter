using UnityEngine;

public abstract class AbstractEnemies : MonoBehaviour
{
    [SerializeField] protected ScriptableEnemies EnemyData;

    protected string EnemyName;
    protected float CurrentHealth;
    protected float MaxHealth;
    protected float MovementSpeed;
    protected float AttackDamage;
    protected float AttackSpeed;


    protected virtual void Start()
    {  
        //Set ScriptableObject
        EnemyName = EnemyData.GSEnemyName;
        CurrentHealth = EnemyData.GSMaxHealth;
        MaxHealth = EnemyData.GSMaxHealth;
        MovementSpeed = EnemyData.GSMovementSpeed;
        AttackDamage = EnemyData.GSAttackDamage;
        AttackSpeed = EnemyData.GSAttackSpeed;
    }
}
