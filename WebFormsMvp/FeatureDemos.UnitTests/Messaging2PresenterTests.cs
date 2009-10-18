﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebFormsMvp.FeatureDemos.Logic.Views;
using Rhino.Mocks;
using WebFormsMvp.FeatureDemos.Logic.Presenters;
using WebFormsMvp.FeatureDemos.Logic.Domain;

namespace WebFormsMvp.FeatureDemos.Web
{
    [TestClass]
    public class Messaging2PresenterTests
    {
        [TestMethod]
        public void MessagingPresenter1_Load_ShouldSubscribeToAWidgetMessage()
        {
            // Arrange
            var view = MockRepository.GenerateStub<IMessaging2View>();
            var presenter = new Messaging2Presenter(view);
            presenter.Messages = MockRepository.GenerateMock<IMessageBus>();
            presenter.Messages
                .Expect(m => m.Subscribe<Widget>(null))
                .IgnoreArguments();

            // Act
            view.Raise(v => v.Load += null, null, null);

            // Assert
            presenter.Messages.VerifyAllExpectations();
        }

        [TestMethod]
        public void MessagingPresenter1_Load_ShouldSetDisplayTextWithReceivedWidget()
        {
            // Arrange
            var view = MockRepository.GenerateStub<IMessaging2View>();
            var presenter = new Messaging2Presenter(view);
            presenter.Messages = new MessageCoordinator();
            var message = new Widget { Id = 12345 };

            // Act
            view.Raise(v => v.Load += null, null, null);
            presenter.Messages.Publish(message);

            // Assert
            StringAssert.Contains(view.Model.DisplayText, message.Id.ToString());
        }
    }
}
