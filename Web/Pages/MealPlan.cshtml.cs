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

            sb.AppendLine($"Generate a meal plan with a calorie sum that is less than or equal to {mealPlanAnswer.Calories} kcal");
            sb.AppendLine($"{mealPlanAnswer.EatingSchedule}");
            sb.AppendLine($"{mealPlanAnswer.MacroNutrientsPref}");
            sb.AppendLine("Do not include a workout session. Only meal plan.");
            sb.AppendLine("Generate 3 different meal plans");

            return sb.ToString();
        }
    }

    public class MealPlanAnswer
    {
        public string Calories { get; set; } = "1700";
        public string EatingSchedule { get; set; } = "Yes, include intermittent fasting";
        public string MacroNutrientsPref { get; set; } = "Low-carb";
    }
}
