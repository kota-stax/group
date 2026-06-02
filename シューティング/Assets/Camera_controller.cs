using UnityEngine;

public class Camera_controller : MonoBehaviour 
{
    [SerializeField] private float scrollSpeed = 5.0f; // スクロール速度

    void Update()
    {
        // カメラを右方向（X軸）へ移動させる
        transform.Translate(new Vector3(scrollSpeed * Time.deltaTime, 0, 0));
    }
}
