using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UI_BuildMenuViewModel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _body;

    [SerializeField] private Button _buildTurret;
    [SerializeField] private Button _buildTower;
    [SerializeField] private Button _clearTile;

    private void OnEnable()
    {
        GridController.OnTileSelect += UpdateBuildMenuTitle;
    }

    private void OnDisable()
    {
        GridController.OnTileSelect -= UpdateBuildMenuTitle;
    }
    private void UpdateBuildMenuTitle(Vector3Int tile, TileStatus status)
    {
        _title.text = tile.ToString();
        _body.text = BuildDisplayText(status);
    }

    private string BuildDisplayText(TileStatus status)
    {
        switch (status)
        {
            case TileStatus.Upgradeable:
                return "Upgrade tower";
            case TileStatus.TowerBase:
                return "Build Base";
            case TileStatus.Buildable:
                return "Place a tower";
            case TileStatus.Clearable:
                return "Clear Foliage";
            default:
                return "Not buildable";
        }
    }
}
