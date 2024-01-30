using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingController : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] Tile towerBaseTile;

    private void OnEnable()
    {
        UI_BuildMenuViewModel.OnBuildTurret += BuildTurret;
    }
    private void OnDisable()
    {
        UI_BuildMenuViewModel.OnBuildTurret -= BuildTurret;
    }

    public void BuildTurret(GameTile tile)
    {
        Instantiate(towerPrefab, new Vector3(tile.Coordiantes.x + 0.5f, tile.Coordiantes.y + 0.5f), Quaternion.identity);
    }

    //Need to update with tile rule
    public Tile GetTowerBaseTile()
    {
        return towerBaseTile;
    }
}
