using System;
using UnityEngine;

public abstract class KeyHolder : MonoBehaviour
{

    public abstract bool MayOpen(String requiredKey);
}
