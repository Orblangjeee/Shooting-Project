using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//역할 : 일정한 속도로 배경 스크롤(-y)

public class BG : MonoBehaviour
{
    public float speed = 0.7f;
    Material bgMat;

    // Start is called before the first frame update
    void Start()
    {
        // Plane에 붙어있는 MeshRenderer 컴포넌트 접근
        MeshRenderer mr = GetComponent<MeshRenderer>();
        // MeshRenderer가 갖고 있는 Material 소환
        bgMat = mr.material;
    }

    // Update is called once per frame
    void Update()
    {
        //1. Material-offset 접근
        //2. -y 방향으로 : Vector2.down
        //배경 위치 = 현재 배경위치 + 속도 * 방향 * 시간

        //bgMat.mainTextureOffset = bgMat.mainTextureOffset + speed * Vector2.down *Time.deltaTime;
        bgMat.mainTextureOffset += speed * Vector2.down * Time.deltaTime;
    }
}
