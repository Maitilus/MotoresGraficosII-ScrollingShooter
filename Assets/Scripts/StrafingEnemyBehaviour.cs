using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;


public class StrafingEnemyBehaviour : AbstractEnemies, IRecieveDamage
{
    private float LeftMaxPosition;
    private float RightMaxPosition;

    private bool NotMoving;
    [SerializeField] private int RNG;
    private bool CanFire;
    [SerializeField] private Transform ProjectileSpawn;
    [SerializeField] private GameObject ProjectilePrefab;
    [SerializeField] private LevelUpManager LevelUp;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(Movement());
        CanFire = true;
        LevelUp = GameObject.Find("LevelUpManager").GetComponent<LevelUpManager>();
    }

    public void GetDamaged(float DamageRecieved)
    {
        CurrentHealth -= DamageRecieved;

        if (CurrentHealth <= 0)
        {
            LevelUp.EnemiesToLevelUp -= 1;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (RNG > 0) { StrafeRight(); }
        else { StrafeLeft(); }

        if (CanFire) { Fire(); }
    }

    #region Movement

    private void StrafeRight()
    {
        rb.linearVelocity = transform.right * MovementSpeed;
    }

    private void StrafeLeft()
    {
        rb.linearVelocity = transform.right * -MovementSpeed;
    }

    private IEnumerator Movement()
    {
        if (transform.position.x > 8) { RNG = 0; }
        else if (transform.position.x < -8) { RNG = 1; }
        else { RNG = UnityEngine.Random.Range(0, 2); }

        yield return new WaitForSeconds(UnityEngine.Random.Range(1, 3));

        StartCoroutine(Movement());
    }

    #endregion

    #region Attacking

    private void Fire()
    {
        CanFire = false;
        Instantiate(ProjectilePrefab, ProjectileSpawn.transform.position, ProjectileSpawn.transform.rotation);
        StartCoroutine(FireRateHandler());
    }

    private IEnumerator FireRateHandler()
    {
        float CD = 1 / AttackSpeed;
        yield return new WaitForSeconds(CD);
        CanFire = true;
    }

    #endregion
}
