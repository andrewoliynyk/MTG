using MTG.Models;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Service;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace MTG
{
    public class Runner
    {
        private readonly MTGContext _context;
        static HttpClient client;

        public Runner(MTGContext CardContex)
        {
            _context = CardContex;

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };

            client = new HttpClient(handler);
            client.BaseAddress = new Uri(@"https://api.magicthegathering.io/v1");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private string ConvertStr(string[] str)
        {
            string result = "";
            if (str == null) { return ""; }
            foreach (var s in str)
            {
                result += s + "|";
            }
            return result;
        }

        private string ConvertInt(int[] i)
        {
            string result = "";
            if (i == null) { return ""; }
            foreach (var s in i)
            {
                result += s.ToString() + "|";
            }
            return result;
        }

        private async Task UpdateCards()
        {
            IEnumerable<Card> Cards = null;

            CardService service = new CardService();
            var asyncResult = await service.Where(x => x.Set, "dom").AllAsync();
            //HttpResponseMessage response = await client.GetAsync(@"https://api.magicthegathering.io/v1/cards");
            if (asyncResult.IsSuccess)
            {
                var obj = asyncResult.Value;
                Cards = obj.Select(item => new Card()
                {
                    Artist = item.Artist,
                    Border = item.Border,
                    Cmc = item.Cmc,
                    ColorIdentity = ConvertStr(item.ColorIdentity),
                    Colors = ConvertStr(item.Colors),
                    Flavor = item.Flavor,
                    Hand = item.Hand,
                    ImageUrl = item.ImageUrl.ToString(),
                    Layout = item.Layout,
                    Life = item.Life,
                    Loyalty = item.Loyalty,
                    ManaCost = item.ManaCost,
                    MultiverseId = item.MultiverseId,
                    Name = item.Name,
                    Names = ConvertStr(item.Names),
                    Number = item.Number,
                    OriginalText = item.OriginalText,
                    OriginalType = item.OriginalType,
                    Power = item.Power,
                    Printings = ConvertStr(item.Printings),
                    Rarity = item.Rarity,
                    ReleaseDate = item.ReleaseDate,
                    Reserved = item.Reserved,
                    Set = item.Set,
                    SetName = item.SetName,
                    Source = item.Source,
                    Starter = item.Starter,
                    SubTypes = ConvertStr(item.SubTypes),
                    SuperTypes = ConvertStr(item.SuperTypes),
                    Text = item.Text,
                    Toughness = item.Toughness,
                    Type = item.Type,
                    Types = ConvertStr(item.Types),
                    Variations = ConvertInt(item.Variations),
                    Watermark = item.Watermark
                });
            }

            foreach (var item in _context.Card)
            {
                _context.Card.Remove(item);
            }

            foreach (var item in Cards.ToList())
            {
                _context.Card.Add(item);
            }
        }

        public async Task Run()
        {
            await UpdateCards();

            _context.SaveChanges();
        }
    }
}
