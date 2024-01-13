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


    public void BuildTurret(Vector3Int spawnCoordiantes)
    {
        Instantiate(towerPrefab, new Vector3(spawnCoordiantes.x + 0.5f, spawnCoordiantes.y + 0.5f), Quaternion.identity);
    }

    //Need to update with tile rule
    public Tile BuildTowerBase()
    {
        return towerBaseTile;
    }
}
