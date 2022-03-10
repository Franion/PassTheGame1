using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Package : MonoBehaviour
{
    public abstract void HandlePickup(Player player);

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player != null)
        {
            HandlePickup(player);
        }
    }
}