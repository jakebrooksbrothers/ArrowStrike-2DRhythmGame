using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Difficulty()
    {

        SceneManager.LoadScene("DifficultyScene");
    }

    // Update is called once per frame
    void Play()
    {

        SceneManager.LoadScene("PlayScene");
    }

    void Credits()
    {
        
        SceneManager.LoadScene("CreditScene");
    }

    void Back()
    {

        SceneManager.LoadScene("MenuScene");
    }
}
