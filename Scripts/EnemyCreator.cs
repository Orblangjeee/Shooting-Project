using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

//역할 : 일정시간마다 Enemy 주기적으로 생성한다.
// 생성 위치, 일정 시간, 만들어질 물체

//역할 : level에 맞추어 생성속도를 일정하게 감소
// 일정하게 감소할 비율 : 10% 


public class EnemyCreator : MonoBehaviour
{
    public GameObject enemyFectory; //만들어질 물체
    public float createTime = 3.0f; //생성 시간
    float currentTime; //경과 시간
    public float decreaseTimeRate = 0.1f;// 일정하게 감소할 비율 : 10% 
    public float stopdecrease =1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //일정시간마다 Enemy를 주기적으로 생성
        
   
        currentTime += Time.deltaTime; //3. 시간이 경과한다.
        if ( currentTime > createTime) //2. 경과시간이 일정시간 되었을 때
        {   
            GameObject enemy = Instantiate(enemyFectory); //1. Enemy를 생성한다.
            enemy.transform.position = transform.position; //생성한 Enemy를 생성 위치에 옮겨놓는다.
                                                           //Enemy.cs 컴포넌트 알기
            Enemy enemyComp = enemy.GetComponent<Enemy>();
            enemyComp.SpeedUp();

            currentTime = 0f; //0. 경과 시간을 0으로 초기화
     
         
        }

    }

    
    public void DecreaseCreateTime()
    {
        // [안전장치]
        // createTime이 1초보다 큰 경우에만 시간을 감소시킨다.
        // 일정 시간 이하로 못내려감
        //1초 --> 변수로 만들어서 inspector창에서 관리
        if (createTime > stopdecrease)
        {
            
            //4-3-1. 현재 creatime의 10%를 감소시키고
            float decresedTime = createTime * (1 - decreaseTimeRate);
            //float decreaseTime = createTime * 0.9f;
            //4-3-2. 감소시킨 시간을 creatime으로 갱신한다.
            createTime = decresedTime;
            

           
        }

       
    }
}
