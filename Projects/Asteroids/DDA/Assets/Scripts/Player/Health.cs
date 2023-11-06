using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private Image[] hearts;

    private void Start()
    {
        health += SaveSystem.LoadData().healthLvl;

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < health;
        }
    }
    private void Update()
    {
        if (health < 0) health = 0;

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < health;
        }
    }

    public int GetHealth() { return health; }
    public void TakeDamage()
    {
        health--;
    }
    public void AddHealth()
    {
        health++;
    }

}
