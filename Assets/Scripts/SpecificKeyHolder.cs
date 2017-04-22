using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificKeyHolder : KeyHolder
{
    public List<string> key = new List<string>();

    public override bool MayOpen(string requiredKey)
    {
        return key.Contains(requiredKey);
    }
}