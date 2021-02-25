using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbScript : MonoBehaviour
{
    public LayerMask groundLayer;
	public float climbSpeed= 6f;
    public bool onGround;
	public bool onWall;
	public bool onRightWall;
	public bool onLeftWall;
	public float collisionRadius;
    public Vector2 groundOffset;
    public Vector2 rightOffset;
    public Vector2 leftOffset;

    public int side;
    public Color gizmoColor = Color.red;

    void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + groundOffset, collisionRadius, groundLayer);
        onWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer)
            || Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer);
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);
        side = onRightWall ? 1 : -1;

    
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere((Vector2)transform.position + groundOffset, collisionRadius);
        Gizmos.DrawSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawSphere((Vector2)transform.position + leftOffset, collisionRadius);
    }

}
