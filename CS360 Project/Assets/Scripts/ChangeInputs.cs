using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeInputs : MonoBehaviour
{

    EventSystem system1;
    public Selectable firstInput;
    public Button submitBtn; 

    // Start is called before the first frame update
    void Start()
    {
        system1 = EventSystem.current;
        firstInput.Select();
    }

    // Update is called once per frame
    // This is for when the user clicks tab to go to the next input field
    void Update()
    {
        // Checks if the the tab and left shift is clicked
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift)) {
            Selectable previous = system1.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if(previous != null) {
                previous.Select();
            }
        }
        // Checks if the tab is clicked
        else if (Input.GetKeyDown(KeyCode.Tab)) {
            Selectable next = system1.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if(next != null) {
                next.Select();
            }
        }
        // Checks if the enter button is clicked 
        else if (Input.GetKeyDown(KeyCode.Return)) {
            submitBtn.onClick.Invoke();
            Debug.Log("Button pressed!");
        }
    }
}
