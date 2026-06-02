using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField] private Transform player; // プレイヤー（またはカメラ）のTransformを指定
    [SerializeField] private float imageWidth = 30f; // 画像の幅

    private Transform[] backgrounds;

    void Start()
    {
        backgrounds = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        // プレイヤーのX座標を基準にする
        float playerX = player.position.x;

        foreach (Transform bg in backgrounds)
        {
            // 背景の右端がプレイヤーの左側に来てしまったら、右側に移動させる
            if (bg.position.x + imageWidth < playerX)
            {
                bg.position += new Vector3(imageWidth * 2, 0, 0);
            }
        }
    }
}