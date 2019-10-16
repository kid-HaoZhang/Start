using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleMenu : MonoBehaviour
{
    public bool IsGamePaused;

    public GameObject Player1;


    void Start()
    {
        Player1 = GameObject.Find("Player1");
        StartGame();
    }
    public void ButtonMenuClick()
    {
        PauseGame();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    void OnGUI()

    {

        if (!IsGamePaused)
            return;

        ///自动布局，按照区域

        GUILayout.BeginArea(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2, 100, 200));

        ///横向

        GUILayout.BeginVertical();

        if (IsGamePaused)

        {

            if (GUILayout.Button("继续游戏", GUILayout.Height(50)))

            {

                StartGame();

            }
            if (GUILayout.Button("重新开始", GUILayout.Height(50)))

            {

                SceneManager.LoadScene("BattleScene");

            }
            if (GUILayout.Button("返回主菜单", GUILayout.Height(50)))

            {

                SceneManager.LoadScene("StartScene");

            }

        }

      
       

        GUILayout.EndVertical();

        GUILayout.EndArea();

    }

    void StartGame()

    {

        IsGamePaused = false;

        Time.timeScale = 1;

       // Player1.SetActive(true);

    }

    void PauseGame()

    {

        IsGamePaused = true;

        Time.timeScale = 0;
       // Player1.SetActive(false);
    }

}
