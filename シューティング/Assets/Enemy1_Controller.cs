using UnityEngine;
using TMPro;

public class Enemy1_Controller : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] int scoreValue = 1; //  ポイント1を設定

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // 💡 消滅する前にScoreManagerに1ポイント送る
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(scoreValue);
            }

            // 弾と自分（エネミー）を削除
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}