using System;
using UnityEngine;

public class TrashCan : MonoBehaviour // Script que toda lata de lixo vai ter
{
    public Type type;
    public GameObject[] feedback;

    public void DeleteTrash(GameObject obj) // Função chamada pelo player para deletar o objeto do tipo lixo
    {
        Trash trash = obj.GetComponent<Trash>();
        if (type == trash.type) // Verificação se o tipo do lixo sendo descartado é o mesmo da lixeira
        {
            Debug.Log("+1");
            try
            {
                GameManager.remaining--; // Caso seja, a variável static do script GameManager será diminuida em 1;
                GameManager.timer += GameManager.saveTimer;
            }
            catch (Exception)
            {

            }
            Instantiate(feedback[0], transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Correct");
        }
        else
        {
            Instantiate(feedback[1], transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Wrong");
        }
        Destroy(obj);
    }


}
