using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    //destroy item picked(Object)
    public virtual void OnPicked()
    {
        Destroy(gameObject);
    }


}
