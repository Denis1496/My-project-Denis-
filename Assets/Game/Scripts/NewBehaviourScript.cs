using UnityEngine;
using UnityEngine.EventSystems;

namespace SortItems
{
    public class NewBehaviourScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler
    {
      [SerializeField] private TrailRenderer _trail;
      private void Awake() {

       _trail.emitting = false; 
       
      }

        public void OnBeginDrag(PointerEventData eventData)
        {
        _trail.emitting = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _trail.emitting = false;
        }
    }
}
