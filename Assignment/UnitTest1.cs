using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Assignment
{
    [TestClass]
    public class UnitTest1
    {
        string jsonString = File.ReadAllText("json.txt");

        [TestMethod]
        public void ForeignPlayerCount()
        {
            var team = JsonConvert.DeserializeObject<Team>(jsonString);
            var foreignePlayerCount = team.Player.FindAll(x => x.Country != "India").Count;
            Assert.IsTrue(foreignePlayerCount == 4, $"Team does not have 4 foreign palyers. Actual: {foreignePlayerCount}");
        }


        [TestMethod]
        public void WicketKeeperCount()
        {
            var team = JsonConvert.DeserializeObject<Team>(jsonString);
            var wicketKeeperCount = team.Player.FindAll(x => x.Role == "Wicket-keeper").Count;
            Assert.IsTrue(wicketKeeperCount >= 1, $"Team has less than 1 Wicket-keeper. Actual: {wicketKeeperCount}");
        }
    }
}
