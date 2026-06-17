using Unity.VisualScripting;
using UnityEngine;

public class Enemy1_Controller : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    private void OnCollisionEnter2D(Collision2D collision) //ぶつかったら消える命令文開始
    {
        Destroy(gameObject);//消滅
    }
}
