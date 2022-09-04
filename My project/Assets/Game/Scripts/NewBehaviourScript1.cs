using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SortItems
{
    public class NewBehaviourScript1 : MonoBehaviour, IPointerDownHandler
    {
     [SerializeField] private GameObject _circleClickFxPrefab;
     public UnityEvent OnClick;

        public void OnPointerDown(PointerEventData eventData)
        {
            Instantiate(_circleClickFxPrefab, transform.position, Quaternion.identity, null);
            OnClick.Invoke();
        }
    }
}
