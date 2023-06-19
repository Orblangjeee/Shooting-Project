using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

//����1 : Player�� Enemy�� ��Ƽ� ���� score�� �ѱ�� Level�� �ø���.
//���緹��, ��������, ������ ���� ��������, ȭ�鿡 ǥ���� text

//����2 : level�� ���� enemycreator�� �����ӵ��� enemy �̵��ӵ��� �ø���.
//enemycreator�� �����ӵ��� level�� ���� ���� ������ ��ȭ


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
        //level�� ������ ��ŭ levelupscore�� ����

        //4. enemycreator�� �����ӵ��� level�� ���� ���ҽ�Ų��.

        GameObject[] enemyCreators = GameObject.FindGameObjectsWithTag("EnemyCreator");   //4-1. "EnemyCreator" tag�� �޸� ��� gameobject ��� �˻�
        for (int i = 0; i < enemyCreators.Length; i++)
        {
            EnemyCreator ecs = enemyCreators[i].GetComponent<EnemyCreator>(); //4-2. �˻��� Creator ���� ���� EnemyCreator.cs ������Ʈ�� ����
            ecs.DecreaseCreateTime(); // 4-3. �� EnemyCreator.cs ������Ʈ�� �����ð� ���� �Լ��� ȣ��
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