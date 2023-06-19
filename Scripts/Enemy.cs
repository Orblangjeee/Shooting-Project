using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

//���� : Enemy�� �Ʒ� �������� ������ �ӵ��� �̵��Ѵ�.
// ���� (�Ʒ� vector.down)
// �ӷ� 
// p = p0 +vt 

//���� : Enemy�� Player�� �浹�� �� �� Destroy

//���� : Enemy�� ó�� ������ ��, �̵������ �����ϰ� ����
// 1. �Ʒ��� �̵� 2. Ÿ�� �̵� 3. ���� Ȯ�� 50%

//���� : Enemy�� �̵���Ŀ� ���� ���� ���ھ� �ٸ��� ����
// 1. � �̵� �������?
// 2. �Ʒ��� �̵� : Score +1 / Player�� ���� �̵� : Score +3

public class Enemy : MonoBehaviour
{
   

    GameObject player; //Ÿ��(Player)
    Vector3 direction; //�̵� ����
    int moveState = -1; //�̵� ��� 0:Down, 1:player

    public float speed = 5f;
    public int enemyHp = 3;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); //plyer ���� ������Ʈ ã��

        //���� : 100���� ���� �� 1�� �̱�
        int randomNumber = Random.Range(0, 100);
        //���� ���� 50���� ū ��� : �Ʒ� �̵� / ���� ��� : Ÿ�� �̵�
        if (randomNumber >= 50)
        {
            direction = Vector3.down;
            moveState = 0;
        }
        if (randomNumber < 50)
        {
            direction = player.transform.position - transform.position;
            direction.Normalize();
            moveState = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position += Vector3.down * speed * Time.deltaTime;

        transform.position += direction * speed * Time.deltaTime;

        //player ������ ���󰡱�
        /*if (transform.position.y >= player.transform.position.y)
        {
            //player(Ÿ��) �������� ������ �ӵ��� �̵��Ѵ�.
            //1. � �������� ���� �˾ƾ� �Ѵ�.
            //Player�� �ٶ󺸴� ����(Player ��ġ - Enemy ��ġ)
            direction = player.transform.position - transform.position;
            //1-1. ���� ������ ũ�⸦ 1�� �����. (�ӵ� �����ϰ�)
            direction.Normalize();
            //2. �ش� �������� ������ �ӷ����� �̵��Ѵ�.
        }*/
    }



    private void OnCollisionEnter(Collision collision)
    {
        //��ü �̸��� Missile �� ��� �ı�
        if (collision.gameObject.name.Contains("Missile"))
        {

            // A: �̵��� down �̸� +1
            // B: �̵��� Player �̸� +3

            Destroy(collision.gameObject);
            enemyHp -= 1;
            Debug.Log("enemyHP:" + enemyHp);
            if (enemyHp <= 0)
            {
                Destroy(gameObject);
                
                // 0-3. ScoreManager.cs ������Ʈ�� ������ �ִ� GameObject�� ã�´�.
                GameObject smObj = GameObject.Find("Score Manager");
                // 0-2. SetScore()�� ������ �ִ� ScoreManager ������Ʈ�� ã�´�.
                ScoreManager sm = smObj.GetComponent<ScoreManager>();
                if (moveState == 0)
                {
                    
                    // 0-1. SetScore ���� // 0. ���� ���� +1 ����
                    sm.SetScore(1);
                }
                if (moveState == 1)
                {
                    
                    sm.SetScore(3);
                }
               
                
                
            }
        }
        if (collision.gameObject.name.Equals("Player"))
        {            
            //Destroy(collision.gameObject);
            Destroy(gameObject);   
        }
    }
}
