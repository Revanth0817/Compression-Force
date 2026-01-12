using CompressionForce.Domain.Validation;
using CompressionForce.Services.Validation;
using CompressionForce.Web.Models.Recipes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace CompressionForce.Web.TagHelpers
{
   
    [HtmlTargetElement(Attributes = "recipe-param")]
    [HtmlTargetElement("recipe-param")]
    public class RecipeParamTagHelper : TagHelper
    {
        [HtmlAttributeName("param-name")]
        public string ParamName { get; set; } = string.Empty;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; } = default!;

        private readonly IRecipeValidationConfigProvider _cfgProvider;

        public RecipeParamTagHelper(IRecipeValidationConfigProvider cfgProvider)
        {
            _cfgProvider = cfgProvider;
        }

        private void ApplyValidationAttributes(TagHelperOutput output,ParameterRule rule)
        {
            
            switch (rule.Type)
            {
                case "numeric":
                    output.Attributes.SetAttribute("type", "number");
                    output.Attributes.SetAttribute("min", rule.Min);
                    output.Attributes.SetAttribute("max", rule.Max);
                    output.Attributes.SetAttribute("value", rule.DefaultValue);
                    output.Attributes.SetAttribute("required", "");
                    output.Attributes.SetAttribute("title", rule.ValidationMsg);
                    output.Attributes.SetAttribute("placeholder", rule.PlaceHolder);
                    break;

                case "text":
                    output.Attributes.SetAttribute("type", "text");
                    output.Attributes.SetAttribute("maxlength", rule.MaxLength);
                    output.Attributes.SetAttribute("pattern", rule.Regex);
                    if (ParamName != "RecipeCode") output.Attributes.SetAttribute("value", rule.DefaultValue);
                    output.Attributes.SetAttribute("required", "");
                    output.Attributes.SetAttribute("title", rule.ValidationMsg);
                    output.Attributes.SetAttribute("placeholder", rule.PlaceHolder);
                    break;

                case "multi-enum":
                    output.Attributes.SetAttribute("multiple", "multiple");
                    break;
            }
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var model = ViewContext.ViewData.Model as AddEditRecipeVm;
            if (model == null) return;

            var rule = _cfgProvider.Get().Parameters.First(r => r.Name == ParamName);

            var index = model.Parameters.FindIndex(p =>
                p.Name.Equals(ParamName, StringComparison.OrdinalIgnoreCase));

            if (index < 0) return;

            var param = model.Parameters[index];

            // Always emit hidden Name & Type
            output.PreElement.AppendHtml(
                $"<input type='hidden' name='Parameters[{index}].Name' value='{param.Name}' recipe-id='{param.Name}Id'/>");

            output.PreElement.AppendHtml(
                $"<input type='hidden' name='Parameters[{index}].Type' value='{param.Type}' recipe-id='{param.Name}Id' />");

            // Standalone tag → hidden Value
            if (ParamName is "ForceFeederRatioS1" or "ForceFeederRatioS2")
            {
                // "@(model.recipeTypes.Any() ? recipeTypes.First() : string.Empty)
                var value = (ParamName == "ForceFeederRatioS1" ? model.ForceFeederRatioS1Types : model.ForceFeederRatioS2Types).FirstOrDefault() ?? string.Empty;
                //var value = ParamName == "ForceFeederRatioS1" ? (model.ForceFeederRatioS1Types.FirstOrDefault() ?? string.Empty) : ((model.ForceFeederRatioS2Types.FirstOrDefault() ?? string.Empty));
                output.PreElement.AppendHtml(
                    $"<input type='hidden' name='Parameters[{index}].Value' value='{ value}' recipe-id='{param.Name}Id' />");
            }
            // Enhance existing input/select
            output.Attributes.SetAttribute("name", $"Parameters[{index}].Value");

            ApplyValidationAttributes(output, rule);

            // REMOVE marker attributes so they don't render
            output.Attributes.RemoveAll("recipe-param");
            output.Attributes.RemoveAll("param-name");
        }
    }
}
