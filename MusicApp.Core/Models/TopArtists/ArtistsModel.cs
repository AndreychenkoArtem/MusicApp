using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MusicApp.Core.Models.TopArtists
{
    /// <summary>
    /// Use auto-generator for creating DTO and time saving
    /// </summary>
    public partial class ArtistsModel
    {
        [JsonProperty("topartists")]
        public Topartists Topartists { get; set; }
    }

    public partial class Topartists
    {
        [JsonProperty("artist")]
        public List<Artist> Artist { get; set; }

        [JsonProperty("@attr")]
        public Attr Attr { get; set; }
    }

    public partial class Artist
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("listeners")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Listeners { get; set; }

        [JsonProperty("mbid")]
        public Guid Mbid { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("streamable")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Streamable { get; set; }

        [JsonProperty("image")]
        public List<Image> Image { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("#text")]
        public Uri Text { get; set; }

        [JsonProperty("size")]
        public Size Size { get; set; }
    }

    public partial class Attr
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("page")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Page { get; set; }

        [JsonProperty("perPage")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PerPage { get; set; }

        [JsonProperty("totalPages")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TotalPages { get; set; }

        [JsonProperty("total")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Total { get; set; }
    }

    public enum Size
    {
        Extralarge,
        Large,
        Medium,
        Mega,
        Small
    };

    public partial class ArtistsModel
    {
        public static ArtistsModel FromJson(string json) =>
            JsonConvert.DeserializeObject<ArtistsModel>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ArtistsModel self) =>
            JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                SizeConverter.Singleton,
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }

            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var value = (long) untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class SizeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Size) || t == typeof(Size?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "extralarge":
                    return Size.Extralarge;
                case "large":
                    return Size.Large;
                case "medium":
                    return Size.Medium;
                case "mega":
                    return Size.Mega;
                case "small":
                    return Size.Small;
            }

            throw new Exception("Cannot unmarshal type Size");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var value = (Size) untypedValue;
            switch (value)
            {
                case Size.Extralarge:
                    serializer.Serialize(writer, "extralarge");
                    return;
                case Size.Large:
                    serializer.Serialize(writer, "large");
                    return;
                case Size.Medium:
                    serializer.Serialize(writer, "medium");
                    return;
                case Size.Mega:
                    serializer.Serialize(writer, "mega");
                    return;
                case Size.Small:
                    serializer.Serialize(writer, "small");
                    return;
            }

            throw new Exception("Cannot marshal type Size");
        }

        public static readonly SizeConverter Singleton = new SizeConverter();
    }
}