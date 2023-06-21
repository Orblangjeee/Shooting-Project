using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//역할 : player가 죽으면 게임 restart
//현재 열려있는 play scene을 reloading 한다.

//Singleton 으로 만들어 관리

public class GameManager : MonoBehaviour
{
    // Singleton 용 인스턴스 1개 필요
    public static GameManager Instance = null;

    public GameObject restartPanel;
    bool gameHasEnded = false;
    //Restart
    private void Awake()
    {
        // 만일 singleton용 인스턴스가 비어있다면, 인스턴스에 나 자신을 넣어준다.
        if (Instance == null) { Instance = this; }
        
    }

    private void Update()
    {
        //만일 restart 스탠바이 상태라면?
        //만일 스탠바이 상태에서 R키를 눌렀다면? -> 재시작
        if (gameHasEnded == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //R 키 누르면 Scene Reload
                // 1. 현재 열려있는 Scene 이름을 가져온다.
                string currentSceneName = SceneManager.GetActiveScene().name;
                // 2. 가져온 scene 이름ㅇ르 buildsetting - scenesinbuild에서 찾아 실행
                SceneManager.LoadScene(currentSceneName);
            }
        }
        
    }
    public void Restart()
    {
        //패널 활성화
        restartPanel.gameObject.SetActive(true);
        gameHasEnded = true;
        //Restart 준비


       
    }
}
