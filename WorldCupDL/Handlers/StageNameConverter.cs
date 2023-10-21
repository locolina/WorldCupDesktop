using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupDL.Models.Enums;

namespace WorldCupDL.Handlers
{
    internal class StageNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(StageName) || t == typeof(StageName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value.ToLower())
            {
                case "final":
                    return StageName.Final;
                case "first stage":
                    return StageName.FirstStage;
                case "play-off for third place":
                    return StageName.PlayOffForThirdPlace;
                case "match for third place":
                    return StageName.PlayOffForThirdPlace;
                case "quarter-finals":
                    return StageName.QuarterFinals;
                case "quarter-final":
                    return StageName.QuarterFinals;
                case "round of 16":
                    return StageName.RoundOf16;
                case "semi-finals":
                    return StageName.SemiFinals;
                case "semi-final":
                    return StageName.SemiFinals;
            }
            throw new Exception("Cannot unmarshal type StageName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (StageName)untypedValue;
            switch (value)
            {
                case StageName.Final:
                    serializer.Serialize(writer, "Final");
                    return;
                case StageName.FirstStage:
                    serializer.Serialize(writer, "First stage");
                    return;
                case StageName.PlayOffForThirdPlace:
                    serializer.Serialize(writer, "Play-off for third place");
                    return;
                case StageName.QuarterFinals:
                    serializer.Serialize(writer, "Quarter-finals");
                    return;
                case StageName.RoundOf16:
                    serializer.Serialize(writer, "Round of 16");
                    return;
                case StageName.SemiFinals:
                    serializer.Serialize(writer, "Semi-finals");
                    return;
            }
            throw new Exception("Cannot marshal type StageName");
        }
        public static readonly StageNameConverter Singleton = new StageNameConverter();
    }
}
