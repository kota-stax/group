using UnityEngine;
using System.Collections;

public class Enemy2_Controller : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] int hp = 10;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] int scoreValue = 5; //  ここで5ポイントに設定！
    public float waitTime = 1.5f;

    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] float shotInterval = 2f;
    float shotTimer = 0f;

    bool started = false;
    bool isEscaping = false;

    private bool activated = false;

    void Start()
    {
        Debug.Log("Boss Start HP : " + hp);
    }

    void OnBecameVisible()
    {
        if (!started)
        {
            started = true;
            StartCoroutine(Escape());
            activated = true;
        }
    }

    IEnumerator Escape()
    {
        yield return new WaitForSeconds(waitTime);
        isEscaping = true;
    }

    void Update()
    {
        if (isEscaping)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

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

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("Boss HP : " + hp);

        if (hp <= 0)
        {
            //  消滅する前にScoreManagerに5ポイント送る
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(scoreValue);
            }
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}