
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
///     
/// </summary>

namespace Chad_Hoang
{
    public class Building : MonoBehaviour
    {
        #region PUBLIC_VARIABLES
        public static int TotalStudents = 0;
        public int Students;
        public int MaxStudents = 3000;
        public int MinStudents = 100;
        //public bool IsConnected;
        //public Building ClosestNeighbor;
        //public List<ERRoad> roads = new List<ERRoad>();
        //public static int AvaliableBuildingID;

        public delegate void BuildingEvent(Building building);
        public static event BuildingEvent OnBuildingEnabled;
        public static event BuildingEvent OnBuildingDisabled;
        #endregion // PUBLIC_VARIABLES

        #region PRIVATE_VARIABLES
        private BuildingUI buildingUI;

        private Animator animatorUI;
        private int isOpenHash = Animator.StringToHash("isOpen");

        private PlayerController playerController;
        private bool isInfoOpen = false;
        #endregion // PRIVATE_VARIABLES

        #region UNTIY_MONOBEHAVIOUR_METHODS
	    void Awake () 
	    {
            buildingUI = GetComponent<BuildingUI>();
            animatorUI = GetComponentInChildren<Animator>();
            playerController = FindObjectOfType<PlayerController>();
        }
	
	    void Start ()
        {
            //  Randomize students in building and add to total
            Students = Random.Range(MinStudents, MaxStudents);
            TotalStudents += Students;

            //  Update UI
            if (buildingUI)
            {
                buildingUI.UpdateStats();
            }
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

            //  Update ui

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