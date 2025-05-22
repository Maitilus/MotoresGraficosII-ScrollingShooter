using System.IO.Compression;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    #region Variables

    [Header("Stats")]

    [SerializeField] private float MaxHealth;
    public float CurrentHealth;
    [SerializeField] private float MovementSpeed;
    private Vector2 MoveDirection;
    [SerializeField] private InputActionReference Move;
    [SerializeField] private InputActionReference Shoot;
    private Rigidbody rb;
    [SerializeField] private Transform ProjectileSpawn;
    [SerializeField] private GameObject ProjectilePrefab;

    #endregion


    private void Start()
    {
        //Get the Rigidbody
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //Set the value of the movement direction
        MoveDirection = Move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(x: MoveDirection.x * MovementSpeed, y: MoveDirection.y * MovementSpeed);
    }

    private void Fire(InputAction.CallbackContext obj)
    {
        //Insert Fire Logic
        Instantiate(ProjectilePrefab, ProjectileSpawn.transform.position, ProjectileSpawn.transform.rotation);
    }

    #region Enable/Disable

        private void OnEnable()
        {
            Shoot.action.started += Fire;
        }

        private void Oisable()
        {
            Shoot.action.started -= Fire;
        }

    #endregion
}