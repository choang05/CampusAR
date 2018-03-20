using UnityEngine;
using System.Collections;

public class Layers
{
    // A list of tag strings.
    //public static LayerMask Players = 1 << 9;
    //public static LayerMask Platform = 1 << 11;
    //public const int Players = 9;
    //public const int Platforms = 11;
    //public const int ViewAlways = 13;   
    public const int ITerrain = 8;
    public const int IBuilding = 9;
    public const int INPC = 10;
    public const int IRoad = 11;

    //public static readonly LayerMask Grid = 1 << 8;
    public static readonly LayerMask Terrain = 1 << LayerMask.NameToLayer("Terrain");
    public static readonly LayerMask Building = 1 << LayerMask.NameToLayer("Building");
    //public static readonly LayerMask Unit = 1 << 10;


    //  Global function to changelayers 
    /*public static void ChangeLayers(GameObject go, int layer)
    {
        go.layer = layer;
        foreach (Transform child in go.transform)
            ChangeLayers(child.gameObject, layer);
    }*/
}
