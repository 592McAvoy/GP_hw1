using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //Menu
    public GameObject gameMenu;
    public GameObject textCanvas;
    public GameObject inMenu;

    private bool start;

    public void OnStartGame()//点击“开始游戏”时执行此方法
    {
        Time.timeScale = 1.0f;
        start = true;
        gameMenu.SetActive(false);
        textCanvas.SetActive(true);
    }

    public void OnRestartGame()//点击“重新开始”时执行此方法
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnQuitGame()//点击“退出游戏”时执行此方法
    {
        Application.Quit();
    }

    public void OnResumeGame()//点击“继续游戏”时执行此方法
    {
        Time.timeScale = 1.0f;
        start = true;
        inMenu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        gameMenu.SetActive(true);
        textCanvas.SetActive(false);
        inMenu.SetActive(false);
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (start && Input.GetKeyDown(KeyCode.Escape))//暂停游戏
        {
            Time.timeScale = 0;
            start = false;
            inMenu.SetActive(true);
        }
    }
}
