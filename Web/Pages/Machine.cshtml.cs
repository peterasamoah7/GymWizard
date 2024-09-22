using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Interfaces;

namespace Web.Pages
{
    public class MachineModel(IGymWizardService gymWizardService) : PageModel
    {
        [BindProperty]
        public IFormFile FileUpload { get; set; }
        public string Result { get; set; }
        public string Image {  get; set; }

        public void OnGet()
        {
            Reset();

            Result = null;
            Image = null;
        }

        public async Task OnPost()
        {
            if (FileUpload == null) return;

            var ms = new MemoryStream();
            await FileUpload.CopyToAsync(ms);

            var result = await gymWizardService.FindMachineAsync(ms);

            if (result == "False")
            {
                Result = "<p>Sorry this is not a gym machine or equipment. Upload another other image and retry :)";
            }
           
            Result = result.Replace("`", string.Empty).Replace("html", string.Empty).ToString();
            Image = Convert.ToBase64String(ms.ToArray());

            Reset();
        }

        private void Reset() => FileUpload = null;
    }
}
