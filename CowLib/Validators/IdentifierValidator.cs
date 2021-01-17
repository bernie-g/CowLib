using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CowLib.Validators
{
    internal class IdentifierValidator : AbstractValidator<string>
    {
        public static IdentifierValidator COMBINED = new IdentifierValidator(true);
        public static IdentifierValidator PARTS = new IdentifierValidator(false);
        public IdentifierValidator(bool combined)
        {
            IRuleBuilderOptions<string, string> builder = RuleFor(x => x).NotEmpty().LowerCase().FirstCharIsLetter();
            if (combined) builder.HasColon();
        }
    }
}
