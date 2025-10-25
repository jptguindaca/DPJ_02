using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Stats")]
public class PlayerStats : ScriptableObject
{

    [Header("Config")]
    public int Level;
    [Header("Health")]
    public float PlayerHealth = 100f;
    public float MaxHealth = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
