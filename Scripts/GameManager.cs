using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//���� : player�� ������ ���� restart
//���� �����ִ� play scene�� reloading �Ѵ�.

//Singleton ���� ����� ����

public class GameManager : MonoBehaviour
{
    // Singleton �� �ν��Ͻ� 1�� �ʿ�
    public static GameManager Instance = null;

    public GameObject restartPanel;
    bool gameHasEnded = false;
    //Restart
    private void Awake()
    {
        // ���� singleton�� �ν��Ͻ��� ����ִٸ�, �ν��Ͻ��� �� �ڽ��� �־��ش�.
        if (Instance == null) { Instance = this; }
        
    }

    private void Update()
    {
        //���� restart ���Ĺ��� ���¶��?
        //���� ���Ĺ��� ���¿��� RŰ�� �����ٸ�? -> �����
        if (gameHasEnded == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //R Ű ������ Scene Reload
                // 1. ���� �����ִ� Scene �̸��� �����´�.
                string currentSceneName = SceneManager.GetActiveScene().name;
                // 2. ������ scene �̸����� buildsetting - scenesinbuild���� ã�� ����
                SceneManager.LoadScene(currentSceneName);
            }
        }
        
    }
    public void Restart()
    {
        //�г� Ȱ��ȭ
        restartPanel.gameObject.SetActive(true);
        gameHasEnded = true;
        //Restart �غ�


       
    }
}
