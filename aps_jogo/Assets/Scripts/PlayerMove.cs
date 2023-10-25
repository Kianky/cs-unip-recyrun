using UnityEngine;
public enum Dir { up, down, left, right };
public class PlayerMove : MonoBehaviour
{
    Vector3 move;
    public float speed = 6f;
    public Joystick joystick;
    public SpriteRenderer playerSprite;
    public int index;
    float timer = 0;
    float maxTimer;
    public Sprite[] spritesUp, spritesDown, spritesLeft, spritesRight;
    public Sprite[] spritesUpIdle, spritesDownIdle, spritesLeftIdle, spritesRightIdle;
    public Dir dir;
    void Update()
    {
        SpriteTimer();
        ChangeSprite();
    }
    void SpriteTimer()
    {  // Metódo que decresce o timer de acordo com a velocidade do player para deixar a animação sincronizada com o movimento
        if (move.magnitude == 0)
        {
            maxTimer = 1f;
        }
        else
        {
            maxTimer = 0.12f / move.magnitude;
        }
        timer += 1 * Time.deltaTime;
        if (timer >= maxTimer)
        {
            index++;
            timer = 0;
        }
        if (index >= spritesDown.Length)
        {
            index = 0;
        }
    }
    void ChangeSprite()
    { // Metódo que detecta a direção em que o player está olhando e altera o seu sprite de acordo com o timer da função anterior
        if (Mathf.Abs(joystick.Vertical) > Mathf.Abs(joystick.Horizontal))
        {
            if (joystick.Vertical >= 0.0001f)
            {
                dir = Dir.up;
            }
            else if (joystick.Vertical <= -0.0001f)
            {
                dir = Dir.down;
            }
        }
        else if (Mathf.Abs(joystick.Horizontal) > Mathf.Abs(joystick.Vertical))
        {
            if (joystick.Horizontal >= 0.0001f)
            {
                dir = Dir.right;
            }
            else if (joystick.Horizontal <= -0.0001f)
            {
                dir = Dir.left;
            }
        }
        if (move.magnitude == 0)
        {
            switch (dir)
            {
                case Dir.up: playerSprite.sprite = spritesUpIdle[index]; break;
                case Dir.down: playerSprite.sprite = spritesDownIdle[index]; break;
                case Dir.right: playerSprite.sprite = spritesRightIdle[index]; break;
                case Dir.left: playerSprite.sprite = spritesLeftIdle[index]; break;
            }
        }
        else if (move.magnitude >= 0.001)
        {
            switch (dir)
            {
                case Dir.up: playerSprite.sprite = spritesUp[index]; break;
                case Dir.down: playerSprite.sprite = spritesDown[index]; break;
                case Dir.right: playerSprite.sprite = spritesRight[index]; break;
                case Dir.left: playerSprite.sprite = spritesLeft[index]; break;
            }
        }
    }
    private void FixedUpdate()
    {

        move = new Vector3(joystick.Horizontal, joystick.Vertical, 0f);

        // Função de movimentar o player
        transform.position += move * speed * Time.deltaTime;
    }

}
