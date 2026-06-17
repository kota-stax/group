using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // 移動速度を調整可能な変数にします
    [SerializeField] float speed = 5.0f;

<<<<<<< HEAD
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shotPoint;
=======
    [SerializeField] AudioClip ShootSE; 
    private AudioSource audioSource;

    [SerializeField] float SeVol = 2.0f;
>>>>>>> a9f8a9bd85ea6a4a695baa0db25881a830bd79f6

    void Start()
    {
        Application.targetFrameRate = 60;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(
                bulletPrefab,
                shotPoint.position,
                Quaternion.identity
            );
        }
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

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (ShootSE != null && audioSource != null)
            {
                audioSource.PlayOneShot(ShootSE, SeVol);
            }
        }

        //画面下部で止まるようにする
        if (position.y < (float)-5.5)
        {
            position.y = (float)-5.5;
        }

        // 変更した座標を反映
        transform.position = position;
    }
}