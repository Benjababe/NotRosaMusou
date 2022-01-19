using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    public void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            GameObject.Find("Laugh").GetComponent<Persistent>().Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
