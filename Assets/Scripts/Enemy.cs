using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem enemyExplosion;
    [SerializeField] Transform spawnPosition;
    [SerializeField] int score;

    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindAnyObjectByType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ParticleSystem vfx = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
        vfx.transform.parent = spawnPosition;
        scoreBoard.IncreaseScore(score);
        Destroy(gameObject);
    }
}
