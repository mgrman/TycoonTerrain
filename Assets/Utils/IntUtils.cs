﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public static class IntUtils
{
    public static int Clip(this int i,int min,int max)
    {
        return i < min ? min : (i > max ? max : i);
    }
    public static bool IsInRange(this int i,int min_inc,int max_exc)
    {
        return i >= min_inc && i < max_exc;
    }
    
    public static int DivideUp(this int a, int b)
    {
        int res = a / b;
        if(a%b != 0)
        {
            res++;
        }
        return res;
    }
    public static int RemainderUp(this int a, int b)
    {
        int res = a % b;
        if (res == 0)
            res = b;
        return res;
    }
}

