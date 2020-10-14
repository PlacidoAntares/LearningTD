using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public TurretBlueprint stdTurret;
    public TurretBlueprint missileTurret;
    public TurretBlueprint laserTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStdTurret()
    {
        Debug.Log("Standard Turret selected");
        buildManager.SelectTurretToBuild(stdTurret);
    }
    public void SelectMissileTurret()
    {
        Debug.Log("Missile Turret selected");
        buildManager.SelectTurretToBuild(missileTurret);
    }

    public void SelectLaserTurret()
    {
        Debug.Log("Laser Turret selected");
        buildManager.SelectTurretToBuild(laserTurret);
    }
}
