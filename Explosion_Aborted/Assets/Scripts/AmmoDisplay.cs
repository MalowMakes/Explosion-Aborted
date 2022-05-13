using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
    public GunData Gun1;
    public GunData Gun2;
    public GunData Gun3;
    public TextMeshProUGUI ammoCount1;
    public TextMeshProUGUI ammoCount2;
    public TextMeshProUGUI ammoCount3;
    public Slider slider;
    public float fillSpeed = .05f;
    public GameObject deathParticles;
    public GameObject deathCam;
    public GameObject orientation;
    public GameObject deathOrientation;
    public LevelRextart restarter;


    void Start()
    {
        slider.value = 1;
    }

    public void updateUI()
    {
        ammoCount1.text = Gun1.currentAmmo.ToString();
        ammoCount2.text = Gun2.currentAmmo.ToString();
        ammoCount3.text = Gun3.currentAmmo.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (slider.value > 0)
        {
            slider.value -= fillSpeed * Time.deltaTime;
        }
        else
        {
            Instantiate(deathCam, deathOrientation.transform.position, deathOrientation.transform.rotation);
            Instantiate(deathParticles, orientation.transform.position, orientation.transform.rotation);
            restarter.InitiateRestart();
            Destroy(this.gameObject);
            
        }
    }
}
