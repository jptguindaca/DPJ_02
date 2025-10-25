using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Header("PlayerStats")]
    [SerializeField] private float playerstats = 10f;

    private PlayerAnimations playerAnimations;

    void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    public void TakeDamage(float damage)
    {
        playerstats -= damage;

        if (playerstats <= 0)
        {
            PlayerDead();
        }

        Debug.Log("Player Derrotado");
    }

    private void PlayerDead()
    {
        playerAnimations.SetDeadAnimation();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1f);
        }
    }
}
