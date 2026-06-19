using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] TMP_Text scoreText;

    // 現在のスコアを保持する変数
    private int score = 0;

    void Awake()
    {
        // シグルトンの初期化（他から ScoreManager.instance で呼べるようにする）
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // ゲーム開始時にスコアを0で表示
        UpdateScoreText();
    }

    // 外部（敵など）からスコアを増やすために呼ぶ関数
    public void AddScore(int point)
    {
        score += point; // 受け取ったポイント分増やす
        UpdateScoreText(); // UIを更新
    }

    // スコアテキストを更新する関数
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}