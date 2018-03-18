using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Chad_Hoang;

/// <summary>
///     
/// </summary>
public class NPCManager : MonoBehaviour 
{
    #region PUBLIC_VARIABLES
    public static NPCManager instance = null;              //Static instance which allows it to be accessed by any other script.
    public Building MainBuilding;
    public GameObject[] NPCs;
    public int InitialSpawnAmount;
    public int MaxSpawnAmount;
    public float RaycastHeight;
    //public float SpawnRadius;
    #endregion // PUBLIC_VARIABLES

    #region PRIVATE_VARIABLES
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
    }

    void Start () 
	{
        //  create random points to spawn on terrain using raycasts
        for (int i = 0; i < InitialSpawnAmount; i++)
        {
            if (i > MaxSpawnAmount)
            {
                #if UNITY_EDITOR
                print("Current spawn amount exceeds max spawn amount... Stopped spawning.");
                #endif
                break;
            }

            //  Create random point to spawn on terrain
            //float x = Random.Range(-SpawnRadius, SpawnRadius);
            //float z = Random.Range(-SpawnRadius, SpawnRadius);
            //Vector3 pos = new Vector3(x, RaycastHeight, z) + MainBuilding.position;
            //Vector3 pos = MainBuilding.GetRandomPOI().position + new Vector3(0, RaycastHeight, 0);

            //  Fire raycast towards terrain
            //Vector3 down = transform.TransformDirection(Vector3.down);
            //RaycastHit hit;
            //#if UNITY_EDITOR
            //Debug.DrawRay(pos, down * 100, Color.red, 1);
            //#endif
            //if (Physics.Raycast(pos, down, out hit, 100, Layers.Terrain))
            //{
            //    //  Spawn units
            //    GameObject currentPlaceableObject = Instantiate(NPCs[Random.Range(0, NPCs.Length)], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal), transform);
            //}
        }
    }
	
	void Update () 
	{
		
	}

    void OnEnable()
    {
        BuildingManager.OnBuildingAdded += OnBuildingAdded;
        BuildingManager.OnBuildingRemoved += OnBuildingRemoved;
    }

    void OnDisable()
    {
        BuildingManager.OnBuildingAdded -= OnBuildingAdded;
        BuildingManager.OnBuildingRemoved -= OnBuildingRemoved;
    }
    #endregion // UNTIY_METHODS

    #region PUBLIC_METHODS
    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS
    private void OnBuildingAdded(Building building)
    {
        
    }

    private void OnBuildingRemoved(Building building)
    {

    }
    #endregion // PRIVATE_METHODS
}
