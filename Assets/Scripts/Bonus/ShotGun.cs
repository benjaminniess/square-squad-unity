using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Bonus
{
    public GameObject bullet;

    public float bulletTime = 0;

    public float remainingBullets = 5;

    private bool isTriggered = false;

    protected override void onTriggerBonus()
    {
        isTriggered = true;
    }

    public new float getDuration()
    {
        return 1;
    }

    void FixedUpdate()
    {
        if (isTriggered == true)
        {
            bulletTime += Time.deltaTime;
            if (bulletTime > 0.1f && remainingBullets > 0)
            {
                remainingBullets--;
                bulletTime = 0;
                fire();
            }
        }
    }

    public void fire()
    {
        GameObject singleBullet =
            Instantiate(bullet,
            new Vector3(holder.transform.position.x,
                holder.transform.position.y + 2,
                0),
            Quaternion.identity);
        Bullet bullerScript = singleBullet.GetComponent<Bullet>();
        bullerScript.setShooter (holder);
    }

    protected override void onBonusEnd()
    {
    }
}
