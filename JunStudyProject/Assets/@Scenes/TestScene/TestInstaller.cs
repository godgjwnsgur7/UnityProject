using Zenject;
using UnityEngine;
using System.Collections;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class TestInstaller : MonoInstaller
{
    public Foo.Settings FooSettings;
    public override void InstallBindings()
    {
        Container.Bind<string>().FromInstance("Hello World!");
        Container.Bind<Greeter>().AsSingle().NonLazy();

        Container.BindInstance(FooSettings);
        Container.BindInterfacesTo<Foo>().AsSingle();

    }

    public void Test()
    {
        SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Additive);
        
        Scene scene = SceneManager.GetActiveScene();
        Scene scene2 = SceneManager.GetSceneByName("GameScene");

        SceneManager.SetActiveScene(scene);
        
        SceneManager.UnloadSceneAsync(scene.name);
    }
}

public class Greeter
{
    public Greeter(string message)
    {
        Debug.Log(message);
    }
}

public class Foo : ITickable
{
    private readonly Settings _settings;

    public Foo(Settings settings)
    {
        _settings = settings;
    }
    public void Tick()
    {
        Debug.Log("Speed : " + _settings.Speed);
    }

    [Serializable]
    public class Settings
    {
        public float Speed;
    }
}

public class TestInjection
{
    [Inject] public int _id; // 필드 주입
    [Inject] public int Id 
    { 
        get
        {
            Debug.Log("get");
            return this._id;
        }
        private set
        {
            Debug.Log("set");
            _id = value;

        }
    } // 속성 주입

    // 생성자 주입   
    public TestInjection(int id)
    {
        this.Id = id;
        Debug.Log("생성자");
    }

    // 메서드 주입
    [Inject]
    public void Init(int id)
    {
        this.Id = id;
        Debug.Log("Init");
    }
}
