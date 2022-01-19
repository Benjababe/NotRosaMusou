using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGame : MonoBehaviour
{
    public GameObject bell;
    private GameObject _hiscore;

    public void Start()
    {
        bell = GetComponent<GameObject>();
        LoadHiscores();
    }

    private void LoadHiscores()
    {
        if (!PlayerPrefs.HasKey("HScore"))
            return;

        _hiscore = GameObject.FindGameObjectWithTag("Hiscore");
        TextMeshProUGUI text = _hiscore.GetComponent<TextMeshProUGUI>();

        int score = PlayerPrefs.GetInt("HScore");
        text.SetText("<align=right>Hi Score: " + score);
    }

    public void Play()
    {
        GameObject.Find("Bell").GetComponent<Persistent>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
