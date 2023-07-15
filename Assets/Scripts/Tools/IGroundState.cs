using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public interface IGroundState
{
    public void StateAction(Vector3 pos);
}
