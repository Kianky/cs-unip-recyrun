using UnityEngine;

public class HoldItem : MonoBehaviour // Script que define o que o botão de ação vai fazer 
{
    public Trash trash;
    public TrashCan trashCan;
    LayerMask trashMask, trashCanMask, spawnMask;
    public float range = 2f;
    public SpriteRenderer holdingItemSprite;
    private void Start()
    {
        trashMask = LayerMask.GetMask("Trash");
        trashCanMask = LayerMask.GetMask("TrashCan");
        spawnMask = LayerMask.GetMask("SpawnPoint");
    }
    void Update()
    {
        Collider2D trashCollider = Physics2D.OverlapCircle(transform.position, range, trashMask); // Código de checar se ocorre colisão com um objeto do tipo lixo
        if (trashCollider != null)
        {
            trash = trashCollider.gameObject.GetComponent<Trash>();
        }
        else
        {
            trash = null;
        }
        Collider2D trashColliderCan = Physics2D.OverlapCircle(transform.position, range, trashCanMask); // Código de checar se ocorre colisão com um objeto do tipo lixeira
        if (trashColliderCan != null)
        {
            trashCan = trashColliderCan.gameObject.GetComponent<TrashCan>();
        }
        else
        {
            trashCan = null;
        }
    }

    public void Action() // Metódo chamada ao apertar o botão de ação
    { 
        if (trash != null)
        {
            trash.BeingCarry(); // Coleta o lixo mais próximo e o carrega
            holdingItemSprite.sprite = trash.sprite;
        }
        else
        {
            return;
        }
        if (trashCan != null)
        {
            trashCan.DeleteTrash(trash.gameObject); // Descarta o lixo carregado na lixeira mais próxima
            holdingItemSprite.sprite = null;
        }
        else
        {
            return;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, range);
    }
}
