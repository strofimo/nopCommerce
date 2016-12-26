using FluentValidation.Attributes;
using Nop.Core;
using Nop.Plugin.Widgets.PromoSlider.Domain;
using Nop.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widget.PromoSlider.Domain
{
    [Validator(typeof(PromoSliderValidator))]
    public class PromoSliderRecord : BaseEntity
    {
        public PromoSliderRecord()
        {
            Images = new List<PromoImageRecord>();
        }

        public virtual int PromoSliderId { get; set; }
        [NopResourceDisplayName("Plugins.Misc.PromoSlider.PromoSliderName")]
        public virtual string PromoSliderName { get; set; }
        [NopResourceDisplayName("Plugins.Misc.PromoSlider.IsActive")]
        public bool IsActive { get; set; }
        [NopResourceDisplayName("Plugins.Misc.PromoSlider.ZoneName")]
        public virtual string ZoneName { get; set; }
        [NopResourceDisplayName("Plugins.Misc.PromoSlider.Interval")]
        public virtual int Interval { get; set; }
        [NopResourceDisplayName("Plugins.Misc.PromoSlider.PauseOnHover")]
        public virtual bool PauseOnHover { get; set; }
        [NopResourceDisplayName("Plugins.Misc.PromoSlider.Wrap")]
        public virtual bool Wrap { get; set; }
        [NopResourceDisplayName("Plugins.Misc.PromoSlider.Keyboard")]
        public virtual bool KeyBoard { get; set; }

        public virtual List<PromoImageRecord> Images { get; set; }
    }
}
