using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理機能を読み込む

public class SceneChanger : MonoBehaviour
{
    // 移動先のシーン名
    public string nextSceneName;

    public void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}