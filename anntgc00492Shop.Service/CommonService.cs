using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using anntgc00492Shop.Common;
using anntgc00492Shop.Data.Infrastructure;
using anntgc00492Shop.Data.Repositories;
using anntgc00492Shop.Model.Models;

namespace anntgc00492Shop.Service
{
    public interface ICommonService
    {
        Footer GetFooter();
        IEnumerable<Slide> GetSlides();
    }
    public class CommonService:ICommonService
    {
        private IFooterRepository _footerRepository;
        private ISlideRepository _slideRepository;
        private IUnitOfWork _unitOfWork;

        public CommonService(IUnitOfWork unitOfWork, IFooterRepository footerRepository, ISlideRepository slideRepository)
        {
            _footerRepository = footerRepository;
            _slideRepository = slideRepository;
            _unitOfWork = unitOfWork;
        }

        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.Id == CommonConstants.DefaultFooterId);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x => x.Status);
        } 
    }
}
