using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour,IKitchenObjectParent
{
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;

    public static event EventHandler OnAnyObjectPlaceHere;

    public virtual void Interact(Player player) { }
    public virtual void InteractAlternate(Player player) { }
    public void ClearKitchenObject() => kitchenObject = null;

    public bool HasKitchenObject() => kitchenObject != null;


    public void SetKitchenObject(KitchenObject kitchenObject) { 
        this.kitchenObject = kitchenObject; 

        if(kitchenObject != null )
        {
            OnAnyObjectPlaceHere?.Invoke(this, EventArgs.Empty);
        }
    
    }


    public Transform GetKitchenObjectFollowTransform() => counterTopPoint;

    public KitchenObject GetKitchenObject() => kitchenObject;

}
