using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCoin : Bonus
{
    private PlayerMovements victim;

    protected override void onTriggerBonus()
    {
        foreach (KeyValuePair<int, GameObject>
            Player
            in
            GameManager.instance.GetPlayers()
        )
        {
            if (Player.Value.name == holder.name)
            {
                continue;
            }

            PlayerMovements playerScript =
                Player.Value.GetComponent<PlayerMovements>();

            if (!playerScript.isHoldingCoin())
            {
                continue;
            }

            victim = playerScript;

            // Don't drop coin of invisible players
            if (!victim.isTracked())
            {
                return;
            }
            victim.setIsHoldingCoin(false);
            victim.setCanHoldCoin(false);
            Main
                .instance
                .AddCoinAtPosition((int) victim.transform.position.x,
                (int) victim.transform.position.y);
        }
    }

    protected override void onBonusEnd()
    {
        if (!victim)
        {
            return;
        }
        victim.setCanHoldCoin(true);
    }
}
