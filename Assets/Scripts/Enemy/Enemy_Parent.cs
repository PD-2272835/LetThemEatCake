using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Parent : MonoBehaviour
{
  public new string name = "Base Class";
  public int health = 3;
  public int moveSpeed = 10;

  public virtual void Move()
  {
    transform.Translate(Vector2.left * (moveSpeed * Time.deltaTime));
  }

  public virtual void TakeDamage(int damage)
  {
    health -= damage;
    if (health <= 0)
    {
      Die();
    }
  }

  protected virtual void Die()
  {
    Debug.Log(name + "Death");
    Destroy(gameObject);
  }

  public virtual void Update()
  {
    Move();
  }





}
