using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private Renderer myRenderer;
    private Color originalColor;

    
    private Vector3 originalScale;

    private bool isHovering = false;
    private bool isDragging = false;
    private HandTipFollower currentHand;
    private PuzzlePiece myPuzzlePiece;

    
    [Header("Efekt Ayarlarý")]
    public float hoverScaleFactor = 1.2f; 
    public float scaleSpeed = 10f; 

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        originalColor = myRenderer.material.color;

     
        originalScale = transform.localScale;

        myPuzzlePiece = GetComponent<PuzzlePiece>();
    }

    void Update()
    {
       
        if (myPuzzlePiece != null && myPuzzlePiece.isLocked)
        {
            isDragging = false;
            
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, scaleSpeed * Time.deltaTime);
            return;
        }
        Vector3 targetScale = originalScale;

        if (isHovering || isDragging)
        {
            targetScale = originalScale * hoverScaleFactor;
        }

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
        

        if (currentHand != null)
        {
            if (isHovering && currentHand.isPinching)
            {
                isDragging = true;
            }
            else if (!currentHand.isPinching)
            {
                isDragging = false;
            }

            if (isDragging)
            {
                transform.position = currentHand.transform.position;
                myRenderer.material.color = Color.green;
            }
            else if (isHovering)
            {
                myRenderer.material.color = Color.red;
            }
            else
            {
                myRenderer.material.color = originalColor;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (myPuzzlePiece != null && myPuzzlePiece.isLocked) return;

        if (other.CompareTag("Player"))
        {
            isHovering = true;
            currentHand = other.GetComponent<HandTipFollower>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isHovering = false;

            if (!isDragging)
            {
                currentHand = null;
                if (myPuzzlePiece == null || !myPuzzlePiece.isLocked)
                {
                    myRenderer.material.color = originalColor;
                }
            }
        }
    }
}