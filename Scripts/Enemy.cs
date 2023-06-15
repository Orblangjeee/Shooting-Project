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

public class Enemy : MonoBehaviour
{
   

    GameObject player; //Ÿ��(Player)
    Vector3 direction; //�̵� ����

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
        }
        if (randomNumber < 50)
        {
            direction = player.transform.position - transform.position;
            direction.Normalize();
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
                // 0-1. SetScore ���� // 0. ���� ���� +1 ����
                sm.SetScore();
            }
        }
        if (collision.gameObject.name.Equals("Player"))
        {            
            //Destroy(collision.gameObject);
            Destroy(gameObject);   
        }
    }
}
