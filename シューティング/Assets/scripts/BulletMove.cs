using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}