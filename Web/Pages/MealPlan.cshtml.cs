using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using Web.Interfaces;

namespace Web.Pages
{
    public class MealPlanModel(IGymWizardService gymWizardService) : PageModel
    {
        public MealPlanAnswer MealPlanAnswer { get; set; }
        public string Result { get; set; }

        public void OnGet()
        {
            Reset();

            Result = null;
        }

        public async Task OnPost(MealPlanAnswer mealPlanAnswer) 
        {
            var mealPlanUserPreferences = MealPlanUserPrefBuilder(mealPlanAnswer);

            var result = await gymWizardService.GenerateMealPlan(mealPlanUserPreferences);

            Result = result.Replace("`", string.Empty).Replace("html", string.Empty).ToString();

            Reset();
        }

        private void Reset() => MealPlanAnswer = new MealPlanAnswer();

        private static string MealPlanUserPrefBuilder(MealPlanAnswer mealPlanAnswer)
        {
            StringBuilder sb = new();

            sb.AppendLine($"My goal for this meal plan is for {mealPlanAnswer.Goal}");
            sb.AppendLine($"I want to meal plan to have a calorie estimate of {mealPlanAnswer.Calories}");
            sb.AppendLine($"{mealPlanAnswer.EatingSchedule}");
            sb.AppendLine($"My macronutrient preference for this plan is: {mealPlanAnswer.MacroNutrientsPref}");
            sb.AppendLine($"{mealPlanAnswer.IncludeCheatMeal}");
            sb.AppendLine("Do not include a workout session. Only meal plan.");
            sb.AppendLine("Generate 3 different meal plans");

            return sb.ToString();
        }
    }

    public class MealPlanAnswer
    {        
        public string Goal { get; set; }
        public string Calories { get; set; }
        public string EatingSchedule { get; set; }
        public string MacroNutrientsPref { get; set; }
        public bool IncludeCheatMeal { get; set; }
    }
}
