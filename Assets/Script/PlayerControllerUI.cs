using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerControllerUI : MonoBehaviour
{
    [SerializeField] Image healthFill;
    HealthBehaviour healthBehaviour;
    public GameObject player;

    [SerializeField] TextMeshProUGUI prizeLabel;
    [SerializeField] private float prizeTimer;
    private float prizeCurrentTimer;

    [SerializeField] private TextMeshProUGUI scoreLabel;

    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        healthBehaviour = player.GetComponent<HealthBehaviour>();
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
        if (prizeCurrentTimer > 0)
        {
            prizeCurrentTimer -= Time.deltaTime;
            if (prizeCurrentTimer <= 0)
            {
                prizeLabel.gameObject.SetActive(false);
            }
        }

        if (scoreLabel != null)
        {
            scoreLabel.text = "Score: " + manager.currentScore;
        }
    }

    public void UpdateHealthBar()
    {
        if (healthBehaviour != null && healthBehaviour.GetMaxHealth() != 0)
        {
            healthFill.fillAmount = healthBehaviour.health / healthBehaviour.GetMaxHealth();
        }
    }

    public void PrizeWon(string prize)
    {
        prizeLabel.gameObject.SetActive(true);
        prizeLabel.text = prize;
        prizeCurrentTimer = prizeTimer;
    }

   
}
