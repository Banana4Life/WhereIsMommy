using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KeyHolder : MonoBehaviour
{

    public abstract bool MayOpen(String requiredKey);
}
