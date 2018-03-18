
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///     
/// </summary>

namespace Chad_Hoang
{
    public class Building : MonoBehaviour
    {
        #region PUBLIC_VARIABLES
        //public bool IsConnected;
        //public Building ClosestNeighbor;
        //public List<ERRoad> roads = new List<ERRoad>();
        public static int AvaliableBuildingID;

        public delegate void BuildingEvent(Building building);
        public static event BuildingEvent OnBuildingEnabled;
        public static event BuildingEvent OnBuildingDisabled;
        #endregion // PUBLIC_VARIABLES

        #region PRIVATE_VARIABLES
        private Animator animatorUI;
        private int isOpenHash = Animator.StringToHash("isOpen");

        private PlayerController playerController;
        private bool isInfoOpen = false;
        #endregion // PRIVATE_VARIABLES

        #region UNTIY_MONOBEHAVIOUR_METHODS
	    void Awake () 
	    {
            animatorUI = GetComponentInChildren<Animator>();
            playerController = FindObjectOfType<PlayerController>();
        }
	
	    void Start ()
        {
            //InitializeLineRenderer();
            //  Assign unique ID
            //AvaliableBuildingID++;
            //name = GetName();
        }

        private void Update()
        {
            if (animatorUI)
            {
                if (playerController.currentLookAtBuilding == this && isInfoOpen == false)
                {
                    isInfoOpen = true;

                    //  Animation
                    animatorUI.SetBool(isOpenHash, true);
                }
                else if (playerController.currentLookAtBuilding != this && isInfoOpen == true)
                {
                    isInfoOpen = false;

                    //  Animation
                    animatorUI.SetBool(isOpenHash, false);
                }
            }
        }

        void OnEnable()
        {
            //BuildingManager.AddBuilding(this);
            //if (OnBuildingEnabled != null)
            //    OnBuildingEnabled(this);
        }

        void OnDisable()
        {
            //BuildingManager.RemoveBuilding(this);
            //if (OnBuildingDisabled != null)
            //    OnBuildingDisabled(this);
        }

        #if UNITY_EDITOR
        void OnDrawGizmosSelected()
        {
            //  Draw cubes over the points of interests to visualize
            //for (int i = 0; i < PointsOfInterests.Length; i++)
            //{
            //    Gizmos.color = Color.blue;
            //    Gizmos.DrawSphere(PointsOfInterests[i].position, 1);
            //}
        }
        #endif
        #endregion // UNTIY_METHODS

        #region PUBLIC_METHODS

        #endregion // PUBLIC_METHODS

        #region PRIVATE_METHODS

        #endregion // PRIVATE_METHODS
    }
}