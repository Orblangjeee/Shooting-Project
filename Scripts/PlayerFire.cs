using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 역할 : 사용자가 특정 버튼(space)을 누르면, 특정 위치에서 Missile을 발사한다.
// missile 생성 위치 : Player 위치
// missile 생성 : form prefab -> 미사일 공장


public class PlayerFire : MonoBehaviour
{
    //1. 미사일 공장
    public GameObject missileFactory;
    //2. 미사일 생성 위치 (Player 위치)
    public GameObject firePos;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //4. when? 내가 버튼을 눌렀을 때
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            //3. 그 위치에 총알을 만든다.
            //3-1. 위치할 장소 파악
            //3-2. 미사일 생성
            GameObject missile = Instantiate(missileFactory);
            //3-3. 미사일 위치에 옮겨놓기
            missile.transform.position = firePos.transform.position;

            //Instantiate(missileFactory, firePos.transform); 
        }
        
    }
}
