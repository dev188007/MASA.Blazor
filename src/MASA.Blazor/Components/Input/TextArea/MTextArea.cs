﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorComponent;
using Microsoft.AspNetCore.Components;

namespace MASA.Blazor
{
    public partial class MTextArea : MTextField<string>
    {
        [Parameter]
        public bool AutoGrow { get; set; }

        [Parameter]
        public bool NoResize { get; set; }

        [Parameter]
        public int Rows { get; set; } = 5;

        protected override void SetComponentClass()
        {
            base.SetComponentClass();

            var prefix = "m-textarea";
            CssProvider
                .Merge(cssBuilder =>
                {
                    cssBuilder
                        .Add(prefix)
                        .AddIf($"{prefix}--auto-grow", () => AutoGrow)
                        .AddIf($"{prefix}--no-resize", () => AutoGrow || NoResize);
                });

            AbstractProvider
                .Merge<IInputBody>(properties =>
                {
                    properties[nameof(MInputBody<string>.Rows)] = Rows;
                    properties[nameof(MInputBody<string>.IsTextArea)] = true;
                });
        }
    }
}
