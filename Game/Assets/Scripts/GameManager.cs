using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            SceneManager.LoadScene("Restart");
        }
    }

    public void Victory()
    {
        SceneManager.LoadScene("EndGame");
    }
}
