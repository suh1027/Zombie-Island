using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public string weaponName; // 무기이름 (칼)

    public float damage; // 데미지
    public float range; // 사정거리

    public float reAttackDelayTime; // 재공격 딜레이 시간
    public float attackTime; // 공격시 시간
    public float attackDelayTime; // 공격후 Idle상태로 오는 시간 // Coroutine으로 구현시 이방법 사용

    public Transform hitDetector;
    private RaycastHit hitInfo; // Ray에 닿은 컴포넌트의 정보를 얻어올 수 있는 변수

    public void Attack()
    {
        // 실제 공격 하는 애니메이션 모션이 없음.. => 야구빠따와 똑같이 구현
    }
}
