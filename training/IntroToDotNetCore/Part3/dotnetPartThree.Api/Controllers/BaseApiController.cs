using dotnetPartThree.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace dotnetPartThree.Api.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected ModelFactory _modelFactory;
        protected readonly LinkGenerator _linkGenerator;

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.ControllerContext, _linkGenerator);
                }
                return _modelFactory;
            }
        }

        public BaseApiController(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }         
    }
}