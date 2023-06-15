using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

//���� : Enemy�� �Ʒ� �������� ������ �ӵ��� �̵��Ѵ�.
// ���� (�Ʒ� vector.down)
// �ӷ� 
// p = p0 +vt 

//���� : Enemy�� Player�� �浹�� �� �� Destroy

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
        //��ü �̸��� Missile �� ��� �ı�
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
