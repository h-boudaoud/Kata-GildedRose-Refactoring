using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 20, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

            };

            for (int i = 0; i < 100; i++)
            {
                app.UpdateQuality(i);
            }


            System.Console.ReadKey();

        }

        public void UpdateQuality(int j)
        {
            for (var i = 0; i < Items.Count; i++)
            {

                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }

                System.Console.WriteLine("{3} \t {0} \t \t {1} \t {2}  ", Items[i].Name, Items[i].Quality, Items[i].SellIn, j);
            }
        }


        #region refactoring

        public static void UpdateItems(IList<Item> items)
        {

            foreach (Item item in items)
            {
                UpdateItemQuality(item);
            }
        }

        private static void UpdateItemQuality(Item item)
        {



            if (item.Name == "Aged Brie")
            {

                if (item.Quality < 50)
                {
                    item.Quality++;
                }

                item.SellIn--;
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.SellIn < 0) 
                {
                    item.Quality = 0;
                }
                else if (item.Quality < 50 && item.SellIn < 6)
                {
                    item.Quality = Math.Min(50, item.Quality + 3);
                }
                else if (item.Quality < 50 && item.SellIn < 11)
                {
                    item.Quality = Math.Min(50, item.Quality + 2); 
                }
                else if (item.Quality < 50)
                {
                        item.Quality ++;
                }

                item.SellIn--;
            }
            else if( item.Name != "Sulfuras, Hand of Ragnaros")
            {
                if (item.SellIn < 0)
                {
                    item.Quality = Math.Max(0,item.Quality - 2);
                }
                else if (item.Quality > 0)
                {                   
                    item.Quality --;
                }

                item.SellIn--;
            }
        } 
        #endregion
    }


    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
