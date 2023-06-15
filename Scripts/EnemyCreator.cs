using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

//���� : �����ð����� Enemy �ֱ������� �����Ѵ�.
// ���� ��ġ, ���� �ð�, ������� ��ü

public class EnemyCreator : MonoBehaviour
{
    public GameObject enemyFectory; //������� ��ü
    public float createTime = 3.0f; //���� �ð�
    float currentTime; //��� �ð�
    
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
            Instantiate(enemyFectory); //1. Enemy�� �����Ѵ�.
            enemyFectory.transform.position = transform.position; //������ Enemy�� ���� ��ġ�� �Űܳ��´�.
            currentTime = 0f;
            
        }
        //0. ��� �ð��� 0���� �ʱ�ȭ
    }
}
