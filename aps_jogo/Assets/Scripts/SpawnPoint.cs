using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool isOccupied;
    public bool isReady;
    public bool isTooClose;
    public float cooldown = 1;

    void Update()
    {
        isOccupied = Physics2D.OverlapCircle(transform.position, 3f, LayerMask.GetMask("Trash"));
        isTooClose = Physics2D.OverlapCircle(transform.position, 17f, LayerMask.GetMask("Player"));
        if (!isOccupied && !isTooClose)
        {
            cooldown -= 1 * Time.deltaTime;
            if (cooldown <= 0)
            {
                isReady = true;
            }
        }
        else
        {
            isReady = false;
            cooldown = 20;
        }
    }
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1f);
    }
}