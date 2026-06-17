using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class Boss_Controller : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] int hp = 1;
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
        hp--;
        if (hp <= 0)
        {
            Destroy(gameObject);//消滅
        }
    }
}
