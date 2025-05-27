using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    [SerializeField] private PlayerController Player;
    [SerializeField] private GameObject Projectile;

    [SerializeField] private int StartingEnemiesToLevelUp;
    [SerializeField] public int EnemiesToLevelUp;

    void Update()
    {
        if (EnemiesToLevelUp <= 0) { LevelUp(); }
    }

    private void LevelUp()
    {
        //Increase and reset "XP"
        StartingEnemiesToLevelUp++;
        EnemiesToLevelUp = StartingEnemiesToLevelUp;

        //Heal Player
        Player.CurrentHealth = Player.GMaxHealth;

        //Increase Firerate, Damage and Projectile Speed
        Player.RPS += 0.5f;
        Projectile.GetComponent<ProjectileBehaviour>().Speed += 100;
        Projectile.GetComponent<ProjectileBehaviour>().Damage += 1;
    }
}
