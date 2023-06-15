using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� : Destroy ���� �ȿ� ���� ��ü ����
// Destroy ���� (Trigger)
// ���� ��ü �˻� (Name)

public class DestroMissile : MonoBehaviour
{
    //Destroy���� �ȿ� ��ü�� ���� ���
    private void OnTriggerEnter(Collider other)
    {
        //��ü �̸��� Missile �� ��� �ı�
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
