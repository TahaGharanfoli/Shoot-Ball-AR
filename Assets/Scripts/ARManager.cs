using System;
using System.Collections;
using System.Collections.Generic;
using easyar;
using UnityEngine;
using UnityEngine.Events;

public class ARManager : MonoBehaviour
{
   private ImageTargetController _imageTargetController;
   [SerializeField] UnityEvent WhenFound;
   [SerializeField] UnityEvent WhenLost;
   private void Awake()
   {
      _imageTargetController= this.GetComponent<ImageTargetController>();
      _imageTargetController.TargetFound += WhenFound.Invoke;
      _imageTargetController.TargetLost += WhenLost.Invoke;
   }
   
}
