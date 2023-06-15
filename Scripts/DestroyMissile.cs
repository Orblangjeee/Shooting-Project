using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 역할 : Destroy 영역 안에 들어온 물체 제거
// Destroy 영역 (Trigger)
// 들어온 물체 검사 (Name)

public class DestroMissile : MonoBehaviour
{
    //Destroy영역 안에 물체가 들어온 경우
    private void OnTriggerEnter(Collider other)
    {
        //물체 이름이 Missile 일 경우 파괴
        if (other.gameObject.name.Contains("Missile"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.name.Contains("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }

    
}
