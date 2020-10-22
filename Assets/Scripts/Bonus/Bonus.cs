using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    protected abstract void onTriggerBonus();
    private PlayerMovements holder;

    public void triggerBonus() {
        onTriggerBonus();

        getHolder().setIsHoldingBonus(false);
    }

    public float getDuration() {
        return 3;
    }

    public void setHolder( PlayerMovements holderPlayer ) {
        holder = holderPlayer;
    }

    public PlayerMovements getHolder() {
        return holder;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag != "Player")
        {
            return;
        }

        PlayerMovements playerScript = collider.gameObject.GetComponent<PlayerMovements>();

        if ( playerScript.isHoldingBonus() ) {
            return;
        }

        playerScript.setIsHoldingBonus(true);
        playerScript.setBonus(this);
        setHolder(playerScript);
        
        Destroy(gameObject);
    }
}
