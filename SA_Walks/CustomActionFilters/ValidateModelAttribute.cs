using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SA_Walks.API.CustomActionFilters
{
    public class ValidateModelAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Check if the model is valid
            if (!context.ModelState.IsValid)
            {
                //Return BadRequest with the validation errors
                context.Result = new BadRequestResult();
            }
        }
    }
      
}
