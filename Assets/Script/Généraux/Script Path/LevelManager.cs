using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    [Serializable]
    public class Path {
        public Transform startPoint;
        public Transform[] path;

    }
    public Transform startPoint;
    public Transform[] path;
    [SerializeField] public List<Path> Paths = new List<Path>();
    private void Awake()
    {
        main = this;
    } 
}
