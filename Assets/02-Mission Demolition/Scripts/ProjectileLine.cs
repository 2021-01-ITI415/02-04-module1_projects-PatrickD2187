﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    static public ProjectileLine S;

    [Header("Set in Inspector")]
    public float            minDist = 0.1f;
    private LineRenderer    line;
    private GameObject      _poi;
    private List<Vector3>   points;

    void Awake()
    {
        S = this;
        //get a reference to the linerenderer
        line = GetComponent<LineRenderer>();
        //disable the line renderer until it is needed
        line.enabled = false;
        //initialize the points list
        points = new List<Vector3>();
    }

    //this is a property (that is, a method masquerading as a field)
    public GameObject poi
    {
        get
        {
            return (_poi);
        }
        set
        {
            _poi = value;
            if(_poi != null)
            {
                line.enabled = false;
                points = new List<Vector3>();
                AddPoint();
            }
        }
    }
    public void Clear()
    {
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();
    }
    
    public void AddPoint()
    {
        //this is called to add a point to the line
        Vector3 pt = _poi.transform.position;
        if(points.Count > 0 && (pt -lastPoint).magnitude < minDist)
        {
            //if the point isnt far enough from the last point it returns
            return;
        }
        if(points.Count == 0) //if this is the launch point
        {
            Vector3 launchPosDiff = pt - Slingshot.LAUNCH_POS;
            points.Add(pt + launchPosDiff);
            points.Add(pt);
            line.positionCount = 2;
            //sets the first two points
            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);
            //enables the line renderer
            line.enabled = true;
        }
        else
        {
            points.Add(pt);
            line.positionCount = points.Count;
            line.SetPosition(points.Count - 1, lastPoint);
            line.enabled = true;

        }
    }
    public Vector3 lastPoint
    {
        get
        {
            if (points == null)
            {
                //if there are no points returns vector3.zero
                return (Vector3.zero);
            }
            return (points[points.Count - 1]);
        }
    }
    void FixedUpdate()
    {
        if(poi == null)
        {
            //if there is no poi, search for one
            if(FollowCam.POI != null)
            {
                if (FollowCam.POI.tag == "Projectile")
                {
                    poi = FollowCam.POI;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
        AddPoint();
        if(FollowCam.POI == null)
        {
            poi = null;
        }
    }

}
