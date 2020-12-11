using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : Bonus
{
    private float bonusSpeed;

    protected override void onTriggerBonus()
    {
        holder.SetAlpha(0.4f);
        holder.setTracked(false);
    }

    protected override void onBonusEnd()
    {
        holder.ResetPlayerAlpha();
        holder.setTracked(true);
    }
}
