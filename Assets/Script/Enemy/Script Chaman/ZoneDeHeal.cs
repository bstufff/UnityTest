using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ZoneDeHeal : MonoBehaviour
{
    static List<Variables> EnemyToheal = new List<Variables>();

    Variables Enemy1;
    Variables Enemy2;
    Variables Enemy3;
    Variables Enemy4;

    public void Dope()// ok
    {
        if (EnemyToheal.Count > 0) { Enemy1 = EnemyToheal[0]; }
        if (EnemyToheal.Count > 1) { Enemy2 = EnemyToheal[1]; }
        if (EnemyToheal.Count > 2) { Enemy3 = EnemyToheal[2]; }
        if (EnemyToheal.Count > 3) { Enemy4 = EnemyToheal[3]; }
    }

    public void Update()// ok
    {
        if (EnemyToheal.Count > 0 && Enemy1 != null)
        {
            if (IsDestroyed1())
            {
                EnemyToheal.RemoveAt(0);
                Enemy1 = (EnemyToheal.Count > 0) ? EnemyToheal[0] : null;
            }
        }
        if (EnemyToheal.Count > 1 && Enemy2 != null)
        {
            if (IsDestroyed2())
            {
                EnemyToheal.RemoveAt(1);
                Enemy2 = (EnemyToheal.Count > 1) ? EnemyToheal[1] : null;
            }
        }
        if (EnemyToheal.Count > 2 && Enemy3 != null)
        {
            if (IsDestroyed3())
            {
                EnemyToheal.RemoveAt(2);
                Enemy3 = (EnemyToheal.Count > 2) ? EnemyToheal[2] : null;
            }
        }
        if (EnemyToheal.Count > 3 && Enemy4 != null)
        {
            if (IsDestroyed4())
            {
                EnemyToheal.RemoveAt(3);
                Enemy4 = (EnemyToheal.Count > 3) ? EnemyToheal[3] : null;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D col)// ok
    {
        Variables temp = col.GetComponent<Variables>();

        EnemyToheal.Add(temp);
        Dope();
    }

    public void OnTriggerStay2D(Collider2D col)// ok
    {
        StartCoroutine(TempsHeal());//ok
        if (Enemy1 != null)
        {
            int pv1 = Enemy1.PvMax;
            if (Enemy1.Pv <= pv1 - 5)
            {
                Enemy1.Pv += 5;
            }
            if (Enemy1.Pv < pv1 && Enemy1.Pv > pv1 - 5)
            {
                Debug.Log("Full");
                Enemy1.Pv = pv1;
            }
        }

        if (Enemy2 != null)
        {
            int pv2 = Enemy2.PvMax;
            if (Enemy2.Pv <= pv2 - 5)
            {
                Enemy2.Pv += 5;
            }
            if (Enemy2.Pv < pv2 && Enemy2.Pv > pv2 - 5)
            {
                Debug.Log("Full");
                Enemy2.Pv = pv2;
            }
        }

        if (Enemy3 != null)
        {
            int pv3 = Enemy3.PvMax;
            if (Enemy3.Pv <= pv3 - 5)
            {
                Enemy3.Pv += 5;
            }
            if (Enemy3.Pv < pv3 && Enemy3.Pv > pv3 - 5)
            {
                Debug.Log("Full");
                Enemy3.Pv = pv3;
            }
        }

        if (Enemy4 != null)
        {
            int pv4 = Enemy4.PvMax;
            if (Enemy4.Pv <= pv4 - 5)
            {
                Enemy4.Pv += 5;
            }
            if (Enemy4.Pv < pv4 && Enemy4.Pv > pv4 - 5)
            {
                Debug.Log("Full");
                Enemy4.Pv = pv4;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D col)// ok
    {
        int positionDansListe = EnemyToheal.IndexOf(col.GetComponent<Variables>());
        if (positionDansListe != -1)
        {
            EnemyToheal.RemoveAt(positionDansListe);
        }
    }

    public bool IsDestroyed1()
    {
        if (Enemy1.Pv <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsDestroyed2()
    {
        if (Enemy2.Pv <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsDestroyed3()
    {
        if (Enemy3.Pv <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsDestroyed4()
    {
        if (Enemy4.Pv <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator TempsHeal()
    {
        yield return new WaitForSeconds(2f);
    }
}



