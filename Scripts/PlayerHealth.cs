using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//���� : Player�� HP ����
//player hp, ǥ���� text
//enemy�� �ε����� hp -1
// hp�� 0�� �Ǹ� player �ı�
// player �ı� ��, Ư��ȿ�� ���(����, ��ġ)
// Ư��ȿ�� ����Ʈ ����
public class PlayerHealth : MonoBehaviour
{
    public GameObject destroyEffectFactory; //Ư��ȿ�� ����Ʈ ����


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
            GameManager.Instance.Restart();

            GameObject effect = Instantiate(destroyEffectFactory);
            effect.transform.position = transform.position;

            //Restart

           

            Destroy(gameObject); //destroy�� ��������
        }
    }
}
