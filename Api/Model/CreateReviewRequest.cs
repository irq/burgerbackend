using System;

namespace Sion.BurgerBackend.Api.Model
{
    public class CreateReviewRequest
    {
        public string? Username { get; set; }
        public Guid BurgerId { get; set; }
        public int TasteScore { get; set; }
        public int TextureScore { get; set; }
        public int VisualScore { get; set; }
    }
}
