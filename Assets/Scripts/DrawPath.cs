using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PointModel;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UnityEngine.EventSystems;
using System.Linq;
using System;
using System.Net;
using UnityEngine.UIElements;

public class DrawPath : MonoBehaviour
{
    
    // Start is called before the first frame update
    public int[] TestId = new int[] { 1, 2, 3, 4 };

    public Vector3 pointScale = new Vector3(1f, 1f, 1f);

    string path = Application.dataPath + "/JSON/items.json";
    public List<Point> FinalPathPoints;
    
    public GameObject pointPrefab;
    Scenes sc;
    public LineRenderer lineRenderer;
    Vector3[] positions;
    Vector3 position;
    int i = 0;

    string TransitionPoint = "";
    string _initialFloor = "1floor";
    string _finalFloor = "1floor";
    public void CreatePoint(Vector3 position)
    {
        GameObject newPoint = Instantiate(pointPrefab, position, Quaternion.identity);
        newPoint.transform.localScale = pointScale;

        
        
    }

    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 2f;
        lineRenderer.endWidth = 2f;
        lineRenderer.material.color = Color.cyan;
        PointModel pointModel = new PointModel()
        {
            Items = new List<Item>()
        };

        using (StreamReader sr = new StreamReader(path))
        {
            
            string _json = sr.ReadToEnd();
            Debug.Log(_json);


            Root root = JsonConvert.DeserializeObject<Root>(_json);
            
            pointModel.Items.AddRange(root.items);
        }

        FinalPathPoints = pointModel.Items
            .SelectMany(item => item.Points)
            .Where(point => TestId.Contains(point.Id))
            .ToList();

        /*foreach (Point point in FinalPathPoints)
        {
            Debug.Log(point.Id);
            if (point.Id == 2)
            {

                Scenes.MoveToFirthFloor();

               
                Vector3 position = new Vector3(float.Parse(point.Pos_x), 0.5f, float.Parse(point.Pos_y));

                CreatePoint(position);
            }
            else
            {
                Vector3 position = new Vector3(float.Parse(point.Pos_x), 0.5f, float.Parse(point.Pos_y));

                CreatePoint(position);
            }
            
            
            
        }*/

        /*positions = new Vector3[FinalPathPoints.Count];
        foreach (Point point in FinalPathPoints)
        {
            if (point.Id == 2) // или любая другая точка из жусона
            {
                positions = new Vector3[FinalPathPoints.Count - 2];
                ClearLine();
                break;
                *//*ClearLine();
                i = 0;
                Scenes.MoveToFloor("4floor");
                position = new Vector3(float.Parse(point.Pos_x), 0.5f, float.Parse(point.Pos_y));
                positions[i] = position;*//*

            }
            else
            {
                position = new Vector3(float.Parse(point.Pos_x), 0.5f, float.Parse(point.Pos_y));
                positions[i] = position;
                i++;
            }

        }*/


        
    }

    // Update is called once per frame
    void Update()
    {

       

        
    }


    //чекает из названия кабинета какой этаж
    public string GetFloorNumber(string pointName)
    {

        if (pointName == null) return null;

        char floorNumber = '1';
        floorNumber = pointName[0];

        return floorNumber.ToString();
    }

    void ClearLine()
    {
        lineRenderer.positionCount = 0;
    }

    void DrawLine(string floor)
    {
        lineRenderer.positionCount = i;
        lineRenderer.SetPositions(positions);
    }

    void SwitchFloorButton(string floor)
    {
        Scenes.MoveToFloor(floor);
        DrawLine(floor);
    }
}

