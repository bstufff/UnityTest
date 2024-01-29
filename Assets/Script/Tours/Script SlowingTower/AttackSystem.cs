using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    public int Cout = 50;

    public float VitesseAv;

    public List<EnemyMovement> EnemyInRange = new List<EnemyMovement>();

    public EnemyMovement AcctualEnemy;
    public SpriteRenderer SlowingTowerZone;
    public void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        AcctualEnemy = col.GetComponent<EnemyMovement>();
        EnemyInRange.Add(AcctualEnemy);
        VitesseAv = AcctualEnemy.moveSpeed;
        AcctualEnemy.moveSpeed = VitesseAv/2;
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        EnemyInRange[0].moveSpeed = VitesseAv;
        EnemyInRange.RemoveAt(0);
        AcctualEnemy = null;
        if(AcctualEnemy == null) 
        {  
            SlowingTowerZone.enabled = false;
        }
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        AcctualEnemy = col.GetComponent<EnemyMovement>();
        SlowingTowerZone.enabled = true;
    }
}
