using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NVS.Common.Infrastructure.Messaging;

namespace NVS.Common.Infrastructure.Messaging.Tests
{
    [TestClass]
    public class BroadcasterTest
    {
        IBroadcaster _broadCaster;

        [TestInitialize()]
        public void Startup() 
        {
            _broadCaster = new Broadcaster();
        }

        [TestMethod]
        public void subscribe_handler_called()
        {
            // Arrange Assert Act

            var handlerCalled = false;

            // Subscribe
            string token = _broadCaster.Subscribe("mytag", (message) => { handlerCalled = true; });

            // Send another one
            _broadCaster.Publish(new TextMessage(payload: "content_msg2", tag: "mytag"));
  
            // Assert.
            Assert.AreEqual<bool>(handlerCalled, true);
        }


        [TestMethod]
        public void subscribe_handler_called_count()
        {
            var HandlerCallingCount = 0;

            // Send message, nobody will recieve it
            _broadCaster.Publish(new TextMessage(payload: "content", tag: "mytag"));

            // Subscribe
            _broadCaster.Subscribe("mytag", (message) => { HandlerCallingCount++; });

            // Send another one
            _broadCaster.Publish(new TextMessage(payload: "content_msg2", tag: "mytag"));

            // Send another one
            _broadCaster.Publish(new TextMessage(payload: "content_msg3", tag: "mytag"));

            // Assert.
            Assert.AreEqual<int>(HandlerCallingCount, 2);
        }

        [TestMethod()]
        public void unsubscribe_successfully()
        {
            var HandlerCallingCount = 0;

            // Subscribe
            string token = _broadCaster.Subscribe("mytag", (message) => { HandlerCallingCount++; });

            // Send message
            _broadCaster.Publish(new TextMessage(payload: "content", tag: "mytag"));

            // Send another one
            _broadCaster.Publish(new TextMessage(payload: "content_msg2", tag: "mytag"));

            _broadCaster.Unsubscribe(token);

            // Send another one
            _broadCaster.Publish(new TextMessage(payload: "content_msg3", tag: "mytag"));

            // Assert.
            Assert.AreEqual<int>(HandlerCallingCount, 2);
        }
    }
}
