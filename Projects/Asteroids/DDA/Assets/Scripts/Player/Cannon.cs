using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject[] shots;
    [SerializeField] private float reloadSpeed;
    [SerializeField] private GameObject bomb;
    [SerializeField] private float bombSpeed;

    private bool fullLoaded = true;
    private int capacity = 3;
    private int shotsRemain;
    private float reloadTimer;

    public float GetBombSpeed()
    {
        return bombSpeed;
    }
    private void Start()
    {
        capacity += SaveSystem.LoadData().cannonCapacityLvl;
        reloadSpeed += SaveSystem.LoadData().cannonReloadLvl / 2;

        reloadTimer = 10 / reloadSpeed;
        shotsRemain = capacity;

        for (int i = 0; i < capacity; i++)
        {
            shots[i].SetActive(i < shotsRemain);
        }
    }
    private void Update()
    {
        fullLoaded = shotsRemain == capacity;

        for (int i = 0; i < capacity; i++)
        {
            shots[i].SetActive(i < (fullLoaded ? shotsRemain : shotsRemain + 1));
        }

        if (!fullLoaded)
        {
            shots[shotsRemain].GetComponent<Animator>().SetBool("Reloading", true);
            Reload();
        }
        if (fullLoaded)
            shots[shotsRemain - 1].GetComponent<Animator>().SetBool("Reloading", false);

        if (shotsRemain > capacity) shotsRemain = capacity;
        if (shotsRemain < 0) shotsRemain = 0;
    }
    private void Reload()
    {
        if (reloadTimer <= 0)
        {
            reloadTimer = 10 / reloadSpeed;
            shotsRemain++;
            shots[shotsRemain - 1].GetComponent<Animator>().SetBool("Reloading", false);
        }
        else
            reloadTimer -= Time.deltaTime;
    }
    public void Shoot()
    {
        if (shotsRemain > 0 && Time.timeScale == 1)
        {
            Instantiate(bomb, new Vector3(transform.position.x, transform.position.y + 0.5f, 0f), Quaternion.identity);
            shotsRemain--;
        }
    }
}
