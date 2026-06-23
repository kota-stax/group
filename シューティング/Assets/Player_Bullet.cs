using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ボスに当たった
        if (collision.CompareTag("Boss"))
        {
            Enemy2_Controller boss = collision.GetComponent<Enemy2_Controller>();

            if (boss != null)
            {
                boss.TakeDamage(1);
            }

            Destroy(gameObject);
        }

        // 雑魚敵に当たった
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}