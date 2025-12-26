using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Ayarlarý")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI instructionText;

    [Header("Ses Ayarlarý (YENÝ)")]
    public AudioSource audioSource; 
    public AudioClip successClip;  

    private int currentScore = 0;
    private int totalObjects = 4;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateScoreUI();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void AddScore()
    {
        currentScore++;
        UpdateScoreUI();

     
        if (successClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(successClip); 
        }

        if (currentScore >= totalObjects)
        {
            instructionText.text = "TEBRÝKLER! HEPSÝNÝ BULDUN!";
            instructionText.color = Color.green;
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Doðru: " + currentScore;
    }
}