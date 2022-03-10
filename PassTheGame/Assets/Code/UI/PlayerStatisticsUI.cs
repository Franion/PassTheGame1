using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatisticsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _platformsTextMesh;

    private void Awake()
    {
        var building = FindObjectOfType<Building>();
        building.OnPlatformBuild += UpdatePlatformText;
    }

    public void UpdatePlatformText(int amount)
    {
        _platformsTextMesh.text = $"Platformy: {amount}";
    }
}