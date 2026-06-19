using Unity.VisualScripting;
using UnityEngine;

public class Enemy1_Controller : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] int hp = 1;
    [SerializeField] int scoreValue = 1;

    private void OnCollisionEnter2D(Collision2D collision) //ぶつかったら消える命令文開始
    {
        hp--;
        if (hp <= 0)
        {
            //消滅する前にScoreManagerにポイント送る
            if(ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(scoreValue);
            }
            Destroy(gameObject);//消滅
        }       
    }
}
