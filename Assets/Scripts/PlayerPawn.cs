using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Shooter))]
public class PlayerPawn : Pawn, IKillable
{
    private PlayerMover mover;
    private Shooter shooter;
    [SerializeField] private GameObject shootPoint;

    // Start is called before the first frame update
    private void Start()
    {
        //load mover
        mover = GetComponent<PlayerMover>();
        shooter = GetComponent<Shooter>();
    }

    public void MoveUp()
    {
        //use the mover to move forward if not null
        if (mover != null)
        {
            mover.MoveForward(moveSpeed);
        }
    }
    public void MoveDown()
    {
        //use the mover to move backward if not null
        if (mover != null)
        {
            mover.MoveForward(-moveSpeed);
        }
    }
    public void MoveRight()
    {
        //use the mover to move backward if not null
        if (mover != null)
        {
            mover.MoveRight(moveSpeed);
        }
    }
    public void MoveLeft()
    {
        //use the mover to move backward if not null
        if (mover != null)
        {
            mover.MoveRight(-moveSpeed);
        }
    }

    [SerializeField] private GameObject bullet;
    public void Shoot()
    {
        shooter.Shoot(bullet, GetComponent<Shooter>().shootForce, this, shootPoint.transform);
    }

    /// <summary>
    /// Unloads the player pawn, to be loaded again later.  "Fakes" death to prevent needing to redo
    /// things too heavily later.  Just some data change stuff.
    /// </summary>
    public void Die()
    {
        this.gameObject.SetActive(false);
    }
}
