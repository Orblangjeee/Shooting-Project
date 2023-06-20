using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//���� : Player�� HP ����
//player hp, ǥ���� text
//enemy�� �ε����� hp -1
// hp�� 0�� �Ǹ� player �ı�

public class PlayerHealth : MonoBehaviour
{
    public int hp = 5;
    public TextMeshProUGUI hpText;
    // Start is called before the first frame update
    void Start()
    {
        //���� HP�� ȭ�鿡 ǥ�����ش�
        hpText.text = "Player HP : " + hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //HP ����
    public void SetHP(int value)
    {
        // 1. ���� Hp���� value��ŭ ����/���� ��Ŵ
        hp = hp + value;
        // 2. ����/���ҽ�Ų Hp�� ȭ�鿡 ǥ��
        hpText.text = "Player Hp : " + hp;

        if (hp < 1)
        {
            
            //Restart
            GameObject gmObj = GameObject.Find("GM");
            GameManager gm = gmObj.GetComponent<GameManager>();
            gm.Restart();

            Destroy(gameObject); //destroy�� ��������
        }
    }
}
