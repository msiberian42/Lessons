using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FireManager : MonoBehaviour
{
    [SerializeField] private int extingCapacity;
    [SerializeField] private float fireIntencity;
    [SerializeField] private float extingSpeed;
    [SerializeField] private Slider fireBar;
    [SerializeField] private GameObject fireUI;
    [SerializeField] private GameObject[] FiresOnPlayer;
    [SerializeField] private Animator fireAnim;

    public int fireLevel { get; private set; }
    private float fireTimer;
    private float extingTimer;
    private bool isExtinguishing = false;
    private float requiredFireLevel;
    private PlayerManager player => GetComponent<PlayerManager>();
    protected ExtingSpawner extingSpawner =>
        GameObject.FindGameObjectWithTag("Spawn").GetComponent<ExtingSpawner>();

    private void Start()
    {
        fireLevel = 1;
        extingTimer = 1 / extingSpeed;
        fireTimer = 1 / fireIntencity;
    }
    private void Update()
    {
        if (fireLevel < 0) fireLevel = 0;       
        if (fireLevel > 100) fireLevel = 100;

        if (player.playerOnFire == true && player.playerIsAlive)
        {
            if (isExtinguishing)
                Extinguish();
            else
                BurnPlayer();
           
            fireBar.value = fireLevel;
            extingSpawner.enabled = true;
            fireUI.SetActive(true);
            ShowFires();
        }
        else
        {
            fireLevel = 1;
            extingSpawner.enabled = false;
            fireUI.SetActive(false);
            fireAnim.SetBool("isExtinguishing", false);
        }
    }

    private void Extinguish()
    {
        if (extingTimer <= 0)
        {
            extingTimer = 1 / extingSpeed;
            fireLevel--;
        }
        else
            extingTimer -= Time.deltaTime;

        if (fireLevel == requiredFireLevel || fireLevel <= 0)
        {
            fireAnim.SetBool("isExtinguishing", false);
            isExtinguishing = false;
        }
    }
    private void BurnPlayer()
    {
        if (fireTimer <= 0)
        {
            fireTimer = 1 / fireIntencity;
            fireLevel++;
        }
        else
            fireTimer -= Time.deltaTime;
    }
    public void CollectExting()
    {
        requiredFireLevel = fireLevel - extingCapacity;
        isExtinguishing = true;
        fireAnim.SetBool("isExtinguishing", true);
    }
    private void ShowFires()
    {
        for (int i = 0; i < FiresOnPlayer.Length; i++)
        {
            FiresOnPlayer[i].SetActive(i * 25 < fireLevel); 
        }
    }
}
