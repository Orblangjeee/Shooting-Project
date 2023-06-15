using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

//역할 : 일정시간마다 Enemy 주기적으로 생성한다.
// 생성 위치, 일정 시간, 만들어질 물체

public class EnemyCreator : MonoBehaviour
{
    public GameObject enemyFectory; //만들어질 물체
    public float createTime = 3.0f; //생성 시간
    float currentTime; //경과 시간
    
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
            Instantiate(enemyFectory); //1. Enemy를 생성한다.
            enemyFectory.transform.position = transform.position; //생성한 Enemy를 생성 위치에 옮겨놓는다.
            currentTime = 0f;
            
        }
        //0. 경과 시간을 0으로 초기화
    }
}
