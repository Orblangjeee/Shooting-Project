using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� : ������ �ӵ��� ��� ��ũ��(-y)

public class BG : MonoBehaviour
{
    public float speed = 0.7f;
    Material bgMat;

    // Start is called before the first frame update
    void Start()
    {
        // Plane�� �پ��ִ� MeshRenderer ������Ʈ ����
        MeshRenderer mr = GetComponent<MeshRenderer>();
        // MeshRenderer�� ���� �ִ� Material ��ȯ
        bgMat = mr.material;
    }

    // Update is called once per frame
    void Update()
    {
        //1. Material-offset ����
        //2. -y �������� : Vector2.down
        //��� ��ġ = ���� �����ġ + �ӵ� * ���� * �ð�

        //bgMat.mainTextureOffset = bgMat.mainTextureOffset + speed * Vector2.down *Time.deltaTime;
        bgMat.mainTextureOffset += speed * Vector2.down * Time.deltaTime;
    }
}
