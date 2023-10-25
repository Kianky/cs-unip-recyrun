using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour // Esse script executa toda a mente da mecânica do jogo
{                                // Criar as váriaveis essenciais da partida, como itens a coletar, tempo e elementos da interface
    public static int remaining; // Variaveis do tipo static para serem acessadas de qualquer lugar do projeto
    public static int timer; 
    public static int saveTimer;
    public static int levelTimer;
    public static float spawnTimer;
    bool gameOver;
    public TMP_Text remainingText;
    public int difficulty;
    public TMP_Text timerText, gameOverTimerText;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public TMP_Text gameOverText, remainingTextGameover;
    public int lixoQuantia;
    int levelTimerMinutes;
    int remainingTotal;
    bool check;
    private void Awake() // Metódo chamado no momento em que a partida começa, esse método define as configurações da dificuldade selecionada no menu
    {
        gameOver = false;
        Time.timeScale = 1;
        check = false;
        if (difficulty <= 0 && difficulty >= 5)
        {
            difficulty = 2;
        }
        pauseMenu.SetActive(false);
        difficulty = PlayerPrefs.GetInt("Difficulty");
        SetDifficulty();
        StartTimer();
        Application.targetFrameRate = 30;
        remainingTotal = remaining;

    }
    void Update()
    {
        remainingText.text = remaining + "/" + remainingTotal; // Código que altera o score e o timer
        timerText.text = "Timer: " + timer;
        if (timer <= 0) // Verificador de game over quando o tempo acaba
        {
            gameOverText.text = "Fim de jogo";
            gameOverTimerText.text = "Tempo: " + levelTimerMinutes + ":" + levelTimer.ToString("00");
            gameOver = true;
            gameOverMenu.SetActive(true);
            if (!check)
            {
                check = true;
                FindObjectOfType<AudioManager>().Play("GameOver");
            }
        }
        else if (remaining == 0) // Verificador de vitória quando coleta todos os itens
        {

            gameOverTimerText.text = "Tempo: " + levelTimerMinutes + ":" + levelTimer.ToString("00");
            gameOver = true;
            gameOverText.text = "Parabéns!";
            remainingTextGameover.text = "Você é top";
            gameOverMenu.SetActive(true);
            if (!check)
            {
                check = true;
                FindObjectOfType<AudioManager>().Play("Succeeded");
            }
        }

        ScalingDifficulty();
        lixoQuantia = GameObject.FindGameObjectsWithTag("Trash").Length;
    }

    IEnumerator Timer() // Função que decresce o timer de 1 em 1 segundo
    { 
        while (timer > 0 && !gameOver)
        {
            yield return new WaitForSeconds(1);
            timer--;
            levelTimer++;
            if (levelTimer >= 60)
            {
                levelTimer = 00;
                levelTimerMinutes++;
            }
        }
    }
    void StartTimer()
    {
        StartCoroutine(Timer());
    }

    void SetDifficulty() // Método que define as configurações do jogo com base na dificuldade
    {

        switch (difficulty)
        {
            case 1: // Fácil
                levelTimer = 0;
                levelTimerMinutes = 0;
                remaining = 15;
                timer = 60;
                saveTimer = 17;
                spawnTimer = 1;
                break;
            case 2: // Médio
                levelTimer = 0;
                levelTimerMinutes = 0;
                remaining = 20;
                timer = 60;
                saveTimer = 13;
                spawnTimer = 1;
                break;
            case 3: // Dificil
                levelTimer = 0;
                levelTimerMinutes = 0;
                remaining = 25;
                timer = 50;
                saveTimer = 10;
                spawnTimer = 1;
                break;
            case 4:
                timer = 99999;
                remaining = 8;
                break;
        }
    }

    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        FindObjectOfType<AudioManager>().Play("Button");
    }
    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("Button");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        FindObjectOfType<AudioManager>().Play("Button");
    }
    public void RestartButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    void ScalingDifficulty() // Metódo que escala a dificuldade conforme o player descarta itens
    {
        switch (difficulty)
        {
            case 1: // Facil
                if (remaining == 10)
                {
                    saveTimer = 15;
                    spawnTimer = 7;
                }
                else if (remaining == 5)
                {
                    saveTimer = 10;
                    spawnTimer = 10;
                }
                else if (remaining == 1)
                {
                    saveTimer = 12;
                    spawnTimer = 7;
                }
                break;
            case 2:  // Medio
                if (remaining == 15)
                {
                    saveTimer = 12;
                    spawnTimer = 5;
                }
                else if (remaining == 10)
                {
                    saveTimer = 10;
                    spawnTimer = 10;
                }
                else if (remaining == 5)
                {
                    saveTimer = 7;
                    spawnTimer = 15;
                }
                break;
            case 3: // Dificil
                if (remaining == 25)
                {
                    saveTimer = 7;
                    spawnTimer = 5;
                }
                else if (remaining == 20)
                {
                    saveTimer = 8;
                    spawnTimer = 10;
                }
                else if (remaining == 15)
                {
                    saveTimer = 5;
                    spawnTimer = 20;
                }
                break;
        }

    }

}
