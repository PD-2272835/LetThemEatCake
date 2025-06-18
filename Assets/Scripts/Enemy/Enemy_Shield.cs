namespace Enemy
{
    public class Enemy_Shield : Enemy_Parent
    {
        public bool hasShield = true;
        
        void Start()
        {
            name = "ShieldEnemy";
            moveSpeed = 5;
            health = 1;
        }

        protected override void TakeDamage(int damage)
        {
            if (hasShield)
            {
                hasShield = false;
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
