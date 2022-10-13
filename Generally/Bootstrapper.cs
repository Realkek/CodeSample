using System;
using System.Collections.Generic;
using System.Linq;
using Scenes.BattleVsZombies.Interfaces.BaseInitialization;
using TestCardGame.Scripts.Interfaces.BaseInitialization;
using UnityEngine;

namespace Scenes.BattleVsZombies.Generally
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private List<BaseInitializable> _services;
        [SerializeField] private List<BaseView> _views;
        [SerializeField] private GameData _gameData;
        private readonly List<IUpdatable> _updatableServices = new();
        private readonly List<IUpdatableFixed> _updatableFixedServices = new();

        private void Awake()
        {
            _gameData.OnAwake();
            InitializeBase();
        }

        private void InitializeBase()
        {
            InitializeViews();
            InitializeServices();
        }

        private void InitializeViews()
        {
            foreach (var viewInitializer in _views.Select(view => view.GetComponent<IBaseInitializable>()))
            {
                viewInitializer.Construct(_gameData);
                viewInitializer.Initialize();
            }
        }

        private void InitializeServices()
        {
            foreach (var service in _services)
            {
                GetServiceComponents(service);
                service.Construct(_gameData);
                InitializeServices(service);
            }
        }

        private void GetServiceComponents(BaseInitializable service)
        {
            if (service is IComponentsReceiver componentsReceiver)
                componentsReceiver.GetComponents();
        }

        private void InitializeServices(BaseInitializable service)
        {
            service.Initialize();
            CheckUpdatableServiceState(service);
        }

        private void CheckUpdatableServiceState(BaseInitializable service)
        {
            if (service is IUpdatable updater)
                _updatableServices.Add(updater);
            if (service is IUpdatableFixed updaterFixed)
                _updatableFixedServices.Add(updaterFixed);
        }

        private void Start()
        {
            foreach (var service in _services)
                if (service is IStartable initializer)
                    initializer.OnStart();
        }

        private void OnEnable()
        {
            foreach (var baseInitializer in _services)
            {
                if (baseInitializer is ISubscriber subscriber) subscriber.Subscribe();
                if (baseInitializer is IEnabler enabler) enabler.Enable();
            }
        }

        private void OnDisable()
        {
            foreach (var baseInitializer in _services)
            {
                if (baseInitializer is ISubscriber subscriber) subscriber.Unsubscribe();
                if (baseInitializer is IDisabler disabler) disabler.Disable();
            }
            _gameData.Disable();
        }

        private void Update()
        {
            foreach (var updatableService in _updatableServices)
                updatableService.Operate();
        }

        private void FixedUpdate()
        {
            foreach (var updatableFixed in _updatableFixedServices)
                updatableFixed.FixedOperate();
        }

        private void OnDestroy()
        {
            foreach (var service in _services)
                if (service is IDisposable disposer)
                    disposer.Dispose();
        }
    }
}