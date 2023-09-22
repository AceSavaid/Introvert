using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerBase : MonoBehaviour
{
    private PlayerM playerActions;
    private Rigidbody2D rb;

    private Vector2 moveDir;

    public float roundTime = 60;
    float currenttime;
    public TextMeshProUGUI timerText;
    public int score= 0;
    public TextMeshProUGUI scoreText;

    public int maxHealth = 20;
    int currentHealth;
    bool isHurt = false;
    float hurtTimer = 0f;
    public float recoverTime = 3f;
    public int healthRegen = 2;
    public int regenTime = 2;
    float regenTimer = 0f;
    public Slider healthBar;

    public float speed = 5;

    public GameObject gameoverScreen;

    // Start is called before the first frame update
    void Awake()
    {
        playerActions = new PlayerM();

        rb = GetComponent<Rigidbody2D>();

        currenttime = roundTime;
        timerText.text = ((int)currenttime).ToString();
        scoreText.text = "Score: " + score.ToString();

        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    private void OnEnable()
    {
        playerActions.Player.Enable();
    }

    private void OnDisable()
    {
        playerActions.Player.Disable();
    }

    void FixedUpdate()
    {
        moveDir = playerActions.Player.Move.ReadValue<Vector2>();
        
        rb.velocity = moveDir * speed;
    }

    // Update is called once per frame
    void Update()
    {
        currenttime -= Time.deltaTime;
        if (currenttime <= 0)
        {
            Die();
        }

        UpdateUI();
        if (isHurt)
        {
            hurtTimer += Time.deltaTime;
            if (hurtTimer >= recoverTime)
            {
                isHurt = false;
                hurtTimer = 0f;
            }
        }
        else
        {
            regenTimer += Time.deltaTime;
            if (regenTimer >= regenTime)
            {
                Regen();
                regenTimer = 0;
            }
        }
    }

    void UpdateUI()
    {
        timerText.text = ((int)currenttime).ToString();
        scoreText.text = "Score: " + score.ToString();
        healthBar.value = currentHealth;
    }

    public void Hurt(int val)
    {
        currentHealth -= val;
        isHurt = true;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Regen()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healthRegen;

        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void Die()
    {
        Time.timeScale = 0;
        gameoverScreen.SetActive(true);
    }

    public void AddTime( int val)
    {
        currenttime += val;
    }
}
