using FluentValidation;
using Nop.Plugin.Widget.PromoSlider.Domain;
using Nop.Services.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Plugin.Widgets.PromoSlider.Domain
{
    public class PromoSliderValidator : AbstractValidator<PromoSliderRecord>
    {
        public PromoSliderValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.PromoSliderName)
                .NotEmpty().WithMessage(localizationService.GetResource("Plugins.Misc.PromoSlider.SliderNameRequired"));

            RuleFor(x => x.Interval)
                .NotEmpty().WithMessage(localizationService.GetResource("Plugins.Misc.PromoSlider.SliderIntervalRequired"))
                .InclusiveBetween(1, 10).WithMessage(localizationService.GetResource("Plugins.Misc.PromoSlider.GreaterThanZero"));
        }
    }
}