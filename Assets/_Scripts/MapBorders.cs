using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBorders : MonoBehaviour
{
    #region Instance
    public static MapBorders ins;

    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
    }
    #endregion

    public Vector2 MapLimits;
    public Color MapBordersColor;

    private void OnDrawGizmos()
    {
        Gizmos.color = MapBordersColor;
        Gizmos.DrawWireCube(transform.position, MapLimits);
    }
}
