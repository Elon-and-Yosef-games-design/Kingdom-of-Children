using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CandidateSelectionController : MonoBehaviour
{
    [SerializeField] private GameObject candidateList;
    [SerializeField] private TextMeshProUGUI selectedCandidateText;
    [SerializeField] private Button confirmButton;

    private string selectedCandidate;

    private void Start()
    {
        confirmButton.interactable = false;
        confirmButton.onClick.AddListener(ConfirmSelection);
    }

    public void SelectCandidate(GameObject candidateItem)
    {
        selectedCandidate = candidateItem.transform.Find("NameText").GetComponent<TextMeshProUGUI>().text;
        selectedCandidateText.text = "Selected Candidate: " + selectedCandidate;
        confirmButton.interactable = true;
    }

    private void ConfirmSelection()
    {
        if (!string.IsNullOrEmpty(selectedCandidate))
        {
            Debug.Log("Confirmed selection of candidate: " + selectedCandidate);

            // Perform any necessary actions upon confirming the selection, e.g., updating game state or transitioning to the next scene
        }
    }
}
