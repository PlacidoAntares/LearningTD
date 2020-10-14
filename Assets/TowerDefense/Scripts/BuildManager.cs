using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("No more than one BuildManager allowed");
        }
        instance = this;

    }

    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject BuildFX;

    private TurretBlueprint turretToBuild;
	private NodeScript selectedNode;
	public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money > turretToBuild.cost[0]; } }
    

	public void SelectNode(NodeScript node)
	{
		if (selectedNode == node) {
			DeselectNode ();
			return;
		}
		selectedNode = node;
		turretToBuild = null;
		nodeUI.SetTarget(node);
	}

	public void DeselectNode()
	{
		selectedNode = null;
		nodeUI.Hide();
	}
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
		DeselectNode ();
    }

	public TurretBlueprint GetTurretToBuild()
	{

		return turretToBuild;
	}
}
