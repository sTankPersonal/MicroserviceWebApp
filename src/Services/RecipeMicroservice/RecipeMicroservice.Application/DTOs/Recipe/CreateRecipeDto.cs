namespace RecipeMicroservice.Application.DTOs.Recipe
{
    public class CreateRecipeDto
    {
        public string Name { get; set; } = string.Empty;
        public int PrepTimeInMinutes { get; set; } = 0;
        public int CookTimeInMinutes { get; set; } = 0;
        public int Servings { get; set; } = 0;
    }
}
