using Business.Services;
using Data.Models;
using FoodPlannerApi.DTO;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace FoodPlannerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IIngrediantsService _ingrediantsService;

        public RecipeController(IRecipeService recipeService, IIngrediantsService ingrediantsService)
        {
            _recipeService = recipeService;
            _ingrediantsService = ingrediantsService;
        }

        [HttpPost]
        [Route("api/[controller]/createrecipe")]
        public async Task<ActionResult<Recipe>> CreateRecipe(RecipeDTO recipeDTO)
        {
            var recipe = new Recipe
            {
                FinalProduct = recipeDTO.FinalProduct,
                Howto = recipeDTO.Howto,
                Name = recipeDTO.Name,
                Picture = recipeDTO.Picture,
            };
            if (ModelState.IsValid)
            {

                var createdRecipe = await _recipeService.CreateRecipe(recipe);


                foreach (var item in recipeDTO.Ingrediants)
                {
                    await _ingrediantsService.CreateIngrediant(item, createdRecipe.Id);
                }
                return Ok(createdRecipe);
            }
            else
                return BadRequest("Modelstate not valid");
        }

        [HttpPost]
        [Route("api/[controller]/deleterecipe/{id}")]
        [ProducesResponseType(typeof(RecipeDTO), 200)]
        public ActionResult<Recipe> DeleteRecipe(int id)
        {
            if (_recipeService.Delete(id).IsCompleted)
            {
                return Ok();

            }
            else
            {
                return BadRequest($"could not find recipe with id {id}");
            }
        }

        [HttpGet]
        [Route("api/[controller]/getrecipe/{id}")]
        public ActionResult<Recipe> GetRecipeAsync(int id)
        {   
            var recipe = _recipeService.GetRecipe(id);
            if (recipe != null)
            {
                recipe.Ingrediants = _ingrediantsService.GetAllIngrediantsWithRecipeId(id);
                return recipe;

            }
            else
            {
                return BadRequest($"Could not find recipe by id {id}");
            }
        }

        [HttpGet]
        [Route("api/[controller]/getallrecipe")]
        public ActionResult<List<Recipe>> GetRecipes()
        {
            var recipies = _recipeService.GetAllRecipes();
            if (recipies != null)
            {
                return recipies;

            }
            else
            {
                return BadRequest("Could not get recipies");
            }
        }

       
    }
}
