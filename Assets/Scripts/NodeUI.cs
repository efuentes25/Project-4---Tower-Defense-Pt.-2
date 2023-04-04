using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public TextMeshProUGUI upgradeCostText;
    public Button upgradeButton;

    public TextMeshProUGUI sellAount;
    
    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();


        if (!target.isUpgraded)
        {
            upgradeCostText.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCostText.text = "Done";
            upgradeButton.interactable = false;
        }

        sellAount.text = "$" + target.turretBlueprint.GetSellAmount();
        
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        buildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        buildManager.instance.DeselectNode();
    }
}
