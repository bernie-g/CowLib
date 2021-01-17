using System.Linq;
using FluentValidation;

namespace CowLibCore.Validators
{
    internal static class CustomValidators
    {
        public static IRuleBuilderOptions<T, string> LowerCase<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(x => x.All(char.IsLower)).WithMessage("This string must be uppercase!");
        }      
        public static IRuleBuilderOptions<T, string> NoSymbols<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(x => x.All(char.IsLetterOrDigit)).WithMessage("No symbols are allowed!");
        }

        public static IRuleBuilderOptions<T, string> FirstCharIsLetter<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(x => x.All(char.IsLower) && x.All(char.IsLetterOrDigit)).WithMessage("The first character cannot be a number!");
        }

        public static IRuleBuilderOptions<T, string> HasColon<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(x => x.Contains(':')).WithMessage("Identifier must contain a colon.");
        }
    }
}