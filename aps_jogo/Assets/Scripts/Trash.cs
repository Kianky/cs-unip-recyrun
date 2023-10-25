using UnityEngine;
public enum Type { PAPEL, METAL, VIDRO, PLASTICO, ORGANICO }; // Enum criado para definir o tipo de lixo mais facilmente

public class Trash : MonoBehaviour // Script que todo lixo vai ter
{
    public Type type;
    public LayerMask playerMask;
    public bool isCloseEnough;
    public float distance = 3f;
    GameObject carryPointObject;
    Transform carryPoint;
    public bool isBeingCarry = false;
    SpriteRenderer spriteRenderer;
    public Sprite sprite;

    private void Start()
    {
        carryPointObject = GameObject.Find("CarryPoint");
        carryPoint = carryPointObject.GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprite = spriteRenderer.sprite;
    }

    private void Update()
    {
        isCloseEnough = Physics2D.OverlapCircle(transform.position, distance, playerMask);
        if (isBeingCarry)
        {
            transform.position = carryPoint.position; // Código que leva o objeto junto com o player ao ser carregado
            spriteRenderer.sprite = null;
        }

    }


    public void BeingCarry() // Metódo chamado pelo player para carregar o objeto
    { 
        isBeingCarry = true;
    }
    private void OnDrawGizmosSelected()
    {
        Color color = Color.blue;
        color.a = 0.3f;
        Gizmos.color = color;

        Gizmos.DrawSphere(transform.position, distance);
    }
}
