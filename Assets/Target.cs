using UnityEngine;

public class Target : MonoBehaviour
{
    private bool isHit = false; 

    public void HandleHit(Vector3 hitPoint, AudioClip hitSound)
    {
        if (isHit) return; 

        isHit = true; 
        GameManager.Instance.UpdateScore(1); 
        AudioSource.PlayClipAtPoint(hitSound, hitPoint);
        Debug.Log("Target hit: " + gameObject.name);

    }
}