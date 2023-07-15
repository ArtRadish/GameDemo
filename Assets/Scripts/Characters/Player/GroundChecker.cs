using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float radius = 0.02f;
    [SerializeField] private float offset = 0.1f;
    [SerializeField] private LayerMask groundLayerMask;

    public bool IsOnGround => CheckGround();
    [HideInInspector]public Collider[] colliders;

    private Vector3 _checkPos => new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);
    private bool CheckGround()
    {
        colliders = Physics.OverlapSphere(_checkPos, radius, groundLayerMask, QueryTriggerInteraction.Ignore);
        return colliders.Length > 0;
    }
    
    private void OnDrawGizmosSelected()
    {
        Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);
        if (IsOnGround) Gizmos.color = transparentGreen;
        else Gizmos.color = transparentRed;
        Gizmos.DrawSphere(_checkPos,radius);
    }
}
