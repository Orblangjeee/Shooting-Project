using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//역할 : Enemy는 아래 방향으로 일정한 속도로 이동한다.
// 방향 (아래 vector.down)
// 속력 
// p = p0 +vt 

//역할 : Enemy와 Player가 충돌시 둘 다 Destroy
// player랑 부딪혔을 때 특수효과

//역할 : Enemy가 처음 생성될 때, 이동방식을 랜덤하게 지정
// 1. 아래로 이동 2. 타깃 이동 3. 랜덤 확률 50%

//역할 : Enemy의 이동방식에 따라 점수 스코어 다르게 지정
// 1. 어떤 이동 방식인지?
// 2. 아래로 이동 : Score +1 / Player를 향해 이동 : Score +3


//역할 : Enemy의 이동속도를 증가시킴
public class Enemy : MonoBehaviour
{
   

    GameObject player; //타깃(Player)
    Vector3 direction; //이동 방향
    int moveState = -1; //이동 방식 0:Down, 1:player

    
    public float speed = 5f;
    public int enemyHp = 3;
    public int minusHp = -1;

    //특수효과
    public GameObject missileEffectFactory; //미사일이랑 enemy가 부딪힐 때
    public GameObject playerEffectFactory; // 플레이어가 enemy랑 부딪힐 때

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); //plyer 게임 오브젝트 찾기
        //문제 : player가 파괴되면 player를 향해 날아가는 enemy가 갈 곳을 잃음
        //해결 : 만약 player를 찾았는데 없다면 숫자 뽑지 말고 down 방향으로 날아가게 만든다.
        // 1. player 변수가 비어있다면 ?
        // 2. direction 을 down 으로 해준다
        
        if (player == null)
        {
            direction = Vector3.down;

            return; //코드 빠져나오기 != null
        }
        
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
            //타겟 방향으로 Enemy 회전
            // Enemy의 기준 방향인 Y축 방향을 타깃방향과 같게 한다.

            transform.up  = -1 * direction;

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
           
            if (enemyHp <= 0)
            {
                
                
                // 0-3. ScoreManager.cs 컴포넌트를 가지고 있는 GameObject를 찾는다.
                //GameObject smObj = GameObject.Find("Score Manager");
                // 0-2. SetScore()를 가지고 있는 ScoreManager 컴포넌트를 찾는다.
                //ScoreManager sm = smObj.GetComponent<ScoreManager>();
                if (moveState == 0)
                {
                    // 0-1. SetScore 실행 // 0. 현재 점수 +1 증가
                    ScoreManager.Instance.SetScore(1);
                }
                if (moveState == 1)
                {
                    ScoreManager.Instance.SetScore(3);
                }

                //미사일이랑 부딪힌 특수효과 실행
                // 1. 미사일 특수효과를 만든다
                GameObject missilefx = Instantiate(missileEffectFactory);
                missilefx.transform.position = transform.position;
                //2. 미사일 특수효과 위치를 옮긴다. -> Enemy 위치 = 나자신의 위치
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.name.Equals("Player"))
        {
            // 부딪힌 plyaer HP 감소
            PlayerHealth playhp = player.GetComponent<PlayerHealth>();
            playhp.SetHP(minusHp);

            GameObject effect = Instantiate(playerEffectFactory);
            effect.transform.position = transform.position;

            
            Destroy(gameObject);   
        }
    }

    //Enemy 이동속도 증가
    public void SpeedUp()
    {
        
        GameObject lmObj = GameObject.Find("Level Manager");
        LevelManager lm = lmObj.GetComponent<LevelManager>();
        //현재 level이 뭐지? 가져와야행

        //[방어코드] 현재 level:2 이상인 경우에만 스피드를 올린다.
        // 현재 level:1 초과인 경우에만 스피드를 올린다.
        if (lm.level > 1)
        {
            
            //Level이 증가한 만큼 speed를 올린다.
            speed += lm.level;
            
        }
        
    }
}
