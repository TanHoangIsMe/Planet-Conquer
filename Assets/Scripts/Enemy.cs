using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem enemyExplosion;
    [SerializeField] ParticleSystem hitEffect;    
    [SerializeField] int score;
    [SerializeField] int hitPoint;

    Transform spawnPosition;
    ScoreBoard scoreBoard;

    private void Start()
    {
        spawnPosition = GameObject.FindWithTag("SpawnAtRuntime").transform;
        scoreBoard = FindAnyObjectByType<ScoreBoard>();
        CreateRigibody();
    }

    private void CreateRigibody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        CreateHitEffect();
        CountScoreBoard();
        DestroyMySelf();
    }

    private void CountScoreBoard()
    {
        scoreBoard.IncreaseScore(score);
    }

    private void DestroyMySelf()
    {
        hitPoint -= 1;
        if (hitPoint < 0)
        {
            Destroy(gameObject);
            CreateDeathEffect();
        }           
    }

    private void CreateDeathEffect()
    {
        ParticleSystem vfx = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
        vfx.transform.parent = spawnPosition;
    }

    private void CreateHitEffect()
    {
        ParticleSystem vfx = Instantiate(hitEffect, transform.position, Quaternion.identity);
        vfx.transform.parent = spawnPosition;
    }
}
