using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CastleCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<HealthManager>().TakeDamage(10);
            Enemy_Parent enemy = collision.gameObject.GetComponent<Enemy_Parent>();
            EventManager.EnemyDied(enemy);
            enemy.Die();
        }
    }
}
