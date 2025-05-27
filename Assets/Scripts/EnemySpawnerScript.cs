using System.Collections;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] private float SpawnCD;
    private bool CanSpawn;
    [SerializeField] private GameObject EnemyPrefab;

    private void Start()
    {
        CanSpawn = true;
    }

    private void Update()
    {
        if (CanSpawn) { SpawnEnemy(); }
    }

    private void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
        CanSpawn = false;
        StartCoroutine(SpawnCooldown());
    }

    private IEnumerator SpawnCooldown()
    {
        transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 20f), 14);
        yield return new WaitForSeconds(SpawnCD);
        CanSpawn = true;
    }
}
