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


    public static event Action<GameTile> OnBuildTurret;
    public static event Action<GameTile> OnBuildTower;
    public static event Action<GameTile> OnClearFoliage;


    private void Start()
    {
        Setup();
    }
    private void OnEnable()
    {
        BuildMenuModel.SelectedTileChanged += UpdateBuildMenuTitle;
    }

    private void OnDisable()
    {
        BuildMenuModel.SelectedTileChanged -= UpdateBuildMenuTitle;
    }
    private void Setup()
    {
        DisableAllButtons();
    }
    private void UpdateBuildMenuTitle(GameTile tile)
    {
        _title.text = tile.Coordiantes.ToString();
        _body.text = BuildDisplayText(tile.TileStatus);
        DisplayButtons(tile);
    }

    private void DisplayButtons(GameTile tile)
    {
        //Horrible code
        DisableAllButtons();
        if (tile.TileStatus == TileStatus.Buildable)
        {
            _buildTower.gameObject.SetActive(true);
            _buildTower.onClick.AddListener(() => OnBuildTower?.Invoke(tile));
            Debug.Log("Build Tower Clicked" + tile);
        }
        if (tile.TileStatus == TileStatus.TowerBase)
        {
            _buildTurret.gameObject.SetActive(true);
            _buildTurret.onClick.AddListener(() => OnBuildTurret?.Invoke(tile));
            Debug.Log("Build Turret Clicked" + tile);
        }
        if (tile.TileStatus == TileStatus.Clearable)
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
