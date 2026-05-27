using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // 移動速度を調整可能な変数にします
    [SerializeField] float speed = 5.0f;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        // 現在のY座標を取得
        Vector3 position = transform.position;

        // Wキーが押されている間
        if (Keyboard.current.wKey.isPressed)
        {
            position.y += speed * Time.deltaTime;
        }

        // Sキーが押されている間
        if (Keyboard.current.sKey.isPressed)
        {
            position.y -= speed * Time.deltaTime;
        }

        // 変更した座標を反映
        transform.position = position;
    }
}