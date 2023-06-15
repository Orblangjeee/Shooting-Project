using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    
    // 1. 날아가게 할 방향
    // 2. 일정한 이동 속력

    //변수 : 이동 속력 (초기값 = 3)

    
    public float speed = 3.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 특정한 방향으로 일정한 속력으로 알아서 날아간다. 방향: Vector3.up/ 속력: Speed/ P= P0+Vt
        transform.position = transform.position + Vector3.up * speed * Time.deltaTime;
        
    }
}
