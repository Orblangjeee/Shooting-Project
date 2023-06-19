using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

//역할 : Enemy는 아래 방향으로 일정한 속도로 이동한다.
// 방향 (아래 vector.down)
// 속력 
// p = p0 +vt 

//역할 : Enemy와 Player가 충돌시 둘 다 Destroy

//역할 : Enemy가 처음 생성될 때, 이동방식을 랜덤하게 지정
// 1. 아래로 이동 2. 타깃 이동 3. 랜덤 확률 50%

//역할 : Enemy의 이동방식에 따라 점수 스코어 다르게 지정
// 1. 어떤 이동 방식인지?
// 2. 아래로 이동 : Score +1 / Player를 향해 이동 : Score +3

public class Enemy : MonoBehaviour
{
   

    GameObject player; //타깃(Player)
    Vector3 direction; //이동 방향
    int moveState = -1; //이동 방식 0:Down, 1:player

    public float speed = 5f;
    public int enemyHp = 3;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); //plyer 게임 오브젝트 찾기

        //랜덤 : 100개의 숫자 중 1개 뽑기
        int randomNumber = Random.Range(0, 100);
        //뽑은 숫자 50보다 큰 경우 : 아래 이동 / 작은 경우 : 타겟 이동
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

        //player 적당히 따라가기
        /*if (transform.position.y >= player.transform.position.y)
        {
            //player(타깃) 방향으로 일정한 속도로 이동한다.
            //1. 어떤 방향으로 갈지 알아야 한다.
            //Player를 바라보는 방향(Player 위치 - Enemy 위치)
            direction = player.transform.position - transform.position;
            //1-1. 방향 벡터의 크기를 1로 맞춘다. (속도 일정하게)
            direction.Normalize();
            //2. 해당 방향으로 일정한 속력으로 이동한다.
        }*/
    }



    private void OnCollisionEnter(Collision collision)
    {
        //물체 이름이 Missile 일 경우 파괴
        if (collision.gameObject.name.Contains("Missile"))
        {

            // A: 이동이 down 이면 +1
            // B: 이동이 Player 이면 +3

            Destroy(collision.gameObject);
            enemyHp -= 1;
            Debug.Log("enemyHP:" + enemyHp);
            if (enemyHp <= 0)
            {
                Destroy(gameObject);
                
                // 0-3. ScoreManager.cs 컴포넌트를 가지고 있는 GameObject를 찾는다.
                GameObject smObj = GameObject.Find("Score Manager");
                // 0-2. SetScore()를 가지고 있는 ScoreManager 컴포넌트를 찾는다.
                ScoreManager sm = smObj.GetComponent<ScoreManager>();
                if (moveState == 0)
                {
                    
                    // 0-1. SetScore 실행 // 0. 현재 점수 +1 증가
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
