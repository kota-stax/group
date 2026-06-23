using UnityEngine;
using TMPro;

public class Enemy1_Controller : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] int scoreValue = 1;

    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] float shotInterval = 2f;

    float shotTimer = 0f;

    void Update()
    {
        shotTimer += Time.deltaTime;

        if (shotTimer >= shotInterval)
        {
            shotTimer = 0f;

            Instantiate(
                enemyBulletPrefab,
                transform.position,
                Quaternion.identity
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(scoreValue);
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}