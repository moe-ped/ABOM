using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour 
{
    public float MovementSpeed;
    public float AttackDamage;
    public float AttackRange;
    public float BreadcrumbDrops;
    public int Team;

	public void Move(Vector2 direction)
    {
        // Time.deltatime has to become tick time or sth. similar if we decide that brains should not be processed once per frame
        Vector3 direction3D = direction;
        transform.position += direction3D.normalized * MovementSpeed * Time.deltaTime;
    }
}
