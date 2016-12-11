using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVS.Common.Infrastructure.Messaging
{
    public class Broadcaster
    {
        private class TagSubscriber
        {
            public string token { get; set; }
            public Action<Message> handler { get; set; }
        }

        Dictionary<string, List<TagSubscriber>> _tagsSubscribers;

        public Broadcaster()
        {
            _tagsSubscribers = new Dictionary<string, List<TagSubscriber>>();
        }


        public string Subscribe(string tag, Action<Message> handler)
        {
            if (!_tagsSubscribers.ContainsKey(tag))
            {
                AddTag(tag);
            }

                
            // generate token
            var token = Guid.NewGuid().ToString();

            _tagsSubscribers[tag].Add(new TagSubscriber()
            {
                token = token,
                handler = handler
            });

            return token;
        }

        
        public bool Unsubscribe(string token)
        {
            foreach (var tagSubscribers in _tagsSubscribers)
            {
                foreach (var subscriber in tagSubscribers.Value)
                {
                    if (subscriber.token == token)
                    {
                        tagSubscribers.Value.Remove(subscriber);
                        return true;
                    }
                }
            }
            return false;
        }



        public void Publish(Message message)
        {
            if (!_tagsSubscribers.ContainsKey(message.Tag))
            {
                AddTag(message.Tag);
                return;
            }

            Broadcast(message);
        }



        private void Broadcast(Message message)
        {
            _tagsSubscribers[message.Tag].ForEach((subscriber) =>
            {
                subscriber.handler(message);
            });
        }

        private void AddTag(string tag)
        {
            _tagsSubscribers.Add(tag, new List<TagSubscriber>());
        }


        //TODO: ideas
        // * implement a queue to save the messages to the broadcaster locally and handle fails.
        // * single instance of broadcaster (singleton )
    }
}
