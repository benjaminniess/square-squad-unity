using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : Bonus
{

    private float bonusSpeed;

    protected override void onTriggerBonus()
    {
        foreach ( KeyValuePair<int, GameObject> Player in LobbyScript.instance.getPlayers() )
        {
            if (Player.Value.name == holder.name)
            {
                continue;
            }

            PlayerMovements playerScript = Player.Value.GetComponent<PlayerMovements>();

            playerScript.setPlayerSpeed(playerScript.getNormalSpeed() / 2);
        }
    }

    protected override void onBonusEnd()
    {
        foreach ( KeyValuePair<int, GameObject> Player in LobbyScript.instance.getPlayers() )
        {
            PlayerMovements playerScript = Player.Value.GetComponent<PlayerMovements>();
            playerScript.resetPlayerSpeed();
        }
    }
}
