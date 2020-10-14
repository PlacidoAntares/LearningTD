using UnityEngine;
using UnityEngine.EventSystems;

public class NodeScript : MonoBehaviour {

    public Color hoverColor;
    public Vector3 positionOffset;

	[HideInInspector]
    public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	public bool isMaxxed = false;
	public int UpgradeID;

    BuildManager buildManager;
    private Renderer rend;
    public Color NotEnoughMoney;
    private Color startColor;

    void Start()
    {
		UpgradeID = 0;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPos()
    {
        return transform.position + positionOffset;
    }
    void OnMouseDown()
    {
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}

        if(turret != null)
        {
			buildManager.SelectNode (this);
            return;
        }

		if(!buildManager.CanBuild)
		{
			return;
		}
        //Build a turret
		BuildTurret(buildManager.GetTurretToBuild());
        
    }

	void BuildTurret(TurretBlueprint blueprint)
	{
		if(PlayerStats.Money < blueprint.cost[UpgradeID])
		{
			Debug.Log("Insuficient Funds");
			return;
		}
		PlayerStats.Money -= blueprint.cost[0];
		GameObject _turret = (GameObject)Instantiate(blueprint.prefab[0],GetBuildPos(),Quaternion.identity);
		turret = _turret;

		turretBlueprint = blueprint;
		GameObject BuildFx = Instantiate(buildManager.BuildFX,GetBuildPos(), Quaternion.identity);
		Destroy(BuildFx, 5f);
		Debug.Log("Turret Built. Money left: " + PlayerStats.Money);
	}

	public void UpgradeTurret()
	{
		if(PlayerStats.Money < turretBlueprint.cost[UpgradeID])
		{
			Debug.Log("Insuficient Funds");
			return;
		}
		if (UpgradeID < (turretBlueprint.cost.Length)) {
			UpgradeID++;
			PlayerStats.Money -= turretBlueprint.cost[UpgradeID];
			Destroy (turret);


			GameObject _turret = (GameObject)Instantiate(turretBlueprint.prefab[UpgradeID],GetBuildPos(),Quaternion.identity);

			turret = _turret;
			GameObject BuildFx = Instantiate(buildManager.BuildFX,GetBuildPos(), Quaternion.identity);
			Destroy(BuildFx, 5f);
			Debug.Log("Turret Upgraded. Money left: " + PlayerStats.Money);

		}
		//Get rid of old turret


		if (UpgradeID >= (turretBlueprint.cost.Length -1)) {
			isMaxxed = true;
			UpgradeID = 0;
		}


	}

	public void SellTurret()
	{
		PlayerStats.Money += turretBlueprint.GetSellAmount(UpgradeID);
		Destroy (turret);
		GameObject BuildFx = Instantiate(buildManager.BuildFX,GetBuildPos(), Quaternion.identity);
		Destroy(BuildFx, 5f);
		turretBlueprint = null;
		UpgradeID = 0;
		isMaxxed = false;
	}

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(!buildManager.CanBuild)
        {
            return;
        }
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = NotEnoughMoney;
        }
           
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;

    }
}
