using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballBat : MonoBehaviour
{
    public string weaponName; // 무기이름 (야구빠따)

    public float damage; // 데미지
    public float range; // 사정거리

    public float reAttackDelayTime; // 재공격 딜레이 시간
    public float attackTime; // 공격시 시간
    public float attackDelayTime; // 공격후 Idle상태로 오는 시간

    public Transform hitDetector;
    private RaycastHit hitInfo; // Ray에 닿은 컴포넌트의 정보를 얻어올 수 있는 변수



    // flag
    private bool isAttack; // 공격 도중에 이동불가능하게 만들기 위한 flag

    // Sound
    public AudioClip swingSound; // 오디오 클립

    public void SwingCheck()
    {
        // 전방으로 Ray 발사해서 충돌체 받기? 
        // -> 정확히 안받아지는건지 아니면 Ray가 발사가 안되는지 모르겠음
        // 우선 스윙시 어떻게 콜라이더가 되는지 확인
        if (CheckObject())
        {
            if(hitInfo.transform.tag == "Enemy")
            {
                // Enemy의 hp를 깎음 > Enemy.hp -= damage; 
                // 아직 구현 x -> 문제가 detect 는 되는데 한번씩 안되는데..? 방법을 바꿔야될듯함
                Debug.Log(hitInfo.transform.tag);
            }
        }

    }

    private bool CheckObject()
    {
        
        if (Physics.Raycast(hitDetector.position, hitDetector.forward, out hitInfo, range))
        {
            Debug.DrawRay(hitDetector.position, hitDetector.forward * range, Color.red); // 왜 Draw가 안되지?
            return true;
        }
        return false;
    }
}

