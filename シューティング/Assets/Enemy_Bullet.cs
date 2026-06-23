using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    [SerializeField] float speed = 8f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}