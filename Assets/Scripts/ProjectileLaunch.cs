using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ProjectileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab, GameOverPanel, PausePanel; // Reference to the projectile prefab
    public Slider angleSlider; // Reference to the angle slider UI
    public Slider speedSlider; // Reference to the speed slider UI
    public Transform spawn;
    public TextMeshProUGUI VelocityTxt, AngleTxt, AmmoTxt, ScoreTxt, FinalScoreTxt;
    int ammo;
    public int score;
    public int enemies;
    public AudioSource SFXSource;
    public AudioClip ShootClip;
    void Start()
    {
        GameOverPanel.SetActive(false);
        PausePanel.SetActive(false);
        score = 0;
        ammo = 7;
        enemies = 7;
        // Add listener methods to the sliders
        angleSlider.onValueChanged.AddListener(UpdateAngle);
        speedSlider.onValueChanged.AddListener(UpdateSpeed);
    }
    private void Update()
    {
        VelocityTxt.text = speedSlider.value.ToString();
        AngleTxt.text = angleSlider.value.ToString();
        AmmoTxt.text = "Ammo: " + ammo.ToString();
        ScoreTxt.text = "Score: " + score.ToString();
        FinalScoreTxt.text = "Final Score: " + score.ToString();

        if (Input.GetKeyDown(KeyCode.P))
        {
            OpenPause();
        }

        if (enemies <= 0)
        {
            
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    void UpdateAngle(float value)
    {
        // Update the angle label
    }

    void UpdateSpeed(float value)
    {
        // Update the speed label
    }

    public void SpawnProjectile()
    {
        if(ammo > 0)
        {
            // Get the current angle and speed values from the sliders
            float angle = angleSlider.value;
            float speed = speedSlider.value;

            // Calculate initial velocity components
            float radians = angle * Mathf.Deg2Rad;
            float initialVelocityX = speed * Mathf.Cos(radians);
            float initialVelocityY = speed * Mathf.Sin(radians);

            Vector2 initialVelocity = new Vector2(initialVelocityX, initialVelocityY);

            // Spawn the projectile
            GameObject projectile = Instantiate(projectilePrefab, spawn.transform.position, Quaternion.identity);
            // Assign the initial velocity to the projectile
            projectile.GetComponent<Projectile>().SetInitialVelocity(initialVelocity);
            ammo--;
            SFXSource.PlayOneShot(ShootClip);
        }
        else
        {
            Debug.Log("No more ammo");
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }

      
        
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy");
        }
    }
    public void OpenPause()
    {
        PausePanel.SetActive(true);
    }
    public void ClosePause()
    {
        PausePanel.SetActive(false);
    }
}
