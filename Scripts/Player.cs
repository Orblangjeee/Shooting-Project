using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    //Ű���� Ư�� Ű�� �Է����� ��,


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // ver.old Player ������ �ڵ�
    void OldPlayerMove()
    {
        if (Input.GetKey(KeyCode.W)) //Ư��Ű �Է����� ��
        {
            // ��ü�� Ư���� �������� �̵���Ű�� �ʹ�.
            //��ü �̵� ���� : Vector3.up (��) , �ӷ�: 1.5f
            // P = P0 + Vt (Position ��ġ, Velocity �ӷ�, time �ð�)
            transform.position = transform.position + Vector3.up * speed * Time.deltaTime;
        }

        //Ű������ SŰ�� ������ ����, �Ʒ� �������� �̵�
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + Vector3.down * speed * Time.deltaTime;
        }
        //Ű������ AŰ�� ������ ����, ���� �������� �̵�
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        }
        //Ű������ DŰ�� ������ ����, ������ �������� �̵�
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
        }

        //Ű������ ����Ű�� Ư�� ���� �̵�
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
        //������� �Է°��� �޾Ƽ� �̵������ �̵��ӵ��� �����ϰ� �ʹ�.
        //1. ������� �Է��� �޴´� (1. ��/�� 2. ��/��)
        float vertical = Input.GetAxis("Vertical"); //����
        float horizontal = Input.GetAxis("Horizontal"); //�¿�
       
        //2. �Է°��� �������� �̵������� �����Ѵ�. 3dimension
       // (x,y,z) -> (�¿��Է�, �����Է�, 0)
       Vector3 direction = new Vector3(horizontal, vertical, 0);
       
        //3. �̵������� Ȱ���ؼ� �ش� �������� ���� �ӵ���ŭ �����δ�.
        // P = P0 + Vt
        transform.position = transform.position + direction * speed * Time.deltaTime;
    }

   
}
