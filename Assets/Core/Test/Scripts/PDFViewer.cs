using UnityEngine;
using UnityEngine.UI;

public class PDFViewer : MonoBehaviour
{
    public GameObject pdfPanel;
    public Button closeButton;

    private Texture2D pdfTexture;
    private byte[] pdfBytes;

    void Start()
    {
        pdfPanel.SetActive(false);
        closeButton.onClick.AddListener(ClosePDFViewer);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePDFViewer();
        }
    }

    void OnMouseUp()
    {
        pdfPanel.SetActive(true);
    }

    void ClosePDFViewer()
    {
        pdfPanel.SetActive(false);
    }
}