using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tutorial : MonoBehaviour
{
    [SerializeField] int lettersPerSecond;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] GameObject joystick, actionButton, dialogBox;
    [SerializeField] GameObject player;
    int restante;
    bool check;


    void Start()
    {
        joystick.SetActive(false);
        actionButton.SetActive(false);
        StartCoroutine(StartTutorial());
    }



    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }
    private void Update()
    {
        restante = GameObject.FindGameObjectsWithTag("Trash").Length;

        if (restante == 0 && !check || Input.GetKeyDown(KeyCode.T))
        {
            check = true;
            StartCoroutine(EndTutorial());
        }
    }
    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }
    IEnumerator StartTutorial()
    {
        StartCoroutine(TypeDialog("Bem-vindo(a)!"));
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(TypeDialog("Descarte os lixos na lixeira correta."));
        yield return new WaitForSeconds(3f);
        StartCoroutine(TypeDialog("Dica: eles estão posicionados em frente a sua lixeira correta."));
        yield return new WaitForSeconds(5.5f);
        joystick.SetActive(true);
        actionButton.SetActive(true);
        dialogBox.SetActive(false);
    }

    IEnumerator EndTutorial()
    {
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog("Parabéns, você concluiu o tutorial!"));
        yield return new WaitForSeconds(3f);
        StartCoroutine(TypeDialog("Agora tente na grande metrópole!"));
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

}
