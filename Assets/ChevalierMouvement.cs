using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ChevalierMouvement : MonoBehaviour
{
    public void Update()
    {
        BlocusPositon Target = FindObjectOfType<BlocusPositon>();
        if (Target.CurrentTarget != null)
        {
            Vector3 move = Target.mouvement;
            transform.Translate(move);
            Target.CurrentTarget.position += Vector3.forward * Time.deltaTime;
        }
        
    }






}
