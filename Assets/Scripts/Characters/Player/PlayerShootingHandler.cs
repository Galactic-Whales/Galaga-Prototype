using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingHandler : ProjectileShooter, ICharacterComponent
{
    [SerializeField] private readonly bool allowShotOnStart;
    private int maxProjectilesOnScreen;
    private float shootingRate;

    private float timeElapsed;

    private int projectilesOnScreen;

    public void OnDataInitialized(CharacterStats characterStats)
    {
        PlayerStats playerStats = (PlayerStats)characterStats;

        if (playerStats != null)
        {
            maxProjectilesOnScreen = playerStats.AvailableShotsOnScreen;
            shootingRate = 1 / playerStats.ShotsPerSecond;
        }
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && timeElapsed >= shootingRate && projectilesOnScreen < maxProjectilesOnScreen)
        {
            Projectile projectile = Shoot();

            if (projectile != null)
            {
                VisibilityNotifier visibilityNotifier = projectile.gameObject.AddComponent<VisibilityNotifier>();

                if (visibilityNotifier != null)
                {
                    visibilityNotifier.OnVisibilityChange += OnProjectileVisibilityChange;
                }
            }

            projectilesOnScreen++;
            timeElapsed = 0.0f;
        }
    }

    private void OnProjectileVisibilityChange(bool visible)
    {
        if (!visible)
        {
            projectilesOnScreen--;
        }
    }

    private void ModifyProjectilesOnScreen(int amount)
    {
        projectilesOnScreen += amount;
        projectilesOnScreen = Mathf.Clamp(projectilesOnScreen, 0, maxProjectilesOnScreen);
    }
}