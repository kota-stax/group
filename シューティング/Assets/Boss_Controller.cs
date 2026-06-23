using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss_Controller : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] int hp = 10;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] int scoreValue = 20; //  ここで20ポイントに設定！
    public float waitTime = 1.5f;

    [SerializeField] float moveRange = 1.5f;
    [SerializeField] float moveFrequency = 1f;

    private float baseY;

    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] float shotInterval = 2f;
    float shotTimer = 0f;

    bool started = false;
    bool isEscaping = false;

    private bool activated = false;

    void Start()
    {
        Debug.Log("Boss Start HP : " + hp);

        baseY = transform.position.y;
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
        // 現在のY座標を取得
        Vector3 position = transform.position;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        float halfHeight = sr.bounds.extents.y;

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

        float yOffset =
    Mathf.Sin(Time.time * moveFrequency)
    * moveRange;

        Vector3 pos = transform.position;
        pos.y = baseY + yOffset;

        // 画面外に出ないよう制限
        pos.y = Mathf.Clamp(
            pos.y,
            -5.5f + halfHeight,
            6.5f - halfHeight
        );

        transform.position = pos;
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
