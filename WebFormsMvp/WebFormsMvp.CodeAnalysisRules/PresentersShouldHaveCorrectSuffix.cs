﻿using System;
using System.Linq;
using Microsoft.FxCop.Sdk;

namespace WebFormsMvp.CodeAnalysisRules
{
    public class PresentersShouldHaveCorrectSuffix : BaseRule
    {
        public PresentersShouldHaveCorrectSuffix()
            : base("PresentersShouldHaveCorrectSuffix")
        {
        }

        public override ProblemCollection Check(TypeNode type)
        {
            if (type == null) return null;

            if (!IsPresenterImplementation(type)) return null;

            if (!type.Name.Name.EndsWith("Presenter", StringComparison.Ordinal))
            {
                return new ProblemCollection { new Problem(
                    GetResolution(type.FullName)) {
                    Certainty = 100,
                    FixCategory = FixCategories.Breaking,
                    MessageLevel = MessageLevel.Warning
                }};
            }

            return null;
        }
    }
}