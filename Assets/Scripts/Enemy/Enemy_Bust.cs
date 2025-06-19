namespace Enemy
{
    public class Enemy_Bust : Enemy_Parent
    {
        private void Start()
        {
            name = "BustEnemy";
            moveSpeed = 0.25f;
            health = 50;
            rewardValue = 100;
        }

        protected override void Die()
        {
            EventManager.BustKilled();
        }
        
    }
}
