using DesktopMTG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMTG.Services
{
    public class CardService : ApiMTGService
    {
        protected CardService()
        {
        }

        private static CardService _service;
        public static CardService Service
        {
            get
            {
                if (_service == null)
                {
                    _service = new CardService();
                }

                return _service;
            }
        }

        public async Task<Card> GetCard(string id)
        {
            var response = await Get("Cards/" + id);
            var card = await response.Content.ReadAsAsync<Card>();
            return card;
        }

        public async Task<IEnumerable<Card>> GetAll()
        {
            var response = await Get("Cards");
            var card = await response.Content.ReadAsAsync<IEnumerable<Card>>();
            return card;
        }

        public async Task<HttpResponseMessage> AddCard(Card card)
        {
            return await Post("Cards", new KeyValuePair<string, string>[]
            {
                    new KeyValuePair<string, string>("Name", card.Name),
                    new KeyValuePair<string, string>("Id", card.Id),
                    new KeyValuePair<string, string>("OriginalType", card.OriginalType)
            });
        }

        public async Task<HttpResponseMessage> EditCard(string id, Card card)
        {
            return await Put("Cards/" + id, new KeyValuePair<string, string>[]
            {
                    new KeyValuePair<string, string>("Name", card.Name),
                    new KeyValuePair<string, string>("Id", card.Id)
            });
        }

        public async Task<HttpResponseMessage> DeleteCard(string id)
        {
            return await Delete("Cards/" + id);
        }
    }
}
