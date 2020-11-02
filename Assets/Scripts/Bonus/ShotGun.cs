using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Bonus
{

    public GameObject bullet;
    public float bulletTime;

    protected override void onTriggerBonus()
    {
        bulletTime = 0;
        fire();
    }

    void FixedUpdate()
    {
        bulletTime += Time.deltaTime;
        if (bulletTime > 3)
        {
            Debug.Log(bulletTime);
            bulletTime = 0;
            //fire();
        }
    }

    public void fire()
    {
        Debug.Log(holder);
        Debug.Log(bullet);
        GameObject singleBullet = Instantiate(bullet, new Vector3(holder.transform.position.x, holder.transform.position.y + 2, 0), Quaternion.identity);
        bulletTime = 0;
    }

    protected override void onBonusEnd()
    {

    }
}
