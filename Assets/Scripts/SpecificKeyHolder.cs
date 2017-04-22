using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificKeyHolder : KeyHolder
{
    public String key = null;

    public override bool MayOpen(string requiredKey)
    {
        return requiredKey.Equals(key);
    }
}