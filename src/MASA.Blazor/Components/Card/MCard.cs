﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorComponent;
using Microsoft.AspNetCore.Components;

namespace MASA.Blazor
{
    public partial class MCard : BCard
    {
        /// <summary>
        /// Whether dark theme
        /// </summary>
        [Parameter]
        public bool Dark { get; set; }

        [Parameter]
        public bool Shaped { get; set; }
        
        [Parameter]
        public bool Flat { get; set; }

        [Parameter]
        public bool Hover { get; set; }

        [Parameter]
        public bool Link { get; set; }

        [Parameter]
        public bool Loading { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool Raised { get; set; }

        protected override void SetComponentClass()
        {
            var prefix = "m-card";

            CssProvider
                .AsProvider<BCard>()
                .Apply(css =>
                {
                    css.Add("m-card")
                        .AddIf("elevation-2", () => !Outlined)
                        .AddTheme(Dark)
                        .Add("m-sheet")
                        .AddIf("m-sheet--outlined", () => Outlined)
                        .AddIf("m-sheet--shaped", () => Shaped)
                        .AddIf($"{prefix}--flat", () => Flat)
                        .AddIf($"{prefix}--hover", () => Hover)
                        .AddIf($"{prefix}--link", () => Link)
                        .AddIf($"{prefix}--loading", () => Loading)
                        .AddIf($"{prefix}--disabled", () => Disabled)
                        .AddIf($"{prefix}--raised", () => Raised); ;
                }, style =>
                {
                    style.AddIf(() => $"max-height: {MaxHeight.TryGetNumber().number}px", () => MaxHeight != null)
                        .AddIf(() => $"min-height: {MinHeight.TryGetNumber().number}px", () => MinHeight != null)
                        .AddIf(() => $"height: {Height.TryGetNumber().number}px", () => Height != null)
                        .AddIf(() => $"max-width: {MaxWidth.TryGetNumber().number}px", () => MaxWidth != null)
                        .AddIf(() => $"min-width: {MinWidth.TryGetNumber().number}px", () => MinWidth != null)
                        .AddIf(() => $"width: {Width.TryGetNumber().number}px", () => Width != null);
                });
        }
    }
}