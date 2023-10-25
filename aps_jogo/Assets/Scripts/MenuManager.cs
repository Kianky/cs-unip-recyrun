using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum Difficulty { easy, medium, hard };
public class MenuManager : MonoBehaviour
{
    public GameObject[] menus;
    public TMP_Text difficultyText;
    public TMP_Text levelName;
    public Image levelImage;
    public Sprite[] images;
    public Difficulty difficulty;
    int difficultyInt = 1;
    int levelInt = 1;
    void Start()
    {
        menus[0].SetActive(true);
        menus[1].SetActive(false);
        menus[2].SetActive(false);
        menus[3].SetActive(false);
    }


    void Update()
    {
        switch (difficultyInt)
        {
            case 1:
                difficultyText.text = "Fácil";
                difficulty = Difficulty.easy;
                PlayerPrefs.SetInt("Difficulty", 1);
                break;
            case 2:
                difficultyText.text = "Normal";
                difficulty = Difficulty.medium;
                PlayerPrefs.SetInt("Difficulty", 2);
                break;
            case 3:
                difficultyText.text = "Difícil";
                difficulty = Difficulty.hard;
                PlayerPrefs.SetInt("Difficulty", 3);
                break;
        }
        switch (levelInt)
        {
            case 1:
                levelImage.sprite = images[0];
                levelName.text = "Centro";
                PlayerPrefs.SetInt("Level", 0);
                break;
            case 2:
                levelImage.sprite = images[1];
                levelName.text = "Suburbio";
                PlayerPrefs.SetInt("Level", 1);
                break;
        }
    }
    public void UpDifficulty()
    {
        if (difficultyInt + 1 <= 3)
        {
            difficultyInt++;
        }
        else
        {
            return;
        }
        FindObjectOfType<AudioManager>().Play("Button");
    }
    public void DownDifficulty()
    {
        if (difficultyInt - 1 >= 1)
        {
            difficultyInt--;
        }
        else
        {
            return;
        }
        FindObjectOfType<AudioManager>().Play("Button");
    }
    public void NextLevel()
    {
        if (levelInt + 1 <= 2)
        {
            levelInt++;
        }
        else
        {
            levelInt = 1;
        }
        FindObjectOfType<AudioManager>().Play("Button");
    }
    public void PreviousLevel()
    {
        if (levelInt - 1 >= 1)
        {
            levelInt--;
        }
        else
        {
            levelInt = 2;
        }
        FindObjectOfType<AudioManager>().Play("Button");
    }
    public void Play()
    {
        SceneManager.LoadScene(levelName.text, LoadSceneMode.Single);
        FindObjectOfType<AudioManager>().Play("Button");
    }
    public void StartButton()
    {
        menus[0].SetActive(false);
        menus[1].SetActive(true);
        menus[2].SetActive(false);
        menus[3].SetActive(false);
        FindObjectOfType<AudioManager>().Play("Button");
    }
    public void CreditsButton()
    {
        menus[0].SetActive(false);
        menus[1].SetActive(false);
        menus[2].SetActive(true);
        menus[3].SetActive(false);
        FindObjectOfType<AudioManager>().Play("Button");
    }
    public void BackButton()
    {
        menus[0].SetActive(true);
        menus[1].SetActive(false);
        menus[2].SetActive(false);
        menus[3].SetActive(false);
        FindObjectOfType<AudioManager>().Play("Button");
    }
    public void TutorialButton()
    {
        /*menus[0].SetActive(false);
        menus[1].SetActive(false);
        menus[2].SetActive(false);
        menus[3].SetActive(true);*/
        PlayerPrefs.SetInt("Difficulty", 4);
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }
}
