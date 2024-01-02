using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingController : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] Tile towerBaseTile;
    public void BuildTower(Vector3 spawnCoordiantes)
    {
        Instantiate(towerPrefab, new Vector3(spawnCoordiantes.x + 0.5f, spawnCoordiantes.y + 0.5f), Quaternion.identity);
    }

    //Need to update with tile rule
    public Tile BuildTowerBase()
    {
        return towerBaseTile;
    }
}
