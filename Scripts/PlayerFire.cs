using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� : ����ڰ� Ư�� ��ư(space)�� ������, Ư�� ��ġ���� Missile�� �߻��Ѵ�.
// missile ���� ��ġ : Player ��ġ
// missile ���� : form prefab -> �̻��� ����


public class PlayerFire : MonoBehaviour
{
    //1. �̻��� ����
    public GameObject missileFactory;
    //2. �̻��� ���� ��ġ (Player ��ġ)
    public GameObject firePos;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //4. when? ���� ��ư�� ������ ��
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            //3. �� ��ġ�� �Ѿ��� �����.
            //3-1. ��ġ�� ��� �ľ�
            //3-2. �̻��� ����
            GameObject missile = Instantiate(missileFactory);
            //3-3. �̻��� ��ġ�� �Űܳ���
            missile.transform.position = firePos.transform.position;

            //Instantiate(missileFactory, firePos.transform); 
        }
        
    }
}
