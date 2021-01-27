using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class UIViewForSettingSizeReset : BaseMonoBehaviour
{
    public Text ui_TvSize;
    public Slider ui_Pro;
    public Button ui_BtSubmit;

    public int sizeX = 10;
    public int sizeY = 10;
    public int sizeZ = 10;

    private void Awake()
    {
        AutoLinkUI();
        if (ui_BtSubmit)
            ui_BtSubmit.onClick.AddListener(OnClickForSizeReset);
        if (ui_Pro)
        {
            ui_Pro.onValueChanged.AddListener(OnValueChangeForPro);
            ui_Pro.value = 0.5f;
        }

    }

    public void SetSizeText(int sizeX, int sizeY, int sizeZ)
    {
        ui_TvSize.text = sizeX + "x" + sizeZ;
    }

    public void GetSize(out int sizeX, out int sizeY, out int sizeZ)
    {
        sizeX = this.sizeX;
        sizeY = this.sizeY;
        sizeZ = this.sizeZ;
    }

    public void OnValueChangeForPro(float value)
    {
        sizeX = (int)(value * 20) + 1;
        sizeY = 10;
        sizeZ = (int)(value * 20) + 1;
        SetSizeText(sizeX, sizeY, sizeZ);
    }

    public void OnClickForSizeReset()
    {
        SceneBuildBean sceneBuild = GameDataHandler.Instance.manager.CreateNewSceneData(sizeX, sizeY, sizeZ);
        BuildHandler.Instance.InitBuild(sceneBuild);
        CameraHandler.Instance.InitCamera();
    }
}