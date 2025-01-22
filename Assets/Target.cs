using UnityEngine;

public class Target : MonoBehaviour
{
    private bool isHit = false; 
    [SerializeField] public bool rangeTarget;

    public void HandleHit(Vector3 hitPoint, AudioClip hitSound)
    {
        if(rangeTarget) {
            AudioSource.PlayClipAtPoint(hitSound, hitPoint);
        }

        else if (isHit) {
            return;
        }

        else if(!rangeTarget)
        {

        isHit = true; 
        GameManager.Instance.UpdateScore(1); 
        AudioSource.PlayClipAtPoint(hitSound, hitPoint);
        Debug.Log("Target hit: " + gameObject.name);

        }
    }
}