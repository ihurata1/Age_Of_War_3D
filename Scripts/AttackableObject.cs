using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableObject : MonoBehaviour
{
    public float health;

    public virtual bool TakeDamage(float damage)
    {
        if (health - damage > 0){
            health -= damage;
            return true;}
        else
        {
            health = 0;
            //TODO Öldürülecek
            if(gameObject.tag=="EnemyCharacter")
            GoldManager.AddGold(Mathf.CeilToInt(gameObject.GetComponent<Character>().price *1.1f));
            Destroy(gameObject);
            return false;

        }

    }

}
