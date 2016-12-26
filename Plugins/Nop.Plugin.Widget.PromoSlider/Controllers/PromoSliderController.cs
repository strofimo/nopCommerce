using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Plugin.Widget.PromoSlider.Domain;
using Nop.Plugin.Widgets.PromoSlider.Infrastructure;
using Nop.Services.Events;
using Nop.Services.Media;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Kendoui;
using Nop.Web.Framework.Mvc;
using System.Linq;
using System.Web.Mvc;

namespace Nop.Plugin.Widget.PromoSlider.Controllers
{
    [AdminAuthorize]
    [PromoSliderAuthorization]
    public class PromoSliderController : BasePluginController
    {
        private IRepository<PromoSliderRecord> _sliderRepo;
        private IRepository<PromoImageRecord> _imageRepo;
        private IPictureService _pictureService;
        private ICacheManager _cacheService;
        private IEventPublisher _eventPublisher;

        public PromoSliderController(IRepository<PromoSliderRecord> sliderRepo,
            IRepository<PromoImageRecord> imageRepo, ICacheManager cacheManager, 
            IPictureService pictureService, IEventPublisher eventPublisher)
        {
            _cacheService = cacheManager;
            _pictureService = pictureService;
            _sliderRepo = sliderRepo;
            _imageRepo = imageRepo;
            _eventPublisher = eventPublisher;
        }

        public ActionResult CreateUpdatePromoSlider(int PromoSliderId = 0)
        {
            PromoSliderRecord slider = new PromoSliderRecord() { Interval = 3 };
            if (PromoSliderId > 0)
            {
                slider = _sliderRepo.GetById(PromoSliderId);
            }
            return View(slider);
        }

        [HttpPost]
        public ActionResult CreateUpdatePromoSlider(PromoSliderRecord record)
        {
            if (ModelState.IsValid)
            {
                PromoSliderRecord slider = _sliderRepo.GetById(record.PromoSliderId);
                if (slider == null)
                {
                    _sliderRepo.Insert(record);
                    SuccessNotification("Slider Created Successfully!");
                    _eventPublisher.EntityInserted(record);

                    return RedirectToRoute(new
                    {
                        Action = "CreateUpdatePromoSlider",
                        Controller = "PromoSlider",
                        PromoSliderId = record.PromoSliderId
                    });
                }
                else
                {

                    slider.PromoSliderName = record.PromoSliderName;
                    slider.Interval = record.Interval;
                    slider.IsActive = record.IsActive;
                    slider.KeyBoard = record.KeyBoard;
                    slider.PauseOnHover = record.PauseOnHover;
                    slider.Wrap = record.Wrap;
                    slider.ZoneName = record.ZoneName;
                    _sliderRepo.Update(slider);
                    _cacheService.Clear();
                    SuccessNotification("Changed Saved!");
                    return View(slider);
                }
            }
            else
            {
                return View();
            }
        }

        [ChildActionOnly]
        public ActionResult ManagePromoImages(int PromoSliderId = 0)
        {
            PromoImageRecord image = new PromoImageRecord();
            image.PromoSliderId = PromoSliderId;
            return View(image);
        }

        [HttpPost]
        public ActionResult CreatePromoImage(PromoImageRecord image)
        {
            image.FilePath = _pictureService.GetPictureUrl(image.PromoImageId);

            var slider = _sliderRepo.GetById(image.PromoSliderId);
            slider.Images.Add(image);
            _sliderRepo.Update(slider);
            SuccessNotification("Image Added!", false);
            return new NullJsonResult();
        }

        [HttpPost]
        public ActionResult GetPromoImagesList(int PromoSliderId)
        {
            var slideImages = _sliderRepo.GetById(PromoSliderId).Images.OrderBy(x => x.DisplayOrder);

            var gridModel = new DataSourceResult
            {
                Data = slideImages.Select(x => new
                {
                    PromoImageId = x.PromoImageId,
                    Caption = x.Caption,
                    Url = x.Url,
                    FilePath = x.FilePath,
                    DisplayOrder = x.DisplayOrder

                }),
                Total = slideImages.Count()
            };

            return Json(gridModel);
        }

        [HttpPost]
        public ActionResult UpdatePromoImage(PromoImageRecord imageUpdate)
        {
            PromoImageRecord image = _imageRepo.GetById(imageUpdate.PromoImageId);

            image.Caption = imageUpdate.Caption;
            image.Url = imageUpdate.Url;
            image.DisplayOrder = imageUpdate.DisplayOrder;

            _imageRepo.Update(image);

            return new NullJsonResult();
        }

        [HttpPost]
        public ActionResult DeletePromoImage(int PromoImageId)
        {
            PromoImageRecord image = _imageRepo.GetById(PromoImageId);
            _imageRepo.Delete(image);

            return new NullJsonResult();
        }

        public ActionResult ManagePromoSliders()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ListPromoSliders()
        {
            var sliders = _sliderRepo.Table.ToList();

            var gridModel = new DataSourceResult
            {
                Data = sliders.Select(x => new
                {
                    PromoSliderId = x.PromoSliderId,
                    PromoSliderName = x.PromoSliderName,
                    IsActive = x.IsActive,
                    Interval = x.Interval,
                    PauseOnHover = x.PauseOnHover
                }),
                Total = sliders.Count()
            };

            return Json(gridModel);
        }

        [HttpPost]
        public ActionResult UpdatePromoSlider(PromoSliderRecord sliderUpdate)
        {
            PromoSliderRecord slider = _sliderRepo.GetById(sliderUpdate.PromoSliderId);
            slider.IsActive = sliderUpdate.IsActive;
            slider.Interval = sliderUpdate.Interval;
            slider.PauseOnHover = sliderUpdate.PauseOnHover;
            _sliderRepo.Update(slider);

            return new NullJsonResult();
        }

        [HttpPost]
        public ActionResult DeletePromoSlider(int PromoSliderId)
        {
            PromoSliderRecord record = _sliderRepo.GetById(PromoSliderId);
            _sliderRepo.Delete(record);

            return new NullJsonResult();
        }

        //Front End Widget
        [AllowAnonymous]
        public ActionResult PromoSliderWidget(string widgetZone)
        {
            var slider = _sliderRepo.Table.FirstOrDefault(x => x.ZoneName == widgetZone && x.IsActive);

            if (slider != null)
            {
                slider.Interval = slider.Interval * 1000;
                slider.Images = slider.Images.OrderBy(x => x.DisplayOrder).ToList();
                return View(slider);
            }
            else
            {
                return Content("");
            }

        }

        public ActionResult Configure()
        {
            return View();
        }

        public ActionResult License()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }
    }
}