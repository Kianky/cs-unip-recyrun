using System.Collections;
using UnityEngine;

public class Fade : MonoBehaviour
{
    float fade = 1;
    void Start()
    {
        StartCoroutine(FeedbackSprite());
    }

    IEnumerator FeedbackSprite()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(1f / 2f);
        fade--;
        sprite.color = new Color(1f, 1f, 1f, fade);
    }
}