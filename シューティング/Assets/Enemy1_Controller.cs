using Unity.VisualScripting;
using UnityEngine;


public class Enemy1_Controller : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] int E_HP = 1;
  

    
    void Update()
    {
        if(E_HP <= 0)
        {
            Destroy(gameObject);//消滅
        }
    }
   

    private void OnCollisionEnter2D(Collision2D collision) //プレイヤーとぶつかったら消える命令文開始    したい
    {
        E_HP--;

      
    }
}
