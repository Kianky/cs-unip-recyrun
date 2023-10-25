using UnityEngine;

public class PropLayer : MonoBehaviour
{
    GameObject player;
    SpriteRenderer sprite;
    public float distance = 0f;
    void Start()
    {
        player = GameObject.Find("Player");
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (player.transform.position.y + distance >= transform.position.y)
        {
            sprite.sortingOrder = 2;
        }
        else
        {
            sprite.sortingOrder = 0;
        }
    }
}
