namespace Web.Services
{
    public class WorkoutDetail(int id, string question, List<WorkoutAnswer> answers, string answer)
    {
        public int Id { get; set; } = id;
        public string Question { get; } = question;
        public List<WorkoutAnswer> Answers { get; } = answers;
        public string Answer { get; } = answer;
        public string Result { get; set; }
    }

    public class WorkoutAnswer 
    {
        public string Answer { get; set; }
        public bool Selected { get; set; }
    }
         
    public class WorkoutBuilder
    {
        private readonly List<string> _qnas =
        [
            "What are your main fitness goals?;Weight loss,Muscle gain,Endurance,Flexibility;My fitness goal is to {0}",
            "Do you have any specific areas of your body you want to focus on?;Arms,Core,Legs,Back;I want to focus on {0}",
            "Have you worked out before? If so, how long have you been exercising?;Regularly,Once every few days,Barely;I exercise {0}",
            "What types of exercise do you enjoy or feel comfortable with?;Weightlifting,Cardio,Yoga;I am confortable with {0} exercise",
            "Have you used gym machines or free weights before?;Gym machines,Free weights,None; I have used {0}",
            "How many days a week can you dedicate to working out? We recommend a maximum of 3 days.;1,2,3;I can commit {0} day(s) at the gym",
            "How long can you spend at the gym each session?;1hr,3hrs,4hrs;I can spend a max of {0} at the gym",
            "What’s your current activity level outside the gym?;Active,Moderatively Active,Barley Active;I am {0} outside of the gym"
        ];

        public List<WorkoutDetail> GetWorkoutModels()
        {
            List<WorkoutDetail> workoutModels = [];

            int idCount = 0;

            foreach (var qna in _qnas)
            {
                idCount++;
                var items = qna.Split(';');
                workoutModels.Add(
                    new WorkoutDetail(
                        idCount,
                        items[0],
                        items[1].Split(',').Select(x => new WorkoutAnswer
                        {
                            Answer = x,
                            Selected = false
                        }).ToList(), items[2])
                    );
            }

            return workoutModels;
        }

        public string BuildUserPreferences()
        {
            return string.Empty;
        }
    }    
}
