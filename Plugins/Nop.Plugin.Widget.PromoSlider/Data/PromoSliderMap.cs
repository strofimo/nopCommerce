using Nop.Plugin.Widget.PromoSlider.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widget.PromoSlider.Data
{
    public class PromoSliderMap : EntityTypeConfiguration<PromoSliderRecord>
    {
        public PromoSliderMap()
        {
            ToTable("PromoSlider_PromoSliders");

            HasKey(m => m.PromoSliderId);

            Property(m => m.PromoSliderName);
            Property(m => m.ZoneName);
            Property(m => m.Interval);
            Property(m => m.KeyBoard);
            Property(m => m.PauseOnHover);
            Property(m => m.Wrap);
        }
    }
}
