using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class Enemy2_Controller : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
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

    private void OnCollisionEnter2D(Collision2D collision) //ぶつかったら消える命令文開始
    {
        Destroy(gameObject);//消滅
    }
}


