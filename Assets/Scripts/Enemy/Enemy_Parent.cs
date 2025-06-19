using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Parent : MonoBehaviour
{
  public new string name = "Base Class";
  public int health = 3;
  public float moveSpeed = 5;
  public int rewardValue = 5;
  private int _count = 0; //track the number of iterations in DamageOverTime
  private bool isProtectorAlive;
  public Animator animator;

  private void OnEnable()
  {
    EventManager.UpdateProtectorInEnemy += UpdateProtectorStatus;
  }

  private void OnDisable()
  {
    EventManager.UpdateProtectorInEnemy -= UpdateProtectorStatus;
  }

  public virtual void Update()
  {
    Move();
  }
  
  public virtual void Move()
  {
    transform.Translate(Vector2.left * (moveSpeed * Time.deltaTime));
  }

  protected virtual void TakeDamage(int damage)
  {
    EventManager.CheckForIfProtectorAlive();
    if (!isProtectorAlive)
    {
      health -= damage;
    }
    if (health <= 0)
    {
      EventManager.EnemyDied(this);
      Die();
    }
  }

  protected void UpdateProtectorStatus(bool state)
  {
    isProtectorAlive = state;
  }
  protected virtual void Die()
  {
    Debug.Log(name + "Death");

    EventManager.UpdateBatterValue(rewardValue);
    
    StartCoroutine(deathAnimation());
  }

  protected IEnumerator deathAnimation()
  {
    animator.SetBool("dead", true);
    yield return new WaitForSeconds(0.3f);
    Destroy(gameObject);
  }

  //Call to 'Hit' this enemy, allowing damage to be dealt or a damage over time effect to be applied
  public virtual void Hit(float[] hitData) //hitData is can either contain only damage or damage over time parameters
  {
    Debug.Log(name + "was hit");
    if (hitData.Length < 2)
    {
      TakeDamage((int)hitData[0]);
    } 
    else
    {
      TakeDamage((int)hitData[0]);
      StartDamageOverTime(hitData[1], (int)hitData[2], (int)hitData[3]);
    }
  }
  
  
  //Damage over time Coroutine
  //not virtual as this does not need to be overwritten by children
  //time between damage ticks(seconds), number of damage ticks, amount of damage dealt each tick
  IEnumerator DamageOverTime(float tickPeriod, int tickCount, int tickDamage) 
  {
    yield return new WaitForSeconds(tickPeriod);
    this.TakeDamage(tickDamage);

    _count++;
    if (_count < tickCount)
    {
      StartCoroutine(DamageOverTime(tickPeriod, tickCount, tickDamage));
    }
    else
    {
      _count = 0;
    }
  }
  
  //Default Damage Over Time start if no parameters are specified
  public virtual void StartDamageOverTime()
  {
    StartCoroutine(DamageOverTime(3f, 3, 5));
  }
  
  //Configureable Damage Over Time start
  public void StartDamageOverTime(float tickPeriod, int tickCount, int tickDamage)
  {
    StartCoroutine(DamageOverTime(tickPeriod, tickCount, tickDamage));
  }
}
