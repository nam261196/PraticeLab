using UnityEngine;
using UnityEngine.UI;
public class PopulateGrid : MonoBehaviour
{
    public GameObject prefab; // This is our prefab object that will be exposed in the inspector
   
    public int numberToCreate; // number of objects to create. Exposed in inspector

    public int poolSize;
    private GameObject[] UIviewImage ;
    public int i = 0, j = 11;
    public RectTransform rectTransform;
    public float currentViewPosition = 0f, nextViewPosition = 0f, previousViewPosition = 0f;
    public float temp;
    void Start()
    {
        UIviewImage = new GameObject[poolSize];
        Populate();
        rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(400, numberToCreate * (100 + 5));
        nextViewPosition = 105;
    }

    void Update()
    {

        if (i >= poolSize)
        {
            i = 0;
        } else if (i < 0)
        {
            i = poolSize - 1;
        }
        if (rectTransform.localPosition.y - currentViewPosition > 310f && j < numberToCreate) 
        {
            temp = - nextViewPosition - 105 *10;
            UIviewImage[i].GetComponent<RectTransform>().localPosition = new Vector3(55, temp, 0);
            previousViewPosition = currentViewPosition;
            currentViewPosition = nextViewPosition;
            nextViewPosition += 105f; 
            j++;
            i++;
        }
        // need to fix this 
        else if ((rectTransform.localPosition.y - previousViewPosition < -155f) && j >11) //right here
        {

            temp = -currentViewPosition;
            UIviewImage[i].GetComponent<RectTransform>().localPosition = new Vector3(55, temp, 0);
            previousViewPosition = currentViewPosition;
            currentViewPosition -=105f;
            i--;
            j--;
        }

    }

    void Populate()
    {

        for (int i = 0; i < poolSize; i++)
        {
            // Create new instances of our prefab until we've created as many as we specified
            UIviewImage[i] = (GameObject)Instantiate(prefab, transform);
            //UIviewImage[i].GetComponent<Image>().color = Random.ColorHSV();
        }
        
    }
}