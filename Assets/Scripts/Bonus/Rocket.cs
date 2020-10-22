using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bonus
{

    private float bonusSpeed;

    protected override void onTriggerBonus() {
        holder.setPlayerSpeed(holder.getNormalSpeed() * 2);
    }

    protected override void onBonusEnd() {
        holder.setPlayerSpeed(holder.getNormalSpeed());
    }
}
