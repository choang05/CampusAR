using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
using Chad_Hoang;

/// <summary>
///     Template script is placed in ..\Program Files\Unity\Editor\Data\Resources\ScriptTemplates\81-C# Script-NewBehaviourScript.cs.txt
/// </summary>
public class NPC : MonoBehaviour 
{
    #region PUBLIC_VARIABLES
    [Header("Non-RichAI Settings")]
    public Transform target;
    public float minIdleTime;
    public float maxIdleTime;
    public float minMaxSpeed;
    public float maxMaxSpeed;
    #endregion // PUBLIC_VARIABLES

    #region PRIVATE_VARIABLES
    //Seeker seeker;
    private IAstarAI ai;
    Animator animator;
    string speedParam = "Speed";
    /*State currentState;
    enum State
    {
        Idle,
        Moving
    }*/
    #endregion // PRIVATE_VARIABLES

    #region MONOBEHAVIOUR_METHODS
    void Awake()
    {
        //seeker = GetComponent<Seeker>();
        ai = GetComponent<IAstarAI>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {   
        //  set target to random building's POI if any
        if (BuildingManager.Buildings.Count > 1)
        {
            Building randomBuilding = BuildingManager.Buildings[Random.Range(0, BuildingManager.Buildings.Count)];
            //target = randomBuilding.GetRandomPOI();
        }
        else if (BuildingManager.Buildings.Count == 1)
        {
            ///target = BuildingManager.Buildings[0].GetRandomPOI();
        }

        //  try path search
        //UpdatePath();

        //  Randomize initial speed using RichAI's maxSpeed as the current speed
        //maxSpeed = Random.Range(minMaxSpeed, maxMaxSpeed);

        //  Randomize initial animation offset
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);//could replace 0 by any other animation layer index
        animator.Play(state.fullPathHash, -1, Random.Range(0f, 1f));
    }

    private void Update()
    {
        if (target != null && ai != null)
            ai.destination = target.position;

        //  Animations
        //animator.SetFloat(speedParam, Velocity.magnitude);  

        /*if (TargetReached && distanceToWaypoint < 0.5f)
        {
            //maxSpeed = 0;
            //animator.SetFloat(speedParam, 0);
        }
        else if (distanceToWaypoint <= maxSpeed)
        {
            //maxSpeed = distanceToWaypoint;
        }*/
    }

    void OnEnable()
    {
        // Update the destination right before searching for a path as well.
        // This is enough in theory, but this script will also update the destination every
        // frame as the destination is used for debugging and may be used for other things by other
        // scripts as well. So it makes sense that it is up to date every frame.
        if (ai != null)
            ai.onSearchPath += Update;

        BuildingManager.OnBuildingRemoved += OnBuildingRemoved;
    }

    void OnDisable()
    {
        if (ai != null)
            ai.onSearchPath -= Update;

        BuildingManager.OnBuildingRemoved -= OnBuildingRemoved;
    }
    #endregion // UNTIY_METHODS

    #region PUBLIC_METHODS
    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS
    void OnTargetReached()
    {
        StartCoroutine(Idle());
    }

    IEnumerator Idle()
    {
        yield return new WaitForSeconds(Random.Range(minIdleTime, maxIdleTime));

        //  Set new target to navigate to
        SetNewTarget();
    }

    private void SetNewTarget()
    {
        //  Search another building's POI
        Building randomBuilding = BuildingManager.Buildings[Random.Range(0, BuildingManager.Buildings.Count)];
        //target = randomBuilding.GetRandomPOI();

        //  try path search
        //UpdatePath();

        //  Randomize initial speed using RichAI's maxSpeed as the current speed
        //maxSpeed = Random.Range(minMaxSpeed, maxMaxSpeed);
    }

    private void OnBuildingRemoved(Building building)
    {
        //if (building.transform == target)
        //{
        //    //  Search another building's POI
        //    Building randomBuilding = BuildingManager.Buildings[Random.Range(0, BuildingManager.Buildings.Count)];
        //    target = randomBuilding.GetRandomPOI();

        //    //  try path search
        //    UpdatePath();

        //    //  Randomize initial speed using RichAI's maxSpeed as the current speed
        //    maxSpeed = Random.Range(minMaxSpeed, maxMaxSpeed);
        //}
    } 
    #endregion // PRIVATE_METHODS
}
