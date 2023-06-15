using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

//역할 : Enemy는 아래 방향으로 일정한 속도로 이동한다.
// 방향 (아래 vector.down)
// 속력 
// p = p0 +vt 

//역할 : Enemy와 Player가 충돌시 둘 다 Destroy

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int enemyHp = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
       
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        //물체 이름이 Missile 일 경우 파괴
        if (collision.gameObject.name.Contains("Missile"))
        {
            Destroy(collision.gameObject);
            enemyHp -= 1;
            Debug.Log("enemyHP:" + enemyHp);
            if (enemyHp <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.name.Equals("Player"))
        {
            //Debug.Log("collision");
            Destroy(collision.gameObject);
            Destroy(gameObject);   
        }
    }
}
