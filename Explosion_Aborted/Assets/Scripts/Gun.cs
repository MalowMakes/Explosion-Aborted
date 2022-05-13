using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    
    [Header("References")]
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform cam;
    [SerializeField] private Transform muzzle;
    [SerializeField] private ParticleSystem shootingSystem;
    [SerializeField] private TrailRenderer bulletTrail;
    public AmmoDisplay AmmoHUD;
    public SFX sfx;

    float timeSinceLastShot;

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
        AmmoHUD.updateUI();
    }

    private void OnDisable()
    {
        if (gunData.reloading == true)
        {
            transform.Rotate(-40, 0, 0, Space.Self);
        }
        gunData.reloading = false;
    }

    public void StartReload()
    {
        if (!gunData.reloading && this.gameObject.activeSelf)
            StartCoroutine(Reload());
        
    }

    private IEnumerator Reload()
    {
        transform.Rotate(40, 0, 0, Space.Self);

        gunData.reloading = true;

        sfx.reloadSound();

        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magSize;

        AmmoHUD.updateUI();

        transform.Rotate(-40, 0, 0, Space.Self);

        gunData.reloading = false;
    }

    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    private void Shoot()
    {
        if (gunData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                shootingSystem.Play();
                sfx.gunSound();
                if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    damageable?.TakeDamage(gunData.damage);

                    TrailRenderer trail = Instantiate(bulletTrail, muzzle.position, Quaternion.identity);
                    StartCoroutine(SpawnTrail(trail, hitInfo));
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                AmmoHUD.updateUI();
                OnGunShot();
            }
        }
        else if (gameObject.activeSelf)
        {
            sfx.emptySound();
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(cam.position, cam.forward * gunData.maxDistance);
    }

    private void OnGunShot() { }

    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit Hit)
    {
       
            float time = 0;
            Vector3 startPosition = Trail.transform.position;
            while (time < 1)
            {
                Trail.transform.position = Vector3.Lerp(startPosition, Hit.point, time);
                time += Time.deltaTime / Trail.time;

                yield return null;
            }
            Trail.transform.position = Hit.point;

            Destroy(Trail.gameObject, Trail.time);
    }
}