using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
   [SerializeField]
    private bool IsBuildable;
    public bool hastower { get; set; }

    public bool GetIsBuildable()
    {
        return IsBuildable;
    }

}
