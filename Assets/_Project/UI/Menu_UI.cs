using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_UI : MonoBehaviour
{
    public EnemyManager enemyManagerRef;
    
    // Start is called before the first frame update
    void Awake()
    {
        enemyManagerRef.GetFinalText();
    }

    public void HidePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene(0);
    }
}
