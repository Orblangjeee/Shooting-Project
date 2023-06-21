using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� : Enemy�� �Ʒ� �������� ������ �ӵ��� �̵��Ѵ�.
// ���� (�Ʒ� vector.down)
// �ӷ� 
// p = p0 +vt 

//���� : Enemy�� Player�� �浹�� �� �� Destroy
// player�� �ε����� �� Ư��ȿ��

//���� : Enemy�� ó�� ������ ��, �̵������ �����ϰ� ����
// 1. �Ʒ��� �̵� 2. Ÿ�� �̵� 3. ���� Ȯ�� 50%

//���� : Enemy�� �̵���Ŀ� ���� ���� ���ھ� �ٸ��� ����
// 1. � �̵� �������?
// 2. �Ʒ��� �̵� : Score +1 / Player�� ���� �̵� : Score +3


//���� : Enemy�� �̵��ӵ��� ������Ŵ
public class Enemy : MonoBehaviour
{
   

    GameObject player; //Ÿ��(Player)
    Vector3 direction; //�̵� ����
    int moveState = -1; //�̵� ��� 0:Down, 1:player

    
    public float speed = 5f;
    public int enemyHp = 3;
    public int minusHp = -1;

    //Ư��ȿ��
    public GameObject missileEffectFactory; //�̻����̶� enemy�� �ε��� ��
    public GameObject playerEffectFactory; // �÷��̾ enemy�� �ε��� ��

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); //plyer ���� ������Ʈ ã��
        //���� : player�� �ı��Ǹ� player�� ���� ���ư��� enemy�� �� ���� ����
        //�ذ� : ���� player�� ã�Ҵµ� ���ٸ� ���� ���� ���� down �������� ���ư��� �����.
        // 1. player ������ ����ִٸ� ?
        // 2. direction �� down ���� ���ش�
        
        if (player == null)
        {
            direction = Vector3.down;

            return; //�ڵ� ���������� != null
        }
        
            //���� : 100���� ���� �� 1�� �̱�
            int randomNumber = Random.Range(0, 100);
            //���� ���� 50���� ū ��� : �Ʒ� �̵� / ���� ��� : Ÿ�� �̵�
            if (randomNumber >= 50)
            {
                direction = Vector3.down;
                
                moveState = 0;
            }
            if (randomNumber < 50)
            {
                direction = player.transform.position - transform.position;
                direction.Normalize();
            //Ÿ�� �������� Enemy ȸ��
            // Enemy�� ���� ������ Y�� ������ Ÿ������ ���� �Ѵ�.

            transform.up  = -1 * direction;

                moveState = 1;
            }
        

    }

    // Update is called once per frame
    void Update()
    {
       // transform.position += Vector3.down * speed * Time.deltaTime;

        transform.position += direction * speed * Time.deltaTime;

        //player ������ ���󰡱�
        /*if (transform.position.y >= player.transform.position.y)
        {
            //player(Ÿ��) �������� ������ �ӵ��� �̵��Ѵ�.
            //1. � �������� ���� �˾ƾ� �Ѵ�.
            //Player�� �ٶ󺸴� ����(Player ��ġ - Enemy ��ġ)
            direction = player.transform.position - transform.position;
            //1-1. ���� ������ ũ�⸦ 1�� �����. (�ӵ� �����ϰ�)
            direction.Normalize();
            //2. �ش� �������� ������ �ӷ����� �̵��Ѵ�.
        }*/
    }



    private void OnCollisionEnter(Collision collision)
    {
        //��ü �̸��� Missile �� ��� �ı�
        if (collision.gameObject.name.Contains("Missile"))
        {

            // A: �̵��� down �̸� +1
            // B: �̵��� Player �̸� +3
           
            Destroy(collision.gameObject);
            enemyHp -= 1;
           
            if (enemyHp <= 0)
            {
                
                
                // 0-3. ScoreManager.cs ������Ʈ�� ������ �ִ� GameObject�� ã�´�.
                //GameObject smObj = GameObject.Find("Score Manager");
                // 0-2. SetScore()�� ������ �ִ� ScoreManager ������Ʈ�� ã�´�.
                //ScoreManager sm = smObj.GetComponent<ScoreManager>();
                if (moveState == 0)
                {
                    // 0-1. SetScore ���� // 0. ���� ���� +1 ����
                    ScoreManager.Instance.SetScore(1);
                }
                if (moveState == 1)
                {
                    ScoreManager.Instance.SetScore(3);
                }

                //�̻����̶� �ε��� Ư��ȿ�� ����
                // 1. �̻��� Ư��ȿ���� �����
                GameObject missilefx = Instantiate(missileEffectFactory);
                missilefx.transform.position = transform.position;
                //2. �̻��� Ư��ȿ�� ��ġ�� �ű��. -> Enemy ��ġ = ���ڽ��� ��ġ
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.name.Equals("Player"))
        {
            // �ε��� plyaer HP ����
            PlayerHealth playhp = player.GetComponent<PlayerHealth>();
            playhp.SetHP(minusHp);

            GameObject effect = Instantiate(playerEffectFactory);
            effect.transform.position = transform.position;

            
            Destroy(gameObject);   
        }
    }

    //Enemy �̵��ӵ� ����
    public void SpeedUp()
    {
        
        GameObject lmObj = GameObject.Find("Level Manager");
        LevelManager lm = lmObj.GetComponent<LevelManager>();
        //���� level�� ����? �����;���

        //[����ڵ�] ���� level:2 �̻��� ��쿡�� ���ǵ带 �ø���.
        // ���� level:1 �ʰ��� ��쿡�� ���ǵ带 �ø���.
        if (lm.level > 1)
        {
            
            //Level�� ������ ��ŭ speed�� �ø���.
            speed += lm.level;
            
        }
        
    }
}
