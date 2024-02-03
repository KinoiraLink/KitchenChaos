using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectParent;

    public KitchenObjectSO GetKitchenObjectSO()=> kitchenObjectSO;

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObejctParent)
    {
        if (this.kitchenObjectParent != null)
            this.kitchenObjectParent.ClearKitchenObject();

        this.kitchenObjectParent = kitchenObejctParent;

        if (kitchenObejctParent.HasKitchenObject())
            Debug.Log("Counter already has a kitchenObject!!");

        kitchenObejctParent.SetKitchenObject(this);

        transform.parent = kitchenObejctParent.GetKitchenObjectFollowTransform();

        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetClearCounter() => kitchenObjectParent;

    public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenObject();

        Destroy(gameObject);
    }

    public  static KitchenObject SpawnKitchenObject(KitchenObjectSO kitchenObjecSO, IKitchenObjectParent kitchenObjectParent)
    {
        Transform kitchenObjectTransform = Instantiate(kitchenObjecSO.prefab);
        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(kitchenObjectParent);
        return kitchenObject;
    }
}
