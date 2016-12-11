using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NVS.Common.Infrastructure.Messaging;

namespace NVS.Common.Infrastructure.Test
{
    [TestClass]
    public class BroadcasterTest
    {
        [TestMethod]
        public void Broadcaster_basicUsage()
        {
            var HandlerCallingCount = 0;

            Broadcaster bc = new Broadcaster();

            // Send message, nobody will recieve it
            bc.Publish(new Message(payload: "content", tag: "mytag"));

            // Subscribe
            string token = bc.Subscribe("mytag", (message) => { HandlerCallingCount++; });

            // Send another one
            bc.Publish(new Message(payload: "content_msg2", tag: "mytag"));

            // Assert.
            Assert.AreEqual<int>(HandlerCallingCount, 1);

            // Unsubscribe.
            bc.Unsubscribe(token);

            // Send another one, nobody will recieve it.
            bc.Publish(new Message(payload: "content_msg3", tag: "mytag"));

            // Assert.
            Assert.AreEqual<int>(HandlerCallingCount, 1);
        }
    }
}
