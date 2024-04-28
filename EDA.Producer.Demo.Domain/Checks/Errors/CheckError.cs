using EDA.Producer.Demo.Domain.Checks.Entities;
using ErrorOr;

namespace EDA.Producer.Demo.Domain.Checks.Errors;

public static class CheckError
{
    public static readonly Error CheckCannotHaveNegativeAmount = Error.Validation(
        "Check.CheckCannotHaveNegativeAmount",
        "Check cannot have negative amount");
    
    public static readonly Error CheckAlreadyGenerated = Error.Validation(
        "Check.CheckAlreadyGenerated",
        "Check is already generated");
}