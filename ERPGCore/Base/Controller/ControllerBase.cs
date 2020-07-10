namespace ERPGCore.Controller
{
    /// <summary>
    /// Controller represent creature action <br />
    /// </summary>
    [System.Serializable]
    public abstract class ControllerBase
    {
        public abstract void MoveToPoint(float x, float y, float z);
    }
}
