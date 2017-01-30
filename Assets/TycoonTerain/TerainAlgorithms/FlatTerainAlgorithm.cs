﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FlatTerainAlgorithm : MonoBehaviour,ITerainAlgorithm
{
    public bool RequiresWalls { get { return true; } }

    public HeightData Process(HeightData heightData)
    {
        float avgHeight = heightData.Avg;
        
        return HeightData.Constant(avgHeight);
    }
}