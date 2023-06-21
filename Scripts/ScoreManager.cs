using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;


    //역할 : 점수를 관리
    //A : Enemy 잡을 때 마다 점수 획득, 화면에 표시
    // 화면 표시 text, 점수
    public TextMeshProUGUI currentScoreText;
    public int currentScore = 0;
    public int movescore = 0;
    //B : 현재 점수가 저장된 최고 점수를 넘겼다면 갱신하여 표시
    // 화면 표시 text, 최고 점수

    //C : 최고 점수를 저장/불러오기를 통해 관리한다.
    //Save, Load
    public TextMeshProUGUI bestScoreText;
     int bestScore = 10;
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
    }

    void Start()
    {
        // 2. 증가 시킨 점수를 화면에 표시
        currentScoreText.text = "Score : " + currentScore;
        //2-1. 최고 점수 불러온다(Load)
        bestScore = PlayerPrefs.GetInt("@Best_Score", 0);
        //2-2. 최고 점수를 화면에 표시한다.
        bestScoreText.text = "BestScore : " + bestScore;
        
    }

  
    void Update()
    {
        
    }
    
    public void SetScore(int value)
    {
        // 1. 점수를 증가시킨다 (+1)
        currentScore += value;
        // 1-1. currentScore = 현재점수 +1
        // 2. 증가 시킨 점수를 화면에 표시
        currentScoreText.text = "Score : " + currentScore;
        if (currentScore > bestScore) //3. 만약 현재 점수가 최고 점수를 넘어선다면?
        {
            bestScore = currentScore; //4. 저장된 최고 점수를 현재점수로 갱신한다.
                                      //2-2. 최고 점수를 화면에 표시한다.
            bestScoreText.text = "BestScore : " + bestScore;
            //6. 최고 점수를 갱신하면 Save
            PlayerPrefs.SetInt("@Best_Score", bestScore);
        }

        //3. levelmanager 컴포넌트가 붙어있는 levelmanager 게임오브젝트를 알아낸다
        //GameObject levelObj = GameObject.Find("Level Manager");
        //2. levelupsocre 변수를 가지고 있는 levelmanager 컴포넌트를 알아낸다
        //LevelManager lv = levelObj.GetComponent<LevelManager>();
        //1. levelupscore가 몇 점인지 알고 싶다
        //현재 점수가 levelUpScore을 넘은 경우

        
        if (currentScore > LevelManager.Instance.levelUpScore )
        {
            LevelManager.Instance.UpdateLevel();
            
            // level 1을 증가시킨다.
            // 증가시킨 level을 화면에 표시
        }

    }

    
}
