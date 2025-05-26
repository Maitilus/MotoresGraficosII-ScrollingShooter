using System.Collections;
using System.IO.Compression;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    #region Variables

    [Header("Stats")]

    [SerializeField] private float MaxHealth;
    public float CurrentHealth;
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float RPS;
    private bool CanFire;
    [SerializeField] private bool IsFireing = false;
    private Vector2 MoveDirection;
    [SerializeField] private InputActionReference Move;
    [SerializeField] private InputActionReference Shoot;
    private Rigidbody rb;
    [SerializeField] private Transform ProjectileSpawn;
    [SerializeField] private GameObject ProjectilePrefab;
    [SerializeField] private Transform Crosshair;

    #endregion


    private void Start()
    {
        //Get the Rigidbody
        rb = gameObject.GetComponent<Rigidbody>();
        CanFire = true;
    }
    private void Update()
    {
        //Set the value of the movement direction
        MoveDirection = Move.action.ReadValue<Vector2>();

        //Rotate
        TakeAim();

        //Fireing
        if (CanFire && IsFireing)
        {
            CanFire = false;
            Instantiate(ProjectilePrefab, ProjectileSpawn.transform.position, ProjectileSpawn.transform.rotation);
            StartCoroutine(FireRateHandler());
        }

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(x: MoveDirection.x * MovementSpeed, y: MoveDirection.y * MovementSpeed);
    }

    #region Fireing

    private void StartFireing(InputAction.CallbackContext context)
    {
        IsFireing = !IsFireing;
    }

    private IEnumerator FireRateHandler()
    {
        float CD = 1 / RPS;
        yield return new WaitForSeconds(CD);
        CanFire = true;
    }

    #endregion

    private void TakeAim()
    {
        //Rotate player to aim
        transform.rotation = Quaternion.LookRotation(Crosshair.position - transform.position);
    }

    #region Enable/Disable

        private void OnEnable()
            {
           Shoot.action.started += StartFireing;
        }

        private void Oisable()
        {
            Shoot.action.started -= StartFireing;
        }

    #endregion
}