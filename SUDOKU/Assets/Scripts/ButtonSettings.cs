using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSettings : MonoBehaviour
{
    public void ButtonClick(string setting)
    {
        if (setting == "Easy")
        {
            Settings.difficulty = Settings.Difficulties.EASY;
        }
        if (setting == "Medium")
        {
            Settings.difficulty = Settings.Difficulties.MEDIUM;
        }
        if (setting == "Hard")
        {
            Settings.difficulty = Settings.Difficulties.HARD;
        }
        if (setting == "Insane")
        {
            Settings.difficulty = Settings.Difficulties.INSANE;
        }
        if (setting == "Pretre")
        {
            Settings.difficulty = Settings.Difficulties.PRETRE;
        }

        SceneManager.LoadScene("GameScene");
    }
    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void backscene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
