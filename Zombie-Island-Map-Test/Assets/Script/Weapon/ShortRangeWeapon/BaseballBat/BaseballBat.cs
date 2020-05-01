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

    // flag
    private bool isAttack; // 공격 도중에 이동불가능하게 만들기 위한 flag

    // Animation
    public Animator anim; // 에니메이터

    // Sound
    public AudioClip swingSound; // 오디오 클립
}
