using Nop.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Nop.Plugin.Widget.PromoSlider.Domain
{
    public class PromoImageRecord : BaseEntity
    {
        [UIHint("Picture")]
        public virtual int PromoImageId { get; set; }
        public virtual int PromoSliderId { get; set; }
        public virtual string Caption { get; set; }
        public virtual string Url { get; set; }
        public virtual string FilePath { get; set; }
        public virtual int DisplayOrder { get; set; }

        public PromoSliderRecord PromoSlider { get; set; }
    }
}
