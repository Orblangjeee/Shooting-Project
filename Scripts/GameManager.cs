using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//���� : player�� ������ ���� restart
//���� �����ִ� play scene�� reloading �Ѵ�.
public class GameManager : MonoBehaviour
{
    public GameObject restartPanel;
    bool gameHasEnded = false;
    //Restart
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
