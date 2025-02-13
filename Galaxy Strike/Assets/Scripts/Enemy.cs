using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyDestroyedVFX;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreValue = 1;

    Scoreboard scoreboard;
    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(enemyDestroyedVFX, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
