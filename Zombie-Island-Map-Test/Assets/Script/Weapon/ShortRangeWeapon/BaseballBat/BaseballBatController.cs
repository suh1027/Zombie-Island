using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballBatController : MonoBehaviour
{
    public Transform weaponHolder; // 무기를 잡는 부분

    public BaseballBat setBaseballBat;
    private BaseballBat baseballBat;

    private void Start()
    {
        if(setBaseballBat!= null)
            EquipBat(setBaseballBat);
    }

    public void SwingCheck() // 스윙으로 충돌한 충돌체의 정보를 체크하는 메소드
    {
        baseballBat.SwingCheck();
    }

    private void EquipBat(BaseballBat _bat)
    {
        baseballBat = Instantiate(_bat, weaponHolder.position, weaponHolder.rotation);
        baseballBat.transform.parent = weaponHolder;
    }
}
