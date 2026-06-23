using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        // 2秒待つ
        yield return new WaitForSeconds(2f);

        // 透明にする時間
        float fadeTime = 1f;

        while (fadeTime > 0)
        {
            fadeTime -= Time.deltaTime;

            Color color = sr.color;
            color.a = fadeTime;
            sr.color = color;

            yield return null;
        }

        Destroy(gameObject);
    }
}