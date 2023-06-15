using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    //키보드 특정 키를 입력했을 때,


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // ver.old Player 움직임 코드
    void OldPlayerMove()
    {
        if (Input.GetKey(KeyCode.W)) //특정키 입력했을 때
        {
            // 물체를 특정한 방향으로 이동시키고 싶다.
            //물체 이동 방향 : Vector3.up (위) , 속력: 1.5f
            // P = P0 + Vt (Position 위치, Velocity 속력, time 시간)
            transform.position = transform.position + Vector3.up * speed * Time.deltaTime;
        }

        //키보드의 S키를 누르는 동안, 아래 방향으로 이동
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + Vector3.down * speed * Time.deltaTime;
        }
        //키보드의 A키를 누르는 동안, 왼쪽 방향으로 이동
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        }
        //키보드의 D키를 누르는 동안, 오른쪽 방향으로 이동
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
        }

        //키보드의 방향키로 특정 방향 이동
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = transform.position + Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Key binding
        //사용자의 입력값을 받아서 이동방향과 이동속도를 결정하고 싶다.
        //1. 사용자의 입력을 받는다 (1. 상/하 2. 좌/우)
        float vertical = Input.GetAxis("Vertical"); //상하
        float horizontal = Input.GetAxis("Horizontal"); //좌우
       
        //2. 입력값을 바탕으로 이동방향을 결정한다. 3dimension
       // (x,y,z) -> (좌우입력, 상하입력, 0)
       Vector3 direction = new Vector3(horizontal, vertical, 0);
       
        //3. 이동공식을 활용해서 해당 방향으로 일정 속도만큼 움직인다.
        // P = P0 + Vt
        transform.position = transform.position + direction * speed * Time.deltaTime;
    }

   
}
