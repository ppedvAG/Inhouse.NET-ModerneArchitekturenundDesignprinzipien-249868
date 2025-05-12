namespace Solid.ISP
{
    /// <summary>
    /// Super-Interface was mehrere Interfaces vereint
    /// *** Bitte nicht nachmachen! *** Verstoß gegen ISP ***
    /// Warum? Unendlich viele Kombinationen möglich.
    /// </summary>
    public interface IHuman : ICanCook, ICanEat, ICanSleep
    {
    }
}