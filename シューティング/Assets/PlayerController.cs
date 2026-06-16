using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    // 移動速度を調整可能な変数にします
    [SerializeField] float speed = 5.0f;
    // プレイヤーのHP
    [SerializeField] int P_HP = 5;
    // HPUI
    [SerializeField] TMP_Text hpText;

    void Start()
    {
        Application.targetFrameRate = 60;

        // 【修正】ゲーム開始時に最初のHPをUIに表示する
        UpdateHPText();
    }

    void Update()
    {
        // 現在のY座標を取得
        Vector3 position = transform.position;

        // カメラにおいて行かれないよう右方向（X軸）へ移動させる
        position.x += speed * Time.deltaTime;

        // Wキーが押されている間
        if (Keyboard.current.wKey.isPressed)
        {
            position.y += speed * Time.deltaTime;
        }

        // 画面上部で止まるようにする
        if (position.y > 5.5f) // (float)5.5 よりも 5.5f と書くのが一般的です
        {
            position.y = 5.5f;
        }

        // Sキーが押されている間
        if (Keyboard.current.sKey.isPressed)
        {
            position.y -= speed * Time.deltaTime;
        }

        // 画面下部で止まるようにする
        if (position.y < -5.5f)
        {
            position.y = -5.5f;
        }

        // 変更した座標を反映
        transform.position = position;

        if (P_HP <= 0)
        {
            Destroy(gameObject); // 消滅
        }
    }

    // 【修正】ぶつかった時の処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ここで敵だけに反応させたい場合は if (collision.gameObject.CompareTag("Enemy")) などで囲うと良いです
        P_HP--;

        // HPの表示を更新する
        UpdateHPText();
    }

    // 【追加】HPテキストを更新するための専用の関数
    void UpdateHPText()
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + P_HP.ToString();
        }
    }
}