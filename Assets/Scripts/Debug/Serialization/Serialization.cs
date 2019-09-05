using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SLevel
{
    public Vector2 Dimensions;
    public List<STile> Tiles = new List<STile>();

    public SConstraints Constraints;
}

[Serializable]
public class SConstraints
{
    public int MaxMoves;
}

[Serializable]
public class STile
{
    public Vector2 Coordinate;
    public int State;
    public int EndState;
}