﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading;

namespace MongoDBProduct
{
    class DocumentCreator
    {
        private Random random = new Random();

        public BsonDocument getDocument(int product_id)
        {
            BsonDocument document = new BsonDocument
            {
                {"product_id", product_id },
                {"name", getName()},
                {"description", getDescription()},
                {"attributes", getAttributeDocument()},
                {"supplier_id", random.Next(10) + 1}
            };
            return document;
        }
        public BsonDocument getAttributeDocument()
        {
            var document = new BsonDocument
            {
                {"Attribute 1", getAttribute() + " " + random.Next(10)+1}
            };
            for(int i = 0; i < random.Next(5) + 5; i++)
            {
                document.Add("Attribute " + i+2 ,getAttribute() + " " + random.Next(10) + 1);
            }
            return document;
        }

        public string getName()
        {
            string[] firstPart = {"Lego", "Duplo"};
            string[] secondPart = {"Marvel", "DC", "Star Wars", "Star Trek", "Barby", "City", "Bionicle", "Ninjago",
            "Classic", "Disney Princess", "Elves", "Friends", "Mindstorms", "Pirates", "Technic", "Adventures",
            "Agents", "Aquazone", "Batman", "Cars", "Dacta", "Discovery", "Homemaker", "Ninja"};
            string[] thirdPart = {"Racers", "Flyers", "Santa", "Easter", "Collectible", "Tiny", "Big", "Small",
            "Story", "Adventures", "Chronicles", "Scrolls", "The beginning", "The final chapter", "Emergency", "Alert",
            "Paradisa", "Nautica", "Launch Command", "Outback", "Expert", "Novice", "System", "Forest", "Desert",
            "Robots", "Machines", "Story", "Soldiers", "Military", "Clones", "Menace", "Hope", "Republic",
            "Egypt", "America", "Forestman", "Royal", "Castle", "Journey", "Ark", "Combat", "Contact",
            "Xalax", "F1", "F2", "F3", "Elektro", "Mechanical", "Natural", "All Guns Blazing", "Stomper",
            "Roboforce", "Unitron", "UFO", "Galaxy", "Insects", "Spiders"};
            string[] fourthPart = {"The reboot", "The revamp", "The original", "the reimagining", "", "", "", "", "", "",
            "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""};
            string[] fifthPart = {"Part 1", "Part 2", "Part 3", "Part 4", "Part 5", "Part 6", "Part 7",
            "Part 8","Part 9","Part 10","Part 11","Part 12","Part 13","Part 14","Part 15","Part 16","Part 17",
            "Part 18","Part 19","Part 20","Part 21","Part 22","Part 23","Part 24","Part 25","Part 26","Part 27",
            "Part 28","Part 29","Part 30","Part 31","Part 32","Part 33","Part 34","Part 35","Part 36","Part 37"};
            return firstPart[random.Next(firstPart.Length)] + " " + secondPart[random.Next(secondPart.Length)] + " " +
                thirdPart[random.Next(thirdPart.Length)] + " " + fourthPart[random.Next(fourthPart.Length)] +" " + fifthPart[random.Next(fifthPart.Length)];
        }
        
        public string getAttribute()
        {
            
            string[] colorArray = {"red", "blue", "yellow", "orange", "purple", "gray", "green", "black",
                                       "white", "brown", "pink"};
            
            // lets create  a block
            if (random.Next(2) == 0)
            {                
                int[] blockArray = { 1, 2, 3, 4, 6, 8 };
                return colorArray[random.Next(colorArray.Length)] + " - " + blockArray[random.Next(blockArray.Length)];
            } else
            {
                // lets create a person
                string[] hairArray = {"afro", "natural", "beehive", "bowl cut", "braid", "bunches", "burr",
                "chignon", "chonmage", "conk", "crew cut", "dreadlocks", "finger wave", "flattop", "fontange",
                "french braid", "french twist", "frosted tips", "half crown", "highlights", "hime cut",
                "ivy league", "jewfro", "longhair", "mohawk", "pageboy", "part out"};

                string[] faceArray = { "angry", "happy", "salty", "neutral", "sad", "shy" };

                return colorArray[random.Next(colorArray.Length)] + " - " + faceArray[random.Next(faceArray.Length)] +
                    " - " + hairArray[random.Next(hairArray.Length)];
            }

        }
        public string getDescription()
        {
            string[] lorumArray = { "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin ullamcorper, ante vitae rhoncus aliquam, leo ante maximus nisi, a efficitur ex arcu a neque. Vestibulum quis egestas odio. In dui nibh, pellentesque a tincidunt vitae, sollicitudin sed tortor. Nam non magna a risus viverra egestas. Phasellus maximus justo at consectetur ullamcorper. Etiam in accumsan dui. Phasellus malesuada ullamcorper urna at iaculis. Fusce ac augue eleifend, sagittis quam non, sollicitudin est." ,
            "Pellentesque ullamcorper orci magna, sed cursus dolor condimentum at. Sed a dolor vitae lacus sodales convallis maximus vitae orci. Sed lobortis leo diam, tincidunt cursus odio pharetra sit amet. Sed pellentesque consectetur ante. Vestibulum volutpat, ex non viverra vulputate, neque urna laoreet sem, non euismod nisl tortor quis nibh.",
            "Morbi vehicula sagittis lacus vel convallis. Cras varius venenatis urna in dignissim. Maecenas vehicula mollis odio. Etiam laoreet pulvinar lacus in vehicula. Curabitur vel diam porta, malesuada nisi vitae, dignissim tellus. Curabitur tempor feugiat arcu, ac posuere tortor sodales eu.",
            "Ut cursus dignissim quam, quis sodales nisl scelerisque eu. Vestibulum blandit, odio sit amet mattis pulvinar, tellus odio semper neque, id lacinia urna dolor scelerisque erat. Duis at ipsum a libero malesuada bibendum ac ut felis. Suspendisse ut nibh ligula. Sed nec leo ante. Cras eu lacus tellus. Nulla nec risus id diam convallis vestibulum. Proin euismod orci vel dolor sollicitudin, non luctus leo sollicitudin. Curabitur varius eros in vulputate convallis.",
            "Nullam vitae tristique tortor, id dignissim leo. Aenean euismod turpis eget enim cursus egestas. Cras elit erat, aliquet a sodales sit amet, porttitor ac massa. In aliquam, nulla vel mattis tempor, dolor elit vehicula orci, vitae malesuada elit justo porta nisi. Sed sit amet eros maximus, ultrices est vitae, eleifend arcu. Mauris eu mi ac nulla vulputate pharetra id id ligula.",
            "Pellentesque blandit eu magna non fringilla. Ut porta lacus nec ligula faucibus aliquet. Nullam quam elit, euismod vel augue ut, pellentesque fringilla augue. Aliquam rhoncus metus non turpis facilisis eleifend. Nunc et lectus lacus. Curabitur eu mi eget diam volutpat eleifend efficitur quis turpis.",
            "Interdum et malesuada fames ac ante ipsum primis in faucibus. Sed ipsum leo, sagittis sed porta vitae, eleifend at magna. Quisque id est ut enim feugiat rutrum dictum ac nisi. Nam a tristique tortor, vel commodo mi. Vivamus diam purus, consectetur sit amet malesuada eget, elementum ac nibh.",
            "Morbi sit amet fringilla felis. Cras imperdiet eleifend elementum. Donec tempus libero sed sem posuere, et placerat quam luctus. Curabitur nisi nisl, venenatis in neque pharetra, faucibus suscipit odio. Vestibulum lobortis nec libero rutrum dapibus. Donec mauris est, tincidunt sit amet augue vitae, fermentum tristique libero. Donec ullamcorper mollis urna eget laoreet. Quisque sollicitudin semper blandit. Maecenas libero sapien, malesuada eget augue quis, malesuada ullamcorper ipsum. Proin at volutpat mauris. Nulla gravida condimentum imperdiet.",
            "Vivamus tristique aliquet pretium. Praesent pellentesque justo tortor, nec fermentum elit tempus a. Fusce rutrum est lorem, nec consectetur neque aliquet non. Donec dignissim placerat felis sed iaculis. Maecenas sit amet finibus dui, eget vulputate tellus. Morbi orci nisl, blandit sed pulvinar scelerisque, ornare in lectus. Cras at gravida libero. Maecenas efficitur, mauris eget imperdiet finibus, eros neque egestas quam, in vehicula turpis velit ac magna.",
            "Nulla malesuada mi orci, nec viverra ante mattis vel. Sed cursus mi vitae ipsum commodo condimentum. Nullam eu mauris ut enim scelerisque dignissim. Donec interdum metus nisi. Nulla velit nisi, varius sit amet accumsan eu, viverra condimentum diam. Morbi metus felis, porttitor et dui eu, fermentum commodo tortor. Quisque fermentum vestibulum accumsan.",
            "Nullam feugiat eros posuere, tempor diam ut, rhoncus metus. Sed at volutpat nisl. Nulla sodales sit amet eros nec bibendum. Aliquam suscipit felis eget eros luctus vestibulum. Aenean in lacus est. Aliquam at magna quis libero volutpat viverra. Duis quis vestibulum sem. Vivamus tellus erat, commodo id ex laoreet, iaculis sodales leo.",
            "Quisque volutpat quam et felis dignissim, vitae bibendum magna varius. Duis rutrum enim sed posuere dignissim. Maecenas diam nunc, congue id volutpat vel, cursus sed justo. Aliquam et mi turpis. Pellentesque egestas eu justo id scelerisque. Phasellus augue dui, sagittis volutpat elementum quis, dapibus eget magna. Proin tincidunt justo hendrerit, consectetur mi id, varius orci.",
            "Quisque a mauris vulputate, bibendum lectus ac, bibendum ligula. Proin sodales risus vitae luctus efficitur. Suspendisse quis porttitor eros. Suspendisse varius ornare risus at efficitur. Morbi ut urna sit amet nunc maximus sodales in at ante. Donec vulputate dapibus leo nec rhoncus. Cras sed faucibus libero. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Fusce at lacinia metus. Nulla vulputate dignissim dignissim. Cras aliquet nibh sed dui tristique congue. Phasellus non orci egestas, lacinia nisi ac, tempor est.",
            "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nullam a tincidunt libero. Cras tristique scelerisque tellus, vitae fermentum risus feugiat ut. Maecenas quis urna cursus, lacinia mi sollicitudin, tempus sem. Aliquam id tortor feugiat, pharetra sapien at, bibendum nisi. Duis accumsan nunc tristique porttitor blandit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec dui elit, ornare ut dui nec, ultrices tempus ante. Cras at tortor efficitur, cursus massa ac, consequat lorem.",
            "Nam in tortor aliquet quam rutrum scelerisque. Proin id dui id purus rhoncus pulvinar. Curabitur dignissim risus mi, ac maximus tellus porta eget. Integer vestibulum velit metus, ullamcorper eleifend leo consequat nec. Mauris consequat, magna vitae fringilla scelerisque, lorem augue egestas elit, non finibus sem nulla et urna. Proin varius aliquet magna, ac convallis nisi tempus ut. Nam pharetra vehicula semper."};
            return lorumArray[random.Next(lorumArray.Length)] + " " + lorumArray[random.Next(lorumArray.Length)];
        }
    }
}