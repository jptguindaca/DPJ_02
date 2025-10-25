using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{

    // Implementou se a interface IDamageable para o PlayerHealth levar dano 
    public void TakeDamage(float damage)
    {
      float currenthealth= playerstats - damage;

        if (currenthealth <= 0)
        {
            playerdead();
        }

        Debug.Log("Player Derrotado");


    }

    void playerdead()
    {
        
    }


    [Header("PlayerStats")]

    [SerializeField] private float playerstats= 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1f);
        }

    }
}
