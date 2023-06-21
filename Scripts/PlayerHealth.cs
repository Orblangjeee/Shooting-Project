using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//역할 : Player의 HP 관리
//player hp, 표시할 text
//enemy와 부딪히면 hp -1
// hp가 0이 되면 player 파괴
// player 파괴 시, 특수효과 재생(만듦, 위치)
// 특수효과 이펙트 공장
public class PlayerHealth : MonoBehaviour
{
    public GameObject destroyEffectFactory; //특수효과 이펙트 공장


    public int hp = 5;
    public TextMeshProUGUI hpText;
    // Start is called before the first frame update
    void Start()
    {
        //현재 HP를 화면에 표시해준다
        hpText.text = "Player HP : " + hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //HP 세팅
    public void SetHP(int value)
    {
        // 1. 현재 Hp에서 value만큼 증가/감소 시킴
        hp = hp + value;
        // 2. 증가/감소시킨 Hp를 화면에 표시
        hpText.text = "Player Hp : " + hp;

        if (hp < 1)
        {
            GameManager.Instance.Restart();

            GameObject effect = Instantiate(destroyEffectFactory);
            effect.transform.position = transform.position;

            //Restart

           

            Destroy(gameObject); //destroy는 마지막에
        }
    }
}
