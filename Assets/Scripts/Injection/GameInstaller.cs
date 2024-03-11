using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InputController>().FromNew().AsSingle().NonLazy();
    }
}

public interface IInputController
{
    bool IsIdle { get; }
    bool IsFiring { get; }
    int MoveDirection { get; }
}

public class InputController : IInputController, ITickable
{
    public bool IsIdle { get; private set; }
    public bool IsFiring { get; private set; }
    public int MoveDirection { get; private set; }

    public void Tick()
    {
        IsIdle = !Input.anyKey;
        IsFiring = Input.GetKeyDown(KeyCode.Space);
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            MoveDirection = -1;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            MoveDirection = 1;
        }
        else 
        { 
            MoveDirection = 0; 
        }

    }
}