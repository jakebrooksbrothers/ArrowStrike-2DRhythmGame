using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIcontroller : MonoBehaviour
{

    public void Difficulty()
    {
        SceneManager.LoadScene("DifficultyScene");
    }

    public void Play()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void Back()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
