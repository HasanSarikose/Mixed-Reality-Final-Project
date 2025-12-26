using UnityEngine;
using UnityEngine.Events; 

public class PuzzlePiece : MonoBehaviour
{
    public int ID = 1;
    public bool isTarget = false;
    public bool isLocked = false;

   
    public UnityEvent onMatchFound;

    private void OnTriggerEnter(Collider other)
    {
        if (isTarget || isLocked) return;

        PuzzlePiece otherPiece = other.GetComponent<PuzzlePiece>();

        if (otherPiece != null && otherPiece.isTarget)
        {
            if (ID == otherPiece.ID)
            {
                LockToTarget(otherPiece.transform);
            }
        }
    }

    void LockToTarget(Transform targetTransform)
    {
        isLocked = true;

       
        Collider targetCollider = targetTransform.GetComponent<Collider>();
        if (targetCollider != null)
        {
            float targetHeight = targetCollider.bounds.size.y;
            float heightOffset = targetHeight / 2f;
            Vector3 newPosition = new Vector3(targetTransform.position.x, targetTransform.position.y + heightOffset, targetTransform.position.z);
            transform.position = newPosition;
        }
        else
        {
            transform.position = targetTransform.position;
        }

        onMatchFound.Invoke();

        Debug.Log("Eþleþme saðlandý ve efektler çalýþtý!");
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore();
        }

        Debug.Log("Skor Eklendi!");
    }
}