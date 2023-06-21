using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

//역할1 : Player가 Enemy를 잡아서 일정 score를 넘기면 Level을 올린다.
//현재레벨, 현재점수, 레벨에 따른 충족점수, 화면에 표시할 text

//역할2 : level에 따라서 enemycreator의 생성속도와 enemy 이동속도를 올린다.
//enemycreator의 생성속도를 level에 따라 일정 비율로 변화
//enemy 이동속도를 level에 따라 일정 비율로 변화

//singleton 으로 만들어 관리

public class LevelManager : MonoBehaviour
{
    //singleton 용 인스턴스 1개 필요
    public static LevelManager Instance = null;

    public int level = 1;
    public int levelUpScore = 10;
    public TextMeshProUGUI levelText;
    int originUpScore;

    private void Awake()
    { //만일 singleton용 인스턴스가 비어있다면 singleton 용 인스턴스에 나 자신을 넣어준다
        if (Instance == null) { Instance = this; }
    }

    // Start is called before the first frame update
    void Start()
    {
        originUpScore = levelUpScore;
        levelText.text = "Lv." + level;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public void Levelup()
    {
        GameObject enemyCreator = GameObject.Find("Enemy Creator");
        EnemyCreator ec = enemyCreator.GetComponent<EnemyCreator>();
        ec.DecreaseCreateTime();
        GameObject enemyCreator1 = GameObject.Find("Enemy Creator (1)");
        EnemyCreator ec1 = enemyCreator1.GetComponent<EnemyCreator>();
        ec1.DecreaseCreateTime();
        GameObject enemyCreator2 = GameObject.Find("Enemy Creator (2)");
        EnemyCreator ec2 = enemyCreator2.GetComponent<EnemyCreator>();
        ec2.DecreaseCreateTime();
        GameObject enemyCreator3 = GameObject.Find("Enemy Creator (3)");
        EnemyCreator ec3 = enemyCreator3.GetComponent<EnemyCreator>();
        ec3.DecreaseCreateTime();
    }
    */
    
   

    //A. 레벨 Up & 다음 Level Score 갱신
    void LevelUp() //level이 증가한 만큼 levelupscore도 증가
    {
        level++;
        levelText.text = "Lv." + level;
        levelUpScore = originUpScore * level;
        

    }
    //B. EnemyCreator 생성속도 감소
    void IncreaseCreateEnemy() //4. enemycreator의 생성속도를 level에 따라 감소시킨다.
    {
                GameObject[] enemyCreators = GameObject.FindGameObjectsWithTag("EnemyCreator");   //4-1. "EnemyCreator" tag가 달린 모든 gameobject 모두 검색
        for (int i = 0; i < enemyCreators.Length; i++)
        {
            EnemyCreator ecs = enemyCreators[i].GetComponent<EnemyCreator>(); //4-2. 검색한 Creator 들이 가진 EnemyCreator.cs 컴포넌트에 접근
            ecs.DecreaseCreateTime(); // 4-3. 각 EnemyCreator.cs 컴포넌트의 생성시간 감소 함수를 호출
        }
    }
    //C. Enemy 이동속도 증가
    void IncreaseEnemySpeed() //5. 레벨업 시, 이미 만들어져있는 enemy와 신규 enemy의 속도가 다름 -> 신규 enemy의 속도도 올려주기
    {
        //-1. 이미 만들어져 Hierarchy에 있는 enemy들을 tag로 모두 검색
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemys.Length; i++)
        {
            //-2. 해당 enemy들이 가지고 있는 enemy 컴포넌트 각각 접근
            Enemy enemy = enemys[i].GetComponent<Enemy>();
            //-3. enemy 컴포넌트가 가지고 있는 speedUp() 함수 각각 호출
            enemy.SpeedUp();
        }
    }

    public void UpdateLevel()
    {
        LevelUp(); //레벨증가
        IncreaseCreateEnemy(); //Enemy 생성속도 증가
        IncreaseEnemySpeed(); //Enemy 이동속도 증가

    }

}

   



