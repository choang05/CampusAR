using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///     
/// </summary>
public class BuildingManager : MonoBehaviour 
{
    #region PUBLIC_VARIABLES
    public GameObject[] BuildingPrefabs;
    public static BuildingManager instance = null;              //Static instance which allows it to be accessed by any other script.
    public static List<Building> Buildings = new List<Building>();
    public delegate void BuildingManagerEvent(Building building);
    public static event BuildingManagerEvent OnBuildingAdded;
    public static event BuildingManagerEvent OnBuildingRemoved;
    #endregion // PUBLIC_VARIABLES

    #region PRIVATE_VARIABLES
    //private RoadManager _roadManager;
    #endregion // PRIVATE_VARIABLES

    #region UNTIY_MONOBEHAVIOUR_METHODS
    void Awake () 
	{
        #region Instance
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        #endregion

        //_roadManager = GetComponent<RoadManager>();
    }

    void Start () 
	{
        //  Add the initial main building
        AddBuilding(FindObjectOfType<Building>());
    }

    void OnEnable()
    {
        Building.OnBuildingEnabled += AddBuilding;
        Building.OnBuildingDisabled += RemoveBuilding;
    }

    void OnDisable()
    {
        Building.OnBuildingEnabled -= AddBuilding;
        Building.OnBuildingDisabled -= RemoveBuilding;
    }

    void OnDestroy()
    {

    }
    #endregion // UNTIY_METHODS

    #region PUBLIC_METHODS
    public static void AddBuilding(Building building)
    {


        //  Try to connect building to network by the closest building if it exists.
        /*float shortestDistance = 0;
        if (Buildings.Count > 0)
        {
            Building closestNeighbor = Buildings[0];
            shortestDistance = Vector3.Distance(Buildings[0].transform.position, building.transform.position);

            //  Loop through each building and find the closest neighbor
            for (int i = 0; i < Buildings.Count; i++)
            {
                //  Get closest distance
                float dist = Vector3.Distance(Buildings[i].transform.position, building.transform.position);
                if (dist < shortestDistance)
                {
                    shortestDistance = dist;
                    closestNeighbor = Buildings[i];
                }  
            }

            //  Assign closest neighbor.
            building.ClosestNeighbor = closestNeighbor;
        }*/

        //  Append to array
        Buildings.Add(building);

        //  Events
        if (OnBuildingAdded != null)
            OnBuildingAdded(building);
    }
    public static void RemoveBuilding(Building building)
    {
        Buildings.Remove(building);

        //  Events
        if (OnBuildingRemoved != null)
            OnBuildingRemoved(building);
    }
    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS
    #endregion // PRIVATE_METHODS
}
