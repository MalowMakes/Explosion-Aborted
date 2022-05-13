using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour, IDamageable
{

    public float health;
    public GameObject deathParticles;
    public Slider slider;
    public SFX sfx;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            slider.value = 1;
            Instantiate(deathParticles, transform.position, transform.rotation);
            sfx.robotSound();
            Destroy(gameObject);
        }
    }
}