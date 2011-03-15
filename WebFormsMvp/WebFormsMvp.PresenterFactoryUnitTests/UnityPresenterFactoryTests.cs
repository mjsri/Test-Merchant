﻿using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebFormsMvp.Binder;
using WebFormsMvp.Unity;

namespace WebFormsMvp.PresenterFactoryUnitTests
{
    [TestClass]
    public class UnityPresenterFactoryTests : PresenterFactoryTests
    {
        protected override IPresenterFactory BuildFactory()
        {
            var container = new UnityContainer();
            return new UnityPresenterFactory(container);
        }
    }
}