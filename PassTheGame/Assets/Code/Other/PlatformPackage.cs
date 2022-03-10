using System.Collections;
using UnityEngine;

public class PlatformPackage : Package
{
    [SerializeField] private int _packageAmount = 3;

    public override void HandlePickup(Player player)
    {
        player.Building.AddPlatforms(_packageAmount);
        Destroy(gameObject);
    }
}