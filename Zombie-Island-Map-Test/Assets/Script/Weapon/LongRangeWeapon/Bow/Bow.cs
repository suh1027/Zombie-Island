using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public string weaponName; // 무기이름 (라이플)

    public float damage; // 데미지 => projectile에 붙이는게 더 맞는듯

    float nextShootingTime; // 다음 발사될 총알까지의 시간
    public float betweenArrowTime; // 생성될 총알 간 속도
    public float arrowSpeed; // 날아가는 총알의 속도

    public Transform arrowShootPoint; // 화살 위치 지정

    public Projectile arrowPrefab; // 화살 prefab

    public void Shoot()
    {
        if(Time.time > nextShootingTime)
        {
            nextShootingTime = Time.time + betweenArrowTime / 1000;
            Projectile newProjectile = Instantiate(arrowPrefab, arrowShootPoint.position, arrowShootPoint.rotation);
            newProjectile.setSpeed(arrowSpeed);
        }
    }
}
