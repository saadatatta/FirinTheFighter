
public interface IEnemy
{

    int Health { get; }

    void PerformAttack();

    void TakeDamage(int amount);
}
