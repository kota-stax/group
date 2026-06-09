using Unity.VisualScripting;
using UnityEngine;

public class Enemy2_Controller : MonoBehaviour
{
    float speed = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        // カメラの視野に入った瞬間に呼ばれる
        if (GetComponent<SpriteRenderer>().isVisible)
        {
            // 現在のY座標を取得
            Vector3 position = transform.position;

            position.x += speed * Time.deltaTime;

            transform.position = position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //ぶつかったら消える命令文開始
    {
        Destroy(gameObject);//消滅
    }
}


