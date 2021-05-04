﻿
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFConstructor.Steps;

namespace WPFConstructor
{
    public class Stage
    {
        public Stage(string name)
        {
            Name = name;
            Steps = ImmutableList<Step>.Empty;
        }
        public string Name { get; private set; }
        public ImmutableList<Step> Steps { get; private set; }
        public Stage AddSteps(Action<StepsFactory> stepsSelector)
        {
            var binder = new StepsBinder(Steps);
            stepsSelector(new StepsFactory(binder));
            Steps = Steps.Clear().AddRange(binder.GetSteps());
            return this;
        }
        public Panel GetContent(int step)
        {
            return Steps[step].Content;
        }
        public override string ToString()
        {
            int stage = -1;
            if(Steps.Count != 0)
            {
            stage = Steps[0].Address.Stage;
            }
            return  $"Этап {stage+1}. {Name}.";
        }

    }
}