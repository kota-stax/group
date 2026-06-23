using UnityEngine;

public class Enemy1_Controller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // 弾を消す
            Destroy(gameObject);           // 敵を消す
        }
    }
}