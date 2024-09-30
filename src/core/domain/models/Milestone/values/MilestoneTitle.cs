using domain.exceptions.milestone.milestoneTitle;
using domain.exceptions.project.ProjectTitle;
using domain.models.project.values;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.models.milestone.values;

public class MilestoneTitle
{
    public string Value { get; }

    private MilestoneTitle() { }

    private MilestoneTitle(string value)
    {
        Value = value;
    }

    public static Result<MilestoneTitle> Create(string value)
    {
        var result = Validate(value);

        if (result.IsFailure)
        {
            return Result<MilestoneTitle>.Failure(result.Errors.ToArray());
        }

        var milestoneTitle = new MilestoneTitle(value);

        return milestoneTitle;
    }

    private static Result Validate(string value)
    {
        var errors = new List<Exception>();

        if (string.IsNullOrEmpty(value))
        {
            errors.Add(new MilestoneTitleEmptyException());
            return Result.Failure(errors.ToArray());
        }

        switch (value)
        {
            case { Length: < 3 }:
                errors.Add(new MilestoneTitleTooShortException());
                break;
            case { Length: > 75 }:
                errors.Add(new MilestoneTitleTooLongException());
                break;
        }

        return errors.Any() ? Result.Failure(errors.ToArray()) : Result.Success();
    }
}
