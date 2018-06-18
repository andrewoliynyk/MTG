using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesktopMTG.Models
{
    //public class ForeignNameCard
    //{
    //    [JsonProperty(PropertyName = "language")]
    //    public string Language { get; set; }

    //    [JsonProperty(PropertyName = "multiverseid")]
    //    public int MultiverseId { get; set;}

    //    [JsonProperty(PropertyName = "name")]
    //    public string Name { get; set; }
    //}

    //public class LegalityDto
    //{
    //    [JsonProperty(PropertyName = "format")]
    //    public string Format { get; set; }

    //    [JsonProperty(PropertyName = "legality")]
    //    public string LegalityName { get; set; }
    //}

    //public class RulingCard
    //{
    //    [JsonProperty(PropertyName = "date")]
    //    public string Date { get; set; }

    //    [JsonProperty(PropertyName = "text")]
    //    public string Text { get; set; }
    //}

    public class Card
    {
        public string Id { get; set; }

        public string Artist { get; set;}

        public string Border { get; set; }

        public float? Cmc { get; set; }

        public string ColorIdentity { get; set; }

        public string Colors { get; set; }

        public string Flavor { get; set; }

        //[JsonProperty(PropertyName = "foreignNames")]
        //public ForeignNameCard[] ForeignNames { get; set; }

        public int? Hand { get; set; }

        public string ImageUrl { get; set; }

        public string Layout { get; set; }

        //public LegalityDto[] Legalities { get; set; }

        public int? Life { get; set; }

        public string Loyalty { get; set; }

        public string ManaCost { get; set; }

        public int? MultiverseId { get; set; }

        public string Name { get; set; }

        public string Names { get; set; }

        public string Number { get; set; }

        public string OriginalText { get; set; }

        public string OriginalType { get; set; }

        public string Power { get; set; }

        public string Printings { get; set; }

        public string Rarity { get; set; }

        public string ReleaseDate { get; set; }

        public bool? Reserved { get; set; }

        //[JsonProperty(PropertyName = "rulings")]
        //public RulingCard[] Rulings { get; set; }

        public string Set { get; set; }

        public string SetName { get; set; }

        public string Source { get; set; }

        public bool? Starter { get; set; }

        public string SubTypes { get; set; }

        public string SuperTypes { get; set; }

        public string Text { get; set; }

        public bool? Timeshifted { get; set; }

        public string Toughness { get; set; }

        public string Type { get; set; }

        public string Types { get; set; }

        public string Variations { get; set; }

        public string Watermark { get; set; }
    }
}
