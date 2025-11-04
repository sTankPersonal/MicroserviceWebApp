namespace MovieMicroservice.Application.DTOs.MovieCategory
{
    public class MovieCategoryDto
    {
        public Guid Id { get; set; }
		public Guid MovieId { get; set; }
        public Guid CategoryId { get; set; }
        //Display Properties
        public string CategoryName { get; set; } = string.Empty;
    }
}
