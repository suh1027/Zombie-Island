using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    public Transform weaponholder;

    public Bow setBow;
    private Bow bow;

    private void Start()
    {
        if (setBow != null)
            EquipBow(setBow);
    }

    public void Shoot()
    {
        if(bow != null)
        {
            bow.Shoot();
        }
    }

    private void EquipBow(Bow _bow)
    {
        //bow.transform.Rotate(Vector3.forward * 90);
        bow = Instantiate(_bow, weaponholder.position, weaponholder.rotation);
        bow.transform.parent = weaponholder;
    }
}
