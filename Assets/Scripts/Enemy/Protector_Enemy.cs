namespace Enemy
{
    public class Protector_Enemy : Enemy_Parent
    {
        // Start is called before the first frame update
        void Start()
        {
            name = "Protector";
            moveSpeed = 2;
            health = 2;
        }

        protected override void TakeDamage(int damage)
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
