using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject startPanel;
    public Button startBTN;

    void Start()
    {
        Time.timeScale = 0;
        startBTN.onClick.AddListener(StartTheGame);
    }

    void StartTheGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
