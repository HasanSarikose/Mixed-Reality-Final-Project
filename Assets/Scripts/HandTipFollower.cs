using UnityEngine;

public class HandTipFollower : MonoBehaviour
{
    private Transform landmarkListParent;
    private Transform thumbTip;
    private Transform indexTip;
    private Transform wrist;
    private Transform middleMCP;

    private Rigidbody rb;
    private Camera cam;

    [Header("Konum ve Yumuþatma")]
    public float smoothSpeed = 10f;

    [Header("Dünya Alaný Sýnýrlarý (Kenar Ayarlarý)")]
    public float worldMinX = -10f;
    public float worldMaxX = 10f;
    public float worldMinY = -5f;
    public float worldMaxY = 5f;

 
    [Header("Merkez Kaydýrma (Ýnce Ayar)")]
    public float xOffset = 0f; 
    public float yOffset = 0f; 

    [Header("Derinlik (Ölçek Hilesi) Ayarlarý")]
    public float fixedZPosition = 0f;
    public float referenceHandSize = 25f;
    public float depthSensitivity = 1.0f;

    [Header("Çimdik (Pinch) Ayarlarý")]
    public bool isPinching = false;
    public float pinchThreshold = 0.05f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    void Update()
    {
        if (landmarkListParent == null)
        {
            FindHandObject();
            return;
        }

        if (landmarkListParent.childCount == 0) return;
        Transform pointContainer = landmarkListParent.GetChild(0);
        if (pointContainer.childCount <= 9) return;

       
        wrist = pointContainer.GetChild(0);
        thumbTip = pointContainer.GetChild(4);
        indexTip = pointContainer.GetChild(8);
        middleMCP = pointContainer.GetChild(9);

        if (indexTip != null && wrist != null && middleMCP != null && indexTip.gameObject.activeInHierarchy)
        {
           
            float currentHandSize = Vector3.Distance(wrist.position, middleMCP.position);
            float sizeDifference = currentHandSize - referenceHandSize;
            float zOffset = -(sizeDifference * depthSensitivity);
            float finalZ = fixedZPosition + zOffset;

            
            Vector3 handViewportPos = cam.WorldToViewportPoint(indexTip.position);

            float targetWorldX = Mathf.Lerp(worldMinX, worldMaxX, handViewportPos.x);
            float targetWorldY = Mathf.Lerp(worldMinY, worldMaxY, handViewportPos.y);

            
            Vector3 targetPos = new Vector3(targetWorldX + xOffset, targetWorldY + yOffset, finalZ);

          
            Vector3 smoothedPos = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);

            if (rb != null) rb.MovePosition(smoothedPos);
            else transform.position = smoothedPos;

           
            Vector3 thumbView = cam.WorldToViewportPoint(thumbTip.position);
            Vector3 indexView = cam.WorldToViewportPoint(indexTip.position);
            float distance2D = Vector2.Distance(new Vector2(thumbView.x, thumbView.y), new Vector2(indexView.x, indexView.y));

            if (distance2D < pinchThreshold) isPinching = true;
            else isPinching = false;
        }
    }

    void FindHandObject()
    {
        GameObject obj = GameObject.Find("HandLandmarkList Annotation(Clone)");
        if (obj != null) landmarkListParent = obj.transform;
    }
}