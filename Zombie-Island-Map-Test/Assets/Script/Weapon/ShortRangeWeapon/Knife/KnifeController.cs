using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{

    public Transform weaponHolder;

    public Knife setKnife;
    private Knife knife;

    private void Start()
    {
        if(setKnife != null)
        {
            EquipKnife(setKnife);
        }
    }

    public void Attack()
    {
        if(knife != null)
        {
            knife.Attack();
        }
    }

    public void EquipKnife(Knife _knife)
    {
        knife = Instantiate(_knife, weaponHolder.position, weaponHolder.rotation);
        knife.transform.parent = weaponHolder;
    }
}
