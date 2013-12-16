﻿namespace FeatureBee.Server.Controllers
{
    using FeatureBee.Server.Data.Features;
    using FeatureBee.Server.Models;

    using Microsoft.AspNet.SignalR;

    public class BoardHub : Hub
    {
        private FeatureRepository featureRepository;

        public BoardHub()
        {
            this.featureRepository = new FeatureRepository();
        }

        public void AddNewItem(string name, string team)
        {
            var feature = new Feature{ title = name, team = team, index = 0 };
            featureRepository.Update(name, feature);
            this.NewItemAdded(feature);
        }

        public void EditItem(string name, string team, int index)
        {
            var feature = new Feature { title = name, team = team, index = index };
            featureRepository.Update(name, feature);
            this.ItemEdited(feature);
        }

        public void ItemEdited(Feature item)
        {
            Clients.All.itemEdited(item);
        }

        public void NewItemAdded(Feature item)
        {
            Clients.All.newItemAdded(item);
        }

        public void Move(string name, int oldIndex, int newIndex)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastItemMoved(new { title = name, oldIndex = oldIndex, newIndex = newIndex });
        }
    }
}