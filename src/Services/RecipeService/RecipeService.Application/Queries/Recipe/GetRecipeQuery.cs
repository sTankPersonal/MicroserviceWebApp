using BuildingBlocks.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeService.Application.Queries.Recipe
{
    public class GetRecipeQuery(string? searchName, int? searchPrepTimeInMinutes, int? searchCookTimeInMinutes, int? searchServings, int pageNumber = 1, int pageSize = 10) : PagedQuery(pageNumber, pageSize)
    {
        public string? SearchName { get; } = searchName;
        public int? SearchPrepTimeInMinutes { get; } = searchPrepTimeInMinutes;
        public int? SearchCookTimeInMinutes { get; } = searchCookTimeInMinutes;
        public int? SearchServings { get; } = searchServings;
    }
}
