using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenuController : MonoBehaviour
{
    [SerializeField] private GameObject buildMenu;

    private void OnEnable()
    {
        GridController.OnTileSelect += OpenBuildMenu;
    }

    private void OnDisable()
    {
        GridController.OnTileSelect -= OpenBuildMenu;
    }

    private void OpenBuildMenu(Vector3Int tile, TileStatus tileStatus)
    {

        Debug.Log("Opening Build Menu");
        Debug.Log("Tile: " + tile);
        Debug.Log("TileStatus" + tileStatus);

        buildMenu.SetActive(true);
    }
}
