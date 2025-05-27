using System.Data.Common;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyProjectileBehaviour : MonoBehaviour
{
    #region Variables

    [SerializeField] private float Damage;
    [SerializeField] private float Speed;
    [SerializeField] private float Lifetime;
    private Vector2 MoveDirection;
    private Rigidbody rb;

    #endregion

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Proyectile Lifetime
        Lifetime -= Time.deltaTime;

        if (Lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * Speed);
    }

    //Detect Collision
    private void OnCollisionEnter(Collision collision)
    {
        //Check if Collision is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            //Apply the Damage
            collision.gameObject.GetComponent<IRecieveDamage>()?.GetDamaged(Damage);

            Destroy(gameObject);
        }
    }
}
