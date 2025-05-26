using System.Runtime.CompilerServices;
using UnityEngine;

public class StrafingEnemyBehaviour : AbstractEnemies, IRecieveDamage
{
    protected override void Start()
    {
        base.Start();
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
