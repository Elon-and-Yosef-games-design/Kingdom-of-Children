using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CandidateListController : MonoBehaviour
{
    [SerializeField] private GameObject candidateItemPrefab;
    [SerializeField] private Transform contentContainer;

    private List<Candidate> candidates = new List<Candidate>
    {
        new Candidate("John Doe", "Experienced in finance and tax collection", 3),
        new Candidate("Jane Smith", "Expert in budgeting and fiscal policy", 4),
        new Candidate("Alice Brown", "Skilled in investment and financial management", 2),
        new Candidate("Bob Johnson", "Knowledgeable in economic planning and trade", 1),
    };

    private void Start()
    {
        PopulateCandidateList();
    }

    private void PopulateCandidateList()
    {
        foreach (Candidate candidate in candidates)
        {
            GameObject candidateItem = Instantiate(candidateItemPrefab, contentContainer);
            candidateItem.transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = candidate.Name;
            candidateItem.transform.Find("CVText").GetComponent<TextMeshProUGUI>().text = candidate.CV;
            candidateItem.transform.Find("RatingText").GetComponent<TextMeshProUGUI>().text = candidate.Rating.ToString();

            // Attach additional scripts or event listeners to candidateItem if needed
            Button candidateButton = candidateItem.GetComponent<Button>();
            if (candidateButton == null)
            {
                candidateButton = candidateItem.AddComponent<Button>();
            }
            candidateButton.onClick.AddListener(() => FindObjectOfType<CandidateSelectionController>().SelectCandidate(candidateItem));
        }
    }
}

[System.Serializable]
public class Candidate
{
    public string Name;
    public string CV;
    public int Rating;

    public Candidate(string name, string cv, int rating)
    {
        Name = name;
        CV = cv;
        Rating = rating;
    }
}

