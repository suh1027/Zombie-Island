using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public string weaponName; // 무기이름 (라이플)

    public float damage; // 데미지 => projectile에 붙이는게 더 맞는듯
    
    public float nextShootingTime; // 다음 발사될 총알까지의 시간
    public float betweenBulletTime; // 생성될 총알 간 속도
    public float reloadTime; // 재장전 속도
    public float bulletSpeed; // 날아가는 총알의 속도
    
    // 총알 관련
    public int currentBulletCount; // 현재 남아있는 총알의 갯수
    public int reloadBulletCount; // 장전 가능한 총알의 갯수
    public int totalBulletCount; // 남아있는 전체 총알 갯수
    public Transform muzzle; // 총구 위치 지정

    // 총알 오브젝트
    public Projectile bulletPrefab; // 왜 생성이 안되지?

    // Flag
    private bool isAttack; // 공격 도중에 이동불가능하게 만들기 위한 flag

    // Sound
    public AudioClip fireSound; // 오디오 클립

    // Effect
    public ParticleSystem muzzleFlash; // 총구 섬광 이펙트

    public void Shoot()
    {
        Debug.Log("Rifle.Shoot() 호출됨");
        // 총 30발 이상을 쏘면 reload 하는 조건 생성? // 총알관리 생각해보기
        if (Time.time > nextShootingTime) //??
        {
            Debug.Log("Bullet 생성 전");
            nextShootingTime = Time.time + betweenBulletTime / 1000; // 왜 이렇게 지정되는지?
            Projectile newProjectile = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation); // 왜 생성이 안되지..
            Debug.Log("Bullet 생성완료");
            newProjectile.setSpeed(bulletSpeed);
        }

    }
}
