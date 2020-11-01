using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    protected abstract void onTriggerBonus();
    protected abstract void onBonusEnd();

    protected Sprite BonusSprite;
    protected PlayerMovements holder;

    public void start() {
        BonusSprite = transform.GetComponent<SpriteRenderer>().sprite;
    }

    public void triggerBonus() {
        Main.instance.removeBonusFromPlayer(holder.getNumber(), BonusSprite);
        onTriggerBonus();

        
        //playersScores[i].transform.Find("Bonus").GetComponent<SpriteRenderer>().sprite = Resources.Load("Tiles_09", typeof(Sprite)) as Sprite;

        getHolder().setIsHoldingBonus(false);
    }

    public void StopBonus() {
        onBonusEnd();
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
        Main.instance.setBonusForPlayer(holder.getNumber(), BonusSprite);
        Main.instance.setBonusForPlayer(holder.getNumber(), transform.GetComponent<SpriteRenderer>().sprite);
        Main.instance.GenerateBonus();
        
        Destroy(gameObject);
    }
}
