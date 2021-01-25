using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class UIViewForSettingSizeReset : BaseMonoBehaviour
{
    public Text ui_TvSize;
    public Slider ui_Pro;
    public Button ui_BtSubmit;

    private void Awake()
    {
        AutoLinkUI();
    }
}