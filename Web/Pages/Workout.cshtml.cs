using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using Web.Interfaces;

namespace Web.Pages
{
    public class WorkoutModel(IGymWizardService gymWizardService) : PageModel
    {
        public WorkoutAnswer WorkoutAnswer { get; set; }

        public string Result { get; set; }

        public void OnGet()
        {
            WorkoutAnswer = new WorkoutAnswer();
            Result = null;
        }

        public async Task OnPost(WorkoutAnswer workoutAnswer)
        {
            var workoutUserPreferences = WorkoutUserPreBuilder(workoutAnswer);

            var result = await gymWizardService.GenerateWorkoutSession(workoutUserPreferences);

            Result = result.Replace("`", string.Empty).Replace("html", string.Empty).ToString();

            WorkoutAnswer = new WorkoutAnswer();
        }

        private static string WorkoutUserPreBuilder(WorkoutAnswer workoutAnswer)
        {
            StringBuilder sb = new();

            sb.AppendLine($"My fitness goal is to {workoutAnswer.Fitness}");
            sb.AppendLine($"I exercise {workoutAnswer.WorkoutHistory}");

            AddOption(sb, "work on Arms", workoutAnswer.Arm);
            AddOption(sb, "work my Core training", workoutAnswer.Core);
            AddOption(sb, "work on my Legs", workoutAnswer.Legs);
            AddOption(sb, "work on my Back strength", workoutAnswer.Back);            

            AddOption(sb, "add Weight lifting", workoutAnswer.Weightlifting);
            AddOption(sb, "add Cardio sessions", workoutAnswer.Cardio);
            AddOption(sb, "add Yoga sessions", workoutAnswer.Yoga);

            AddOption(sb, "GymMachine", workoutAnswer.GymMachine);
            AddOption(sb, "FreeWeights", workoutAnswer.FreeWeights);

            sb.AppendLine($"I can spend a max of {workoutAnswer.WorkoutTime} at the gym");
            sb.AppendLine($"I can commit {workoutAnswer.WorkoutDays} day(s) at the gym");
            sb.AppendLine($"I am {workoutAnswer.ActivityLevel} outside of the gym");

            sb.AppendLine("Include a description of how to preform each workout");

            return sb.ToString();
        }

        private static void AddOption(StringBuilder sb, string option, bool include)
        {
            if (include && option != "None")
            {
                sb.AppendLine($"I want to {option} in my workout");
            }
        }
    }

    public class WorkoutAnswer
    {
        public string Fitness { get; set; } = "Weight loss";
        public bool Arm { get; set; } = true;
        public bool Core { get; set; }
        public bool Legs { get; set; }
        public bool Back { get; set; }
        public string WorkoutHistory { get; set; } = "Regularly";
        public bool Weightlifting { get; set; } = true;
        public bool Cardio { get; set; }
        public bool Yoga { get; set; }
        public bool GymMachine { get; set; } = true;
        public bool FreeWeights { get; set; }
        public bool None { get; set; }
        public string WorkoutDays { get; set; } = "1";
        public string WorkoutTime { get; set; } = "1";
        public string ActivityLevel { get; set; } = "Very Active";
    }
}
