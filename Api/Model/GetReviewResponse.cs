using System;

namespace Sion.BurgerBackend.Api.Model
{
    public class GetReviewResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public int TasteScore { get; set; }
        public int TextureScore { get; set; }
        public int VisualScore { get; set; }

        public GetReviewResponse(Guid id, string username, int tasteScore, int textureScore, int visualScore)
        {
            Id = id;
            Username = username;
            TasteScore = tasteScore;
            TextureScore = textureScore;
            VisualScore = visualScore;
        }
    }
}
