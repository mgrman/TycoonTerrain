﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SimpleMeshGenerator:MonoBehaviour,IMeshGenerator
{
    public bool RequiresWalls { get { return false; } }

    public HeightData Process(HeightData sampleData)
    {
        return sampleData;
    }
}
