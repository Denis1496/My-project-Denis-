using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SortItems
{
    public class NewBehaviourScript1 : MonoBehaviour, IPointerDownHandler
    {
    // [SerializeField] private GameObject _circleClickFxPrefab;
     [SerializeField] private VFXPool_Provider _particlesPoolProvider;
     public UnityEvent OnClick;
   

        public void OnPointerDown(PointerEventData eventData)
        {

        VFXPool_Item ItemInstance = _particlesPoolProvider.VFXPool.GetFromPool();
        ItemInstance.transform.position= transform.position;
        ItemInstance.ParticleSystem.Play();

        //Instantiate(_circleClickFxPrefab, transform.position, Quaternion.identity, null);
        OnClick.Invoke();
        }

    }
}
