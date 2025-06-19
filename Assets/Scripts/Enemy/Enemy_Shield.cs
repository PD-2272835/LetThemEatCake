using UnityEngine;

namespace Enemy
{
    public class Enemy_Shield : Enemy_Parent
    {
        public bool hasShield = true;
        
        void Start()
        {
            name = "ShieldEnemy";
            moveSpeed = 0.5f;
            health = 1;
            rewardValue = 3;
        }

        protected override void TakeDamage(int damage)
        {
            if (hasShield)
            {
                hasShield = false;
                animator.SetBool("sheild", false);
            }
            else
            {
                health -= damage;
                if (health <= 0)
                {
                    EventManager.EnemyDied(this);
                    Die();
                }
            }
        }
        
    }
}
