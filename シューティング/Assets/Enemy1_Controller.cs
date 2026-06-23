using UnityEngine;
using TMPro;

public class Enemy1_Controller : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] int scoreValue = 1;

    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] float shotInterval = 2f;

    float shotTimer = 0f;

    private bool activated = false;

    void Update()
    {
        if (GetComponent<SpriteRenderer>().isVisible) //視界内に入ったら弾を撃ち始めるように
        {
            activated = true;
        }

        if (!activated) return;

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

    void OnBecameInvisible()
    {
        // オブジェクトを破棄
        Destroy(gameObject);
    }
}