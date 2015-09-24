using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public int newGameLevelIndex = 1;

    public Button continueButton;
    public GameObject panel1, panel2;

    void Awake()
    {
        if (PlayerPrefs.GetInt("Saved", 0) == 0)
        {
            continueButton.interactable = false;
        }
    }

    public void OnNewGameClick()
    {
        if(PlayerPrefs.GetInt("Saved", 0) == 0)
		{
			PlayerPrefs.SetInt("Saved", 0);
            Application.LoadLevel(newGameLevelIndex);
        }
        else
        {
            panel1.SetActive(false);
            panel2.SetActive(true);
        }
    }

    public void OnContinueClick()
    {
        int levelIndex = PlayerPrefs.GetInt("LevelIndex", newGameLevelIndex);
		Application.LoadLevel(levelIndex);
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void OnNoButton()
    {
        panel2.SetActive(false);
        panel1.SetActive(true);
    }

    public void OnYesButton()
    {
		PlayerPrefs.SetInt("Saved", 0);
        Application.LoadLevel(newGameLevelIndex);
    }


}
