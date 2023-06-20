using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

//���� : �����ð����� Enemy �ֱ������� �����Ѵ�.
// ���� ��ġ, ���� �ð�, ������� ��ü

//���� : level�� ���߾� �����ӵ��� �����ϰ� ����
// �����ϰ� ������ ���� : 10% 


public class EnemyCreator : MonoBehaviour
{
    public GameObject enemyFectory; //������� ��ü
    public float createTime = 3.0f; //���� �ð�
    float currentTime; //��� �ð�
    public float decreaseTimeRate = 0.1f;// �����ϰ� ������ ���� : 10% 
    public float stopdecrease =1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�����ð����� Enemy�� �ֱ������� ����
        
   
        currentTime += Time.deltaTime; //3. �ð��� ����Ѵ�.
        if ( currentTime > createTime) //2. ����ð��� �����ð� �Ǿ��� ��
        {   
            GameObject enemy = Instantiate(enemyFectory); //1. Enemy�� �����Ѵ�.
            enemy.transform.position = transform.position; //������ Enemy�� ���� ��ġ�� �Űܳ��´�.
                                                           //Enemy.cs ������Ʈ �˱�
            Enemy enemyComp = enemy.GetComponent<Enemy>();
            enemyComp.SpeedUp();

            currentTime = 0f; //0. ��� �ð��� 0���� �ʱ�ȭ
     
         
        }

    }

    
    public void DecreaseCreateTime()
    {
        // [������ġ]
        // createTime�� 1�ʺ��� ū ��쿡�� �ð��� ���ҽ�Ų��.
        // ���� �ð� ���Ϸ� ��������
        //1�� --> ������ ���� inspectorâ���� ����
        if (createTime > stopdecrease)
        {
            
            //4-3-1. ���� creatime�� 10%�� ���ҽ�Ű��
            float decresedTime = createTime * (1 - decreaseTimeRate);
            //float decreaseTime = createTime * 0.9f;
            //4-3-2. ���ҽ�Ų �ð��� creatime���� �����Ѵ�.
            createTime = decresedTime;
            

           
        }

       
    }
}
