using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ConnectedPoint
{
    public int Target_id { get; set; }
    public int Weight { get; set; }
}

public class Item
{
    public int Floor { get; set; }
    public List<Point> Points { get; set; }
}


public class Point
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }

    public string Pos_x { get; set; }
    public string Pos_y { get; set; }
    public string Icon { get; set; }
    public List<ConnectedPoint> ConnectedPoints { get; set; }
}

public class PointModel
{
    public List<Item> Items { get; set; }
}

public class Root
{
    public List<Item> items;
}


