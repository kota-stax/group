using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class Enemy2_Controller : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] int hp = 10;     // ボスのHP
    public float waitTime = 1.5f;

    bool started = false;
    bool isEscaping = false;

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

    // ダメージを受ける関数
    public void TakeDamage(int damage)
    {
        hp -= damage;

        Debug.Log("Boss HP : " + hp);

        // HPが0になったら撃破
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}