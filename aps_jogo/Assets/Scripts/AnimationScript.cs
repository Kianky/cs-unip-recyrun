using UnityEngine;
using UnityEngine.UI;
using System;
public enum State { RIGHT, LEFT, UP, DOWN, FREEZE };
public class AnimationScript : MonoBehaviour
{
    public bool useAnimation;
    public State direction;
    public float speed;
    SpriteRenderer spriteRenderer;
    Image image;
    public float maxTimer = 0.7f;
    public Sprite[] sprite;
    int index;
    float timer;

    private void Start()
    {
        try
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        catch (Exception)
        {
            Debug.Log("Não tem spriteRenderer");
        }
        try
        {
            image = GetComponent<Image>();
        }
        catch (Exception)
        {
            Debug.Log("Não tem image");
        }


    }
    void Update()
    {
        if (useAnimation)
        {
            TimerFunction();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = sprite[index];
            }
            else
            {
                image.sprite = sprite[index];
            }
        }
        MoveDirection();
    }

    void TimerFunction()
    {
        timer += 1 * Time.deltaTime;
        if (timer >= maxTimer)
        {
            if (index < sprite.Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            timer = 0;
        }
    }
    void MoveDirection()
    {
        Vector3 move;
        switch (direction)
        {
            case State.RIGHT:
                move = new Vector3(speed * Time.deltaTime, 0f, 0f);
                transform.position += move; break;
            case State.LEFT:
                move = new Vector3(-speed * Time.deltaTime, 0f, 0f);
                transform.position += move; break;
            case State.UP:
                move = new Vector3(0f, speed * Time.deltaTime, 0f);
                transform.position += move; break;
            case State.DOWN:
                move = new Vector3(0f, -speed * Time.deltaTime, 0f);
                transform.position += move; break;
        }
    }
}
