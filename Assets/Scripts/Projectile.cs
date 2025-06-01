using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    
    public float speed; // Speed of the projectile
    public float angle; // Launch angle in degrees
    ProjectileLaunch projectileLaunch;
    private float gravity; // Gravity value
    private Vector2 initialVelocity; // Initial velocity of the projectile

   
    void Start()
    {
        projectileLaunch = GameObject.FindObjectOfType<ProjectileLaunch>();
        speed = projectileLaunch.speedSlider.value;
        angle = projectileLaunch.angleSlider.value;
        Debug.Log(speed +"  " +  angle);
        // Calculate gravity based on Unity's physics settings
        gravity = Mathf.Abs(Physics2D.gravity.y);

        // Calculate initial velocity components
        float radians = angle * Mathf.Deg2Rad;
        float initialVelocityMagnitude = speed/10;
        float initialVelocityX = initialVelocityMagnitude * Mathf.Cos(radians);
        float initialVelocityY = initialVelocityMagnitude * Mathf.Sin(radians);

        initialVelocity = new Vector2(initialVelocityX, initialVelocityY);
    }

    void Update()
    {
      
        // Calculate the new position using the parabolic motion equation
        float time = Time.deltaTime;
        Vector2 newPosition = new Vector2(transform.position.x + (initialVelocity.x * time),transform.position.y + (initialVelocity.y * time) - (0.5f * gravity * time * time));

        // Update the position of the projectile
        transform.position = newPosition;
        // Update the vertical velocity due to gravity
        initialVelocity.y -= gravity * Time.deltaTime;
    }
    public void SetInitialVelocity(Vector2 newInitialVelocity)
    {
        initialVelocity = newInitialVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        projectileLaunch.score++;
    }
}
