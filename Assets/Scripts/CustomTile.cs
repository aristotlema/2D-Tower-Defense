using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTile
{
    public Vector3Int Coordiantes { get; set; }
    public TileStatus TileStatus { get; set; }

    public CustomTile(Vector3Int coordiantes, TileStatus tileStatus)
    {
        this.Coordiantes = coordiantes;
        this.TileStatus = tileStatus;
    }
}
