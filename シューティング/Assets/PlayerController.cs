using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // 移動速度を調整可能な変数にします
    [SerializeField] float speed = 5.0f;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shotPoint;
    [SerializeField] AudioClip spaceSE;
    [SerializeField] int P_HP = 5;
    [SerializeField] TMP_Text hpText;
    private AudioSource audioSource;

    void Start()
    {
        Application.targetFrameRate = 60;
        UpdateHPText();
        audioSource = GetComponent<AudioSource>();
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

        //画面上部で止まるようにする
        if (position.y > (float)5.5)
        {
            position.y = (float)5.5;
        }

        // Sキーが押されている間
        if (Keyboard.current.sKey.isPressed)
        {
            position.y -= speed * Time.deltaTime;
        }

        //画面下部で止まるようにする
        if (position.y < (float)-4.5)
        {
            position.y = (float)-4.5;
        }

        // 変更した座標を反映
        transform.position = position;

        // スペースキーで弾発射＆SE
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(
                bulletPrefab,
                shotPoint.position,
                Quaternion.identity
            );

            if (spaceSE != null && audioSource != null)
            {
                audioSource.PlayOneShot(spaceSE);
            }
        }
    }
    //ぶつかったときの処理
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            P_HP--;

            Destroy(other.gameObject); // 当たった弾を消す
        }

        if (P_HP <= 0)
        {
            Destroy(gameObject);
        }

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