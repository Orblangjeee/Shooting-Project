using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

//역할1 : Player가 Enemy를 잡아서 일정 score를 넘기면 Level을 올린다.
//현재레벨, 현재점수, 레벨에 따른 충족점수, 화면에 표시할 text

//역할2 : level에 따라서 enemycreator의 생성속도와 enemy 이동속도를 올린다.
//enemycreator의 생성속도를 level에 따라 일정 비율로 변화


public class LevelManager : MonoBehaviour
{
    public int level = 1;
    public int levelUpScore = 10;
    public TextMeshProUGUI levelText;
    int originUpScore;
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

    public void Levelup()
    {
        level++;
        levelText.text = "Lv."+ level;
        levelUpScore = originUpScore * level;
        //level이 증가한 만큼 levelupscore도 증가

        //4. enemycreator의 생성속도를 level에 따라 감소시킨다.

        GameObject[] enemyCreators = GameObject.FindGameObjectsWithTag("EnemyCreator");   //4-1. "EnemyCreator" tag가 달린 모든 gameobject 모두 검색
        for (int i = 0; i < enemyCreators.Length; i++)
        {
            EnemyCreator ecs = enemyCreators[i].GetComponent<EnemyCreator>(); //4-2. 검색한 Creator 들이 가진 EnemyCreator.cs 컴포넌트에 접근
            ecs.DecreaseCreateTime(); // 4-3. 각 EnemyCreator.cs 컴포넌트의 생성시간 감소 함수를 호출
        }

        /*
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
        */

    }

    
}
