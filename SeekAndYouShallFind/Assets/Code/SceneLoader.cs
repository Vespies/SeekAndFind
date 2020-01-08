using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void OpenMenu()
    {
        //Loads scene number 0
        SceneManager.LoadScene(0);
    }
    public void OpenGame()
    {
        //Loads scene number 1
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
