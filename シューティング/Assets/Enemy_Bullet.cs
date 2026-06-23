using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private float speed = 8f;
=======
    public float speed = 5f;
>>>>>>> 7f2cc3e4a7ffbd532efceb04f74694430ac583a1

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

<<<<<<< HEAD
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Hit!");

            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
=======
    void OnBecameInvisible()
>>>>>>> 7f2cc3e4a7ffbd532efceb04f74694430ac583a1
    {
        Destroy(gameObject);
    }
}