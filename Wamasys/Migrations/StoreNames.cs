using System;
using System.Collections;

namespace Wamasys.Migrations
{
    class StoreNames
    {
        private string[] stores = new string[] { "Bart Smid", "Intertoys", "Speelboom", "Speel-O-Theek", "Speelgoedland", "Steengoed", "Top1Toys", "ToyRus", "Wehkamp", "Bol.com" };
        private string[] locations = new string[] { "Amsterdam", "Rotterdam", "Den Haag", "Utrecht", "Eindhoven", "Tilburg", "Groningen", "Almere", "Breda", "Nijmegen", "Enschede", "Apeldoorn", "Haarlem", "Amersfoort", "Zaanstad", "Arnhem", "Haarlemmermeer", "'s Hertogenbosch", "Zoetermeer", "Zwolle", "Maastricht", "Leiden", "Dordrecht", "Ede", "Emmen", "Westland", "Venlo", "Delft", "Deventer", "Leeuwarden", "Alkmaar", "Sittard-Geleen", "Helmond", "Heerlen", "Hilversum", "Oss", "Amstelveen", "Súdwest-Fryslân", "Hengelo", "Purmerend", "Roosendaal", "Schiedam", "Lelystad", "Alphen aan den Rijn", "Leidschendam-Voorburg", "Almelo", "Spijkenisse", "Hoorn", "Gouda", "Vlaardingen", "Assen", "Bergen op Zoom", "Capelle aan den IJssel", "Veenendaal", "Katwijk", "Zeist", "Nieuwegein", "Roermond", "Den Helder", "Doetinchem", "Hoogeveen", "Terneuzen", "Middelburg" };
        private int maxStores;
        private ArrayList availableStoreList;
        private ArrayList usedStoreList;

        public StoreNames()
        {
            maxStores = stores.Length * locations.Length;
            availableStoreList = new ArrayList();
            loadStores();
            usedStoreList = new ArrayList();
        }

        /// <summary>
        /// gets a new Store
        /// </summary>
        /// <returns></returns>
        public string GetNewStore()
        {
            if (availableStoreList.Count != 0)
            {
                return newStore();
            }

            else
            {
                Console.WriteLine("NoMoreStores to Generate");
                return "noMoreStores";
            }
        }

        /// <summary>
        /// Returns a new Store, puts it in the list 
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        private string newStore()
        {
            var rand = new Random();

            var id = rand.Next(0, availableStoreList.Count);
            var name = (string)availableStoreList[id];
            availableStoreList.RemoveAt(id);
            usedStoreList.Add(name);
            return name;
        }

        /// <summary>
        /// Creates a storeList 
        /// </summary>
        private void loadStores()
        {
            availableStoreList = new ArrayList();
            for (var i = 0; i < stores.Length; i++)
            {
                for (var j = 0; j < locations.Length; j++)
                {
                    availableStoreList.Add(stores[i] + " " + locations[j]);
                }
            }
        }
    }
}