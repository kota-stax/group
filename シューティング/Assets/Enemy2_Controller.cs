using UnityEngine;
using System.Collections;

public class Enemy2_Controller : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] int hp = 10;
    [SerializeField] GameObject explosionPrefab;
    public float waitTime = 1.5f;

    bool started = false;
    bool isEscaping = false;

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
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("Boss HP : " + hp);

        if (hp <= 0)
        {
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}