using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
 
    public void PlayAgain()
    {
        Debug.Log("Game");
        SceneManager.LoadScene("Game");
    }

    public void EndGame()
    {
        Application.Quit();
    }


}
