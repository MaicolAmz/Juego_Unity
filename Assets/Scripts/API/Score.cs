using Newtonsoft.Json;

namespace networking
{
    public class ScoreJson
    {
        [JsonProperty("score")]
        public Score score;

    }

    public class Score
    {
        [JsonProperty("id")] public int id { get; set; }
        [JsonProperty("nick")] public string nick { get; set; }
        [JsonProperty("score")] public int score { get; set; }
        [JsonProperty("date")] public string date { get; set; }

        public Score(string nick, int score)
        {
            this.id = 0;
            this.nick = nick;
            this.score = score;
            this.date = "hoy";
        }

        public override string ToString()
        {
            return $"nick: {nick} | score: {score} | date: {date}";
        }
    }
}
