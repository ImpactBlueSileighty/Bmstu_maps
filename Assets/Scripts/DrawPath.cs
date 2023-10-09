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

public class DrawPath : MonoBehaviour
{
    // Start is called before the first frame update
    public int[] TestId = new int[] { 1, 2, 3, 4 };

    public Vector3 pointScale = new Vector3(1f, 1f, 1f);

    string path = Application.dataPath + "/JSON/items.json";
    public List<Point> FinalPathPoints;
    
    public GameObject pointPrefab;

    public LineRenderer lineRenderer;

    public void CreatePoint(Vector3 position)
    {
        GameObject newPoint = Instantiate(pointPrefab, position, Quaternion.identity);
        newPoint.transform.localScale = pointScale;

        
        
    }

    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 5f;
        lineRenderer.endWidth = 10f;
        lineRenderer.material.color = Color.green;
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

        foreach (Point point in FinalPathPoints)
        {
            Debug.Log(point.Pos_x);
            Vector3 position = new Vector3(float.Parse(point.Pos_x), 0, float.Parse(point.Pos_y));
            
            CreatePoint(position);
            
        }


    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        Vector3[] positions = new Vector3[FinalPathPoints.Count];
        foreach (Point point in FinalPathPoints)
        {
            
            Vector3 position = new Vector3(float.Parse(point.Pos_x), 0, float.Parse(point.Pos_y));

            positions[i] = position;
            i++;
        }

        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }
}

