using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    [CreateAssetMenu(fileName = "VFXPool", menuName = "Game/VFXPool", order =1)]
    public class VFXPool : ScriptableObject {
    [SerializeField] private int _size = 5;
    [SerializeField] private GameObject _vfxPrefab;

    private List<VFXPool_Item> _items;
    private Queue<VFXPool_Item> _queue;
    private bool _poolIsInitialized = false;

    public void InitializePool() {
        if(_poolIsInitialized) {

            return;
        }

        _items = new List<VFXPool_Item>(_size); 
        _queue = new Queue<VFXPool_Item>(_size); 

        for(int i = 0; i<_size; i++ ) {
            
      CreateItem();

        }

_poolIsInitialized = true;

    }

    public void ResetPool() {

_items.ForEach(item => {
   if (item != null && item.gameObject != null){
    Destroy(item);
   }
});

_items?.Clear();
_queue?.Clear();

_poolIsInitialized =false;

    }
    public VFXPool_Item GetFromPool() {

if(_queue.Count == 0) {
ExpandPool();

}

VFXPool_Item vfxPoolItem = _queue.Dequeue();
vfxPoolItem.OnGetFromPool();

return vfxPoolItem;
    }

    public void ReturnToPool(VFXPool_Item item) {

     _queue.Enqueue(item);

    }
    
    protected void ExpandPool() {

        for(int i = 0; i<_size; i++ ) {
            
      CreateItem();

        }

    }

    protected VFXPool_Item CreateItem(){
        GameObject itemInstance = Instantiate(_vfxPrefab);
        itemInstance.SetActive(false);
        VFXPool_Item vfxPoolItem = itemInstance.GetComponent<VFXPool_Item>();
        vfxPoolItem.Pool = this;
        _items.Add(vfxPoolItem);
        _queue.Enqueue(vfxPoolItem);
        return vfxPoolItem;
    }
   
    }
}

