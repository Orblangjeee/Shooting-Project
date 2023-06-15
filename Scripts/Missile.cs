using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    
    // 1. ���ư��� �� ����
    // 2. ������ �̵� �ӷ�

    //���� : �̵� �ӷ� (�ʱⰪ = 3)

    
    public float speed = 3.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ư���� �������� ������ �ӷ����� �˾Ƽ� ���ư���. ����: Vector3.up/ �ӷ�: Speed/ P= P0+Vt
        transform.position = transform.position + Vector3.up * speed * Time.deltaTime;
        
    }
}
