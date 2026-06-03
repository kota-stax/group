using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField] private Transform player;
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
        float playerX = player.position.x;

        foreach (Transform bg in backgrounds)
        {
            // 背景の右端がプレイヤーの左側に来たら、右側に移動
            if (bg.position.x + imageWidth < playerX)
            {
                bg.position += new Vector3(imageWidth * 2, 0, 0);
            }
        }
    }
}