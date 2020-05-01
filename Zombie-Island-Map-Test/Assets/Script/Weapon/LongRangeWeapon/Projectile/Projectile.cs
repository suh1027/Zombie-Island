using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 10; // 총알의 속도
    [SerializeField] private float damage;

    private float lifeTIme; // 이후 오브젝트 풀링으로 처리
    public LayerMask collisionMask; // 어떤 오브젝트와 충돌할지 결정하는 마스크
 

    private void Update()
    {
        float moveDistance = speed * Time.deltaTime; // 잘 이해는 안가는 부분
        transform.Translate(Vector3.forward * moveDistance);
    }

    public void setSpeed(float _newSpeed)
    {
        speed = _newSpeed;
    }

}
