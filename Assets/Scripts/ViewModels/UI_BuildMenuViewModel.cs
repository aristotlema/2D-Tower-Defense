using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_BuildMenuViewModel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _body;

    [SerializeField] private Button _buildTurret;
    [SerializeField] private Button _buildTower;
    [SerializeField] private Button _clearTile;

    public static event Action<Vector3Int> OnBuildTurret;
    public static event Action<Vector3Int> OnBuildTower;
    public static event Action<Vector3Int> OnClearFoliage;

    private void Start()
    {
        Setup();
    }
    private void OnEnable()
    {
        GridController.OnTileSelect += UpdateBuildMenuTitle;
    }

    private void OnDisable()
    {
        GridController.OnTileSelect -= UpdateBuildMenuTitle;
    }
    private void Setup()
    {
        DisableAllButtons();
    }
    private void UpdateBuildMenuTitle(Vector3Int tile, TileStatus status)
    {
        _title.text = tile.ToString();
        _body.text = BuildDisplayText(status);
        DisplayButtons(tile, status);
    }

    private void DisplayButtons(Vector3Int tile, TileStatus status)
    {
        //Horrible code
        DisableAllButtons();
        if (status == TileStatus.Buildable)
        {
            _buildTower.gameObject.SetActive(true);
            _buildTower.onClick.AddListener(() => OnBuildTower?.Invoke(tile));
            Debug.Log("Build Tower Clicked" + tile);
        }
        if (status == TileStatus.TowerBase)
        {
            _buildTurret.gameObject.SetActive(true);
            _buildTurret.onClick.AddListener(() => OnBuildTurret?.Invoke(tile));
            Debug.Log("Build Turret Clicked" + tile);
        }
        if (status == TileStatus.Clearable)
        {
            _clearTile.gameObject.SetActive(true);
            _clearTile.onClick.AddListener(() => OnClearFoliage?.Invoke(tile));
            Debug.Log("Clear Foliage" + tile);
        }
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

    private void DisableAllButtons()
    {
        _buildTurret.gameObject.SetActive(false);
        _buildTower.gameObject.SetActive(false);
        _clearTile.gameObject.SetActive(false);
    }
}
