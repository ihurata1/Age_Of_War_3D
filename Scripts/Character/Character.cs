using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : AttackableObject
{
    public ParticleSystem bloodParticles;
    CharacterMoving movement;
    protected EnemyDetecter enemyDetecter;
    public int price;
    public float attackDamage;
    public float runSpeed;
    public float attackSpeed;
    protected virtual void Start()
    {
        enemyDetecter = GetComponent<EnemyDetecter>();
        movement = GetComponent<CharacterMoving>();
        bloodParticles = gameObject.GetComponentInChildren<ParticleSystem>();

    }
    private void OnDestroy()
    {
        if (enemyDetecter.isEnemy)
            GameManager.enemyCharacters.Remove(gameObject);
        else
            GameManager.playerCharacters.Remove(gameObject);
    }
    public override bool TakeDamage(float damage)
    {
        bloodParticles.Play();
        return base.TakeDamage(damage);
    }
    public virtual void Attack(GameObject enemy)
    {
        if(enemy!=null)
        AttackRotate(enemy);
        
    }
    //bool selfRotate = false;
    //TODO Performansı artır
    public void AttackRotate(GameObject enemy)
    {

        Debug.Log("Atak Oynadı");
        Vector3 dir = enemy.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(gameObject.transform.rotation, lookRotation, Time.deltaTime * 10f).eulerAngles;
        gameObject.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        Debug.Log(gameObject.transform.rotation + "=" + lookRotation);
        //selfRotate = false;
        Debug.Log("Atak Oynadı");
        movement.animator.SetTrigger("Attack");
    }

}
