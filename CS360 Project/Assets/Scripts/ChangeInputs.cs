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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift)) {
            Selectable previous = system1.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if(previous != null) {
                previous.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Tab)) {
            Selectable next = system1.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if(next != null) {
                next.Select();
            }
        } else if (Input.GetKeyDown(KeyCode.Return)) {
            submitBtn.onClick.Invoke();
            Debug.Log("Button pressed!");
        }
    }
}
