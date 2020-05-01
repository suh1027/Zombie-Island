using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleController : MonoBehaviour
{
    //public static bool isActive = false; //활성화 플래그

    public Transform weaponHolder; // 무기를 잡는 부분 (weaponHolder)

    public Rifle setRifle; // 장착 할 라이플
    private Rifle rifle; // 현재 장착 된 라이플 // 두개를 구분해서 장착 비장착 구분
   

    private void Start()
    {
        if(setRifle != null)
            EquipGun(setRifle);
    }

    /*    private void Update()
        {
            if(rifle != null)
                Shoot();
        }*/

    // #1. 총알 발사 메소드
    public void Shoot()
    {
        Debug.Log("RifleController.Shoot()");
        if (rifle != null) // 총이 장착 되어 있으면 발사
        {
            Debug.Log("RifleController.Shoot() Inside");
            rifle.Shoot();
        }

    }

    // #2. 총 장착 메소드
    private void EquipGun(Rifle _rifle) 
    {
        rifle = Instantiate(_rifle, weaponHolder.position, weaponHolder.rotation);
        rifle.transform.parent = weaponHolder;
    }

}
