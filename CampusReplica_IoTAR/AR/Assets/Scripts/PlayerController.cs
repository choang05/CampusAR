using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Chad_Hoang;

/// <summary>
///     
/// </summary>
public class PlayerController : MonoBehaviour 
{
    #region PUBLIC_VARIABLES
    public Building currentLookAtBuilding;
    public static PlayerController instance = null;              //Static instance which allows it to be accessed by any other script.
    public KeyCode newObjectHotkey = KeyCode.A;
    #endregion // PUBLIC_VARIABLES

    #region PRIVATE_VARIABLES
    private BuildingManager buildingManager;
    private float mouseWheelRotation;
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

        buildingManager = BuildingManager.instance;
    }

    void Start () 
	{
		
	}

    void Update()
    {
        //MoveCurrentObjectToMouse();
        CheckCenterRaycast();


    }
    #endregion // UNTIY_METHODS

    #region PUBLIC_METHODS
    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS
    private void CheckCenterRaycast()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //  ray from center of screen
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        RaycastHit hit;

        LayerMask allowedRaycasts = Layers.Building | Layers.Terrain;

        //  Debug ray
        #if UNITY_EDITOR	
        Debug.DrawRay(ray.origin, ray.direction * 250, Color.red);
        #endif

        if (Physics.Raycast(ray, out hit, 150, allowedRaycasts))
        {
            //  if it hit a building...
            if ((1 << hit.collider.gameObject.layer) == Layers.Building.value)
            {
                currentLookAtBuilding = hit.collider.GetComponent<Building>();
                //Debug.Log(building.GetName());
            }
            else
            {
                currentLookAtBuilding = null;
            }

            //  if left click...
            if (Input.GetMouseButtonDown(0))
            {
                //currentPlaceableObject = Instantiate(buildingManager.BuildingPrefabs[Random.Range(0, buildingManager.BuildingPrefabs.Length)], hitInfo.point, Quaternion.FromToRotation(Vector3.up, hitInfo.normal), buildingManager.transform);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                /*if (hitInfo.collider.CompareTag(Tags.Building))
                {
                    Building building = hitInfo.collider.GetComponent<Building>();
                    BuildingManager.RemoveBuilding(building);
                    Destroy(building.gameObject);
                    //building.gameObject.SetActive(false);
                }*/
            }
        }
    }
    #endregion // PRIVATE_METHODS
}
