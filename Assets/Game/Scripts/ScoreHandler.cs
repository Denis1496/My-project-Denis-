using System;
using UnityEngine;
using UnityEngine.Events;

namespace SortItems
{
    public class ScoreHandler : MonoBehaviour {
    [SerializeField] private  CylinderParameters[] _cylinders;
    public UnityEvent onFull;

private void Start() {
  if(_cylinders == null) {

    Debug.LogError("Cylinder is null");
    return;
  } 
  foreach (var cylinder in _cylinders) {

cylinder.cylinder.SetCount(cylinder.targetCount);
cylinder.cylinder.onCountChanged.AddListener(onCountChanged); 

   }
}


        private void OnDestroy(){
 foreach (var cylinder in _cylinders) {

cylinder.cylinder.onCountChanged.RemoveListener(onCountChanged); 
    } 
  
}
private void onCountChanged(Cylinder cylinder) {

    for (int idx =0; idx < _cylinders.Length; idx++) {

       ref var item = ref _cylinders[idx];

        if(item.cylinder != cylinder)

        continue;

        item.count++;
      }

      bool full = true;

      foreach (CylinderParameters item in _cylinders) {

           if(item.count < item.targetCount) {

              full = false;
              break;
          }
      }
      if(full){
        Debug.Log("You win!");
        onFull.Invoke();
      }

    }
}

[System.Serializable]
public struct CylinderParameters {
public Cylinder cylinder;
public int targetCount;
[HideInInspector] public int count;
   }
}
