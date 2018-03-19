using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Chad_Hoang;
using TMPro;
using System;

/// <summary>
///     Template script is placed in ..\Program Files\Unity\Editor\Data\Resources\ScriptTemplates\81-C# Script-NewBehaviourScript.cs.txt
/// </summary>
public class BuildingUI : MonoBehaviour 
{
    #region PUBLIC_VARIABLES
    #endregion // PUBLIC_VARIABLES

    #region PRIVATE_VARIABLES
    private Building building;
    private TextMeshProUGUI tmpText;
    private static TextMeshProUGUI tmpTotalStudents;
    #endregion // PRIVATE_VARIABLES

    #region MONOBEHAVIOUR_METHODS
    void Awake () 
	{
        building = GetComponent<Building>();

        //  Find TextMeshProUGUI component in children using tag
        TextMeshProUGUI[] tmps = GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI tmp in tmps)
        {
            if (tmp.CompareTag(Tags.Stats))
            {
                tmpText = tmp.GetComponent<TextMeshProUGUI>();
                break;
            }
        }

        if (!tmpTotalStudents)
        {
            tmpTotalStudents = GameObject.FindGameObjectWithTag(Tags.TotalStudents).GetComponent<TextMeshProUGUI>();
        }
    }

    void Start () 
	{

	}
	
	void Update () 
	{
		
	}

	void OnEnable()
    {
        
    }

    void OnDisable()
    {
        
    }

    internal void UpdateStats()
    {
        //  Update UI stats
        if (tmpText)
        {
            tmpText.text = "Students: " + building.Students.ToString();
        }

        //  Update total students
        if (tmpTotalStudents)
        {
            tmpTotalStudents.text = Building.TotalStudents.ToString();
        }
    }
    #endregion // UNTIY_METHODS

    #region PUBLIC_METHODS
    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS
    #endregion // PRIVATE_METHODS
}
