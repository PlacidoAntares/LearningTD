using UnityEngine.UI;
using UnityEngine;

public class NodeUI : MonoBehaviour {

	public GameObject UI;
	public Text upgradeCost;
	public Button upgradeButton;

	public Text sellAmt;

	private NodeScript target;
	public int upgradeID;

	public void Start()
	{
		upgradeID = 0;
	}

	public void SetTarget(NodeScript _target)
	{
		target = _target;
		transform.position = target.GetBuildPos();
		if (!target.isMaxxed) {
			upgradeID = target.UpgradeID;
			upgradeCost.text = "$" + target.turretBlueprint.cost[upgradeID];
			upgradeButton.interactable = true;
		} else {

			upgradeCost.text = "Max lvl";
			upgradeButton.interactable = false;
		}

		sellAmt.text = "$" + target.turretBlueprint.GetSellAmount (upgradeID);
		UI.SetActive(true);
	}

	public void Hide()
	{
		UI.SetActive(false);
		Debug.Log ("UI hidden");
	}

	public void Upgrade()
	{
		target.UpgradeTurret ();
		BuildManager.instance.DeselectNode ();
	}

	public void Sell()
	{
		target.SellTurret ();
		BuildManager.instance.DeselectNode ();
	}
}
