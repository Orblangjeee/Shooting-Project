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


//���� : Enemy�� �̵��ӵ��� ������Ŵ
public class Enemy : MonoBehaviour
{
   

    GameObject player; //Ÿ��(Player)
    Vector3 direction; //�̵� ����
    int moveState = -1; //�̵� ��� 0:Down, 1:player

    
    public float speed = 5f;
    public int enemyHp = 3;
    public int minusHp = -1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); //plyer ���� ������Ʈ ã��
        //���� : player�� �ı��Ǹ� player�� ���� ���ư��� enemy�� �� ���� ����
        //�ذ� : ���� player�� ã�Ҵµ� ���ٸ� ���� ���� ���� down �������� ���ư��� �����.
        // 1. player ������ ����ִٸ� ?
        // 2. direction �� down ���� ���ش�
        
        if (player == null)
        {
            direction = Vector3.down;

            return; //�ڵ� ���������� != null
        }
        
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
            // �ε��� plyaer HP ����
            PlayerHealth playhp = player.GetComponent<PlayerHealth>();
            playhp.SetHP(minusHp);

            //
            Destroy(gameObject);   
        }
    }

    //Enemy �̵��ӵ� ����
    public void SpeedUp()
    {
       
        GameObject lmObj = GameObject.Find("Level Manager");
        LevelManager lm = lmObj.GetComponent<LevelManager>();
        //���� level�� ����? �����;���

        //[����ڵ�] ���� level:2 �̻��� ��쿡�� ���ǵ带 �ø���.
        // ���� level:1 �ʰ��� ��쿡�� ���ǵ带 �ø���.
        if (lm.level > 1)
        {
            //Level�� ������ ��ŭ speed�� �ø���.
            speed = speed + lm.level;
        }
        
    }
}
