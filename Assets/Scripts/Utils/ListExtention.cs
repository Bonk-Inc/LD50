using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtention
{
    public static T GetRandom<T>(this List<T> list)
    {
        if(list.Count == 0) return default;
        
        var randomIndex = Random.Range(0, list.Count);
        return list[randomIndex];
    }
}
