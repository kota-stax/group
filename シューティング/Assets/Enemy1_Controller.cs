using System;
using TMPro;
using UnityEngine;

public class Enemy1_Controller : MonoBehaviour
{
<<<<<<< HEAD
    [Header("体力")]
    [SerializeField] private int hp = 3;

    [Header("射撃設定")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float shotInterval = 2f;

    [SerializeField] int scoreValue = 1; //  ポイント1を設定
=======
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
>>>>>>> 7f2cc3e4a7ffbd532efceb04f74694430ac583a1

    private bool activated = false;

    private float shotTimer = 0f;

    void Update()
    {
        if (GetComponent<SpriteRenderer>().isVisible)
        {
            activated = true;
        }

<<<<<<< HEAD
        if (!activated) return;

        shotTimer += Time.deltaTime;

        if (shotTimer >= shotInterval)
        {
            Shoot();
            shotTimer = 0f;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
            return;

        Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.identity
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bullet"))
            return;

        hp--;

        // 💡 消滅する前にScoreManagerに1ポイント送る
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(scoreValue);
        }

        Destroy(other.gameObject);

        if (hp <= 0)
        {
=======
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(scoreValue);
            }

            Destroy(collision.gameObject);
>>>>>>> 7f2cc3e4a7ffbd532efceb04f74694430ac583a1
            Destroy(gameObject);
        }
    }
}