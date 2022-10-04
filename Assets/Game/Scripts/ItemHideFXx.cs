using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace SortItems
{
    public class ItemHideFXx : MonoBehaviour
    {
     //[SerializeField] private GameObject _hideFxPrefub;
     [SerializeField] private VFXPool_Provider _vfxPoolProvider;
     public void Hide() {
        //Instantiate(_hideFxPrefub, transform.position, Quaternion.identity, null);
        VFXPool_Item pool_Item = _vfxPoolProvider.VFXPool.GetFromPool();
        pool_Item.transform.position= transform.position;
        pool_Item.ParticleSystem.Play();
        Destroy(this.gameObject);
       
     }
    }
}
