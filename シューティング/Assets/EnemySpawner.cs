using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab1;
    [SerializeField] float spawnInterval1 = 3f;
    float timer1 = 0f; // 敵1用のタイマー

    [SerializeField] GameObject enemyPrefab2;
    [SerializeField] float spawnInterval2 = 15f;
    float timer2 = 0f; // 敵2用のタイマー

    [SerializeField] GameObject bossPrefab1;
    [SerializeField] float spawnInterval1_1 = 10f;
    float timer1_1 = -1f; // 敵2用のタイマー

    void Update()
    {
        timer1 += Time.deltaTime;
        if (timer1 >= spawnInterval1)
        {
            timer1 = 0f;
            SpawnEnemy(enemyPrefab1);
        }

        timer2 += Time.deltaTime;
        if (timer2 >= spawnInterval2)
        {
            timer2 = 0f;
            SpawnEnemy(enemyPrefab2);
        }

        timer1_1 += Time.deltaTime;
        if (timer1_1 >= spawnInterval1_1)
        {
            timer1_1 = -10000f;
            SpawnEnemy(bossPrefab1);
            timer1_1 -= Time.deltaTime;
        }
    }

    void SpawnEnemy(GameObject prefab)
    {
        Vector3 spawnPos = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, Random.Range(0.3f, 0.9f), 10f));

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}