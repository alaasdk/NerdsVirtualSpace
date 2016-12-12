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
        public void Broadcaster_basicUsage()
        {
            var HandlerCallingCount = 0;

            // Send message, nobody will recieve it
            _broadCaster.Publish(new Message(payload: "content", tag: "mytag"));

            // Subscribe
            string token = _broadCaster.Subscribe("mytag", (message) => { HandlerCallingCount++; });

            // Send another one
            _broadCaster.Publish(new Message(payload: "content_msg2", tag: "mytag"));

            // Assert.
            Assert.AreEqual<int>(HandlerCallingCount, 1);

            // Unsubscribe.
            _broadCaster.Unsubscribe(token);

            // Send another one, nobody will recieve it.
            _broadCaster.Publish(new Message(payload: "content_msg3", tag: "mytag"));

            // Assert.
            Assert.AreEqual<int>(HandlerCallingCount, 1);
        }
    }
}
