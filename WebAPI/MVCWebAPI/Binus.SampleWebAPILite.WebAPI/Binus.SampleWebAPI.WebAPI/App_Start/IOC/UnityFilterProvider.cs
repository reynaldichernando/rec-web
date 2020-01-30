using System.Collections.Generic;
using Microsoft.Practices.Unity;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Binus.SampleWebAPI.WebAPI.App_Start.IOC
{
    public class UnityFilterProvider :ActionDescriptorFilterProvider, IFilterProvider
    {
        private readonly IUnityContainer container;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="container">Unity container from UnityConfig.</param>
        public UnityFilterProvider(IUnityContainer container)
        {
            this.container = container;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="actionDescriptor"></param>
        /// <returns></returns>
        public new IEnumerable<FilterInfo> GetFilters(
        HttpConfiguration configuration,
        HttpActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(configuration, actionDescriptor);
            foreach (var filter in filters)
            {
                container.BuildUp(filter.Instance.GetType(), filter.Instance);
            }
            return filters;
        }
    }

}