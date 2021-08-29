using System;

namespace Sion.BurgerBackend.Api.Model
{
    public class GetReviewResponse
    {
        public string Username { get; set; }
        public int TasteScore { get; set; }
        public int TextureScore { get; set; }
        public int VisualScore { get; set; }

        public GetReviewResponse(string username, int tasteScore, int textureScore, int visualScore)
        {
            Username = username;
            TasteScore = tasteScore;
            TextureScore = textureScore;
            VisualScore = visualScore;
        }
    }
}
