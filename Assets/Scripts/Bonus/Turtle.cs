using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : Bonus
{

    private float bonusSpeed;

    protected override void onTriggerBonus() {
        foreach( GameObject Player in Main.instance.getPlayers() ) {
            if ( Player.name == holder.name ) {
                continue;
            }

            PlayerMovements playerScript = Player.GetComponent<PlayerMovements>();

            playerScript.setPlayerSpeed( playerScript.getNormalSpeed() / 2 );
        }
    }

    protected override void onBonusEnd() {
        foreach( GameObject Player in Main.instance.getPlayers() ) {
            PlayerMovements playerScript = Player.GetComponent<PlayerMovements>();
            playerScript.resetPlayerSpeed();
        }
    }
}
