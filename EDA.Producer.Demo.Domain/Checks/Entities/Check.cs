using System.ComponentModel.DataAnnotations.Schema;
using EDA.Producer.Demo.Domain.Checks.Errors;
using ErrorOr;

namespace EDA.Producer.Demo.Domain.Checks.Entities;

public class Check
{
    [Column("id")]
    public Guid Id { get; private set; }
    [Column("name")]
    public string Name { get; private set; }
    [Column("amount")]
    public decimal Amount { get; private set; }
    [Column("isgenerated")]
    public bool IsGenerated { get; private set; }

    public Check(Guid id, string name, decimal amount, bool isGenerated)
    {
        Id = id;
        Name = name;
        Amount = amount;
        IsGenerated = isGenerated;
    }
    public Check (string name, decimal amount) : this(Guid.NewGuid(), name, amount, false)
    {
    }
    
    public void Generate()
    {
        IsGenerated = true;
    }
    
    public ErrorOr<Check> WithNonNegativeAmount()
    {
        if (Amount < 0)
        {
            return CheckError.CheckCannotHaveNegativeAmount;
        }
        return this;
    }
    
    public ErrorOr<Check> CheckIsNotGenerated(Check check)
    {
        if (check.IsGenerated)
        {
            return CheckError.CheckAlreadyGenerated;
        }
        return this;
    }
    
    
    public ErrorOr<Check> UpdateAmount(decimal amount)
    {
        if (amount < 0)
        {
            return CheckError.CheckCannotHaveNegativeAmount;
        }
        Amount = amount;
        return this;
    }
}
