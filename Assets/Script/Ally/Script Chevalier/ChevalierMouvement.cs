using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ChevalierMouvement : MonoBehaviour
{
    Variables speed;
    public void Start()
    {
        speed = gameObject.GetComponent<Variables>();
    }
    public void Update()
    {
        BlocusPositon Target = FindObjectOfType<BlocusPositon>();
        if (Target.CurrentTarget != null && speed.Encombat != true)
        {
            Vector3 mouvement = Target.direction * speed.Speed * Time.deltaTime;
            transform.Translate(mouvement);
            Target.CurrentTarget.position += Vector3.forward * Time.deltaTime;
        }
        
    }






}
