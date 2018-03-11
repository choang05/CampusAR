using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///     
/// </summary>
public class Building : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public Transform[] PointsOfInterests;
    //public bool IsConnected;
    //public Building ClosestNeighbor;
    //public List<ERRoad> roads = new List<ERRoad>();

    public static int AvaliableBuildingID;
    public Type type;
    public enum Type
    {
        Cullen,
        Mechler,
        Stadium,
        Moody
    }
    public delegate void BuildingEvent(Building building);
    public static event BuildingEvent OnBuildingEnabled;
    public static event BuildingEvent OnBuildingDisabled;
    #endregion // PUBLIC_VARIABLES

    #region PRIVATE_VARIABLES

    #endregion // PRIVATE_VARIABLES

    #region UNTIY_MONOBEHAVIOUR_METHODS
	void Awake () 
	{

    }
	
	void Start ()
    {
        //InitializeLineRenderer();
        //  Assign unique ID
        AvaliableBuildingID++;
        name = GetName();
    }

    void OnEnable()
    {
        //BuildingManager.AddBuilding(this);
        if (OnBuildingEnabled != null)
            OnBuildingEnabled(this);
    }

    void OnDisable()
    {
        //BuildingManager.RemoveBuilding(this);
        if (OnBuildingDisabled != null)
            OnBuildingDisabled(this);
    }

    #if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        //  Draw cubes over the points of interests to visualize
        for (int i = 0; i < PointsOfInterests.Length; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(PointsOfInterests[i].position, 1);
        }
    }
    #endif
    #endregion // UNTIY_METHODS

    #region PUBLIC_METHODS
    public string GetName()
    {
        return type.ToString();
    }
    public Transform GetRandomPOI()
    {
        return PointsOfInterests[Random.Range(0, PointsOfInterests.Length)];
    }
    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS

    #endregion // PRIVATE_METHODS
}