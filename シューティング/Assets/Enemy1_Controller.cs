using UnityEngine;

public class Enemy1_Controller : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] int hp = 1;

    [Header("射撃設定")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float shotInterval = 2f;

    private float shotTimer = 0f;

    void Update()
    {
        // 射撃タイマー
        shotTimer += Time.deltaTime;

        if (shotTimer >= shotInterval)
        {
            Shoot();
            shotTimer = 0f;
        }
    }

    void Shoot()
    {
        Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.identity
        );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hp--;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}