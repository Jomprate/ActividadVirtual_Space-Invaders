using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextShowed;
    public GameObject PanelRestart;
    public EnemyCO enemyCO;
    public bool playerWon;

    void Start()
    {
        PanelRestart.SetActive(false);
    } 

    void Update()
    {
        if (EnemyDeathCounter.enemyKilled >= 21 || playerWon )
        {
            Time.timeScale = 0;
            PanelRestart.SetActive(true);
            TextShowed.text = "You've won";
        }
        
        if (GameOver.playerIsDead)
        {
            Time.timeScale = 0;
            TextShowed.text = "You've Lose";
            PanelRestart.SetActive(true);
        }
        
    }

    public void RestartSceneV()
    {
        SoundControllerSC.PlaySound("MenuSelection");
        GameOver.playerIsDead = false;
        Time.timeScale = 1;
        EnemyDeathCounter.enemyKilled = 0;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
