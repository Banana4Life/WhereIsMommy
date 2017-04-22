using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyKeyHolder : KeyHolder
{
    public override bool MayOpen(string requiredKey)
    {
        return true;
    }
}