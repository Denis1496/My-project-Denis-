using System;
using UnityEngine;
using UnityEngine.Events;

namespace SortItems
{
    public class Cylinder : MonoBehaviour {
        [SerializeField] private ItemType type;
       
        private DragItem _item;
        private Material _material;
        private Color _defaultcolor;
        private int targetCount = 1;
        private int count = 0;
        private bool active = true;
        public UnityEvent <Cylinder> onCountChanged;
        internal int length;

        public void SetCount(int value){
            targetCount = value;
            if(count >= targetCount) {
                _material.color = Color.grey;
                active = false;
            }
        }
        private void Start() {
_material = GetComponent<MeshRenderer>().material;
_defaultcolor = _material.color;
        }

        private void OnTriggerStay(Collider other) {
            if(!active)
            return;
        var item = other.attachedRigidbody.GetComponent<DragItem>();

        if (item != null && item.isDraggable == true) {

         _item = item;
          if(_item.Type == type){
_material.color = Color.green;
          } else {
_material.color = Color.black;
          }
         return;
        } 
        if(item.isDraggable == false && _item == item) {

            TryGetItem();
            _material.color = _defaultcolor;
            _item = null;

            return;
        }
     
    }
    
    private void OnTriggerExit(Collider other) {
        if(!active)
        return;
     var item = other.attachedRigidbody.GetComponent<DragItem>();

     if(_item == item) {
 _material.color = _defaultcolor;

   if(item.isDraggable == false)
 TryGetItem();
  _item = null;
    }
}

        private void TryGetItem() {

            if(_item.Type == type) {  

            //Destroy(_item.gameObject);
            _item.OnHideRequest.Invoke();
            count++;
            onCountChanged.Invoke(this);

             if(count >= targetCount) {
                _material.color = Color.grey;
                active = false;
             }
            
            }
        }
    }
   }


