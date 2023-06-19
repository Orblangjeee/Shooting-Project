using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //���� : ������ ����
    //A : Enemy ���� �� ���� ���� ȹ��, ȭ�鿡 ǥ��
    // ȭ�� ǥ�� text, ����
    public TextMeshProUGUI currentScoreText;
    public int currentScore = 0;
    public int movescore = 0;
    //B : ���� ������ ����� �ְ� ������ �Ѱ�ٸ� �����Ͽ� ǥ��
    // ȭ�� ǥ�� text, �ְ� ����

    //C : �ְ� ������ ����/�ҷ����⸦ ���� �����Ѵ�.
    //Save, Load
    public TextMeshProUGUI bestScoreText;
     int bestScore = 10;
    void Start()
    {
        // 2. ���� ��Ų ������ ȭ�鿡 ǥ��
        currentScoreText.text = "Score : " + currentScore;
        //2-1. �ְ� ���� �ҷ��´�(Load)
        bestScore = PlayerPrefs.GetInt("@Best_Score", 0);
        //2-2. �ְ� ������ ȭ�鿡 ǥ���Ѵ�.
        bestScoreText.text = "BestScore : " + bestScore;
        
    }

  
    void Update()
    {
        
    }
    
    public void SetScore(int value)
    {
        // 1. ������ ������Ų�� (+1)
        currentScore += value;
        // 1-1. currentScore = �������� +1
        // 2. ���� ��Ų ������ ȭ�鿡 ǥ��
        currentScoreText.text = "Score : " + currentScore;
        if (currentScore > bestScore) //3. ���� ���� ������ �ְ� ������ �Ѿ�ٸ�?
        {
            bestScore = currentScore; //4. ����� �ְ� ������ ���������� �����Ѵ�.
                                      //2-2. �ְ� ������ ȭ�鿡 ǥ���Ѵ�.
            bestScoreText.text = "BestScore : " + bestScore;
            //6. �ְ� ������ �����ϸ� Save
            PlayerPrefs.SetInt("@Best_Score", bestScore);
        }

        //3. levelmanager ������Ʈ�� �پ��ִ� levelmanager ���ӿ�����Ʈ�� �˾Ƴ���
        GameObject levelObj = GameObject.Find("Level Manager");
        //2. levelupsocre ������ ������ �ִ� levelmanager ������Ʈ�� �˾Ƴ���
        LevelManager lv = levelObj.GetComponent<LevelManager>();
        //1. levelupscore�� �� ������ �˰� �ʹ�
        //���� ������ levelUpScore�� ���� ���

        
        if (currentScore > lv.levelUpScore )
        {
            lv.Levelup();
            
            // level 1�� ������Ų��.
            // ������Ų level�� ȭ�鿡 ǥ��
        }

    }

    
}
